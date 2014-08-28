using InnoThink.Domain;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.DAL.Analysis
{
    #region interface
    public interface IAnalysis_Repo
    {
        Analysis_Info GetBySN(long AnalysisSN);
        IEnumerable<Analysis_Info> GetAll();
        IEnumerable<Analysis_Info> GetByParam(Analysis_Filter Filter, string _orderby = "");
        IEnumerable<Analysis_Info> GetByParam(Analysis_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(Analysis_Info data);
        int Update(long AnalysisSN, Analysis_Info data, IEnumerable<string> columns);
        int Update(Analysis_Info data);
        int Delete(long AnalysisSN);
    }
    #endregion

    #region Implementation
    public class Analysis_Repo
    {
        #region Operation: Select
        public Analysis_Info GetBySN(long AnalysisSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM Analysis")
                .Append("WHERE AnalysisSN=@0", AnalysisSN);

                var result = db.SingleOrDefault<Analysis_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Analysis_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM Analysis");
                var result = db.Query<Analysis_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<Analysis_Info> GetByParam(Analysis_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<Analysis_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<Analysis_Info> GetByParam(Analysis_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<Analysis_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(Analysis_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long AnalysisSN, Analysis_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, AnalysisSN, columns);
            }
        }

        public int Update(Analysis_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long AnalysisSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("Analysis", "AnalysisSN", null, AnalysisSN);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Analysis_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(Analysis_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM Analysis")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.TopicSN.HasValue)
                {
                    SQLStr.Append(" AND TopicSN=@0", filter.TopicSN.Value);
                }
                if (filter.AnalysisType.HasValue)
                {
                    SQLStr.Append(" AND AnalysisType=@0", filter.AnalysisType.Value);
                }
                //
                //if (filter.ID != 0)
                    //SQLStr.Append(" AND AnalysisSN=@0", filter.ID);
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