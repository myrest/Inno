using DbSchemaGenerator.Base;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DbSchemaGenerator.Database
{
    public class SqliteDB : AbsTableSchema
    {

        private string _Filename = string.Empty;
        private SQLiteConnection _Conn;
        private List<string> ExcludeTableName = new List<string>() { "sqlite_sequence" };
        private List<TableSchemaObject> _AllTableSchema = new List<TableSchemaObject>() { };
        private List<string> _TableList = new List<string>() { };


        private SQLiteConnection getConnection()
        {
            return new SQLiteConnection(string.Format("Data Source={0};Version=3;", _Filename));
        }

        public SqliteDB(string DBFileName)
        {
            _Filename = DBFileName;
        }

        public override List<string> GetTableList()
        {
            if (_TableList.Count() == 0)
            {
                List<string> tables = new List<string>() { };

                using (var conn = getConnection())
                {
                    string sql = "SELECT * FROM sqlite_master  WHERE type = 'table' ORDER BY 1";
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
                }
                _TableList = tables;
            }
            return _TableList.OrderBy(x => x).ToList();
        }

        public override TableSchemaObject GetTableSchema(string TableName)
        {
            if (_AllTableSchema.Count() == 0)
            {
                _AllTableSchema = GetAllTableSchema();
            }
            return _AllTableSchema.Where(x => x.Tablename == TableName).FirstOrDefault();
        }

        private List<TableSchemaObject> GetAllTableSchema()
        {
            List<TableSchemaObject> rtn = new List<TableSchemaObject>() { };
            List<string> TableList = GetTableList();
            TableList.ForEach(tablename =>
            {
                TableSchemaObject schema = new TableSchemaObject();

                using (var conn = getConnection())
                {
                    using (var comm = new SQLiteCommand("PRAGMA table_info(" + tablename + ");", conn))
                    {
                        schema.Tablename = tablename;
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
                                        schema.PrimaryKey = reader["name"].ToString();
                                    }
                                    schema.ColumnInfo.Add(new ColumnObject()
                                    {
                                         ColumnDescription = string.Empty,
                                         ColumnName = reader["name"].ToString(),
                                         ColumnType = reader["type"].ToString()
                                    });
                                }
                            }
                        }
                        if (schema.ColumnInfo.Count() > 0)
                        {
                            schema.ColumnInfo = schema.ColumnInfo.OrderBy(x => x.ColumnName).ToList();
                        }
                        rtn.Add(schema);
                    }
                }
            });
            return rtn;
        }
    }
}
