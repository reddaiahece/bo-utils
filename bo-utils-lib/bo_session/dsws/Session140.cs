extern alias DSWS140;

using System;
using System.Text;

using Connection = DSWS140::BusinessObjects.DSWS.Connection;
using Session_ = DSWS140::BusinessObjects.DSWS.Session.Session;
using SessionInfo = DSWS140::BusinessObjects.DSWS.Session.SessionInfo;
using EnterpriseCredential = DSWS140::BusinessObjects.DSWS.Session.EnterpriseCredential;
using BIPlatform = DSWS140::BusinessObjects.DSWS.BIPlatform.BIPlatform;
using ReportEngine = DSWS140::BusinessObjects.DSWS.ReportEngine.ReportEngine;
using DSWSException = DSWS140::BusinessObjects.DSWS.DSWSException;
using WSResource = DSWS140::BusinessObjects.DSWS.Session.WSResource;

namespace BusinessObjectsUtils.bo_session.dsws
{
    public class Session140 : ISession
    {
        private Connection boConnection = null;
        private Session_ boSession = null;
        private SessionInfo boSessionInfo = null;
        private string boSessionId = null;
        private BIPlatform boBIPlatform = null;
        private ReportEngine boReportEngine = null;

        public Session140()
        {
		}

        public string SessionId
        {
            get{
                return boSessionId;
            }
        }

        public Session_ Session
        {
            get{
                if (String.IsNullOrEmpty(boSessionId)) throw new Exception("You must Login first !");
                return boSession;
            }
        }

        public BIPlatform BIPlatform
        {
            get{
                if (boBIPlatform == null) throw new Exception("BIPlatform is not connected!");
                return boBIPlatform;
            }
        }

        public ReportEngine ReportEngine
        {
            get{
                if (boReportEngine == null) throw new Exception("ReportEngine is not connected!");
                return boReportEngine;
            }
        }

        public void Login(LoginData credentials)
		{
            boConnection = new Connection(credentials.Url);
            boSession = new Session_(boConnection);
            if(credentials.Proxy!=null && !String.IsNullOrEmpty(credentials.Proxy.Host)){
                boConnection.Proxy = credentials.Proxy.ToWebProxy();
            }
			EnterpriseCredential boEnterpriseCredential = new EnterpriseCredential();
            boEnterpriseCredential.Domain = credentials.Domain;
            boEnterpriseCredential.Login = credentials.Login;
            boEnterpriseCredential.Password = credentials.Password;
            boEnterpriseCredential.AuthType = credentials.AuthType;
			boSessionInfo = boSession.Login(boEnterpriseCredential);
			boSessionId = boSessionInfo.SessionID;
		}

        public void Logout(){
			if(boSession != null ){
			    boSession.Logout();
		        boSession = null;
		        boReportEngine = null;
		        boBIPlatform = null;
		        boSessionId = null;
            }
		}

        public string GetVersion()
        {
            return boSession.GetVersion();
        }

        public void ConnectToBIPlatform()
        {
			foreach (WSResource ressource in boSessionInfo.WSResourceList){
				if(ressource.WSType == "BIPlatform"){
                    boConnection.URL = ressource.URL;
                    boBIPlatform = new BIPlatform(boConnection, boSession.ConnectionState);
					break;
				}
			}
            if (boBIPlatform == null) throw new Exception("BIPlatform service is not available!");
        }

        public void ConnectToReportEngine()
        {
			foreach (WSResource ressource in boSessionInfo.WSResourceList){
				if(ressource.WSType == "ReportEngine"){
					boConnection.URL = ressource.URL;
                    boReportEngine = new ReportEngine(boConnection, boSession.ConnectionState);
					break;
				}
			}
            if (boReportEngine == null) throw new Exception("ReportEngine service is not available!");
        }

        public void ResetSessionTimeOut()
        {
            boSession.ResetSessionTimeOut();
        }

        public Exception ParseException(string message, Exception exception)
        {
            if (exception is DSWSException){
                DSWSException dswsex = exception as DSWSException;
                return new Exception(message, new Exception( dswsex.CauseMessage) );
            }else{
                return new Exception(message, exception);
            }
        }

        public string ParseException(Exception exception)
        {
            if (exception is DSWSException){
                DSWSException dswsex = exception as DSWSException;
                return dswsex.CauseMessage;
            }else{
                return Func.ParseException(exception, "  ");
            }
        }
    }
}
