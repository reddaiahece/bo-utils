using System;

namespace BusinessObjectsUtils.bo_session
{

    [Serializable()]
    public class LoginData
    {
        public string Url;
        public int Version;
        public string Domain;
        public string AuthType;
        public string Login;
        public string Password;
        public Proxy Proxy;
    }

    [Serializable()]
    public class Proxy
    {
        public string Host;
        public int Port;
        public string User;
        public string Password;

        public System.Net.IWebProxy ToWebProxy()
        {
            System.Net.IWebProxy proxyObject = new System.Net.WebProxy(Host, Port);
            if(!String.IsNullOrEmpty(User))
                proxyObject.Credentials = new System.Net.NetworkCredential( User, Password);
            return proxyObject;
        }
    }

}
