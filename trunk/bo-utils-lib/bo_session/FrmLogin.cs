using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessObjectsUtils.helper;

namespace BusinessObjectsUtils.bo_session
{
    public partial class FrmLogin : BaseForm
    {
        private Dictionary<string, LoginData> historyList = new Dictionary<string, LoginData>();
        private const string defaultUrl = @"http://<hostname>:<port>/dswsbobje/services";

        public FrmLogin(int hwnd) : base(hwnd)
        {
            InitializeComponent();

            ctrlAuth.AddItem("");
            ctrlAuth.AddItem("secEnterprise");
            ctrlAuth.AddItem("secLDAP");
            ctrlAuth.AddItem("secWindowsNT");
            ctrlAuth.AddItem("secWinAD");

            ctrlVersion.AddItem(0, "");
            ctrlVersion.AddItem(11, "XI R2");
            ctrlVersion.AddItem(12, "XI V3");
            ctrlVersion.AddItem(14, "BI4");
#if(DEBUG)
            ctrlVersion.AddItem(98, "Random");
            ctrlVersion.AddItem(99, "Test");
#endif
            ctrlUrl.AddItem(defaultUrl);

            toolTip.SetToolTip(ctrlUrl, "Web service URL");
            toolTip.SetToolTip(ctrlVersion, "Plateform verson");
            toolTip.SetToolTip(ctrlAuth, "Authentication type");
            toolTip.SetToolTip(ctrlDomain, "System name");
            toolTip.SetToolTip(ctrlLogin, "User's login");
            toolTip.SetToolTip(ctrlPassword, "User's password");

        }

        public Dictionary<string,LoginData> LogHistory {
            set{
                if (value == null) return;
                historyList = (Dictionary<string, LoginData>)value;
                var keysCollection = historyList.Keys;
                int nbKey = keysCollection.Count;
                string[] keys = new string[nbKey];
                foreach (var key in historyList.Keys)
                    keys[--nbKey] = (string)key;
                foreach (var key in keys)
                    ctrlUrl.AddItem(key);
                    
                //for (string logindata in historyList.Keys.Reverse<string>())
                //    ctrlUrl.AddItem(logindata);
            }
            get{
                LoginData curlogdata = LoginData;
                if(historyList.ContainsKey(curlogdata.Url)){
                    historyList.Remove(curlogdata.Url);
                }
                historyList.Add(curlogdata.Url, curlogdata);
                return historyList;
            }

        }

        public LoginData LoginData
        {
            set{
                LoginData cred = (LoginData)value;
                ctrlUrl.Text = cred.Url;
                foreach (ValuePair item in ctrlVersion.Items)
                    if( (int)item.Key == cred.Version) ctrlVersion.SelectedItem = item;
                ctrlAuth.Text = cred.AuthType;
                ctrlDomain.Text = cred.Domain;
                ctrlLogin.Text = cred.Login;
                ctrlPassword.Text = cred.Password;
                if (cred.Proxy != null && !String.IsNullOrEmpty(cred.Proxy.Host)){
                    ctrlProxyHost.Text = cred.Proxy.Host;
                    ctrlProxyPort.Text = cred.Proxy.Port.ToString();
                    ctrlProxyUser.Text = cred.Proxy.User;
                    ctrlProxyPasword.Text = cred.Password;
                }else{
                    ctrlProxyHost.Text = String.Empty;
                    ctrlProxyPort.Text = String.Empty;
                    ctrlProxyUser.Text = String.Empty;
                    ctrlProxyPasword.Text = String.Empty;
                }
            }
            get{
                LoginData cred = new LoginData{
                    Url = ctrlUrl.Text,
                    Version = (int)((ValuePair)ctrlVersion.SelectedItem).Key,
                    AuthType = ctrlAuth.Text,
                    Domain = ctrlDomain.Text,
                    Login = ctrlLogin.Text,
                    Password = ctrlPassword.Text
                };
                if(!String.IsNullOrEmpty(ctrlProxyHost.Text)){
                    cred.Proxy = new Proxy{
                        Host=ctrlProxyHost.Text,
                        Port=int.Parse(ctrlProxyPort.Text),
                        User=ctrlProxyUser.Text,
                        Password=ctrlProxyPasword.Text
                    };
                }
                return cred;
            }
        }

        private void ctrlUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ctrlUrl.SelectedIndex;
            if(index==0){
                LoginData =  new LoginData(){ Url = defaultUrl };
            }else{
                LoginData = historyList[ctrlUrl.Text];
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (Func.CheckEmptyFields(ctrlUrl, ctrlVersion, ctrlAuth, ctrlDomain, ctrlLogin)){
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        /*
        private void TestURL(){

            try{
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if ( String.IsNullOrEmpty(ctrlUrl.Text)==false ){
                    Session.GetSessionUrl(ctrlUrl.Text);
                }else{
                    ctrlUrl.Text = defaultUrl;
                }
            }catch(Exception ex){
                MsgBox.ShowError(ex.Message);
            }finally{
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        */

    }
}
