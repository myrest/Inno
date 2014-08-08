using InnoThink.Domain.Settings;
using Rest.Core;
using Rest.Core.Constancy;
using System.Collections.Generic;

namespace InnoThink.DAL.Settings
{
    #region interface

    public interface ISettings_Repo
    {
        Settings_Info GetByID(long NoPk);

        IEnumerable<Settings_Info> GetAll();

        IEnumerable<Settings_Info> GetByParam(Settings_Filter Filter, string _orderby = "");

        IEnumerable<Settings_Info> GetByParam(Settings_Filter Filter, string[] fieldNames, string _orderby = "");

        long Insert(Settings_Info data);

        int Update(long NoPk, Settings_Info data, IEnumerable<string> columns);

        int Delete(long NoPk);
    }

    #endregion interface

    #region Implementation

    public class Settings_Repo
    {
        #region Operation: Select

        public Settings_Info GetByID(long NoPk)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM Settings")
                .Append("WHERE NoPk=@0", NoPk);

                var result = db.SingleOrDefault<Settings_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Settings_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM Settings");
                var result = db.Query<Settings_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<Settings_Info> GetByParam(Settings_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<Settings_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<Settings_Info> GetByParam(Settings_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<Settings_Info>(SQLStr);

                return result;
            }
        }

        #endregion Operation: Select

        #region Operation: Insert

        public long Insert(Settings_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }

        #endregion Operation: Insert

        #region Operation: Update

        public int Update(long NoPk, Settings_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, NoPk, columns);
            }
        }

        #endregion Operation: Update

        #region Operation: Delete

        public int Delete(long NoPk)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("Settings", "NoPk", null, NoPk);
            }
        }

        #endregion Operation: Delete



        #region private function

        private Rest.Core.PetaPoco.Sql ConstructSQL(Settings_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Settings_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM Settings")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                //if (filter.ID != 0)
                //SQLStr.Append(" AND NoPk=@0", filter.ID);
                //Should updat the filter for wide search

                if (_orderby != "")
                    SQLStr.Append("ORDER BY @0", _orderby);
            }
            return SQLStr;
        }

        private string FieldNameArrayToFieldNameString(string[] fieldNames)
        {
            return string.Join(", ", fieldNames);
        }

        #endregion private function
    }

    #endregion Implementation
}