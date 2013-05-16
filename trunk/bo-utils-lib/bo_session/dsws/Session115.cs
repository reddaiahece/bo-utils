extern alias DSWS115;

using System;
using System.Text;

using Connection = DSWS115::BusinessObjects.DSWS.Connection;
using Session_ = DSWS115::BusinessObjects.DSWS.Session.Session;
using SessionInfo = DSWS115::BusinessObjects.DSWS.Session.SessionInfo;
using EnterpriseCredential = DSWS115::BusinessObjects.DSWS.Session.EnterpriseCredential;
using BIPlatform = DSWS115::BusinessObjects.DSWS.BIPlatform.BIPlatform;
using ReportEngine = DSWS115::BusinessObjects.DSWS.ReportEngine.ReportEngine;
using DSWSException = DSWS115::BusinessObjects.DSWS.DSWSException;
using WSResource = DSWS115::BusinessObjects.DSWS.Session.WSResource;

namespace BusinessObjectsUtils.bo_session.dsws
{
    public class Session115 : ISession
    {
        private Connection _boConnection;
        private Session_ _boSession;
        private SessionInfo _boSessionInfo;
        private string _boSessionId;
        private BIPlatform _boBiPlatform = null;
        private ReportEngine _boReportEngine = null;

        public string SessionId
        {
            get{
                return _boSessionId;
            }
        }

        public Session_ Session
        {
            get{
                if (String.IsNullOrEmpty(_boSessionId)) throw new Exception("You must Login first !");
                return _boSession;
            }
        }

        public BIPlatform BIPlatform
        {
            get{
                if (_boBiPlatform == null) throw new Exception("BIPlatform is not connected!");
                return _boBiPlatform;
            }
        }

        public ReportEngine ReportEngine
        {
            get{
                if (_boReportEngine == null) throw new Exception("ReportEngine is not connected!");
                return _boReportEngine;
            }
        }

        public void Login(LoginData credentials)
		{
            _boConnection = new Connection(credentials.Url);
            _boSession = new Session_(_boConnection);
            if(credentials.Proxy!=null && !String.IsNullOrEmpty(credentials.Proxy.Host)){
                _boConnection.Proxy = credentials.Proxy.ToWebProxy();
            }
			EnterpriseCredential boEnterpriseCredential = new EnterpriseCredential();
            boEnterpriseCredential.Domain = credentials.Domain;
            boEnterpriseCredential.Login = credentials.Login;
            boEnterpriseCredential.Password = credentials.Password;
            boEnterpriseCredential.AuthType = credentials.AuthType;
			_boSessionInfo = _boSession.Login(boEnterpriseCredential);
			_boSessionId = _boSessionInfo.SessionID;
		}

        public void Logout(){
			if(_boSession != null ){
			    _boSession.Logout();
		        _boSession = null;
		        _boReportEngine = null;
		        _boBiPlatform = null;
		        _boSessionId = null;
            }
		}

        public string GetVersion()
        {
            return _boSession.GetVersion();
        }

        public void ConnectToBIPlatform()
        {
			foreach (WSResource ressource in _boSessionInfo.WSResourceList){
				if(ressource.WSType == "BIPlatform"){
                    _boConnection.URL = ressource.URL;
                    _boBiPlatform = new BIPlatform(_boConnection, _boSession.ConnectionState);
					break;
				}
			}
            if (_boBiPlatform == null) throw new Exception("BIPlatform service is not available!");
        }

        public void ConnectToReportEngine()
        {
			foreach (WSResource ressource in _boSessionInfo.WSResourceList){
				if(ressource.WSType == "ReportEngine"){
					_boConnection.URL = ressource.URL;
                    _boReportEngine = new ReportEngine(_boConnection, _boSession.ConnectionState);
					break;
				}
			}
            if (_boReportEngine == null) throw new Exception("ReportEngine service is not available!");
        }

        public void ResetSessionTimeOut()
        {
            _boSession.ResetSessionTimeOut();
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
