using InnoThink.Domain.BestIdeaGroupRank;
using Rest.Core;
using Rest.Core.Constancy;
using System.Collections.Generic;

namespace InnoThink.DAL.BestIdeaGroupRank
{
    #region interface

    public interface IBestIdeaGroupRank_Repo
    {
        BestIdeaGroupRank_Info GetByID(long NoPk);

        IEnumerable<BestIdeaGroupRank_Info> GetAll();

        IEnumerable<BestIdeaGroupRank_Info> GetByParam(BestIdeaGroupRank_Filter Filter, string _orderby = "");

        IEnumerable<BestIdeaGroupRank_Info> GetByParam(BestIdeaGroupRank_Filter Filter, string[] fieldNames, string _orderby = "");

        long Insert(BestIdeaGroupRank_Info data);

        int Update(long NoPk, BestIdeaGroupRank_Info data, IEnumerable<string> columns);

        int Delete(long NoPk);
    }

    #endregion interface

    #region Implementation

    public class BestIdeaGroupRank_Repo
    {
        #region Operation: Select

        public BestIdeaGroupRank_Info GetByID(long NoPk)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM BestIdeaGroupRank")
                .Append("WHERE NoPk=@0", NoPk);

                var result = db.SingleOrDefault<BestIdeaGroupRank_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<BestIdeaGroupRank_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM BestIdeaGroupRank");
                var result = db.Query<BestIdeaGroupRank_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BestIdeaGroupRank_Info> GetByParam(BestIdeaGroupRank_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<BestIdeaGroupRank_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BestIdeaGroupRank_Info> GetByParam(BestIdeaGroupRank_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<BestIdeaGroupRank_Info>(SQLStr);

                return result;
            }
        }

        #endregion Operation: Select

        #region Operation: Insert

        public long Insert(BestIdeaGroupRank_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }

        #endregion Operation: Insert

        #region Operation: Update

        public int Update(long NoPk, BestIdeaGroupRank_Info data, IEnumerable<string> columns)
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
                return db.Delete("BestIdeaGroupRank", "NoPk", null, NoPk);
            }
        }

        #endregion Operation: Delete



        #region private function

        private Rest.Core.PetaPoco.Sql ConstructSQL(BestIdeaGroupRank_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(BestIdeaGroupRank_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM BestIdeaGroupRank")
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