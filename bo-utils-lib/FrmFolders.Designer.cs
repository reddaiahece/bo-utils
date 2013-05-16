namespace BusinessObjectsUtils
{
    partial class FrmFolders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFolders));
            ctrlTreeView = new System.Windows.Forms.TreeView();
            ctrlCancel = new System.Windows.Forms.Button();
            ctrlAdd = new System.Windows.Forms.Button();
            icons = new System.Windows.Forms.ImageList(components);
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            ctrlList = new System.Windows.Forms.ListView();
            colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            label1 = new System.Windows.Forms.Label();
            ctrlPath = new System.Windows.Forms.Label();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // ctrlTreeView
            // 
            ctrlTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            ctrlTreeView.Location = new System.Drawing.Point(0, 0);
            ctrlTreeView.Name = "ctrlTreeView";
            ctrlTreeView.Size = new System.Drawing.Size(124, 302);
            ctrlTreeView.TabIndex = 0;
            ctrlTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(ctrlTreeView_AfterSelect);
            // 
            // ctrlCancel
            // 
            ctrlCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            ctrlCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            ctrlCancel.CausesValidation = false;
            ctrlCancel.Location = new System.Drawing.Point(433, 332);
            ctrlCancel.Name = "ctrlCancel";
            ctrlCancel.Size = new System.Drawing.Size(90, 24);
            ctrlCancel.TabIndex = 29;
            ctrlCancel.Text = "Cancel";
            ctrlCancel.UseVisualStyleBackColor = true;
            ctrlCancel.Click += new System.EventHandler(ctrlCancel_Click);
            // 
            // ctrlAdd
            // 
            ctrlAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            ctrlAdd.FlatAppearance.BorderSize = 2;
            ctrlAdd.Location = new System.Drawing.Point(337, 332);
            ctrlAdd.Name = "ctrlAdd";
            ctrlAdd.Size = new System.Drawing.Size(90, 24);
            ctrlAdd.TabIndex = 28;
            ctrlAdd.Text = "Add";
            ctrlAdd.UseVisualStyleBackColor = true;
            ctrlAdd.Click += new System.EventHandler(ctrlAdd_Click);
            // 
            // icons
            // 
            icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            icons.TransparentColor = System.Drawing.Color.Transparent;
            icons.Images.SetKeyName(0, "folder.jpg");
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            splitContainer1.Location = new System.Drawing.Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(ctrlTreeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ctrlList);
            splitContainer1.Size = new System.Drawing.Size(535, 302);
            splitContainer1.SplitterDistance = 124;
            splitContainer1.TabIndex = 30;
            // 
            // ctrlList
            // 
            ctrlList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colId,
            colType,
            colName});
            ctrlList.Dock = System.Windows.Forms.DockStyle.Fill;
            ctrlList.FullRowSelect = true;
            ctrlList.Location = new System.Drawing.Point(0, 0);
            ctrlList.Name = "ctrlList";
            ctrlList.Size = new System.Drawing.Size(407, 302);
            ctrlList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            ctrlList.TabIndex = 0;
            ctrlList.UseCompatibleStateImageBehavior = false;
            ctrlList.View = System.Windows.Forms.View.Details;
            ctrlList.SelectedIndexChanged += new System.EventHandler(ctrlList_SelectedIndexChanged);
            // 
            // colId
            // 
            colId.Text = "Id";
            // 
            // colType
            // 
            colType.Text = "Type";
            // 
            // colName
            // 
            colName.Text = "Name";
            colName.Width = 266;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(2, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 13);
            label1.TabIndex = 31;
            label1.Text = "Path:";
            // 
            // ctrlPath
            // 
            ctrlPath.AutoSize = true;
            ctrlPath.Location = new System.Drawing.Point(36, 6);
            ctrlPath.Name = "ctrlPath";
            ctrlPath.Size = new System.Drawing.Size(0, 13);
            ctrlPath.TabIndex = 31;
            // 
            // FrmFolders
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(535, 361);
            Controls.Add(ctrlPath);
            Controls.Add(label1);
            Controls.Add(splitContainer1);
            Controls.Add(ctrlCancel);
            Controls.Add(ctrlAdd);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmFolders";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Folders";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ctrlTreeView;
        private System.Windows.Forms.Button ctrlCancel;
        private System.Windows.Forms.Button ctrlAdd;
        private System.Windows.Forms.ImageList icons;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView ctrlList;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ctrlPath;
    }
}