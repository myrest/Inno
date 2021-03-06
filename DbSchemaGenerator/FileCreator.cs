﻿using System;
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
            string SqlDataType = item.Value.ToUpper();
            string SqlDataName = item.Key;
            string rtn = string.Empty;
            string AllowNull = (isFilter) ? "?" : "";
            switch (SqlDataType)
            {
                case "TEXT":
                case "NVARCHAR":
                case "VARCHAR":
                case "CHAR":
                case "NCHAR":
                case "NTEXT":
                case "GUID":
                    SqlDataType = "string";
                    break;
                case "NUM":
                case "INTEGER":
                case "INT":
                case "NUMERIC":
                case "BIT":
                case "BIGINT":
                case "TINYINT":
                    SqlDataType = SqlDataName.StartsWith("is") ? "bool" : "int";
                    SqlDataType += AllowNull;
                    break;
                case "DATE":
                case "TIME":
                case "TIMESTAMP":
                case "DATETIME":
                case "SMALLDATETIME":
                    SqlDataType = "DateTime";
                    SqlDataType += AllowNull;
                    break;
                case "REAL":
                case "MONEY":
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

        private static string MapTypeSqlite(ColumnInformation item, bool isFilter = false)
        {
            return MapTypeSqlite(new KeyValuePair<string, string>(item.Name, item.DataType), isFilter);
        }

        private static string RemovePrefix(string DBName, string PreFix = "db_")
        {
            if (DBName.ToLower().StartsWith(PreFix))
            {
                DBName = DBName.Substring(PreFix.Length);
            }
            return DBName;
        }

        #region Domain
        internal static string GetDomainContent(List<ColumnInformation> columns, string pk, string DomainPath, string NameSpace, string TableName)
        {
            string RealTableName = TableName;
            TableName = RemovePrefix(TableName);
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
    [Rest.Core.PetaPoco.PrimaryKey(""{2}"")]
    public class {1}_Info //: I{1}_Info
    {{
        #region private fields", RealTableName, TableName, pk);
            foreach (var item in columns)
            {
                //Column description
                if (!string.IsNullOrEmpty(item.Description))
                {
                    sb.AppendFormat(@"
        /// <summary>
        /// {0}
        /// </summary>", item.Description);
                }
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

        internal static void CreateDomainFile(List<ColumnInformation> columns, string pk, string DomainPath, string NameSpace, string TableName)
        {
            string Content = GetDomainContent(columns, pk, DomainPath, NameSpace, TableName);
            TableName = RemovePrefix(TableName);
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
            using (var db = new DBExecutor().GetDatabase())
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
            using (var db = new DBExecutor().GetDatabase())
            {{
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append(""SELECT * FROM {2}"");
                var result = db.Query<{2}_Info>(SQLStr);

                return result;
            }}
        }}

        public IEnumerable<{2}_Info> GetByParam({2}_Filter Filter, string _orderby = """")
        {{
            using (var db = new DBExecutor().GetDatabase())
            {{
                var SQLStr = ConstructSQL(Filter, new string[] {{ ""*"" }}, _orderby);

                var result = db.Query<{2}_Info>(SQLStr);

                return result;
            }}
        }}

        public IEnumerable<{2}_Info> GetByParam({2}_Filter Filter, string[] fieldNames, string _orderby = """")
        {{
            using (var db = new DBExecutor().GetDatabase())
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
            using (var db = new DBExecutor().GetDatabase())
            {{
                long NewID = 0;
                var result = db.Insert(data);
                if (result != null)
                {{
                    long.TryParse(result.ToString(), out NewID);
                }}
                return NewID;
            }}
        }}
        #endregion

        #region Operation: Update
        public int Update(long {3}, {2}_Info data, IEnumerable<string> columns)
        {{
            using (var db = new DBExecutor().GetDatabase())
            {{
                return db.Update(data, {3}, columns);
            }}
        }}

        public int Update({2}_Info data)
        {{
            using (var db = new DBExecutor().GetDatabase())
            {{
                return db.Update(data);
            }}
        }}
        #endregion

        #region Operation: Delete
        public int Delete(long {3})
        {{
            using (var db = new DBExecutor().GetDatabase())
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
            {{", NameSpace, curNamespace, TableName, pk);
            foreach (var item in columns)
            {
                string columnType = MapTypeSqlite(item, true);
                bool isNullAble = columnType.IndexOf("?") > 0;
                if (isNullAble)
                {
                    sb.AppendFormat(@"
                if (filter.{0}.HasValue)
                {{
                    SQLStr.Append("" AND {0}=@0"", filter.{0}.Value);
                }}", item.Key);
                }
                else
                {
                    sb.AppendFormat(@"
                if (!string.IsNullOrEmpty(filter.{0}))
                {{
                    SQLStr.Append("" AND {0}=@0"", filter.{0});
                }}", item.Key);
                }
            }
                    //Should updat the filter for wide search
            sb.AppendFormat(@"
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

}}");
            #endregion
            return sb.ToString();
        }

        internal static void CreateDALFile(Dictionary<string, string> columns, string pk, string DALPath, string NameSpace, string TableName)
        {
            TableName = RemovePrefix(TableName);
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
            string curNamespace = string.Format("{0}.BLL", NameSpace);
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
            TableName = RemovePrefix(TableName);
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

    public class ColumnInformation
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string Description { get; set; }
    }
}
