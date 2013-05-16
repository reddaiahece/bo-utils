using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using FirebirdSql.Data.FirebirdClient;

namespace BusinessObjectsEtl
{

    [AttributeUsage(AttributeTargets.Field)]
    public class FbColumn : Attribute {
        public string Name;
        public string DataType;
        public string FkConstraint;
        public bool IsPrimaryKey;
        public bool AutoIncrement;
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class FbTable : Attribute {
        public string Name;
        public string Description;
        public string ColPrefix;
    }

    [Guid("249C8672-AD2D-4CC6-8CB2-DD9A3ECC58F0"), ComVisible(true)]
    public interface IFirebird {
        void Initialise(string dataBasePath, string user, string password, bool mutipleLoad);
        void Dispose();
    }

    [Guid("2B485454-4EC1-4F6A-B7B1-0F206A3677A7")]
    [ProgId("BusinessObjectsEtl.Firebird"), Description("")]
    [ComDefaultInterface(typeof(IFirebird)), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class Firebird : IDataBase, IFirebird, IDisposable
    {
        public delegate void LogHandler(string info);
        public event LogHandler Log;

        FbConnection con = null;
        string insertionTime = null;
        string dbName;

        public Firebird(){}
        
        public void Initialise(string dataBasePath, string user, string password, bool mutipleLoad ){
            if(mutipleLoad){
                insertionTime = "'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'";
            }
            FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
            csb.ServerType = FbServerType.Default;
            csb.Dialect = 3;
            csb.DataSource = "localhost";
            csb.Database = dataBasePath;
            csb.UserID = user;
            csb.Pooling = false;
            csb.Password = password;
            string connectonString = csb.ToString();
            int pageSize = 8192;
            bool forcedWrites = false;
            bool overwrite = false;
            dbName = Path.GetFileNameWithoutExtension(dataBasePath);
            if (File.Exists(csb.Database) & mutipleLoad==false){
                try{
                    File.Move(dataBasePath, dataBasePath);
                }catch(Exception){
                    throw new Exception("Database " + Path.GetFileName(csb.Database) + " is being used by another person or program. Close any programs that might be using the file and try again.");
                }
                File.Delete(csb.Database);
            }
            if (!File.Exists(csb.Database)){
                if (this.Log != null) this.Log("Create database " + dataBasePath);
                FbConnection.CreateDatabase(connectonString, pageSize, forcedWrites, overwrite);
                this.con = new FbConnection(connectonString);
                ExecuteNonQuery("CREATE DOMAIN \"BOOLEAN\" AS Smallint CHECK (value is null or value in (0, 1));");
            }else{
                if (this.Log != null) this.Log("Use existing database " + dataBasePath);
                this.con = new FbConnection(connectonString);
            }
        }

        ~Firebird(){
            Dispose();
        }

        public void Dispose(){
            if(this.con!=null){
                this.con.Close();
                this.con.Dispose();
                this.con=null;
            }
        }

        public bool TableExists(Type objectType ){
            string sql = "select 1 from rdb$relations where rdb$relation_name = '" + objectType.Name + "';";
            return ExecuteScalar(sql.ToString())!=null;
        }

        public void CreateTable(Type objectType ){
            StringBuilder sqlTable = new StringBuilder();
            List<string> pkList = new List<string>();
            StringBuilder sqlFk = new StringBuilder();
            string sqlSequence = null;
            StringBuilder sqlTrigger = new StringBuilder();
            FieldInfo[] fields = objectType.GetFields();
            int i=0;

            object[] tableAtts = objectType.GetCustomAttributes(typeof(FbTable), false);
            FbTable tableAtt = (tableAtts.Length != 0) ? (FbTable)tableAtts[0] : null;
            string tableName = objectType.Name;
            sqlTable.Append("create table " + tableName + " (");
            foreach(FieldInfo field in fields){
                if (i++ != 0) sqlTable.Append(",");
                object[] colAtts = field.GetCustomAttributes(typeof(FbColumn), false);
                FbColumn att = (colAtts.Length!=0) ? (FbColumn)colAtts[0] : null;
                string fieldName = null;
                if(att!=null && att.Name!=null){
                    fieldName = att.Name;
                }else{
                    fieldName = field.Name;
                }
                sqlTable.Append(fieldName);
                if(att!=null && att.DataType!=null){
                    sqlTable.Append(" " + att.DataType);
                }else{
                    sqlTable.Append(" " + ConvertType(field.FieldType));
                }
                if(att!=null){
                    if( att.IsPrimaryKey) pkList.Add(fieldName);
                    if( att.FkConstraint!=null){
                        string constField = fieldName;
                        string[] refFk = att.FkConstraint.Split('.');
                        if(this.insertionTime != null){
                            refFk[1] += ",INSDATE";
                            constField += ",INSDATE";
                        }
                        sqlFk.AppendLine(",CONSTRAINT FK_" + tableName + "_" + fieldName + " FOREIGN KEY (" + refFk[1] + ") REFERENCES " + refFk[0] + "(" + refFk[1] + ") on update NO ACTION on delete NO ACTION");
                    }
                    if (att.AutoIncrement){
                        sqlSequence = "CREATE SEQUENCE SEQ_" + tableName + ";";
                        sqlTrigger.AppendLine("CREATE TRIGGER TRI_" + tableName + " FOR " + tableName);
                        sqlTrigger.AppendLine(" ACTIVE BEFORE INSERT POSITION 0 as begin");
                        sqlTrigger.AppendLine(" if(new." + fieldName + " is null) then new." + fieldName + " = next value for SEQ_" + tableName + ";");
                        sqlTrigger.AppendLine("END");
                    }
                }
            }

            if(this.insertionTime != null){
                sqlTable.Append(",INSDATE timestamp");
                pkList.Add("INSDATE");
            }
            sqlTable.Append(",CONSTRAINT PK_" + tableName + " PRIMARY KEY (" + string.Join(",", pkList.ToArray()) + ")");
            sqlTable.Append(sqlFk);
            sqlTable.Append(");");
            ExecuteNonQuery(sqlTable.ToString());
            ExecuteNonQuery(sqlSequence);
            ExecuteNonQuery(sqlTrigger.ToString());
            if(tableAtt != null){
                ExecuteNonQuery("update RDB$RELATIONS set RDB$DESCRIPTION='" + tableAtt.Description + "' where RDB$RELATION_NAME = '" + tableName + "';");
            }
        }

        public bool InsertObjects(ICollection listObjects){
            Type type = null; FieldInfo[] fields = null;
            int cpt = -1; int max = listObjects.Count;
            string[] sqls = new string[max];
            string startQuary=null;
            Type listObjectsType = listObjects.GetType();
            if (listObjectsType.IsGenericType && listObjectsType.GetGenericTypeDefinition() == typeof(List<>)) {
                Type objectType = listObjectsType.GetGenericArguments()[0];
                try{
                    if (!TableExists(objectType)) CreateTable(objectType);
                }catch(Exception ex){
                    if (this.Log != null) this.Log("Failed to create table " + dbName + "/" + objectType.Name + " - " + ex.Message);
                    return false;
                }

                if (this.Log != null) this.Log("Insert " + listObjects.Count + " rows in table " + dbName + "/" + objectType.Name);
            }
            foreach(Object obj in listObjects){
                if(++cpt==0){
                    type = obj.GetType();
                    fields = type.GetFields();
                    int c=0; StringBuilder sbColumns = new StringBuilder();
                    foreach(FieldInfo property in fields){
                        sbColumns.Append( (c++ != 0 ? "," : "") + property.Name);
                    }
                    if(this.insertionTime != null){
                        sbColumns.Append(",INSDATE");
                    }
                    startQuary = "insert into " + type.Name + "(" + sbColumns.ToString() + ") ";
                }
                int v=0; StringBuilder sbValues = new StringBuilder();
                foreach(FieldInfo field in fields){
                    object value = field.GetValue(obj);
                    sbValues.Append( (v++ != 0 ? "," : "") + ConvertObject(value));
                }
                if(this.insertionTime != null){
                    sbValues.Append("," + this.insertionTime);
                }
                sqls[cpt] = startQuary + "values(" + sbValues.ToString() + ");";
            }
            try{
                ExecuteNonQuery(sqls);
            }catch(Exception ex){
                if (this.Log != null) this.Log("Failed to insert objects in table " + dbName + "/" + type.Name + " - " + ex.Message);
                return false;
            }
            return true;
        }

        private string ConvertObject(object obj){
            if (obj == null) return "null";
            if (obj is string) return "'" + ((string)obj).Replace("'", "''") + "'";
            if (obj is bool || obj is bool?) return (bool)obj ? "1" : "0";
            if (obj is DateTime || obj is DateTime?) return "'" + ((DateTime)obj).ToString("yyyy/MM/dd HH:mm:ss") + "'";
         //   if (obj is DateTime) return ((DateTime)obj - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds.ToString();
            return obj.ToString();
        }

        private string ConvertType(Type type){
            if (type == typeof(string) ) return "varchar(255)";
            if (type == typeof(decimal) || type == typeof(decimal?)) return "decimal";
            if (type == typeof(int) || type == typeof(int?)) return "integer";
            if (type == typeof(long) || type == typeof(long?)) return "integer";
            if (type == typeof(double) || type == typeof(double?)) return "double";
            if (type == typeof(float) || type == typeof(float?)) return "float";
            if (type == typeof(bool) || type == typeof(bool?)) return "boolean";
            if (type == typeof(DateTime) || type == typeof(DateTime?)) return "timestamp";
            return null;
        }

        public object ExecuteScalar(string sql){
            FbCommand cmd = new FbCommand(sql, con);
            cmd.Connection.Open();
            object ret=null;
            try{
                ret=cmd.ExecuteScalar();
            }catch(Exception ex){
                throw ex;
            }finally{
                cmd.Connection.Close();
            }
            return ret;
        }

        public int ExecuteNonQuery(string[] sqls){
            int ret = 0, max=0;
            FbCommand cmd = new FbCommand(null, con);
            StringBuilder sbBlock = new StringBuilder();
            int length = string.Join("\n", sqls).Length;
            int totalLen = 0; int cptContext=0;
            max = sqls.Length;
            try{
                cmd.Connection.Open();
                foreach(string sql in sqls){
                    int len = sql.Length;
                    totalLen += len;
                    cptContext += 1;
                    if( totalLen<65000 && cptContext<255 ){
                        sbBlock.Append(sql + "\n");
                    }else{
                        cmd.CommandText = "EXECUTE BLOCK AS BEGIN\n" + sbBlock.ToString() + "END";
                        ret = ret + cmd.ExecuteNonQuery();
                        totalLen = len;
                        cptContext = 1;
                        sbBlock = new StringBuilder(sql + "\n");
                    }
                }
                cmd.CommandText = "EXECUTE BLOCK AS BEGIN\n" + sbBlock.ToString() + "END";
                ret = ret + cmd.ExecuteNonQuery();
                //cmd.CommandText = sbBlock.ToString();
            }catch(Exception ex){
                throw new Exception( ex.Message + " - Queries: " + sbBlock.ToString().Replace("\n", " ") );
            }finally{
                cmd.Connection.Close();
            }
            return ret;
        }

        public int ExecuteNonQuery(string sql){
            if (sql == null || sql == "") return 0;
            FbCommand cmd = new FbCommand(sql, this.con);
            int ret;
            try{
                cmd.Connection.Open();
                ret = cmd.ExecuteNonQuery();
            }catch(Exception ex){
                throw ex;
            }finally{
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return ret;
        }

    }
}
