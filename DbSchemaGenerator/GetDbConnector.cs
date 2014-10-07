using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DbSchemaGenerator
{
    public class GetDbConnector
    {
        public static SqlConnection GetMssqlConnection(string serverName, string DbName, string UserName, string Password)
        {
            var myConnection = new SqlConnection(string.Format(
                "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}"
                , serverName, DbName, UserName, Password));
            return myConnection;
        }

    }
}
