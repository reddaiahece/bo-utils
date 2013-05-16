using System;
using System.Text;
using System.Windows.Forms;

namespace BusinessObjectsUtils.bo_scheduler
{
    public partial class FrmDelete : BaseForm
    {
        public StringBuilder Reports {
            set {
                ctrlReports.Text = value.ToString();
            }
        }
        
        public string AssociatedInstance {
            get {
                if (ctrlDelFailed.Checked) return "ALL_FAILED";
                if (ctrlDelSucceed.Checked) return "ALL_SUCCEED";
                if (ctrlDelAllState.Checked) return "ALL_STATUS";
                if (ctrlDelSpecified.Checked) return "SPECIFIED";
                return null;
            }
            set {
                switch(value){
                    case "ALL_FAILED": ctrlDelFailed.Checked = true; break;
                    case "ALL_SUCCEED": ctrlDelSucceed.Checked = true; break;
                    case "ALL_STATUS": ctrlDelAllState.Checked = true; break;
                    case "SPECIFIED": ctrlDelSpecified.Checked = true; break;
                    default: throw new Exception("Option <" + value + "> is not a valid argument for AssociatedInstance !");
                }
            }
        }

        public FrmDelete(int hwnd) : base(hwnd){
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e){
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btDelete_Click(object sender, EventArgs e){
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}

