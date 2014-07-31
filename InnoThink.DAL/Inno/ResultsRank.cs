using InnoThink.Domain;
using InnoThink.Domain.ResultsRank;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.DAL.ResultsRank
{
    #region interface
    public interface IResultsRank_Repo
    {
        ResultsRank_Info GetByID(long NoPk);
        IEnumerable<ResultsRank_Info> GetAll();
        IEnumerable<ResultsRank_Info> GetByParam(ResultsRank_Filter Filter, string _orderby = "");
        IEnumerable<ResultsRank_Info> GetByParam(ResultsRank_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(ResultsRank_Info data);
        int Update(long NoPk, ResultsRank_Info data, IEnumerable<string> columns);
        int Delete(long NoPk);
    }
    #endregion

    #region Implementation
    public class ResultsRank_Repo
    {
        #region Operation: Select
        public ResultsRank_Info GetByID(long NoPk)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM ResultsRank")
                .Append("WHERE NoPk=@0", NoPk);

                var result = db.SingleOrDefault<ResultsRank_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<ResultsRank_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM ResultsRank");
                var result = db.Query<ResultsRank_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<ResultsRank_Info> GetByParam(ResultsRank_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<ResultsRank_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<ResultsRank_Info> GetByParam(ResultsRank_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<ResultsRank_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(ResultsRank_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long NoPk, ResultsRank_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, NoPk, columns);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NoPk)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("ResultsRank", "NoPk", null, NoPk);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(ResultsRank_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(ResultsRank_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM ResultsRank")
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
        #endregion
    }
    #endregion

}