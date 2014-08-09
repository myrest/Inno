using InnoThink.Domain;
using InnoThink.Domain.Users;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.DAL.Users
{
    #region interface
    public interface IUsers_Repo
    {
        Users_Info GetByID(long UsersSN);
        IEnumerable<Users_Info> GetAll();
        IEnumerable<Users_Info> GetByParam(Users_Filter Filter, string _orderby = "");
        IEnumerable<Users_Info> GetByParam(Users_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(Users_Info data);
        int Update(long UsersSN, Users_Info data, IEnumerable<string> columns);
        int Delete(long UsersSN);
    }
    #endregion

    #region Implementation
    public class Users_Repo
    {
        #region Operation: Select
        public Users_Info GetByID(long UsersSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM Users")
                .Append("WHERE UsersSN=@0", UsersSN);

                var result = db.SingleOrDefault<Users_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Users_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM Users");
                var result = db.Query<Users_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<Users_Info> GetByParam(Users_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<Users_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<Users_Info> GetByParam(Users_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<Users_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(Users_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long UsersSN, Users_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, UsersSN, columns);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long UsersSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("Users", "UsersSN", null, UsersSN);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Users_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Users_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM Users")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                //if (filter.ID != 0)
                    //SQLStr.Append(" AND UsersSN=@0", filter.ID);
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