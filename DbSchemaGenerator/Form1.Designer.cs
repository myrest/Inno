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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabMainFunction = new System.Windows.Forms.TabControl();
            this.DDLTableListing = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GenDomain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GenBLL = new System.Windows.Forms.Button();
            this.GenDAL = new System.Windows.Forms.Button();
            this.ReloadSchema = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabMainFunction.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.labFn.Location = new System.Drawing.Point(10, 11);
            this.labFn.Name = "labFn";
            this.labFn.Size = new System.Drawing.Size(58, 12);
            this.labFn.TabIndex = 0;
            this.labFn.Text = "File Name :";
            // 
            // FileName
            // 
            this.FileName.AutoSize = true;
            this.FileName.Location = new System.Drawing.Point(74, 11);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(33, 12);
            this.FileName.TabIndex = 0;
            this.FileName.Text = "label1";
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
            this.TargetFolder.Size = new System.Drawing.Size(33, 12);
            this.TargetFolder.TabIndex = 4;
            this.TargetFolder.Text = "label1";
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 60);
            this.tabControl1.TabIndex = 7;
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
            this.tabPage1.Size = new System.Drawing.Size(793, 337);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Build ALL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.FileSelector);
            this.tabPage2.Controls.Add(this.FileName);
            this.tabPage2.Controls.Add(this.labFn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(793, 34);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.DDLTableListing);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(793, 337);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabMainFunction
            // 
            this.tabMainFunction.Controls.Add(this.tabPage1);
            this.tabMainFunction.Controls.Add(this.tabPage3);
            this.tabMainFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMainFunction.Location = new System.Drawing.Point(0, 60);
            this.tabMainFunction.Name = "tabMainFunction";
            this.tabMainFunction.SelectedIndex = 0;
            this.tabMainFunction.Size = new System.Drawing.Size(801, 363);
            this.tabMainFunction.TabIndex = 8;
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
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(138, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(652, 296);
            this.textBox1.TabIndex = 1;
            this.textBox1.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.GenDAL);
            this.panel1.Controls.Add(this.GenBLL);
            this.panel1.Controls.Add(this.ReloadSchema);
            this.panel1.Controls.Add(this.GenDomain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(138, 299);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 35);
            this.panel1.TabIndex = 2;
            // 
            // GenDomain
            // 
            this.GenDomain.Location = new System.Drawing.Point(407, 7);
            this.GenDomain.Name = "GenDomain";
            this.GenDomain.Size = new System.Drawing.Size(75, 23);
            this.GenDomain.TabIndex = 0;
            this.GenDomain.Text = "Domain";
            this.GenDomain.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generator code to Clipboard";
            // 
            // GenBLL
            // 
            this.GenBLL.Location = new System.Drawing.Point(488, 7);
            this.GenBLL.Name = "GenBLL";
            this.GenBLL.Size = new System.Drawing.Size(75, 23);
            this.GenBLL.TabIndex = 0;
            this.GenBLL.Text = "BLL";
            this.GenBLL.UseVisualStyleBackColor = true;
            // 
            // GenDAL
            // 
            this.GenDAL.Location = new System.Drawing.Point(569, 7);
            this.GenDAL.Name = "GenDAL";
            this.GenDAL.Size = new System.Drawing.Size(75, 23);
            this.GenDAL.TabIndex = 0;
            this.GenDAL.Text = "DAL";
            this.GenDAL.UseVisualStyleBackColor = true;
            // 
            // ReloadSchema
            // 
            this.ReloadSchema.Location = new System.Drawing.Point(3, 7);
            this.ReloadSchema.Name = "ReloadSchema";
            this.ReloadSchema.Size = new System.Drawing.Size(95, 23);
            this.ReloadSchema.TabIndex = 0;
            this.ReloadSchema.Text = "Reload Schema";
            this.ReloadSchema.UseVisualStyleBackColor = true;
            this.ReloadSchema.Click += new System.EventHandler(this.ReloadSchema_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 423);
            this.Controls.Add(this.tabMainFunction);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabMainFunction.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabMainFunction;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GenDAL;
        private System.Windows.Forms.Button GenBLL;
        private System.Windows.Forms.Button GenDomain;
        private System.Windows.Forms.ComboBox DDLTableListing;
        private System.Windows.Forms.Button ReloadSchema;



    }
}

