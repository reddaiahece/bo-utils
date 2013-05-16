using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BusinessObjectsUtils.bo_session.dsws
{
    class SessionTest : ISession
    {
        public SessionTest()
        {
		}

        public void Login(LoginData credentials)
		{
            //throw new Exception("Description effect", new Exception("Description root"));
		}

        public void Logout(){
 
		}

        public string GetVersion()
        {
            return "11.5.0";
        }

        public void ConnectToBIPlatform()
        {
     
        }

        public void ConnectToReportEngine()
        {
     
        }

        public void ResetSessionTimeOut()
        {
            
        }

        public Exception ParseException(string message, Exception exception)
        {
            return new Exception(message, exception);
        }

        public string ParseException(Exception exception)
        {
            return exception.Message;
        }

    }
}
