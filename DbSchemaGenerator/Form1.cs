using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;

namespace DbSchemaGenerator
{
    public enum GenType
    {
        Domain,
        DAL,
        BLL
    }
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

                        //MsSql Setting
                        servername.Text = settings[3];
                        dbname.Text = settings[4];
                        username.Text = settings[5];
                        password.Text = settings[6];
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
            string[] mergeCon = new string[7];
            mergeCon[0] = NameSpace.Text;
            mergeCon[1] = FileName.Text;
            mergeCon[2] = TargetFolder.Text;
            //MSsql Setting
            mergeCon[3] = servername.Text;
            mergeCon[4] = dbname.Text;
            mergeCon[5] = username.Text;
            mergeCon[6] = password.Text;

            string setting = string.Join(",", mergeCon);
            using (FileStream fs = File.Create(SettingFullFileName))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(setting);
                fs.Write(info, 0, info.Length);
            }
        }
        #endregion

        private static string RemovePrefix(string DBName, string PreFix = "db_")
        {
            if (DBName.ToLower().StartsWith(PreFix))
            {
                DBName = DBName.Substring(PreFix.Length);
            }
            return DBName;
        }

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
            if (CheckAndSetEnv())
            {
                FileGenerator();
                MessageBox.Show("Done");
            }
        }

        private bool CheckAndSetEnv()
        {
            bool rtn = false;
            string DBfilename = string.Empty;
            switch (tabDBSetting.SelectedIndex)
            {
                case 0:
                    //check sqlite
                    rtn = CheckAndSetSqlite();
                    DBfilename = Path.GetFileNameWithoutExtension(FileName.ToString().Trim());
                    break;
                case 1:
                    rtn = CheckAndSetMsSql();
                    DBfilename = dbname.Text;
                    break;
                default:
                    throw new Exception("Data check is not implemented.");
            }

            if (string.IsNullOrEmpty(DBfilename))
            {
                rtn = false;
                MessageBox.Show("DBfilename is empty.");
            }


            if (rtn)
            {
                //Check Folder is exist.
                string curNamespace = NameSpace.Text.Trim();
                string targetPath = TargetFolder.Text.Trim();
                DomainPath = string.Format(@"{0}\{1}.Domain\{2}", targetPath, curNamespace, DBfilename);
                BLLPath = string.Format(@"{0}\{1}.BLL\{2}", targetPath, curNamespace, DBfilename);
                DALPath = string.Format(@"{0}\{1}.DAL\{2}", targetPath, curNamespace, DBfilename);
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
                    rtn = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return rtn;
        }

        private bool CheckAndSetMsSql()
        {
            bool rtn = false;
            if (string.IsNullOrEmpty(servername.Text.Trim()))
            {
                MessageBox.Show("Server name is empty.");
                servername.Focus();
            }
            else if (string.IsNullOrEmpty(dbname.Text.Trim()))
            {
                MessageBox.Show("Database name is empty.");
                dbname.Focus();
            }
            else if (string.IsNullOrEmpty(username.Text.Trim()))
            {
                MessageBox.Show("User name is empty.");
                username.Focus();
            }
            else if (string.IsNullOrEmpty(password.Text.Trim()))
            {
                MessageBox.Show("Password is empty.");
                password.Focus();
            }
            else
            {
                rtn = true;
            }
            return rtn;
        }

        private bool CheckAndSetSqlite()
        {
            bool rtn = false;
            if (string.Compare(TargetFolder.Text, "NoData", true) == 0)
            {
                MessageBox.Show("Plese select your out target folder.");
                FolderSelector.Focus();
            }
            else if (string.IsNullOrEmpty(NameSpace.Text.Trim()))
            {
                MessageBox.Show("Namespace is not option.");
                NameSpace.Focus();
            }
            else if (string.Compare(FileName.Text, "NoData", true) == 0)
            {
                MessageBox.Show("Plese select your database file.");
                FileSelector.Focus();
            }
            else
            {
                rtn = true;
            }
            return rtn;
        }

        private void FileGenerator(List<string> Tables)
        {
            if (Tables != null && Tables.Count > 0)
            {
                Tables.ForEach(x =>
                {
                    string pk = string.Empty;
                    Dictionary<string, string> columns = new Dictionary<string, string>() { };
                    List<ColumnInformation> Column3s = new List<ColumnInformation>() { };
                    if (tabDBSetting.SelectedIndex == 1)
                    {
                        var conn = GetDbConnector.GetMssqlConnection(servername.Text, dbname.Text, username.Text, password.Text);
                        conn.Open();
                        Column3s = GetColumnInformationByTable(x, out pk, conn);
                        conn.Close();
                    }
                    else
                    {
                        columns = GetColumnInformationByTable(x, out pk);
                    }

                    FileCreator.CreateDomainFile(Column3s, pk, DomainPath, NameSpace.Text.Trim(), x);
                    FileCreator.CreateDALFile(columns, pk, DALPath, NameSpace.Text.Trim(), x);
                    FileCreator.CreateBLLFile(columns, pk, BLLPath, NameSpace.Text.Trim(), x);
                });
            }
        }

        private List<ColumnInformation> GetColumnInformationByTable(string TableName, out string pk,  SqlConnection conn)
        {
            List<ColumnInformation> rtn = new List<ColumnInformation>() { };
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(string.Format(@"
                    select ctype.Data_type [DataType], st.name [Table], sc.name [Column], sep.value [Description] from sys.tables st
                    inner join sys.columns sc on st.object_id = sc.object_id left join sys.extended_properties sep on st.object_id = sep.major_id
                    and sc.column_id = sep.minor_id and sep.name = 'MS_Description'
                    inner join INFORMATION_SCHEMA.COLUMNS ctype on sc.name = ctype.Column_Name and ctype.TABLE_NAME = st.name
                    where st.name = '{0}'", TableName), conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    rtn.Add(new ColumnInformation()
                    {
                        DataType = myReader["DataType"].ToString(),
                        Description = myReader["Description"].ToString(),
                        Name = myReader["Column"].ToString()
                    });
                }
                myReader.Close();
                myCommand.CommandText = string.Format("SELECT Column_Name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 AND table_name = '{0}'", TableName);
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    pk = myReader["Column_Name"].ToString();
                }
                else
                {
                    pk = string.Empty;
                }
            }
            catch (Exception e)
            {
                pk = string.Empty;
                throw e;
            }
            return rtn;
        }

        private void FileGenerator()
        {
            //Get all tablename
            List<string> AllTable = new List<string>() { };
            switch (tabDBSetting.SelectedIndex)
            {
                case 0:
                    //sqlite
                    AllTable = GetSqliteTableListing();
                    break;
                case 1:
                    //mssql
                    AllTable = GetMssqlTableListing();
                    break;
            }

            FileGenerator(AllTable);
        }

        private List<string> GetMssqlTableListing()
        {
            List<string> rtn = new List<string>() { };
            var conn = GetDbConnector.GetMssqlConnection(servername.Text, dbname.Text, username.Text, password.Text);
            conn.Open();
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT table_name FROM information_schema.tables group by table_name", conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    rtn.Add(myReader["table_name"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return rtn;
        }

        //colum nname , column type
        private Dictionary<string, string> GetColumnInformationByTable(string TableName, out string pk)
        {
            Dictionary<string, string> rtn = new Dictionary<string, string>() { };
            pk = "";
            switch (tabDBSetting.SelectedIndex)
            {
                case 0:
                    rtn = GetSqliteColumnInformationByTable(TableName, out pk);
                    break;
                case 1:
                    var conn = GetDbConnector.GetMssqlConnection(servername.Text, dbname.Text, username.Text, password.Text);
                    conn.Open();
                    rtn = GetMssqlColumnInformationByTable(TableName, out pk, conn);
                    conn.Close();
                    break;
            }

            return rtn;
        }

        private Dictionary<string, string> GetMssqlColumnInformationByTable(string TableName, out string pk, SqlConnection conn)
        {
            Dictionary<string, string> element = new Dictionary<string, string>() { };
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(string.Format("SELECT Column_Name, Data_type FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'{0}'", TableName), conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    element.Add(myReader["Column_Name"].ToString(), myReader["Data_type"].ToString());
                }
                myReader.Close();
                myCommand.CommandText = string.Format("SELECT Column_Name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 AND table_name = '{0}'", TableName);
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    pk = myReader["Column_Name"].ToString();
                }
                else
                {
                    pk = string.Empty;
                }
            }
            catch (Exception e)
            {
                pk = string.Empty;
                throw e;
            }
            return element;
        }

        private Dictionary<string, string> GetSqliteColumnInformationByTable(string TableName, out string pk)
        {
            pk = string.Empty;
            Dictionary<string, string> element = new Dictionary<string, string>() { };

            SQLiteConnection conn = new SQLiteConnection(string.Format("Data Source={0};Version=3;", FileName.Text));

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

        private List<string> GetSqliteTableListing()
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
            SaveSetting();
            ReloadSchemaSqlite();
        }

        private void ReloadSchemaSqlite()
        {
            List<string> obj = new List<string>() { };
            switch (tabDBSetting.SelectedIndex)
            {
                case 0:
                    obj = GetSqliteTableListing();
                    break;
                case 1:
                    obj = GetMssqlTableListing();
                    break;
                default:
                    throw new Exception("Not setting yet.");
            }
            var ds = obj.ToDictionary(x => x, y => y);
            DDLTableListing.DataSource = obj;
        }

        private void tabMainFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMainFunction.SelectedIndex == 1)
            {
                if (tabDBSetting.SelectedIndex == 0 && FileName.Text == "NoData")
                {
                    tabMainFunction.SelectedIndex = 0;
                    MessageBox.Show("Sqlite資料來源還沒設定完成。");
                }
                if (tabDBSetting.SelectedIndex == 1)
                {
                    if (string.IsNullOrEmpty(dbname.Text) || string.IsNullOrEmpty(servername.Text) || string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
                    {
                        tabMainFunction.SelectedIndex = 0;
                        MessageBox.Show("MsSql資料來源還沒設定完成。");
                    }
                }
            }
            if (tabMainFunction.SelectedTab.Name == tabBuildIdv.Name)
            {
                ReloadSchemaSqlite();
            }
        }

        private void DDLTableListing_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtons();
            GenDomain.FlatStyle = FlatStyle.Flat;
            GetContent(GenType.Domain);
        }

        private void GetContent(GenType gt)
        {
            string pk = string.Empty;
            string Content = string.Empty;
            string TableName = DDLTableListing.SelectedValue.ToString();
            TableName = RemovePrefix(TableName);
            Dictionary<string, string> columns = new Dictionary<string, string>() { };
            List<ColumnInformation> Column3s = new List<ColumnInformation>() { };
            if (tabDBSetting.SelectedIndex == 1)
            {
                var conn = GetDbConnector.GetMssqlConnection(servername.Text, dbname.Text, username.Text, password.Text);
                conn.Open();
                Column3s = GetColumnInformationByTable(TableName, out pk, conn);
                conn.Close();
            }
            else
            {
                columns = GetColumnInformationByTable(TableName, out pk);
            }


            switch (gt)
            {
                case GenType.Domain:
                    Content = FileCreator.GetDomainContent(Column3s, pk, DomainPath, NameSpace.Text.Trim(), TableName);
                    break;
                case GenType.DAL:
                    Content = FileCreator.CreateDALContent(columns, pk, DomainPath, NameSpace.Text.Trim(), TableName);
                    break;
                case GenType.BLL:
                    Content = FileCreator.CreateBLLContent(columns, pk, DomainPath, NameSpace.Text.Trim(), TableName);
                    break;
                default:
                    throw new Exception(string.Format("GenType:{0} not found.", gt.ToString()));
            }
            ContentBody.Text = Content;
        }

        private void ResetButtons()
        {
            GenDomain.FlatStyle = FlatStyle.Standard;
            GenBLL.FlatStyle = FlatStyle.Standard;
            GenDAL.FlatStyle = FlatStyle.Standard;
        }

        private void GenBLL_Click(object sender, EventArgs e)
        {
            ResetButtons();
            GenBLL.FlatStyle = FlatStyle.Flat;
            GetContent(GenType.BLL);
        }

        private void GenDAL_Click(object sender, EventArgs e)
        {
            ResetButtons();
            GenDAL.FlatStyle = FlatStyle.Flat;
            GetContent(GenType.DAL);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ContentBody.Text);
            MessageBox.Show("Copy to Clipboard done.");
        }

        private void GenDomain_Click(object sender, EventArgs e)
        {
            ResetButtons();
            GenDomain.FlatStyle = FlatStyle.Flat;
            GetContent(GenType.Domain);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveSetting();
            if (CheckAndSetEnv())
            {
                List<string> Tables = new List<string>() { DDLTableListing.SelectedItem.ToString() };
                FileGenerator(Tables);
                MessageBox.Show(string.Format("{0} build done.", DDLTableListing.SelectedItem.ToString()));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
#if !DEBUG
            new Login(this).ShowDialog();
#endif
        }
    }
}
