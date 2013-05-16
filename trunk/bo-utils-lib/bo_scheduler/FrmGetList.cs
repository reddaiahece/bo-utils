using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace BusinessObjectsUtils.bo_scheduler
{
    public partial class FrmGetList : BaseForm
    {

        public delegate TreeNodeCollection EnumFolders_Delegate();
        public delegate List<ListViewItem> EnumFiles_Delegate(string path);

        FrmFolders _folders;
        public EnumFolders_Delegate _enum_folders_delegate;
        public EnumFiles_Delegate _enum_files_delegate;


        public string ReportsPath {
            get { return ctrlReportsPath.Text.Trim(new[] { '\r', '\n' }).Replace("\r\n", ","); }
            set { ctrlReportsPath.Text = value; }
        }

        public bool IncludePrompts { 
            get { return ctrlPrompts.Checked; } 
            set { ctrlPrompts.Checked = value; } 
        }

        public string AssociatedInstance {
            get { 
                if( ctrlGetLastCreated.Checked ) return "LAST_CREATED";
                if( ctrlGetLastSucceed.Checked ) return "LAST_SUCCEED";
                if( ctrlGetLastFailed.Checked ) return "LAST_FAILED";
                return null;
            }
            set {
                switch(value){
                    case "LAST_CREATED": ctrlGetLastCreated.Checked = true; break;
                    case "LAST_SUCCEED": ctrlGetLastSucceed.Checked = true; break;
                    case "LAST_FAILED": ctrlGetLastFailed.Checked = true; break;
                    default : ctrlGetLastNone.Checked = true; break;
                }
            }
        }

        public FrmGetList(int hwnd, EnumFolders_Delegate enumfolders_delegate, EnumFiles_Delegate enumfiles_delegate) : base(hwnd)
        {
            InitializeComponent();
            _enum_files_delegate = enumfiles_delegate;
            _enum_folders_delegate = enumfolders_delegate;
        }

        private void btCancel_Click(object sender, EventArgs e){
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btExtract_Click(object sender, EventArgs e){
            if (ctrlReportsPath.Text == "") { MsgBox.ShowError("Reports location is empty !  "); return; }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ctrlWizard_Click(object sender, EventArgs e)
        {
            if(_folders==null)
                _folders = new FrmFolders(_enum_folders_delegate, _enum_files_delegate);
            if (_folders.ShowDialog() != DialogResult.OK) return;
            var txt = ctrlReportsPath.Text;
            if (!string.IsNullOrEmpty(txt))
                txt += ",";
            txt += _folders.SelectedPath;
            ctrlReportsPath.Text = txt;
        }

    }
}
