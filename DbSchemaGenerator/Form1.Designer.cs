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
            this.tabDBSetting = new System.Windows.Forms.TabControl();
            this.Sqlite = new System.Windows.Forms.TabPage();
            this.MsSql = new System.Windows.Forms.TabPage();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.mssqldbname = new System.Windows.Forms.TextBox();
            this.servername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabBuildIdv = new System.Windows.Forms.TabPage();
            this.ContentBody = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GenDAL = new System.Windows.Forms.Button();
            this.GenBLL = new System.Windows.Forms.Button();
            this.ReloadSchema = new System.Windows.Forms.Button();
            this.GenDomain = new System.Windows.Forms.Button();
            this.DDLTableListing = new System.Windows.Forms.ComboBox();
            this.tabMainFunction = new System.Windows.Forms.TabControl();
            this.tabDBSetting.SuspendLayout();
            this.Sqlite.SuspendLayout();
            this.MsSql.SuspendLayout();
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
            this.FileSelector.Location = new System.Drawing.Point(1532, 12);
            this.FileSelector.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.FileSelector.Name = "FileSelector";
            this.FileSelector.Size = new System.Drawing.Size(182, 46);
            this.FileSelector.TabIndex = 2;
            this.FileSelector.Text = "Select File...";
            this.FileSelector.UseVisualStyleBackColor = true;
            this.FileSelector.Click += new System.EventHandler(this.FileSelector_Click);
            // 
            // labFn
            // 
            this.labFn.AutoSize = true;
            this.labFn.Location = new System.Drawing.Point(74, 22);
            this.labFn.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labFn.Name = "labFn";
            this.labFn.Size = new System.Drawing.Size(117, 24);
            this.labFn.TabIndex = 0;
            this.labFn.Text = "File Name :";
            // 
            // FileName
            // 
            this.FileName.AutoSize = true;
            this.FileName.Location = new System.Drawing.Point(212, 22);
            this.FileName.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(79, 24);
            this.FileName.TabIndex = 0;
            this.FileName.Text = "NoData";
            // 
            // lbNameSpace
            // 
            this.lbNameSpace.AutoSize = true;
            this.lbNameSpace.Location = new System.Drawing.Point(39, 24);
            this.lbNameSpace.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lbNameSpace.Name = "lbNameSpace";
            this.lbNameSpace.Size = new System.Drawing.Size(136, 24);
            this.lbNameSpace.TabIndex = 0;
            this.lbNameSpace.Text = "Name Space :";
            // 
            // NameSpace
            // 
            this.NameSpace.Location = new System.Drawing.Point(199, 18);
            this.NameSpace.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.NameSpace.Name = "NameSpace";
            this.NameSpace.Size = new System.Drawing.Size(1259, 36);
            this.NameSpace.TabIndex = 1;
            // 
            // Build
            // 
            this.Build.Location = new System.Drawing.Point(1519, 146);
            this.Build.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(182, 46);
            this.Build.TabIndex = 3;
            this.Build.Text = "Build ALL";
            this.Build.UseVisualStyleBackColor = true;
            this.Build.Click += new System.EventHandler(this.Save_Click);
            // 
            // TargetFolder
            // 
            this.TargetFolder.AutoSize = true;
            this.TargetFolder.Location = new System.Drawing.Point(195, 98);
            this.TargetFolder.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.TargetFolder.Name = "TargetFolder";
            this.TargetFolder.Size = new System.Drawing.Size(79, 24);
            this.TargetFolder.TabIndex = 4;
            this.TargetFolder.Text = "NoData";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Target Folder :";
            // 
            // FolderSelector
            // 
            this.FolderSelector.Location = new System.Drawing.Point(1519, 88);
            this.FolderSelector.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.FolderSelector.Name = "FolderSelector";
            this.FolderSelector.Size = new System.Drawing.Size(182, 46);
            this.FolderSelector.TabIndex = 6;
            this.FolderSelector.Text = "Target Folder..";
            this.FolderSelector.UseVisualStyleBackColor = true;
            this.FolderSelector.Click += new System.EventHandler(this.FolderSelector_Click);
            // 
            // tabDBSetting
            // 
            this.tabDBSetting.Controls.Add(this.Sqlite);
            this.tabDBSetting.Controls.Add(this.MsSql);
            this.tabDBSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabDBSetting.Location = new System.Drawing.Point(0, 0);
            this.tabDBSetting.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabDBSetting.Name = "tabDBSetting";
            this.tabDBSetting.SelectedIndex = 0;
            this.tabDBSetting.Size = new System.Drawing.Size(1736, 190);
            this.tabDBSetting.TabIndex = 7;
            // 
            // Sqlite
            // 
            this.Sqlite.Controls.Add(this.FileSelector);
            this.Sqlite.Controls.Add(this.FileName);
            this.Sqlite.Controls.Add(this.labFn);
            this.Sqlite.Location = new System.Drawing.Point(4, 34);
            this.Sqlite.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Sqlite.Name = "Sqlite";
            this.Sqlite.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Sqlite.Size = new System.Drawing.Size(1728, 152);
            this.Sqlite.TabIndex = 1;
            this.Sqlite.Text = "Sqlite setting";
            this.Sqlite.UseVisualStyleBackColor = true;
            // 
            // MsSql
            // 
            this.MsSql.Controls.Add(this.password);
            this.MsSql.Controls.Add(this.username);
            this.MsSql.Controls.Add(this.mssqldbname);
            this.MsSql.Controls.Add(this.servername);
            this.MsSql.Controls.Add(this.label5);
            this.MsSql.Controls.Add(this.label4);
            this.MsSql.Controls.Add(this.label3);
            this.MsSql.Controls.Add(this.label1);
            this.MsSql.Location = new System.Drawing.Point(4, 34);
            this.MsSql.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MsSql.Name = "MsSql";
            this.MsSql.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MsSql.Size = new System.Drawing.Size(1728, 152);
            this.MsSql.TabIndex = 2;
            this.MsSql.Text = "MsSql";
            this.MsSql.UseVisualStyleBackColor = true;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(683, 78);
            this.password.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(273, 36);
            this.password.TabIndex = 8;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(683, 22);
            this.username.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(273, 36);
            this.username.TabIndex = 7;
            // 
            // mssqldbname
            // 
            this.mssqldbname.Location = new System.Drawing.Point(199, 78);
            this.mssqldbname.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.mssqldbname.Name = "mssqldbname";
            this.mssqldbname.Size = new System.Drawing.Size(273, 36);
            this.mssqldbname.TabIndex = 6;
            // 
            // servername
            // 
            this.servername.Location = new System.Drawing.Point(199, 22);
            this.servername.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.servername.Name = "servername";
            this.servername.Size = new System.Drawing.Size(273, 36);
            this.servername.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(559, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "UserName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Database Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbNameSpace);
            this.tabPage1.Controls.Add(this.FolderSelector);
            this.tabPage1.Controls.Add(this.TargetFolder);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.Build);
            this.tabPage1.Controls.Add(this.NameSpace);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage1.Size = new System.Drawing.Size(1728, 618);
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
            this.tabBuildIdv.Location = new System.Drawing.Point(4, 34);
            this.tabBuildIdv.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabBuildIdv.Name = "tabBuildIdv";
            this.tabBuildIdv.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabBuildIdv.Size = new System.Drawing.Size(1728, 618);
            this.tabBuildIdv.TabIndex = 0;
            this.tabBuildIdv.Text = "Build individual";
            this.tabBuildIdv.UseVisualStyleBackColor = true;
            // 
            // ContentBody
            // 
            this.ContentBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentBody.Location = new System.Drawing.Point(295, 64);
            this.ContentBody.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ContentBody.Multiline = true;
            this.ContentBody.Name = "ContentBody";
            this.ContentBody.ReadOnly = true;
            this.ContentBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ContentBody.Size = new System.Drawing.Size(1426, 490);
            this.ContentBody.TabIndex = 1;
            this.ContentBody.WordWrap = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(295, 554);
            this.panel2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1426, 58);
            this.panel2.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(919, 6);
            this.button2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(223, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "Build File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1179, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 46);
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
            this.panel1.Location = new System.Drawing.Point(295, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1426, 58);
            this.panel1.TabIndex = 2;
            // 
            // GenDAL
            // 
            this.GenDAL.Location = new System.Drawing.Point(1244, 6);
            this.GenDAL.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.GenDAL.Name = "GenDAL";
            this.GenDAL.Size = new System.Drawing.Size(163, 46);
            this.GenDAL.TabIndex = 0;
            this.GenDAL.TabStop = false;
            this.GenDAL.Text = "DAL";
            this.GenDAL.UseVisualStyleBackColor = true;
            this.GenDAL.Click += new System.EventHandler(this.GenDAL_Click);
            // 
            // GenBLL
            // 
            this.GenBLL.Location = new System.Drawing.Point(1068, 6);
            this.GenBLL.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.GenBLL.Name = "GenBLL";
            this.GenBLL.Size = new System.Drawing.Size(163, 46);
            this.GenBLL.TabIndex = 0;
            this.GenBLL.TabStop = false;
            this.GenBLL.Text = "BLL";
            this.GenBLL.UseVisualStyleBackColor = true;
            this.GenBLL.Click += new System.EventHandler(this.GenBLL_Click);
            // 
            // ReloadSchema
            // 
            this.ReloadSchema.Location = new System.Drawing.Point(13, 6);
            this.ReloadSchema.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ReloadSchema.Name = "ReloadSchema";
            this.ReloadSchema.Size = new System.Drawing.Size(206, 46);
            this.ReloadSchema.TabIndex = 0;
            this.ReloadSchema.Text = "Reload Schema";
            this.ReloadSchema.UseVisualStyleBackColor = true;
            this.ReloadSchema.Click += new System.EventHandler(this.ReloadSchema_Click);
            // 
            // GenDomain
            // 
            this.GenDomain.Location = new System.Drawing.Point(893, 6);
            this.GenDomain.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.GenDomain.Name = "GenDomain";
            this.GenDomain.Size = new System.Drawing.Size(163, 46);
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
            this.DDLTableListing.Location = new System.Drawing.Point(7, 6);
            this.DDLTableListing.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.DDLTableListing.Name = "DDLTableListing";
            this.DDLTableListing.Size = new System.Drawing.Size(288, 606);
            this.DDLTableListing.TabIndex = 0;
            this.DDLTableListing.SelectedIndexChanged += new System.EventHandler(this.DDLTableListing_SelectedIndexChanged);
            // 
            // tabMainFunction
            // 
            this.tabMainFunction.Controls.Add(this.tabPage1);
            this.tabMainFunction.Controls.Add(this.tabBuildIdv);
            this.tabMainFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMainFunction.Location = new System.Drawing.Point(0, 190);
            this.tabMainFunction.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabMainFunction.Name = "tabMainFunction";
            this.tabMainFunction.SelectedIndex = 0;
            this.tabMainFunction.Size = new System.Drawing.Size(1736, 656);
            this.tabMainFunction.TabIndex = 8;
            this.tabMainFunction.SelectedIndexChanged += new System.EventHandler(this.tabMainFunction_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1736, 846);
            this.Controls.Add(this.tabMainFunction);
            this.Controls.Add(this.tabDBSetting);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabDBSetting.ResumeLayout(false);
            this.Sqlite.ResumeLayout(false);
            this.Sqlite.PerformLayout();
            this.MsSql.ResumeLayout(false);
            this.MsSql.PerformLayout();
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
        private System.Windows.Forms.TabControl tabDBSetting;
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage MsSql;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox mssqldbname;
        private System.Windows.Forms.TextBox servername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;



    }
}

