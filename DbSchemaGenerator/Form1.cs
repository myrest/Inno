using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using DbSchemaGenerator.Base;
using DbSchemaGenerator.Database;
using DbSchemaGenerator.CodeTemplates;

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
        private AbsTableSchema schema;
        private string DBName = string.Empty;

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
                        mssqldbname.Text = settings[4];
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
            mergeCon[4] = mssqldbname.Text;
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
            switch (tabDBSetting.SelectedIndex)
            {
                case 0:
                    //check sqlite
                    rtn = CheckAndSetSqlite();
                    DBName = Path.GetFileNameWithoutExtension(FileName.ToString().Trim());
                    break;
                case 1:
                    rtn = CheckAndSetMsSql();
                    DBName = mssqldbname.Text;
                    break;
                default:
                    throw new Exception("Data check is not implemented.");
            }

            if (string.IsNullOrEmpty(DBName))
            {
                rtn = false;
                MessageBox.Show("DBfilename is empty.");
            }

            if (rtn)
            {
                //Check Folder is exist.
                string curNamespace = NameSpace.Text.Trim();
                string targetPath = TargetFolder.Text.Trim();
                DomainPath = GetFullPathByType(GenType.Domain, DBName);
                BLLPath = GetFullPathByType(GenType.BLL, DBName);
                DALPath = GetFullPathByType(GenType.DAL, DBName);
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

        /// <summary>
        /// Not handeled
        /// </summary>
        /// <returns></returns>
        private bool CheckAndSetMsSql()
        {
            bool rtn = false;
            if (string.IsNullOrEmpty(servername.Text.Trim()))
            {
                MessageBox.Show("Server name is empty.");
                servername.Focus();
            }
            else if (string.IsNullOrEmpty(mssqldbname.Text.Trim()))
            {
                MessageBox.Show("Database name is empty.");
                mssqldbname.Focus();
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

        #region MSSLQ releated
//        private List<ColumnInformation> GetColumnInformationByTable(string TableName, out string pk, SqlConnection conn)
//        {
//            List<ColumnInformation> rtn = new List<ColumnInformation>() { };
//            try
//            {
//                SqlDataReader myReader = null;
//                SqlCommand myCommand = new SqlCommand(string.Format(@"
//                    select ctype.Data_type [DataType], st.name [Table], sc.name [Column], sep.value [Description] from sys.tables st
//                    inner join sys.columns sc on st.object_id = sc.object_id left join sys.extended_properties sep on st.object_id = sep.major_id
//                    and sc.column_id = sep.minor_id and sep.name = 'MS_Description'
//                    inner join INFORMATION_SCHEMA.COLUMNS ctype on sc.name = ctype.Column_Name and ctype.TABLE_NAME = st.name
//                    where st.name = '{0}'", TableName), conn);
//                myReader = myCommand.ExecuteReader();
//                while (myReader.Read())
//                {
//                    rtn.Add(new ColumnInformation()
//                    {
//                        DataType = myReader["DataType"].ToString(),
//                        Description = myReader["Description"].ToString(),
//                        Name = myReader["Column"].ToString()
//                    });
//                }
//                myReader.Close();
//                myCommand.CommandText = string.Format("SELECT Column_Name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 AND table_name = '{0}'", TableName);
//                myReader = myCommand.ExecuteReader();
//                if (myReader.Read())
//                {
//                    pk = myReader["Column_Name"].ToString();
//                }
//                else
//                {
//                    pk = string.Empty;
//                }
//            }
//            catch (Exception e)
//            {
//                pk = string.Empty;
//                throw e;
//            }
//            return rtn;
//        }

        //private List<string> GetMssqlTableListing()
        //{
        //    List<string> rtn = new List<string>() { };
        //    var conn = GetDbConnector.GetMssqlConnection(servername.Text, mssqldbname.Text, username.Text, password.Text);
        //    conn.Open();
        //    try
        //    {
        //        SqlDataReader myReader = null;
        //        SqlCommand myCommand = new SqlCommand("SELECT table_name FROM information_schema.tables group by table_name", conn);
        //        myReader = myCommand.ExecuteReader();
        //        while (myReader.Read())
        //        {
        //            rtn.Add(myReader["table_name"].ToString());
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //    return rtn;
        //}

        //private Dictionary<string, string> GetMssqlColumnInformationByTable(string TableName, out string pk, SqlConnection conn)
        //{
        //    Dictionary<string, string> element = new Dictionary<string, string>() { };
        //    try
        //    {
        //        SqlDataReader myReader = null;
        //        SqlCommand myCommand = new SqlCommand(string.Format("SELECT Column_Name, Data_type FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'{0}'", TableName), conn);
        //        myReader = myCommand.ExecuteReader();
        //        while (myReader.Read())
        //        {
        //            element.Add(myReader["Column_Name"].ToString(), myReader["Data_type"].ToString());
        //        }
        //        myReader.Close();
        //        myCommand.CommandText = string.Format("SELECT Column_Name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 AND table_name = '{0}'", TableName);
        //        myReader = myCommand.ExecuteReader();
        //        if (myReader.Read())
        //        {
        //            pk = myReader["Column_Name"].ToString();
        //        }
        //        else
        //        {
        //            pk = string.Empty;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        pk = string.Empty;
        //        throw e;
        //    }
        //    return element;
        //}

        #endregion

        private void FileGenerator()
        {
            //Get all tablename
            List<string> AllTable = new List<string>() { };
            switch (tabDBSetting.SelectedIndex)
            {
                case 0:
                    //sqlite
                    schema = new SqliteDB(FileName.Text);
                    AllTable = schema.GetTableList();
                    FileGenerator(schema, AllTable);
                    break;
                case 1:
                    //mssql
                    //AllTable = GetMssqlTableListing();
                    //FileGenerator(AllTable);
                    MessageBox.Show("MSSQL not finished.");
                    break;
            }

        }

        private string GetFullPathByType(GenType Gtype, string DBName)
        {
            string TypeName = string.Empty;
            switch (Gtype)
            {
                case GenType.Domain:
                    TypeName = "Domain";
                    break;
                case GenType.DAL:
                    TypeName = "DAL";
                    break;
                case GenType.BLL:
                    TypeName = "BLL";
                    break;
                default:
                    throw new Exception("GenType not defined");
            }
            string curNamespace = NameSpace.Text.Trim();
            string targetPath = TargetFolder.Text.Trim();
            return string.Format(@"{0}\{1}.{2}\{3}", targetPath, curNamespace, Gtype.ToString(), DBName);
        }

        private void FileGenerator(AbsTableSchema schema, List<string> Tables)
        {
            if (Tables != null && Tables.Count > 0)
            {
                DomainPath = GetFullPathByType(GenType.Domain, DBName);
                BLLPath = GetFullPathByType(GenType.BLL, DBName);
                DALPath = GetFullPathByType(GenType.DAL, DBName);

                Tables.ForEach(x =>
                {
                    //Create Domain code
                    DomainCodeHelper domain = new DomainCodeHelper(NameSpace.Text.Trim(), schema, x);
                    DALCodeHelper dal = new DALCodeHelper(NameSpace.Text.Trim(), schema, x);
                    BLLCodeHelper bll = new BLLCodeHelper(NameSpace.Text.Trim(), schema, x);

                    string DomainFile = GetFullPathByType(GenType.Domain, DBName);
                    string BLLFile = GetFullPathByType(GenType.BLL, DBName);
                    string DALFile = GetFullPathByType(GenType.DAL, DBName);

                    File.WriteAllText(string.Format(@"{0}\{1}.cs", DomainFile, x), domain.TransformText());
                    File.WriteAllText(string.Format(@"{0}\{1}.cs", BLLFile, x), bll.TransformText());
                    File.WriteAllText(string.Format(@"{0}\{1}.cs", DALFile, x), dal.TransformText());
                });
            }
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
            MessageBox.Show("Not yet implement.");
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
                    if (string.IsNullOrEmpty(mssqldbname.Text) || string.IsNullOrEmpty(servername.Text) || string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
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


        private void ReloadSchemaSqlite()
        {
            schema = new SqliteDB(FileName.Text);
            List<string> obj = schema.GetTableList();
            var ds = obj.ToDictionary(x => x, y => y);
            DDLTableListing.DataSource = obj;
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

            switch (gt)
            {
                case GenType.Domain:
                    Content = new DomainCodeHelper(NameSpace.Text.Trim(), schema, TableName).TransformText();
                    Content = Content.Replace("\r", "").Replace("\n", Environment.NewLine);
                    break;
                case GenType.DAL:
                    Content = new DALCodeHelper(NameSpace.Text.Trim(), schema, TableName).TransformText();
                    break;
                case GenType.BLL:
                    Content = new BLLCodeHelper(NameSpace.Text.Trim(), schema, TableName).TransformText();
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
                FileGenerator(schema, Tables);
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
