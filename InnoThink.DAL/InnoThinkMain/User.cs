using InnoThink.Domain;
using InnoThink.Domain.User;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnoThink.Domain.Facebook;

namespace InnoThink.DAL.User
{
    #region interface
    public interface IUser_Repo
    {
        User_Info GetByID(long UserSN);
        IEnumerable<User_Info> GetAll();
        IEnumerable<User_Info> GetByParam(User_Filter Filter, string _orderby = "");
        IEnumerable<User_Info> GetByParam(User_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(User_Info data);
        int Update(long UserSN, User_Info data, IEnumerable<string> columns);
        int Delete(long UserSN);
    }
    #endregion

    #region Implementation
    public class User_Repo
    {
        #region Operation: Select
        public User_Info GetByID(long UserSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM User")
                .Append("WHERE UserSN=@0", UserSN);

                var result = db.SingleOrDefault<User_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<User_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM User");
                var result = db.Query<User_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<User_Info> GetByParam(User_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<User_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<User_Info> GetByParam(User_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<User_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(User_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long UserSN, User_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, UserSN, columns);
            }
        }
        public int Update(User_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long UserSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("User", "UserSN", null, UserSN);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(User_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(User_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM User")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.LoginId))
                {
                    SQLStr.Append(" AND LoginId=@0", filter.LoginId);
                }
                if (filter.Status.HasValue)
                {
                    SQLStr.Append(" AND LoginId=@0", filter.Status.Value);
                }
                if (filter.TeamGroupSN.HasValue)
                {
                    SQLStr.Append(" AND LoginId=@0", filter.TeamGroupSN.Value);
                }
                if (!string.IsNullOrEmpty(filter.UserName))
                {
                    SQLStr.Append(" AND LoginId like %@0%", filter.UserName);
                }
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