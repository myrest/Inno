using InnoThink.Domain.BestGAP;
using Rest.Core;
using Rest.Core.Constancy;
using System.Collections.Generic;

namespace InnoThink.DAL.BestGAP
{
    #region interface

    public interface IBestGAP_Repo
    {
        BestGAP_Info GetByID(long SN);

        IEnumerable<BestGAP_Info> GetAll();

        IEnumerable<BestGAP_Info> GetByParam(BestGAP_Filter Filter, string _orderby = "");

        IEnumerable<BestGAP_Info> GetByParam(BestGAP_Filter Filter, string[] fieldNames, string _orderby = "");

        long Insert(BestGAP_Info data);

        int Update(long SN, BestGAP_Info data, IEnumerable<string> columns);

        int Delete(long SN);
    }

    #endregion interface

    #region Implementation

    public class BestGAP_Repo
    {
        #region Operation: Select

        public BestGAP_Info GetByID(long SN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM BestGAP")
                .Append("WHERE SN=@0", SN);

                var result = db.SingleOrDefault<BestGAP_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<BestGAP_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM BestGAP");
                var result = db.Query<BestGAP_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BestGAP_Info> GetByParam(BestGAP_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<BestGAP_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BestGAP_Info> GetByParam(BestGAP_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<BestGAP_Info>(SQLStr);

                return result;
            }
        }

        #endregion Operation: Select

        #region Operation: Insert

        public long Insert(BestGAP_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }

        #endregion Operation: Insert

        #region Operation: Update

        public int Update(long SN, BestGAP_Info data, IEnumerable<string> columns)
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
                return db.Delete("BestGAP", "SN", null, SN);
            }
        }

        #endregion Operation: Delete



        #region private function

        private Rest.Core.PetaPoco.Sql ConstructSQL(BestGAP_Filter filter)
        {
            return ConstructSQL(filter, new string[] { "*" }, "");
        }

        private Rest.Core.PetaPoco.Sql ConstructSQL(BestGAP_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM BestGAP")
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