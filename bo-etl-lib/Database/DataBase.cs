using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BusinessObjectsEtl
{
    public interface IDataBase
    {
        bool InsertObjects(ICollection listObjects);
    }

    public class DataBase
    {
        public delegate void LogHandler(string info);
        public event LogHandler LogEvent;
        private StringBuilder log;

        public DataBase(){
            this.log = new StringBuilder();
        }

        public void Log(string info){
            if (this.LogEvent != null) this.LogEvent(info);
            log.AppendLine(info);
        }
    }
}
