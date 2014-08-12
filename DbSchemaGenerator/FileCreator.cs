using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DbSchemaGenerator
{
    public class FileCreator
    {
        private static string MapTypeSqlite(KeyValuePair<string, string> item, bool isFilter = false)
        {
            string SqlDataType = item.Value;
            string SqlDataName = item.Key;
            string rtn = string.Empty;
            string AllowNull = (isFilter) ? "?" : "";
            switch (SqlDataType)
            {
                case "TEXT":
                    SqlDataType = "string";
                    break;
                case "NUM":
                case "INTEGER":
                case "INT":
                case "NUMERIC":
                    SqlDataType = SqlDataName.StartsWith("is") ? "bool" : "int";
                    SqlDataType += AllowNull;
                    break;
                case "DATE":
                case "TIME":
                case "TIMESTAMP":
                    SqlDataType = "DateTime";
                    SqlDataType += AllowNull;
                    break;
                case "REAL":
                    SqlDataType = "decimal";
                    SqlDataType += AllowNull;
                    break;
                case "BLOB":
                    SqlDataType = "object";
                    SqlDataType += AllowNull;
                    break;
                default:
                    MessageBox.Show("Can't mapping the type of [" + SqlDataType + "]");
                    return SqlDataType;
            }
            rtn = string.Format("{0} {1} {{ get; set; }}", SqlDataType, SqlDataName);
            return rtn;
        }

        #region Domain
        internal static string GetDomainContent(Dictionary<string, string> columns, string pk, string DomainPath, string NameSpace, string TableName)
        {
            string curNamespace = string.Format("{0}.Domain", NameSpace);
            StringBuilder sb = new StringBuilder();
            #region Create Domain StringBuilder
            sb.AppendFormat(@"using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace {0}
{{
    /*
    #region interface
    public interface I{1}_Info
    {{", curNamespace, TableName);
            foreach (var item in columns)
            {
                sb.AppendFormat(@"
        {0}", MapTypeSqlite(item));
            }
            sb.AppendFormat(@"
    }}
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName(""{0}"")]
    [Rest.Core.PetaPoco.PrimaryKey(""{1}"")]
    public class {0}_Info //: I{0}_Info
    {{
        #region private fields", TableName, pk);
            foreach (var item in columns)
            {
                sb.AppendFormat(@"
        public {0}", MapTypeSqlite(item));
            }
            sb.AppendFormat(@"
        #endregion

        #region Constructor
        public {0}_Info()
        {{
        }}
        #endregion
    }}

    public class {0}_Filter
    {{", TableName);
            foreach (var item in columns)
            {
                sb.AppendFormat(@"
        public {0}", MapTypeSqlite(item, true));
            }
            sb.AppendFormat(@"
        //You can copy/modify above {0}_Info field for search criteria
    }}
    #endregion
}}", TableName);
            #endregion
            return sb.ToString();
        }

        internal static void CreateDomainFile(Dictionary<string, string> columns, string pk, string DomainPath, string NameSpace, string TableName)
        {
            string Content = GetDomainContent(columns, pk, DomainPath, NameSpace, TableName);

            if (!DomainPath.EndsWith("\\"))
            {
                DomainPath += "\\";
            }

            string DomainFileOutPutPath = DomainPath + TableName + ".cs";

            using (FileStream fs = File.Create(DomainFileOutPutPath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(Content);
                fs.Write(info, 0, info.Length);
            }

        }
        #endregion

        #region DAL
        internal static string CreateDALContent(Dictionary<string, string> columns, string pk, string DALPath, string NameSpace, string TableName)
        {
            pk = (string.IsNullOrEmpty(pk)) ? "NoPk" : pk;
            string curNamespace = string.Format("{0}.DAL.{1}", NameSpace, TableName);
            StringBuilder sb = new StringBuilder();
            #region Create Domain StringBuilder
            sb.AppendFormat(@"using {0}.Domain;
using {0}.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace {1}
{{
    #region interface
    public interface I{2}_Repo
    {{
        {2}_Info GetBySN(long {3});
        IEnumerable<{2}_Info> GetAll();
        IEnumerable<{2}_Info> GetByParam({2}_Filter Filter, string _orderby = """");
        IEnumerable<{2}_Info> GetByParam({2}_Filter Filter, string[] fieldNames, string _orderby = """");
        long Insert({2}_Info data);
        int Update(long {3}, {2}_Info data, IEnumerable<string> columns);
        int Update({2}_Info data);
        int Delete(long {3});
    }}
    #endregion

    #region Implementation
    public class {2}_Repo
    {{
        #region Operation: Select
        public {2}_Info GetBySN(long {3})
        {{
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {{
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append(""SELECT * FROM {2}"")
                .Append(""WHERE {3}=@0"", {3});

                var result = db.SingleOrDefault<{2}_Info>(SQLStr);
                return result;
            }}
        }}

        public IEnumerable<{2}_Info> GetAll()
        {{
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {{
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append(""SELECT * FROM {2}"");
                var result = db.Query<{2}_Info>(SQLStr);

                return result;
            }}
        }}

        public IEnumerable<{2}_Info> GetByParam({2}_Filter Filter, string _orderby = """")
        {{
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {{
                var SQLStr = ConstructSQL(Filter, new string[] {{ ""*"" }}, _orderby);

                var result = db.Query<{2}_Info>(SQLStr);

                return result;
            }}
        }}

        public IEnumerable<{2}_Info> GetByParam({2}_Filter Filter, string[] fieldNames, string _orderby = """")
        {{
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {{
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<{2}_Info>(SQLStr);

                return result;
            }}
        }}
        #endregion

        #region Operation: Insert
        public long Insert({2}_Info data)
        {{
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {{
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }}
        }}
        #endregion

        #region Operation: Update
        public int Update(long {3}, {2}_Info data, IEnumerable<string> columns)
        {{
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {{
                return db.Update(data, {3}, columns);
            }}
        }}

        public int Update({2}_Info data)
        {{
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {{
                return db.Update(data);
            }}
        }}
        #endregion

        #region Operation: Delete
        public int Delete(long {3})
        {{
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {{
                return db.Delete(""{2}"", ""{3}"", null, {3});
            }}
        }}
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL({2}_Filter filter)
        {{
            return ConstructSQL(filter, new string[] {{ ""*"" }}, """");
        }}

        private Rest.Core.PetaPoco.Sql ConstructSQL({2}_Filter filter, string[] fieldNames, string _orderby)
        {{
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append(""SELECT "" + FieldNameArrayToFieldNameString(fieldNames) + "" FROM {2}"")
                .Append(""WHERE 1=1 "");
            if (filter != null)
            {{
                //if (filter.ID != 0)
                    //SQLStr.Append("" AND {3}=@0"", filter.ID);
                    //Should updat the filter for wide search

                if (_orderby != """")
                    SQLStr.Append(""ORDER BY @0"", _orderby);

            }}
            return SQLStr;
        }}

        private string FieldNameArrayToFieldNameString(string[] fieldNames)
        {{
            return string.Join("", "", fieldNames);
        }}
        #endregion
    }}
    #endregion

}}", NameSpace, curNamespace, TableName, pk);
            #endregion
            return sb.ToString();
        }

        internal static void CreateDALFile(Dictionary<string, string> columns, string pk, string DALPath, string NameSpace, string TableName)
        {
            string Content = CreateDALContent(columns, pk, DALPath, NameSpace, TableName);
            if (!DALPath.EndsWith("\\"))
            {
                DALPath += "\\";
            }

            string DomainFileOutPutPath = DALPath + TableName + ".cs";

            using (FileStream fs = File.Create(DomainFileOutPutPath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(Content);
                fs.Write(info, 0, info.Length);
            }
        }
        #endregion

        #region BLL
        internal static string CreateBLLContent(Dictionary<string, string> columns, string pk, string BLLPath, string NameSpace, string TableName)
        {
            pk = (string.IsNullOrEmpty(pk)) ? "NoPk" : pk;
            string curNamespace = string.Format("{0}.BLL.{1}", NameSpace, TableName);
            StringBuilder sb = new StringBuilder();
            #region Create Domain StringBuilder
            sb.AppendFormat(@"using System;
using System.Collections.Generic;
using System.Linq;
using {0}.DAL.{2};
using {0}.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace {1}
{{
    /*
    #region interface
    public interface I{2}_Manager
    {{
        {2}_Info GetBySN(long {3});
        IEnumerable<{2}_Info> GetAll();
        IEnumerable<{2}_Info> GetByParameter({2}_Filter Filter, string _orderby = """");
        long Insert({2}_Info data);
        bool Update(long {3}, {2}_Info data, IEnumerable<string> columns);
        bool Update({2}_Info data);
        int Delete(long {3});
        bool IsExist(long {3});
    }}
    #endregion
    */
    #region implementation
    public class {2}_Manager //: I{2}_Manager
    {{
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof({2}_Manager));
        #endregion

        #region Operation: Select
        public {2}_Info GetBySN(long {3})
        {{
            return new {2}_Repo().GetBySN({3});
        }}

        public IEnumerable<{2}_Info> GetAll()
        {{
            return new {2}_Repo().GetAll();
        }}

        public IEnumerable<{2}_Info> GetByParameter({2}_Filter Filter, string _orderby = """")
        {{
            return new {2}_Repo().GetByParam(Filter, _orderby);
        }}
        #endregion

        #region Operation: Raw Insert
        public long Insert({2}_Info data)
        {{
            long newID = 0;
            try
            {{
                newID = new {2}_Repo().Insert(data);
            }}
            catch (Exception ex)
            {{
                log.Exception(ex);
            }}
            return newID;
        }}
        #endregion

        #region Operation: Raw Update
        public bool Update(long {3}, {2}_Info data, IEnumerable<string> columns)
        {{
            return new {2}_Repo().Update({3}, data, columns) > 0;
        }}

        public bool Update({2}_Info data)
        {{
            return new {2}_Repo().Update(data) > 0;
        }}
        #endregion

        #region Operation: Delete
        public int Delete(long {3})
        {{
            return new {2}_Repo().Delete({3});
        }}
        #endregion

        #region public functions
        public bool IsExist(long {3})
        {{
            return (GetBySN({3}) != null);
        }}
        #endregion

        #region private functions
        #endregion
    }}
    #endregion
}}", NameSpace, curNamespace, TableName, pk);
            //NameSpace = InnoThink.Domain
            //curNameSpace = 
            #endregion
            return sb.ToString();
        }

        internal static void CreateBLLFile(Dictionary<string, string> columns, string pk, string BLLPath, string NameSpace, string TableName)
        {
            string Content = CreateBLLContent(columns, pk, BLLPath, NameSpace, TableName);
            if (!BLLPath.EndsWith("\\"))
            {
                BLLPath += "\\";
            }

            string DomainFileOutPutPath = BLLPath + TableName + ".cs";

            using (FileStream fs = File.Create(DomainFileOutPutPath))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(Content);
                fs.Write(info, 0, info.Length);
            }
        }
        #endregion
    }
}
