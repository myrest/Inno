using InnoThink.Core.Constancy;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Rest.Core.Constancy;

namespace InnoThink.Core.Utility
{
    public abstract class BaseDAO
    {
        private SQLiteConnection _conn;
        private static SysLog Log;

        protected BaseDAO()
        {
        }

        protected void init(string className, DataBaseName dbname)
        {
            Log = SysLog.GetLogger(className);
            string dbName = dbname.ToString();
            _conn = getDBConnection(dbName);
        }

        private static SQLiteConnection getDBConnection(string dbName)
        {
            string dbFolder = string.Empty;
            try
            {
                dbFolder = HttpContext.Current.Server.MapPath(string.Concat("\\App_Data"));
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
#if DEBUG
                dbFolder = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName + "\\App_Data";
#endif
            }

            string strDbFileName = String.Format("{0}\\{1}.oo2", dbFolder, dbName);

            if (File.Exists(strDbFileName))
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + strDbFileName);
                return conn;
            }
            else
            {
                throw new Exception(string.Format("Can't find the DB file {0} in {1}", dbName, strDbFileName));
            }
        }

        private static SQLiteCommand CreateCommand(SQLiteConnection conn, CommandType commandType, string commandText, IList<SQLiteParameter> paraList)
        {
            SQLiteCommand cmd = new SQLiteCommand(commandText, conn)
            {
                CommandType = commandType
            };
            if (paraList != null)
            {
                foreach (SQLiteParameter sPara in paraList)
                {
                    cmd.Parameters.Add(sPara);
                }
            }
            return cmd;
        }

        private static IList<SQLiteParameter> GetOutputParaList(SQLiteParameterCollection parameters)
        {
            List<SQLiteParameter> outputParaList = new List<SQLiteParameter>() { };
            foreach (SQLiteParameter para in parameters)
            {
                if (para.Direction == ParameterDirection.Output)
                {
                    outputParaList.Add(para);
                }
            }
            return outputParaList;
        }

        private static void WriteErrorLog(Exception ex)
        {
            Log.Exception(string.Format("Execute DB Error: {0}", ex.Message));
        }

        #region ExecuteNonQuery

        protected int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, null);
        }

        protected int ExecuteNonQuery(string commandText, IList<SQLiteParameter> paraList)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, paraList);
        }

        protected int ExecuteNonQuery(string commandText, ref IList<SQLiteParameter> outputParaList)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, null, ref outputParaList);
        }

        protected int ExecuteNonQuery(string commandText, IList<SQLiteParameter> paraList, ref IList<SQLiteParameter> outputParaList)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, paraList, ref outputParaList);
        }

        protected int ExecuteNonQuery(CommandType commandType, string commandText, IList<SQLiteParameter> paraList)
        {
            IList<SQLiteParameter> outputParaList = null;
            return ExecuteNonQuery(commandType, commandText, paraList, ref outputParaList);
        }

        protected int ExecuteNonQuery(CommandType commandType, string commandText, IList<SQLiteParameter> paraList, ref IList<SQLiteParameter> outputParaList)
        {
            int irtn = 0;
            try
            {
                SQLiteCommand cmd = CreateCommand(_conn, commandType, commandText, paraList);
                _conn.Open();
                irtn = cmd.ExecuteNonQuery();
                _conn.Close();
                if (!(outputParaList == null))
                {
                    outputParaList = GetOutputParaList(cmd.Parameters);
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                if (_conn != null && _conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                    _conn.Dispose();
                }
            }
            return irtn;
        }

        private SQLiteCommand transactionBegin(SQLiteConnection conn)
        {
            SQLiteCommand cmd = new SQLiteCommand("begin transaction", conn)
            {
                CommandType = CommandType.Text
            };
            conn.Open();
            cmd.ExecuteNonQuery();
            return cmd;
        }

        private void transactionRollback(SQLiteCommand cmd)
        {
            cmd.CommandText = "rollback";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private void transactionCommit(SQLiteCommand cmd)
        {
            cmd.CommandText = "commit";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        #endregion ExecuteNonQuery

        #region ExecuteReader

        protected List<T> ExecuteReader<T>(string commandText, Func<SQLiteDataReader, List<T>> cbFunction)
        {
            return ExecuteReader<T>(CommandType.Text, commandText, new List<SQLiteParameter>() { }, cbFunction);
        }

        protected List<T> ExecuteReader<T>(string commandText, IList<SQLiteParameter> paraList, Func<SQLiteDataReader, List<T>> cbFunction)
        {
            return ExecuteReader<T>(CommandType.Text, commandText, paraList, cbFunction);
        }

        protected List<T> ExecuteReader<T>(CommandType commandType, string commandText, IList<SQLiteParameter> paraList, Func<SQLiteDataReader, List<T>> cbFunction)
        {
            SQLiteDataReader dr;
            List<T> rtnT = new List<T>() { };
            try
            {
                SQLiteCommand cmd = CreateCommand(_conn, commandType, commandText, paraList);
                _conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                rtnT = cbFunction(dr);
                _conn.Close();
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                if (_conn != null && _conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                    _conn.Dispose();
                }
            }
            return rtnT;
        }

        #endregion ExecuteReader

        #region ExecuteReader for Count

        protected int ExecuteReaderCount<T>(string TableName, string ColumnName, T ColumnValue)
        {
            int rtn = -1;
            if (ColumnName != "")
            {
                string tType = typeof(T).ToString().ToLower();
                string vValue = default(string);
                switch (tType)
                {
                    case "DateTime":
                        vValue = Convert.ToDateTime(ColumnValue).ToString("yyyy-MM-dd HH:mm:ss");
                        break;

                    default:
                        vValue = ColumnValue.ToString();
                        break;
                }

                string commandText = string.Format("Select count(*) as rcnt from {0} where {1} = @value", TableName, ColumnName);
                List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@value", vValue));
                try
                {
                    rtn = ExecuteReaderCount(CommandType.Text, commandText, listPara);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return rtn;
        }

        protected int ExecuteReaderCount(string TableName, Dictionary<string, string> paras)
        {
            int rtn = -1;
            if (paras.Count > 0)
            {
                string commandText = string.Format("Select count(*) as rcnt from {0} where 1 = 1 ", TableName);
                List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
                foreach (KeyValuePair<string, string> d in paras)
                {
                    commandText += string.Format(" and {0} = @{1}", d.Key, d.Key);
                    listPara.Add(new SQLiteParameter(string.Format("@{0}", d.Key), d.Value));
                }
                try
                {
                    rtn = ExecuteReaderCount(CommandType.Text, commandText, listPara);
                }
                catch (Exception) { }
            }
            return rtn;
        }

        protected int ExecuteReaderCount(string TableNameOrCommandString)
        {
            string commandText = default(string);
            if (TableNameOrCommandString.Contains(' '))
            {
                commandText = TableNameOrCommandString;
            }
            else
            {
                commandText = string.Format("Select count(*) as rcnt from {0}", TableNameOrCommandString);
            }
            return ExecuteReaderCount(CommandType.Text, commandText, new List<SQLiteParameter>() { });
        }

        protected int ExecuteReaderCount(string commandText, IList<SQLiteParameter> paraList)
        {
            return ExecuteReaderCount(CommandType.Text, commandText, paraList);
        }

        protected int ExecuteReaderCount(CommandType commandType, string commandText, IList<SQLiteParameter> paraList)
        {
            int irnt = 0;
            try
            {
                SQLiteCommand cmd = CreateCommand(_conn, commandType, commandText, paraList);
                _conn.Open();
                SQLiteDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    int iFieldCount = dr.FieldCount;
                    if (1 == iFieldCount)
                    {
                        dr.Read();
                        irnt = dr.GetInt32(0);
                    }
                    else
                    {
                        Log.Exception(string.Format("Data return column:[{0}], not just only one.", iFieldCount));
                    }
                }
                _conn.Close();
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                if (_conn != null && _conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                    _conn.Dispose();
                }
            }
            return irnt;
        }

        #endregion ExecuteReader for Count

        protected int ExecuteInsert(string commandText, IList<SQLiteParameter> paraList)
        {
            int irnt = 0;
            try
            {
                commandText += ";SELECT last_insert_rowid()";
                SQLiteCommand cmd = CreateCommand(_conn, CommandType.Text, commandText, paraList);
                _conn.Open();
                SQLiteDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    int iFieldCount = dr.FieldCount;
                    if (1 == iFieldCount)
                    {
                        dr.Read();
                        irnt = dr.GetInt32(0);
                    }
                    else
                    {
                        Log.Exception(string.Format("Data return column:[{0}], not just only one.", iFieldCount));
                    }
                }
                _conn.Close();
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
                throw ex;
            }
            finally
            {
                if (_conn != null && _conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                    _conn.Dispose();
                }
            }
            return irnt;
        }
    }
}