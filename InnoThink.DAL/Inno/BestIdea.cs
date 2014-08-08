using InnoThink.Domain.BestIdea;
using Rest.Core;
using Rest.Core.Constancy;
using System.Collections.Generic;

namespace InnoThink.DAL.BestIdea
{
    #region interface

    public interface IBestIdea_Repo
    {
        BestIdea_Info GetByID(long SN);

        IEnumerable<BestIdea_Info> GetAll();

        IEnumerable<BestIdea_Info> GetByParam(BestIdea_Filter Filter, string _orderby = "");

        IEnumerable<BestIdea_Info> GetByParam(BestIdea_Filter Filter, string[] fieldNames, string _orderby = "");

        long Insert(BestIdea_Info data);

        int Update(long SN, BestIdea_Info data, IEnumerable<string> columns);

        int Delete(long SN);
    }

    #endregion interface

    #region Implementation

    public class BestIdea_Repo
    {
        #region Operation: Select

        public BestIdea_Info GetByID(long SN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM BestIdea")
                .Append("WHERE SN=@0", SN);

                var result = db.SingleOrDefault<BestIdea_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<BestIdea_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM BestIdea");
                var result = db.Query<BestIdea_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BestIdea_Info> GetByParam(BestIdea_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<BestIdea_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BestIdea_Info> GetByParam(BestIdea_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<BestIdea_Info>(SQLStr);

                return result;
            }
        }

        #endregion Operation: Select

        #region Operation: Insert

        public long Insert(BestIdea_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }

        #endregion Operation: Insert

        #region Operation: Update

        public int Update(long SN, BestIdea_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, SN, columns);
            }
        }

        #endregion Operation: Update

        #region Operation: Delete

        public int Delete(long SN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("BestIdea", "SN", null, SN);
            }
        }

        #endregion Operation: Delete



        #region private function

        private Rest.Core.PetaPoco.Sql ConstructSQL(BestIdea_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(BestIdea_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM BestIdea")
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

        #endregion private function
    }

    #endregion Implementation
}