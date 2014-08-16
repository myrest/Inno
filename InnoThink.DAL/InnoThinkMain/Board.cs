using InnoThink.Domain;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;
using Rest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rest.Core.PetaPoco;
using InnoThink.Domain.InnoThinkMain.Binding;
namespace InnoThink.DAL.Board
{
    #region interface
    public interface IBoard_Repo
    {
        Board_Info GetBySN(long BoardSN);
        IEnumerable<Board_Info> GetAll();
        IEnumerable<Board_Info> GetPagingByParam(Board_Filter Filter, Paging pageing, string _orderby = "");
        IEnumerable<Board_Info> GetByParam(Board_Filter Filter, string _orderby = "");
        IEnumerable<Board_Info> GetByParam(Board_Filter Filter, string[] fieldNames, string _orderby = "");
        long Insert(Board_Info data);
        int Update(long BoardSN, Board_Info data, IEnumerable<string> columns);
        int Update(Board_Info data);
        int Delete(long BoardSN);
    }
    #endregion

    #region Implementation
    public class Board_Repo
    {
        #region Operation: Select
        public Board_Info GetBySN(long BoardSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT * FROM Board")
                .Append("WHERE BoardSN=@0", BoardSN);

                var result = db.SingleOrDefault<Board_Info>(SQLStr);
                return result;
            }
        }

        public IEnumerable<Board_Info> GetAll()
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                    .Append("SELECT * FROM Board");
                var result = db.Query<Board_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<BoardUI> GetPagingByParam(Board_Filter Filter, Paging paging, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructBindingSQL(Filter);

                var result = db.Page<BoardUI>(paging.CurrentPage, paging.ItemsPerPage, SQLStr);
                paging.Convert(result);
                return result.Items;
            }
        }

        public IEnumerable<Board_Info> GetByParam(Board_Filter Filter, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, new string[] { "*" }, _orderby);

                var result = db.Query<Board_Info>(SQLStr);

                return result;
            }
        }

        public IEnumerable<Board_Info> GetByParam(Board_Filter Filter, string[] fieldNames, string _orderby = "")
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = ConstructSQL(Filter, fieldNames, _orderby);

                var result = db.Query<Board_Info>(SQLStr);

                return result;
            }
        }
        #endregion

        #region Operation: Insert
        public long Insert(Board_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                long NewID = db.Insert(data) as long? ?? 0;
                return NewID;
            }
        }
        #endregion

        #region Operation: Update
        public int Update(long BoardSN, Board_Info data, IEnumerable<string> columns)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data, BoardSN, columns);
            }
        }

        public int Update(Board_Info data)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Update(data);
            }
        }
        #endregion

        #region Operation: Delete
        public int Delete(long BoardSN)
        {
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                return db.Delete("Board", "BoardSN", null, BoardSN);
            }
        }
        #endregion

        #region public function
        #endregion

        #region private function
        private Rest.Core.PetaPoco.Sql ConstructSQL(Board_Filter filter)
        {
            return ConstructSQL(filter);
        }

        private Rest.Core.PetaPoco.Sql ConstructBindingSQL(Board_Filter filter)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append(@"select b.*, u.UserName, u.LoginId, u.Picture
                        from board b inner join User u on b.UserSN = u.UserSN")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.PublishType.HasValue)
                    SQLStr.Append(" AND PublishType=@0", filter.PublishType.Value);
                //Should updat the filter for wide search
            }
            return SQLStr;
        }


        private Rest.Core.PetaPoco.Sql ConstructSQL(Board_Filter filter, string[] fieldNames, string _orderby)
        {
            var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append("SELECT " + FieldNameArrayToFieldNameString(fieldNames) + " FROM Board")
                .Append("WHERE 1=1 ");
            if (filter != null)
            {
                if (filter.PublishType.HasValue)
                    SQLStr.Append(" AND PublishType=@0", filter.PublishType.Value);
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