using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessObjectsUtils.bo_scheduler;

namespace BusinessObjectsUtils
{
    public partial class FrmFolders : Form
    {
        private readonly FrmGetList.EnumFiles_Delegate _enumfiles_delegate;
        private string _path;

        public string SelectedPath
        {
            get{ return _path; }
        }

        public FrmFolders(FrmGetList.EnumFolders_Delegate enumfolders_delegate, FrmGetList.EnumFiles_Delegate enumfiles_delegate)
        {
            InitializeComponent();
                ctrlTreeView.ImageList = icons;
                try {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    ctrlTreeView.BeginUpdate();
                    foreach (TreeNode treenode in enumfolders_delegate())
                        ctrlTreeView.Nodes.Add(treenode);
                    ctrlTreeView.Sort();
                    ctrlTreeView.EndUpdate();
                } catch {
                    throw;
                } finally {
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
                _enumfiles_delegate = enumfiles_delegate;
        }

        private void ctrlAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ctrlCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ctrlTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedNode = e.Node;
            _path = selectedNode.FullPath.Replace('\\', '/').Replace("\'", "\\\'");
            _path += selectedNode.Nodes.Count==0 ? "/*" : "/**/*";
            ctrlPath.Text = _path;
            ctrlList.Items.Clear();

            Cursor.Current = Cursors.WaitCursor;
            var reports = _enumfiles_delegate(_path);
            foreach (var viewitem in reports)
                ctrlList.Items.Add(viewitem);
            Cursor.Current = Cursors.Default;

        }

        private void ctrlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _path = null;
            foreach(ListViewItem item in ctrlList.SelectedItems){
                if (_path != null) _path += ",";
                _path += item.Text;
            }
            ctrlPath.Text = _path;
        }

    }
}
