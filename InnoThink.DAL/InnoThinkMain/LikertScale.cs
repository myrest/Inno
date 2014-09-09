using InnoThink.Domain;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.DAL.LikertScale
{
    #region interface
    public interface ILikertScale_Repo
    {
        LikertScale_Info GetBySN(long NoPk);
        IEnumerable<LikertScale_Info> GetAll();
        IEnumerable<LikertScale_Info> GetByParam(LikertScale_Filter Filter, string _orderby = "");
        IEnumerable<LikertScale_Info> GetByParam(LikertScale_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(LikertScale_Info data);
        int Update(long NoPk, LikertScale_Info data, IEnumerable<string> columns);
        int Update(LikertScale_Info data);
        int Delete(long NoPk);
    }
    #endregion

    #region Implementation
    public class LikertScale_Repo
    {
        #region Operation: Select
        public LikertScale_Info GetBySN(long NoPk)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM LikertScale")
                .Append("WHERE NoPk=@0", NoPk);

                var result = db.SingleOrDefault<LikertScale_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<LikertScale_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM LikertScale");
                var result = db.Query<LikertScale_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<LikertScale_Info> GetByParam(LikertScale_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<LikertScale_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<LikertScale_Info> GetByParam(LikertScale_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<LikertScale_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(LikertScale_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long NoPk, LikertScale_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, NoPk, columns);
            }
        }

        public int Update(LikertScale_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NoPk)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("LikertScale", "NoPk", null, NoPk);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(LikertScale_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(LikertScale_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM LikertScale")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.LikertScaleType.HasValue)
                {
                    SQLStr.Append(" AND LikertScaleType=@0", filter.LikertScaleType.Value);
                }
                if (filter.ParentSN.HasValue)
                {
                    SQLStr.Append(" AND ParentSN=@0", filter.ParentSN.Value);
                }
                if (filter.Rank.HasValue)
                {
                    SQLStr.Append(" AND Rank=@0", filter.Rank.Value);
                }
                if (filter.TopicSN.HasValue)
                {
                    SQLStr.Append(" AND TopicSN=@0", filter.TopicSN.Value);
                }
                if (filter.UserSN.HasValue)
                {
                    SQLStr.Append(" AND UserSN=@0", filter.UserSN.Value);
                }
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