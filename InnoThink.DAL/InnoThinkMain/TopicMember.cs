using InnoThink.Domain;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnoThink.Domain.InnoThinkMain.Binding;

namespace InnoThink.DAL.TopicMember
{
    #region interface
    public interface ITopicMember_Repo
    {
        TopicMember_Info GetBySN(long TopicMemberSN);
        IEnumerable<TopicMember_Info> GetAll();
        IEnumerable<TopicMember_Info> GetByParam(TopicMember_Filter Filter, string _orderby = "");
        IEnumerable<TopicMember_Info> GetByParam(TopicMember_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(TopicMember_Info data);
        int Update(long TopicMemberSN, TopicMember_Info data, IEnumerable<string> columns);
        int Update(TopicMember_Info data);
        int Delete(long TopicMemberSN);

        List<TopicMemberUI> getStep0Description(int TopicSN);
    }
    #endregion

    #region Implementation
    public class TopicMember_Repo
    {
        #region Operation: Select
        public List<TopicMemberUI> getStep0Description(int TopicSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append(@"select u.Picture,m.Description,u.Professional, u.UserName, u.UserSN, m.LeaderSNVoteTo, m.HandleJob
                        from User u inner join TopicMember m on
                        u.UserSN = m.UserSN
                        where m.TopicSN = @0
                        order by u.UserName desc", TopicSN);
                var result = db.Query<TopicMemberUI>(SQLStr);
                return result.ToList();
            }
        }

        public TopicMember_Info GetBySN(long TopicMemberSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM TopicMember")
                .Append("WHERE TopicMemberSN=@0", TopicMemberSN);

                var result = db.SingleOrDefault<TopicMember_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<TopicMember_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM TopicMember");
                var result = db.Query<TopicMember_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<TopicMember_Info> GetByParam(TopicMember_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<TopicMember_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<TopicMember_Info> GetByParam(TopicMember_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<TopicMember_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(TopicMember_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long TopicMemberSN, TopicMember_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, TopicMemberSN, columns);
            }
        }

        public int Update(TopicMember_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long TopicMemberSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("TopicMember", "TopicMemberSN", null, TopicMemberSN);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(TopicMember_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(TopicMember_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM TopicMember")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.UserSN.HasValue)
                {
                    SQLStr.Append("And UserSN=@0", filter.UserSN.Value);
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

        public List<TopicMemberUI> GetAllJoinedTopicByUserSN(int UserSN)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append(@"
                        select tm.*, u.UserName 
                        from TopicMember tm inner join User u on tm.UserSN = u.UserSN 
                        where tm.UserSN = @0", UserSN);

            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var result = db.Query<TopicMemberUI>(SQLStr);

                return result.ToList();
            }
        }

        public List<TopicMemberUI> getTopicMember(int TopicSN, int UserSN)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append(@"
                    select tm.*, u.UserName 
                    from TopicMember tm inner join User u on tm.UserSN = u.UserSN 
                    where tm.UserSN = @0 and tm.TopicSN = @1", UserSN, TopicSN);
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var result = db.Query<TopicMemberUI>(SQLStr);

                return result.ToList();
            }
        }

        public List<TopicMemberUI> getALLTopicMember(int TopicSN)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append(@"
                    select tm.*, u.UserName, u.Picture
                    from TopicMember tm inner join User u on tm.UserSN = u.UserSN 
                    where tm.TopicSN = @0", TopicSN);
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var result = db.Query<TopicMemberUI>(SQLStr);

                return result.ToList();
            }
        }
    }
    #endregion

}