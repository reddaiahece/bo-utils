using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectsUtils.bo_session.dsws
{
    public interface ISession
    {
        void Login(LoginData credentials);
        void ConnectToBIPlatform();
        void ConnectToReportEngine();
        void Logout();
        string GetVersion();
        void ResetSessionTimeOut();
        Exception ParseException(string message, Exception exception);
        string ParseException(Exception exception);
    }
}
