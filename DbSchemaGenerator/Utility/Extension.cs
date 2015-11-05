using DbSchemaGenerator.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbSchemaGenerator.Utility
{
    public static class Extension
    {
        public static string ToCSharpType(this ColumnObject column)
        {
            string rtn = string.Empty;
            switch (column.ColumnType.ToUpper())
            {
                case "TEXT":
                case "NVARCHAR":
                case "VARCHAR":
                case "CHAR":
                case "NCHAR":
                case "NTEXT":
                case "GUID":
                    rtn = "string";
                    break;
                case "NUM":
                case "INTEGER":
                case "INT":
                case "NUMERIC":
                case "BIT":
                case "BIGINT":
                case "TINYINT":
                    rtn = column.ColumnType.ToUpper().StartsWith("IS") ? "bool" : "int";
                    break;
                case "DATE":
                case "TIME":
                case "TIMESTAMP":
                case "DATETIME":
                case "SMALLDATETIME":
                    rtn = "DateTime";
                    break;
                case "REAL":
                case "MONEY":
                    rtn = "decimal";
                    break;
                default:
                    throw new Exception(string.Format("Date type [(0)] not found.", column.ColumnType.ToUpper()));
            }
                    
            return rtn;
        }
    }
}
