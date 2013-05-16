using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace BusinessObjectsEtl
{

    [Guid("1847C177-3C92-405A-A502-46F62C5C61D1"), ComVisible(true)]
    public interface IEtl {
        bool TestURL(string sessionURL);
        ExitCode Login(string sessionURL, string cmsname, string username, string password, string authType);
        ExitCode Logout();
    }

    [Guid("83847508-4471-441F-89C1-8ECA1339ED90")]
    [ProgId("BusinessObjectsEtl.Etl"), Description("")]
    [ComDefaultInterface(typeof(IEtl)), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class Etl : IEtl
    {
        Object lEtl;
        int[] version;
        public delegate void LogHandler(string info);
        public event LogHandler Log;

        public bool TestURL(string sessionURL){
            return Func.GetSessionUrl(sessionURL) != null;
        }

        public ExitCode Login(string url, string cmsname, string username, string password, string authType)
        {
            if(this.Log!=null) this.Log("Connect to web service " + url);
            string lUrl = Func.GetSessionUrl(url);
            if (lUrl == null || lUrl == String.Empty) throw new Exception("URL is not reachable or invalide " + url);
            this.lEtl = new Etl115(lUrl);
            this.version = ((Etl115)this.lEtl).GetVersion();
            switch (this.version[0]){
                case 11:
                    ConnectEvents(this.lEtl);
                    return ((Etl115)this.lEtl).Login(cmsname, username, password, authType, true, false);
                case 12:
                    this.lEtl = new Etl120(lUrl);
                    ConnectEvents(this.lEtl);
                    return ((Etl120)this.lEtl).Login(cmsname, username, password, authType, true, false);
                case 14:
                    this.lEtl = new Etl140(lUrl);
                    ConnectEvents(this.lEtl);
                    return ((Etl140)this.lEtl).Login(cmsname, username, password, authType, true, false);
                default: throw new Exception("Version " + this.version[0] + " is not implemented !  ");
            }
        }

        public ExitCode Logout()
        {
            if(this.lEtl == null) return ExitCode.FAILED;
            switch (this.version[0]){
                case 11: return ((Etl115)lEtl).Logout();
                case 12: return ((Etl120)lEtl).Logout();
                case 14: return ((Etl140)lEtl).Logout();
                default: throw new NotSupportedException("Version " + this.version[0] + " is not supported ! ");
            }
        }

        private void ConnectEvents(object pScheduler){
            if (Log != null) ((SessionBase)this.lEtl).LogEvent += new SessionBase.LogHandler(Log);
        }

        public bool ExtractTo(IDataBase[] iDataBase)
        {
            bool succeed=true;
            switch (this.version[0]){
                case 11:
                    Etl115 etl115 = (Etl115)lEtl;
                    etl115.SetDatabase(iDataBase);
                    //etl115.GetRoles();
                    succeed &= etl115.GetGroups();
                    succeed &= etl115.GetUsers();
                    succeed &= etl115.GetFolders();
                    succeed &= etl115.GetConnections();
                    succeed &= etl115.GetUniverses();
                    succeed &= etl115.GetDocuments();
                    succeed &= etl115.GetInstances();
                    succeed &= etl115.GetCategories();
                    succeed &= etl115.GetInboxes();
                    succeed &= etl115.GetProfiles();
                    break;
                case 12:
                    Etl120 etl120 = (Etl120)lEtl;
                    etl120.SetDatabase(iDataBase);
                    succeed &= etl120.GetRoles();
                    succeed &= etl120.GetGroups();
                    succeed &= etl120.GetUsers();
                    succeed &= etl120.GetFolders();
                    succeed &= etl120.GetConnections();
                    succeed &= etl120.GetUniverses();
                    succeed &= etl120.GetDocuments();
                    succeed &= etl120.GetInstances();
                    succeed &= etl120.GetCategories();
                    succeed &= etl120.GetInboxes();
                    succeed &= etl120.GetProfiles();
                    break;
                case 14:
                    Etl140 etl140 = (Etl140)lEtl;
                  /*   etl140.testPaging();     */
                    etl140.SetDatabase(iDataBase);
                    succeed &= etl140.GetRoles();
                    succeed &= etl140.GetGroups();
                    succeed &= etl140.GetUsers();
                    succeed &= etl140.GetFolders();
                    succeed &= etl140.GetConnections();
                    succeed &= etl140.GetUniverses();
                    succeed &= etl140.GetDocuments();
                    succeed &= etl140.GetInstances();
                    succeed &= etl140.GetCategories();
                    succeed &= etl140.GetInboxes();
                    succeed &= etl140.GetProfiles();
                
                    break;
                default: throw new NotSupportedException("Version " + this.version[0] + " is not supported ! ");
            }
            return succeed;
        }

    }
}
