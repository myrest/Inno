using Rest.Core.Constancy;
using Rest.Core.PetaPoco;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Rest.Core
{
    public class DBExecutor
    {
        //Put all the connection for each Database, redurce the check db file is exist. only pass the test will add in the variable.
        private static Dictionary<DataBaseName, string> DbListing = new Dictionary<DataBaseName, string>() { };

        private static Object SyncLock = new Object();
        private DataBaseName DbName;

        public DBExecutor()
        {
        }

        public DBExecutor(DataBaseName _dbName)
        {
            DbName = _dbName;
        }

        public Database GetDatabase()
        {
            if (DbName != null)
            {
                string connectionString = "Data Source=" + DBExecutor.GetDatabaseFullPath(DbName);
                return new Database(connectionString, "System.Data.SQLite");
            }
            else
            {
                throw new Exception("Constructs need has paramater for Database Enum");
            }
        }

        public Database GetDatabase(DataBaseName dbname)
        {
            string connectionString = "Data Source=" + DBExecutor.GetDatabaseFullPath(dbname);
            return new Database(connectionString, "System.Data.SQLite");
        }

        private static string _GetDatabaseFullPath(DataBaseName dbname)
        {
            string DataBaseFileName = dbname.ToString() + ".oo2";
            string dbFolder = string.Empty;
            if (HttpContext.Current != null)
            {
                dbFolder = HttpContext.Current.Server.MapPath(string.Concat("\\App_Data"));
            }
            else
            {
#if DEBUG
                dbFolder = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName + "\\App_Data";
                if (!Directory.Exists(dbFolder))
                {
                    dbFolder = @"F:\Roy桌面\周亞寬\Inno\InnoThink.Website\App_Data";
                }
#endif
            }
            string strDbFileName = String.Format("{0}\\{1}", dbFolder, DataBaseFileName);
            return strDbFileName;
        }

        private static string GetDatabaseFullPath(DataBaseName dbname)
        {
            if (!DBExecutor.DbListing.Keys.Contains(dbname))
            {
                lock (DBExecutor.SyncLock)
                {
                    if (!DBExecutor.DbListing.Keys.Contains(dbname))
                    {
                        string dbfilepathname = _GetDatabaseFullPath(dbname);
                        if (File.Exists(dbfilepathname))
                        {
                            DBExecutor.DbListing.Add(dbname, dbfilepathname);
                        }
                        else
                        {
                            string fn = Path.GetFileName(dbfilepathname);
                            throw new Exception(string.Format("Database file [{0}] not found.", fn));
                        }
                    }
                }
            }
            return DBExecutor.DbListing[dbname];
        }
    }
}