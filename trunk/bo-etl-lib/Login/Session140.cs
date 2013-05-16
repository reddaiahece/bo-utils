extern alias DSWS140;

using System;
using System.Collections.Generic;
using System.Text;

using Connection = DSWS140::BusinessObjects.DSWS.Connection;
using Session = DSWS140::BusinessObjects.DSWS.Session.Session;
using SessionInfo = DSWS140::BusinessObjects.DSWS.Session.SessionInfo;
using EnterpriseCredential = DSWS140::BusinessObjects.DSWS.Session.EnterpriseCredential;
using BIPlatform = DSWS140::BusinessObjects.DSWS.BIPlatform.BIPlatform;
using DSWSException = DSWS140::BusinessObjects.DSWS.DSWSException;
using WSResource = DSWS140::BusinessObjects.DSWS.Session.WSResource;

namespace BusinessObjectsEtl
{
    public class Session140 : SessionBase
    {
        public Connection boConnection = null;
        public Session boSession = null;
        public SessionInfo boSessionInfo = null;
        public string SessionId = null;
        public BIPlatform boBIPlatform = null;

		public Session140( string sessionURL) : base(sessionURL){
			this.boConnection = new Connection(sessionURL);
			this.boSession = new Session(this.boConnection);
		}

        protected Exception CustomException(string message, Exception exception){
            if(exception is DSWSException){
                DSWSException ex = exception as DSWSException;
                return new Exception(message + "\r" + ex.CauseMessage + "\r" + ex.Message);
            }else{
                return new Exception(message + '\r' + exception.Message);
            }
        }

        protected string ReportException(Exception exception){
            string message;
            if(exception is DSWSException){
                DSWSException ex = exception as DSWSException;
                message = " EXCEPTION: " + ex.Message + ", " + ex.CauseMessage;
            }else{
                message = " EXCEPTION: " + exception.Message;
            }
            base.Log(message);
            return message;
        }

		internal int[] GetVersion(){
		    int[] numver = new int[3];
			try{
				string[] version = this.boSession.GetVersion().Split('.');
				for (int i = 0; i < version.Length; i++)
					numver[i] = int.Parse(version[i]);
			}catch (Exception ex) {
                if(ex is DSWSException && (((DSWSException)ex).ID == "0" || ((DSWSException)ex).ID=="90001")){
                    numver[0] = 14;
                }else{
                    throw CustomException("Failed to get the version", ex);
                }
            }
		    return numver;
		}

		public ExitCode Login(string cmsname, string username, string password, string authType, bool toBIPlatform, bool toReportEngine){
			//Login
            if (base.cancel) return ExitCode.CANCELED;
			base.SetProgress(4);
			base.Log("Login to " + base.SessionURL);
			try{
				EnterpriseCredential boEnterpriseCredential = new EnterpriseCredential();
				boEnterpriseCredential.Domain = cmsname;
				boEnterpriseCredential.Login = username;
				boEnterpriseCredential.Password = password;
				boEnterpriseCredential.AuthType = authType;
				this.boSessionInfo = boSession.Login(boEnterpriseCredential);
				this.SessionId =  this.boSessionInfo.SessionID;
			}catch(Exception ex){
			  //  this.boSession.Dispose();
				this.boSession = null;
				throw CustomException("Failed to Login", ex);
			}
            if (base.cancel) return ExitCode.CANCELED;
            if(toBIPlatform){
                base.SetProgress(9);
			    //Get the BIPlatform service
                base.Log("Connect to BIPlatform service");
			    try{
				    foreach (WSResource ressource in boSessionInfo.WSResourceList){
					    if(ressource.WSType == "BIPlatform"){
                            this.boConnection.URL = ressource.URL;
                            this.boBIPlatform = new BIPlatform(boConnection, boSession.ConnectionState);
						    break;
					    }
				    }
				    if (this.boBIPlatform == null) throw new Exception("Service not available !  ");
			    }catch(Exception ex){
				    this.Logout();
                    throw CustomException("Failed to access to the BIPlatform service : \r\n", ex);
			    }
            }
            if (base.cancel) return ExitCode.CANCELED;
            return ExitCode.SUCCEED;
		}

		public ExitCode Logout(){
            base.Log("Logout web service");
            base.SetProgress(100);
            try{
			    if(this.boSession != null ){
				    this.boSession.Logout();
				    this.boSession = null;
			    }
			    this.boBIPlatform = null;
			    this.SessionId = null;
                return ExitCode.SUCCEED;
            }catch(Exception){
                return ExitCode.FAILED;
            }
		}


    }
}
