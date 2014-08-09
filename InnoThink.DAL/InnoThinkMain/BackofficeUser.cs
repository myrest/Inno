using InnoThink.Domain;
using InnoThink.Domain.BackofficeUser;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.DAL.BackofficeUser
{
    #region interface
    public interface IBackofficeUser_Repo
    {
        BackofficeUser_Info GetByID(long BackofficeUserSN);
        IEnumerable<BackofficeUser_Info> GetAll();
        IEnumerable<BackofficeUser_Info> GetByParam(BackofficeUser_Filter Filter, string _orderby = "");
        IEnumerable<BackofficeUser_Info> GetByParam(BackofficeUser_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(BackofficeUser_Info data);
        int Update(long BackofficeUserSN, BackofficeUser_Info data, IEnumerable<string> columns);
        int Delete(long BackofficeUserSN);
    }
    #endregion

    #region Implementation
    public class BackofficeUser_Repo
    {
        #region Operation: Select
        public BackofficeUser_Info GetByID(long BackofficeUserSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM BackofficeUser")
                .Append("WHERE BackofficeUserSN=@0", BackofficeUserSN);

                var result = db.SingleOrDefault<BackofficeUser_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<BackofficeUser_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM BackofficeUser");
                var result = db.Query<BackofficeUser_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BackofficeUser_Info> GetByParam(BackofficeUser_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<BackofficeUser_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BackofficeUser_Info> GetByParam(BackofficeUser_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<BackofficeUser_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(BackofficeUser_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long BackofficeUserSN, BackofficeUser_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, BackofficeUserSN, columns);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long BackofficeUserSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("BackofficeUser", "BackofficeUserSN", null, BackofficeUserSN);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(BackofficeUser_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(BackofficeUser_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM BackofficeUser")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                //if (filter.ID != 0)
                    //SQLStr.Append(" AND BackofficeUserSN=@0", filter.ID);
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
        #endregion
    }
    #endregion

}