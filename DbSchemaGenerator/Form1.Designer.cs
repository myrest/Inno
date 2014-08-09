namespace DbSchemaGenerator
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FileSelector = new System.Windows.Forms.Button();
            this.labFn = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.Label();
            this.lbNameSpace = new System.Windows.Forms.Label();
            this.NameSpace = new System.Windows.Forms.TextBox();
            this.Build = new System.Windows.Forms.Button();
            this.TargetFolder = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FolderSelector = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabSqlite = new System.Windows.Forms.TabControl();
            this.Sqlite = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabBuildIdv = new System.Windows.Forms.TabPage();
            this.ContentBody = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GenDAL = new System.Windows.Forms.Button();
            this.GenBLL = new System.Windows.Forms.Button();
            this.ReloadSchema = new System.Windows.Forms.Button();
            this.GenDomain = new System.Windows.Forms.Button();
            this.DDLTableListing = new System.Windows.Forms.ComboBox();
            this.tabMainFunction = new System.Windows.Forms.TabControl();
            this.tabSqlite.SuspendLayout();
            this.Sqlite.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabBuildIdv.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabMainFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FileSelector
            // 
            this.FileSelector.Location = new System.Drawing.Point(701, 6);
            this.FileSelector.Name = "FileSelector";
            this.FileSelector.Size = new System.Drawing.Size(84, 23);
            this.FileSelector.TabIndex = 2;
            this.FileSelector.Text = "Select File...";
            this.FileSelector.UseVisualStyleBackColor = true;
            this.FileSelector.Click += new System.EventHandler(this.FileSelector_Click);
            // 
            // labFn
            // 
            this.labFn.AutoSize = true;
            this.labFn.Location = new System.Drawing.Point(34, 11);
            this.labFn.Name = "labFn";
            this.labFn.Size = new System.Drawing.Size(58, 12);
            this.labFn.TabIndex = 0;
            this.labFn.Text = "File Name :";
            // 
            // FileName
            // 
            this.FileName.AutoSize = true;
            this.FileName.Location = new System.Drawing.Point(98, 11);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(40, 12);
            this.FileName.TabIndex = 0;
            this.FileName.Text = "NoData";
            // 
            // lbNameSpace
            // 
            this.lbNameSpace.AutoSize = true;
            this.lbNameSpace.Location = new System.Drawing.Point(18, 12);
            this.lbNameSpace.Name = "lbNameSpace";
            this.lbNameSpace.Size = new System.Drawing.Size(68, 12);
            this.lbNameSpace.TabIndex = 0;
            this.lbNameSpace.Text = "Name Space :";
            // 
            // NameSpace
            // 
            this.NameSpace.Location = new System.Drawing.Point(92, 9);
            this.NameSpace.Name = "NameSpace";
            this.NameSpace.Size = new System.Drawing.Size(583, 22);
            this.NameSpace.TabIndex = 1;
            // 
            // Build
            // 
            this.Build.Location = new System.Drawing.Point(701, 73);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(84, 23);
            this.Build.TabIndex = 3;
            this.Build.Text = "Build ALL";
            this.Build.UseVisualStyleBackColor = true;
            this.Build.Click += new System.EventHandler(this.Save_Click);
            // 
            // TargetFolder
            // 
            this.TargetFolder.AutoSize = true;
            this.TargetFolder.Location = new System.Drawing.Point(90, 49);
            this.TargetFolder.Name = "TargetFolder";
            this.TargetFolder.Size = new System.Drawing.Size(40, 12);
            this.TargetFolder.TabIndex = 4;
            this.TargetFolder.Text = "NoData";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Target Folder :";
            // 
            // FolderSelector
            // 
            this.FolderSelector.Location = new System.Drawing.Point(701, 44);
            this.FolderSelector.Name = "FolderSelector";
            this.FolderSelector.Size = new System.Drawing.Size(84, 23);
            this.FolderSelector.TabIndex = 6;
            this.FolderSelector.Text = "Target Folder..";
            this.FolderSelector.UseVisualStyleBackColor = true;
            this.FolderSelector.Click += new System.EventHandler(this.FolderSelector_Click);
            // 
            // tabSqlite
            // 
            this.tabSqlite.Controls.Add(this.Sqlite);
            this.tabSqlite.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabSqlite.Location = new System.Drawing.Point(0, 0);
            this.tabSqlite.Name = "tabSqlite";
            this.tabSqlite.SelectedIndex = 0;
            this.tabSqlite.Size = new System.Drawing.Size(801, 61);
            this.tabSqlite.TabIndex = 7;
            // 
            // Sqlite
            // 
            this.Sqlite.Controls.Add(this.FileSelector);
            this.Sqlite.Controls.Add(this.FileName);
            this.Sqlite.Controls.Add(this.labFn);
            this.Sqlite.Location = new System.Drawing.Point(4, 22);
            this.Sqlite.Name = "Sqlite";
            this.Sqlite.Padding = new System.Windows.Forms.Padding(3);
            this.Sqlite.Size = new System.Drawing.Size(793, 35);
            this.Sqlite.TabIndex = 1;
            this.Sqlite.Text = "Sqlite setting";
            this.Sqlite.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbNameSpace);
            this.tabPage1.Controls.Add(this.FolderSelector);
            this.tabPage1.Controls.Add(this.TargetFolder);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.Build);
            this.tabPage1.Controls.Add(this.NameSpace);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(793, 336);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Build ALL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabBuildIdv
            // 
            this.tabBuildIdv.Controls.Add(this.ContentBody);
            this.tabBuildIdv.Controls.Add(this.panel2);
            this.tabBuildIdv.Controls.Add(this.panel1);
            this.tabBuildIdv.Controls.Add(this.DDLTableListing);
            this.tabBuildIdv.Location = new System.Drawing.Point(4, 22);
            this.tabBuildIdv.Name = "tabBuildIdv";
            this.tabBuildIdv.Padding = new System.Windows.Forms.Padding(3);
            this.tabBuildIdv.Size = new System.Drawing.Size(793, 337);
            this.tabBuildIdv.TabIndex = 0;
            this.tabBuildIdv.Text = "Build individual";
            this.tabBuildIdv.UseVisualStyleBackColor = true;
            // 
            // ContentBody
            // 
            this.ContentBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentBody.Location = new System.Drawing.Point(138, 32);
            this.ContentBody.Multiline = true;
            this.ContentBody.Name = "ContentBody";
            this.ContentBody.ReadOnly = true;
            this.ContentBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ContentBody.Size = new System.Drawing.Size(652, 273);
            this.ContentBody.TabIndex = 1;
            this.ContentBody.WordWrap = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(138, 305);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(652, 29);
            this.panel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(544, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Copy to Clipboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GenDAL);
            this.panel1.Controls.Add(this.GenBLL);
            this.panel1.Controls.Add(this.ReloadSchema);
            this.panel1.Controls.Add(this.GenDomain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(138, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 29);
            this.panel1.TabIndex = 2;
            // 
            // GenDAL
            // 
            this.GenDAL.Location = new System.Drawing.Point(574, 3);
            this.GenDAL.Name = "GenDAL";
            this.GenDAL.Size = new System.Drawing.Size(75, 23);
            this.GenDAL.TabIndex = 0;
            this.GenDAL.TabStop = false;
            this.GenDAL.Text = "DAL";
            this.GenDAL.UseVisualStyleBackColor = true;
            this.GenDAL.Click += new System.EventHandler(this.GenDAL_Click);
            // 
            // GenBLL
            // 
            this.GenBLL.Location = new System.Drawing.Point(493, 3);
            this.GenBLL.Name = "GenBLL";
            this.GenBLL.Size = new System.Drawing.Size(75, 23);
            this.GenBLL.TabIndex = 0;
            this.GenBLL.TabStop = false;
            this.GenBLL.Text = "BLL";
            this.GenBLL.UseVisualStyleBackColor = true;
            this.GenBLL.Click += new System.EventHandler(this.GenBLL_Click);
            // 
            // ReloadSchema
            // 
            this.ReloadSchema.Location = new System.Drawing.Point(6, 3);
            this.ReloadSchema.Name = "ReloadSchema";
            this.ReloadSchema.Size = new System.Drawing.Size(95, 23);
            this.ReloadSchema.TabIndex = 0;
            this.ReloadSchema.Text = "Reload Schema";
            this.ReloadSchema.UseVisualStyleBackColor = true;
            this.ReloadSchema.Click += new System.EventHandler(this.ReloadSchema_Click);
            // 
            // GenDomain
            // 
            this.GenDomain.Location = new System.Drawing.Point(412, 3);
            this.GenDomain.Name = "GenDomain";
            this.GenDomain.Size = new System.Drawing.Size(75, 23);
            this.GenDomain.TabIndex = 0;
            this.GenDomain.TabStop = false;
            this.GenDomain.Text = "Domain";
            this.GenDomain.UseVisualStyleBackColor = true;
            this.GenDomain.Click += new System.EventHandler(this.GenDomain_Click);
            // 
            // DDLTableListing
            // 
            this.DDLTableListing.Dock = System.Windows.Forms.DockStyle.Left;
            this.DDLTableListing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.DDLTableListing.FormattingEnabled = true;
            this.DDLTableListing.Location = new System.Drawing.Point(3, 3);
            this.DDLTableListing.Name = "DDLTableListing";
            this.DDLTableListing.Size = new System.Drawing.Size(135, 331);
            this.DDLTableListing.TabIndex = 0;
            this.DDLTableListing.SelectedIndexChanged += new System.EventHandler(this.DDLTableListing_SelectedIndexChanged);
            // 
            // tabMainFunction
            // 
            this.tabMainFunction.Controls.Add(this.tabPage1);
            this.tabMainFunction.Controls.Add(this.tabBuildIdv);
            this.tabMainFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMainFunction.Location = new System.Drawing.Point(0, 61);
            this.tabMainFunction.Name = "tabMainFunction";
            this.tabMainFunction.SelectedIndex = 0;
            this.tabMainFunction.Size = new System.Drawing.Size(801, 362);
            this.tabMainFunction.TabIndex = 8;
            this.tabMainFunction.SelectedIndexChanged += new System.EventHandler(this.tabMainFunction_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 423);
            this.Controls.Add(this.tabMainFunction);
            this.Controls.Add(this.tabSqlite);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabSqlite.ResumeLayout(false);
            this.Sqlite.ResumeLayout(false);
            this.Sqlite.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabBuildIdv.ResumeLayout(false);
            this.tabBuildIdv.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabMainFunction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button FileSelector;
        private System.Windows.Forms.Label labFn;
        private System.Windows.Forms.Label FileName;
        private System.Windows.Forms.Label lbNameSpace;
        private System.Windows.Forms.TextBox NameSpace;
        private System.Windows.Forms.Button Build;
        private System.Windows.Forms.Label TargetFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FolderSelector;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl tabSqlite;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage Sqlite;
        private System.Windows.Forms.TabPage tabBuildIdv;
        private System.Windows.Forms.TabControl tabMainFunction;
        private System.Windows.Forms.TextBox ContentBody;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GenDAL;
        private System.Windows.Forms.Button GenBLL;
        private System.Windows.Forms.Button GenDomain;
        private System.Windows.Forms.ComboBox DDLTableListing;
        private System.Windows.Forms.Button ReloadSchema;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;



    }
}

