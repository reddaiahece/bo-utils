using System;
using System.Text;
using System.Windows.Forms;


namespace BusinessObjectsUtils.bo_scheduler
{
    public partial class FrmGetStatus : BaseForm
    {
        public StringBuilder Reports {
            set {
                ctrlReports.Text = value.ToString();
            }
        }

        public string AssociatedInstance {
            get { 
                if(ctrlGetLastCreated.Checked) return "LAST_CREATED";
                if(ctrlGetLastSucceed.Checked) return "LAST_SUCCEED";
                if(ctrlGetLastFailed.Checked) return "LAST_FAILED";
                if(ctrlGetSpecified.Checked) return "SPECIFIED";
                return null;
            }
            set {
                switch(value){
                    case "LAST_CREATED": ctrlGetLastCreated.Checked = true; break;
                    case "LAST_SUCCEED": ctrlGetLastSucceed.Checked = true; break;
                    case "LAST_FAILED": ctrlGetLastFailed.Checked = true; break;
                    case "SPECIFIED": ctrlGetSpecified.Checked = true; break;
                    default : throw new Exception("Option <" + value + "> is not a valid argument for AssociatedInstance !");
                }
            }
        }

        public FrmGetStatus(int hwnd) : base(hwnd)
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btGetStatus_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
