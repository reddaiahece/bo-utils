using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectsUtils.bo_session.dsws;
using BusinessObjectsUtils.bo_session;

namespace BusinessObjectsUtils.bo_session
{
    public class SessionManager : Logger
    {
        private LoginData _credentials;
        private bool _loggedin;

        public LoginData Credentials
        {
            get{ return _credentials;}
        }

        public ISession Session
        {
            get; private set;
        }

        public int Version
        {
            get { return _credentials.Version; }
        }

        public Logger Logger
        {
            get{return this;}
        }

        public void Cancel()
        {
            _cancel = true;
        }

        public bool LoggedIn
        {
            get { return _loggedin; }
        }

        public ExitCode Login(LoginData credentials)
        {
            _credentials = credentials;
            try{
                base.Log("Login to " + credentials.Url);
                switch (credentials.Version)
                {
                    case 11: Session = new Session115(); break;
                    case 12: Session = new Session120(); break;
                    case 14: Session = new Session140(); break;
#if(DEBUG)
                    case 98: Session = new SessionRand(); break;
                    case 99: Session = new SessionTest(); break;
#endif
                    default: throw new Exception("Version " + credentials.Version + " is not implemented!  ");
                }
                credentials.Url = GetSessionUrl(credentials.Url, credentials.Proxy);
                base.InitProgress(3, 100, 3);
                Session.Login(credentials);
                _loggedin = true;
                base.IncProgress();
            }catch(Exception ex){
                throw Session.ParseException("Failed to Login!", ex);
			}
            if (_cancel) return ExitCode.CANCELED;
            base.Log("Connect to BIPlatform service");
            try{
                Session.ConnectToBIPlatform();
                base.IncProgress();
			}catch(Exception ex){
                try{
                    Session.Logout();
                }catch { }
                throw Session.ParseException("Failed to connect to the BIPlatform service", ex);
            }
            if (_cancel) return ExitCode.CANCELED;
            base.Log("Connect to ReportEngine service");
            try{
                Session.ConnectToReportEngine();
                base.IncProgress();
			}catch(Exception ex){
                try{
                    Session.Logout();
                }catch { }
                throw Session.ParseException("Failed to connect to the ReportEngine service", ex);
			}
            return _cancel ? ExitCode.CANCELED : ExitCode.SUCCEED;
        }

        public void Logout()
        {
            if(_loggedin){
                base.Log("Logout web service");
                try{
                    Session.Logout();
                }catch { }
                _loggedin = false;
            }
        }

        public int[] GetVersion(){
            var numver = new int[3];
            try{
                var version = Session.GetVersion().Split('.');
                for (int i = 0; i < version.Length; i++)
                    numver[i] = int.Parse(version[i]);
            }catch (Exception ex) {
                //if(ex is DSWSException && (((DSWSException)ex).ID == "0" || ((DSWSException)ex).ID=="90001")) numver[0] = 14;
                throw Session.ParseException("Failed to get the version", ex);
            }
            return numver;
        }

        public static string GetSessionUrl(string url, Proxy proxy)
        {
            #if(DEBUG)
                if(url=="test") return "test";
            #endif

            url = url.TrimEnd('\\');
            if( String.IsNullOrEmpty(url) ){
                throw new Exception("Url is empty!");
            }
            if( Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute)==false ){
                throw new Exception("Url format is incorrect!");
            }
            string returnUrl = null;
            if(url.ToLower().EndsWith("session")){
                if (Func.TestURL(url + "?wsdl", proxy))
                {
                    returnUrl = url;
                }
            }
            if( Func.TestURL(url + "/Session?wsdl", proxy) ){
                returnUrl = url + "/Session";
            }else if(Func.TestURL(url + "/session?wsdl", proxy) ){
                returnUrl = url + "/session";
            }
            if( String.IsNullOrEmpty(returnUrl) ){
                throw new Exception("Error 404, web service not found!");
            }
            return returnUrl;
        }

        public void ResetSessionTimeOut()
        {
            Session.ResetSessionTimeOut();
        }

        public Exception ParseException(string message, Exception exception)
        {
            return Session.ParseException(message, exception);
        }

        public string ParseException(Exception exception, string prefix = "ERROR: ", string seperator = " ")
        {
            return Session.ParseException(exception);
        }
    }
}
