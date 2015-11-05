    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbSchemaGenerator.Base
{
    public abstract class AbsTableSchema
    {
        public abstract TableSchemaObject GetTableSchema(string TableName);
        public abstract List<string> GetTableList();
    }

    public class TableSchemaObject
    {
        public string Tablename { get; set; }
        public string PrimaryKey { get; set; }
        public List<ColumnObject> ColumnInfo { get; set; }
        public TableSchemaObject()
        {
            Tablename = string.Empty;
            PrimaryKey = string.Empty;
            ColumnInfo = new List<ColumnObject>() { };
        }
    }

    public class ColumnObject
    {
        public string ColumnName { get; set; }
        public string ColumnType { get; set; }
        public string ColumnDescription { get; set; }
    }
}
