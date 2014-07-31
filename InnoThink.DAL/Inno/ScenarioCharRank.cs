using InnoThink.Domain;
using InnoThink.Domain.ScenarioCharRank;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.DAL.ScenarioCharRank
{
    #region interface
    public interface IScenarioCharRank_Repo
    {
        ScenarioCharRank_Info GetByID(long NoPk);
        IEnumerable<ScenarioCharRank_Info> GetAll();
        IEnumerable<ScenarioCharRank_Info> GetByParam(ScenarioCharRank_Filter Filter, string _orderby = "");
        IEnumerable<ScenarioCharRank_Info> GetByParam(ScenarioCharRank_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(ScenarioCharRank_Info data);
        int Update(long NoPk, ScenarioCharRank_Info data, IEnumerable<string> columns);
        int Delete(long NoPk);
    }
    #endregion

    #region Implementation
    public class ScenarioCharRank_Repo
    {
        #region Operation: Select
        public ScenarioCharRank_Info GetByID(long NoPk)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM ScenarioCharRank")
                .Append("WHERE NoPk=@0", NoPk);

                var result = db.SingleOrDefault<ScenarioCharRank_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<ScenarioCharRank_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM ScenarioCharRank");
                var result = db.Query<ScenarioCharRank_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<ScenarioCharRank_Info> GetByParam(ScenarioCharRank_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<ScenarioCharRank_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<ScenarioCharRank_Info> GetByParam(ScenarioCharRank_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<ScenarioCharRank_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(ScenarioCharRank_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long NoPk, ScenarioCharRank_Info data, IEnumerable<string> columns)
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
                return db.Delete("ScenarioCharRank", "NoPk", null, NoPk);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(ScenarioCharRank_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(ScenarioCharRank_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM ScenarioCharRank")
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