using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DbSchemaGenerator
{

    public partial class Form1 : Form
    {
        private string SettingFilename = "Config.cfg";
        private string SettingFullFileName = string.Empty;
        private string DomainPath = string.Empty;
        private string BLLPath = string.Empty;
        private string DALPath = string.Empty;

        private List<string> ExcludeTableName = new List<string>() { "sqlite_sequence" };

        public Form1()
        {
            InitializeComponent();
            ReadSetting();
        }

        #region Config related.
        private void ReadSetting()
        {
            //Current execute path
            string ConfigFullFileName = string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), SettingFilename);
            SettingFullFileName = ConfigFullFileName;

            //Get file content
            try
            {
                string text = System.IO.File.ReadAllText(ConfigFullFileName);
                if (text != null && text.Trim().Length > 0)
                {
                    var settings = text.Split(new char[] { ',' });
                    if (settings.Length > 0)
                    {
                        NameSpace.Text = settings[0];
                        FileName.Text = settings[1];
                        TargetFolder.Text = settings[2];
                    }
                }
            }
            catch
            {
                using (FileStream fs = File.Create(ConfigFullFileName))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("");
                    fs.Write(info, 0, info.Length);
                }
            }
        }

        private void SaveSetting()
        {
            string[] mergeCon = new string[3];
            mergeCon[0] = NameSpace.Text;
            mergeCon[1] = FileName.Text;
            mergeCon[2] = TargetFolder.Text;
            string setting = string.Join(",", mergeCon);
            using (FileStream fs = File.Create(SettingFullFileName))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(setting);
                fs.Write(info, 0, info.Length);
            }
        }
        #endregion

        private void FileSelector_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    FileName.Text = file;
                }
                catch (IOException)
                {
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveSetting();
            CheckAndSetEnv();
            FileGenerator();
            MessageBox.Show("Done");
        }

        private void CheckAndSetEnv()
        {
            //Check Folder is exist.
            string curNamespace = NameSpace.Text.Trim();
            string targetPath = TargetFolder.Text.Trim();
            DomainPath = string.Format(@"{0}\{1}.Domain", targetPath, curNamespace);
            BLLPath = string.Format(@"{0}\{1}.BLL", targetPath, curNamespace);
            DALPath = string.Format(@"{0}\{1}.DAL", targetPath, curNamespace);
            try
            {
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }
                if (!Directory.Exists(DomainPath))
                {
                    Directory.CreateDirectory(DomainPath);
                }
                if (!Directory.Exists(BLLPath))
                {
                    Directory.CreateDirectory(BLLPath);
                }
                if (!Directory.Exists(DALPath))
                {
                    Directory.CreateDirectory(DALPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FileGenerator()
        {
            //Get all tablename
            var AllTable = GetTableListing();
            if (AllTable != null && AllTable.Count > 0)
            {
                AllTable.ForEach(x =>
                {
                    string pk = string.Empty;
                    var columns = GetColumnInformationByTable(x, out pk);
                    FileCreator.CreateDomainFile(columns, pk, DomainPath, NameSpace.Text.Trim(), x);
                    FileCreator.CreateDALFile(columns, pk, DALPath, NameSpace.Text.Trim(), x);
                    FileCreator.CreateBLLFile(columns, pk, BLLPath, NameSpace.Text.Trim(), x);
                });
            }
        }

        private Dictionary<string, string> GetColumnInformationByTable(string TableName, out string pk)
        {
            pk = string.Empty;
            Dictionary<string, string> element = new Dictionary<string, string>() { };

            SQLiteConnection conn = new SQLiteConnection(string.Format("Data Source={0};Version=3;", FileName.Text));

            //SQLiteCommand comm = new SQLiteCommand("PRAGMA table_info(Settings);", conn);

            using (var comm = new SQLiteCommand("PRAGMA table_info(" + TableName + ");", conn))
            {
                conn.Open();
                using (var reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // Step through each row
                        while (reader.Read())
                        {
                            if (reader["pk"].ToString() == "1")
                            {
                                pk = reader["name"].ToString();
                            }
                            element.Add(reader["name"].ToString(), reader["type"].ToString());
                        }
                    }
                }
            }
            return element.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        private List<string> GetTableListing()
        {
            List<string> tables = new List<string>() { };
            SQLiteConnection conn = new SQLiteConnection(string.Format("Data Source={0};Version=3;", FileName.Text));
            string sql = "SELECT * FROM sqlite_master  WHERE type = 'table' ORDER BY 1";

            //SQLiteCommand comm = new SQLiteCommand(sql, conn);

            using (var comm = new SQLiteCommand(sql, conn))
            {
                conn.Open();

                SQLiteDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string type = reader["type"].ToString();
                        if (string.Compare(type, "table", true) == 0)
                        {
                            string tablename = reader["tbl_name"].ToString();
                            if (!ExcludeTableName.Contains(tablename))
                            {
                                tables.Add(reader["tbl_name"].ToString());
                            }
                        }
                    }
                }
            }

            return tables.OrderBy(x => x).ToList();
        }

        private void FolderSelector_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                try
                {
                    TargetFolder.Text = folderName;
                }
                catch (IOException)
                {
                }
            }
        }

        private void ReloadSchema_Click(object sender, EventArgs e)
        {
            //DDLTableListing.DataSource
            var obj = GetTableListing();
            var ds = obj.ToDictionary(x => x, y => y);
            DDLTableListing.DataSource = obj;
        }
    }
}
