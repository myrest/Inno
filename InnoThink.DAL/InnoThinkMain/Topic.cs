using InnoThink.Domain;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.DAL.Topic
{
    #region interface
    public interface ITopic_Repo
    {
        Topic_Info GetBySN(long TopicSN);
        IEnumerable<Topic_Info> GetAll();
        IEnumerable<Topic_Info> GetByParam(Topic_Filter Filter, string _orderby = "");
        IEnumerable<Topic_Info> GetByParam(Topic_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(Topic_Info data);
        int Update(long TopicSN, Topic_Info data, IEnumerable<string> columns);
        int Update(Topic_Info data);
        int Delete(long TopicSN);
    }
    #endregion

    #region Implementation
    public class Topic_Repo
    {
        #region Operation: Select
        public Topic_Info GetBySN(long TopicSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM Topic")
                .Append("WHERE TopicSN=@0", TopicSN);

                var result = db.SingleOrDefault<Topic_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Topic_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM Topic");
                var result = db.Query<Topic_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<Topic_Info> GetByParam(Topic_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<Topic_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<Topic_Info> GetByParam(Topic_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<Topic_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(Topic_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long TopicSN, Topic_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, TopicSN, columns);
            }
        }

        public int Update(Topic_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long TopicSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("Topic", "TopicSN", null, TopicSN);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Topic_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Topic_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM Topic")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.Status.HasValue)
                {
                    switch (filter.Status.Value)
                    {
                        case TopicStatus.Closed:
                            SQLStr.Append(" DateClosed is not null");
                            break;
                        case TopicStatus.InProcess:
                            SQLStr.Append(" DateClosed is null");
                            break;
                    }
                }
                if (string.IsNullOrEmpty(filter.Subject))
                {
                    SQLStr.Append(" Subject = @0", filter.Subject);
                }
                if (filter.TeamGroupSN.HasValue)
                {
                    SQLStr.Append(" TeamGroupSN = @0", filter.TeamGroupSN.Value);
                }
                if (filter.PublishType.HasValue)
                {
                    SQLStr.Append(" PublishType = @0", filter.PublishType.Value);
                }
                //if (filter.ID != 0)
                    //SQLStr.Append(" AND TopicSN=@0", filter.ID);
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