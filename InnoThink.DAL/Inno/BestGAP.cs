using InnoThink.Domain;
using InnoThink.Domain.BestGAP;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    #endregion

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
        #endregion

        #region Operation: Insert
        public long Insert(BestGAP_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long SN, BestGAP_Info data, IEnumerable<string> columns)
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
                return db.Delete("BestGAP", "SN", null, SN);
            }
        }
        #endregion

        #region public function
        #endregion

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
        #endregion
    }
    #endregion

}