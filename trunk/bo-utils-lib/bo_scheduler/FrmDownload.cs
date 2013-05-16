using System;
using System.Text;
using System.Windows.Forms;


namespace BusinessObjectsUtils.bo_scheduler
{
    public partial class FrmDownload : BaseForm
    {
        FolderBrowserDialog _folderBrowserDialog1;

        public StringBuilder Reports {
            set {
                ctrlReports.Text = value.ToString();
            }
        }

        public string Directory { 
            get { return ctrlReportsPath.Text; } 
            set { ctrlReportsPath.Text = value; }
        }

        public string AssociatedInstance {
            get {
                if (ctrlDlNone.Checked) return "NONE";
                if (ctrlDlLastSucceed.Checked) return "LAST_SUCCEED";
                if (ctrlDlSpecified.Checked) return "SPECIFIED";
                return null;
            }
            set {
                switch(value){
                    case "NONE": ctrlDlSpecified.Checked = true; break;
                    case "LAST_SUCCEED": ctrlDlLastSucceed.Checked = true; break;
                    case "SPECIFIED": ctrlDlSpecified.Checked = true; break;
                    default: throw new Exception("Option <" + value + "> is not a valid argument for AssociatedInstance !");
                }
            }
        }

        public string Format {
            get {
                if (ctrlFormatBinary.Checked) return "DEFAULT";
                if (ctrlFormatXml.Checked) return "XML";
                if (ctrlFormatHtml.Checked) return "HTML";
                if (ctrlFormatPdf.Checked) return "PDF";
                if (ctrlFormatExcel.Checked) return "EXCEL";
                return null;
            }
            set {
                switch(value){
                    case "DEFAULT": ctrlFormatBinary.Checked = true; break;
                    case "XML": ctrlFormatXml.Checked = true; break;
                    case "HTML": ctrlFormatHtml.Checked = true; break;
                    case "PDF": ctrlFormatPdf.Checked = true; break;
                    case "EXCEL": ctrlFormatExcel.Checked = true; break;
                    default: throw new Exception("Option <" + value + "> is not a valid argument for Format !");
                }
            }
        }

        public FrmDownload(int hwnd) : base(hwnd){
            InitializeComponent();
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            if(_folderBrowserDialog1 == null){
                 _folderBrowserDialog1 = new FolderBrowserDialog();
                 if(System.IO.Directory.Exists( ctrlReportsPath.Text))
                    _folderBrowserDialog1.SelectedPath =  ctrlReportsPath.Text;
            }
            if (_folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ctrlReportsPath.Text = _folderBrowserDialog1.SelectedPath;
            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btDownload_Click(object sender, EventArgs e)
        {
            if (ctrlReportsPath.Text == "") { MsgBox.ShowError("Reports location is empty !  "); return; }
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
