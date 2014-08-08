using InnoThink.Domain.BestIdeaMemberRank;
using Rest.Core;
using Rest.Core.Constancy;
using System.Collections.Generic;

namespace InnoThink.DAL.BestIdeaMemberRank
{
    #region interface

    public interface IBestIdeaMemberRank_Repo
    {
        BestIdeaMemberRank_Info GetByID(long NoPk);

        IEnumerable<BestIdeaMemberRank_Info> GetAll();

        IEnumerable<BestIdeaMemberRank_Info> GetByParam(BestIdeaMemberRank_Filter Filter, string _orderby = "");

        IEnumerable<BestIdeaMemberRank_Info> GetByParam(BestIdeaMemberRank_Filter Filter, string[] fieldNames, string _orderby = "");

        long Insert(BestIdeaMemberRank_Info data);

        int Update(long NoPk, BestIdeaMemberRank_Info data, IEnumerable<string> columns);

        int Delete(long NoPk);
    }

    #endregion interface

    #region Implementation

    public class BestIdeaMemberRank_Repo
    {
        #region Operation: Select

        public BestIdeaMemberRank_Info GetByID(long NoPk)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM BestIdeaMemberRank")
                .Append("WHERE NoPk=@0", NoPk);

                var result = db.SingleOrDefault<BestIdeaMemberRank_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<BestIdeaMemberRank_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM BestIdeaMemberRank");
                var result = db.Query<BestIdeaMemberRank_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BestIdeaMemberRank_Info> GetByParam(BestIdeaMemberRank_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<BestIdeaMemberRank_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BestIdeaMemberRank_Info> GetByParam(BestIdeaMemberRank_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<BestIdeaMemberRank_Info>(SQLStr);

                return result;
            }
        }

        #endregion Operation: Select

        #region Operation: Insert

        public long Insert(BestIdeaMemberRank_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }

        #endregion Operation: Insert

        #region Operation: Update

        public int Update(long NoPk, BestIdeaMemberRank_Info data, IEnumerable<string> columns)
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
                return db.Delete("BestIdeaMemberRank", "NoPk", null, NoPk);
            }
        }

        #endregion Operation: Delete



        #region private function

        private Rest.Core.PetaPoco.Sql ConstructSQL(BestIdeaMemberRank_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(BestIdeaMemberRank_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM BestIdeaMemberRank")
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