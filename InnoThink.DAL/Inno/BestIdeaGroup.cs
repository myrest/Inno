using InnoThink.Domain;
using InnoThink.Domain.BestIdeaGroup;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.DAL.BestIdeaGroup
{
    #region interface
    public interface IBestIdeaGroup_Repo
    {
        BestIdeaGroup_Info GetByID(long SN);
        IEnumerable<BestIdeaGroup_Info> GetAll();
        IEnumerable<BestIdeaGroup_Info> GetByParam(BestIdeaGroup_Filter Filter, string _orderby = "");
        IEnumerable<BestIdeaGroup_Info> GetByParam(BestIdeaGroup_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(BestIdeaGroup_Info data);
        int Update(long SN, BestIdeaGroup_Info data, IEnumerable<string> columns);
        int Delete(long SN);
    }
    #endregion

    #region Implementation
    public class BestIdeaGroup_Repo
    {
        #region Operation: Select
        public BestIdeaGroup_Info GetByID(long SN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM BestIdeaGroup")
                .Append("WHERE SN=@0", SN);

                var result = db.SingleOrDefault<BestIdeaGroup_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<BestIdeaGroup_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM BestIdeaGroup");
                var result = db.Query<BestIdeaGroup_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BestIdeaGroup_Info> GetByParam(BestIdeaGroup_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<BestIdeaGroup_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BestIdeaGroup_Info> GetByParam(BestIdeaGroup_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<BestIdeaGroup_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(BestIdeaGroup_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long SN, BestIdeaGroup_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, SN, columns);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long SN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("BestIdeaGroup", "SN", null, SN);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(BestIdeaGroup_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(BestIdeaGroup_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM BestIdeaGroup")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                //if (filter.ID != 0)
                    //SQLStr.Append(" AND SN=@0", filter.ID);
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