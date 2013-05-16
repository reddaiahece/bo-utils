using System;
using System.Windows.Forms;

namespace BusinessObjectsUtils
{
    public partial class FrmAbout : BaseForm
    {
        public FrmAbout(int hwnd) : base(hwnd)
        {
            InitializeComponent();
            txtVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }

        //private void SetLabel(){
        //    txtProductId.Text = Func.id();
        //    RegistryKey or = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\0" + Func.id(), true);
        //    if (or != null){
        //        txtLicense.Text = (string)or.GetValue("l");
        //        or.Close();
        //        int dl = Func.Dl();
        //        if(dl==0x09280){
        //            txtStatus.ForeColor = System.Drawing.Color.Blue;
        //            txtStatus.Text =  "Unlimited license on the current domain";
        //        }else if((0xFFF0|dl)==0xFFF0 && (0xFFF0&dl)>0){
        //            txtStatus.ForeColor = System.Drawing.Color.Blue;
        //            txtStatus.Text = "This license will expire in " + (dl>>4) + " days ! ";
        //        }else{
        //            txtStatus.ForeColor = System.Drawing.Color.Red;
        //            txtStatus.Text =  "This license has expired ! "; 
        //        }
        //    }
        //}

        //private void btAddKey_Click(object sender, EventArgs e)
        //{
        //    string res= null;
        //    if( InputBox.Show("License key", "Enter your license key : ",ref res) == System.Windows.Forms.DialogResult.OK){
        //        int ret = Func.sDl(res);
        //        if((0x0FFF0|ret)!=0xFFF0 || (0xFFF0&ret)<1 ){
        //            MsgBox.ShowWarn("This license key is incorrect !    ");
        //            return;
        //        }else{
        //            SetLabel();
        //        }
        //    }
        //}

    }
}
