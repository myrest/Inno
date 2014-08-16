using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.Board;
using InnoThink.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;
using Rest.Core;
using InnoThink.Domain.Constancy;
using InnoThink.Domain.InnoThinkMain.Binding;

namespace InnoThink.BLL.Board
{
    /*
    #region interface
    public interface IBoard_Manager
    {
        Board_Info GetBySN(long BoardSN);
        IEnumerable<Board_Info> GetAll();
        IEnumerable<Board_Info> GetByParameter(Board_Filter Filter, string _orderby = "");
        long Insert(Board_Info data);
        bool Update(long BoardSN, Board_Info data, IEnumerable<string> columns);
        bool Update(Board_Info data);
        int Delete(long BoardSN);
        bool IsExist(long BoardSN);
    }
    #endregion
    */
    #region implementation
    public class Board_Manager //: IBoard_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Board_Manager));
        #endregion

        #region Operation: Select
        public Board_Info GetBySN(long BoardSN)
        {
            return new Board_Repo().GetBySN(BoardSN);
        }

        public IEnumerable<BoardUI> GetByLimitedRecord(Board_Filter filter, Paging paging)
        {
            var rep = new Board_Repo();
            var data = rep.GetPagingByParam(filter, paging);
            return data;
        }
        public IEnumerable<BoardUI> GetByLimitedRecord(BoardType? boardType = null)
        {
            Paging pg = new Paging()
            {
                CurrentPage = 1,
                ItemsPerPage = 10
            };
            Board_Filter filter = new Board_Filter() { };
            if (boardType.HasValue)
            {
                filter.PublishType = (int)boardType.Value;
            }

            return GetByLimitedRecord(filter, pg);
        }

        public IEnumerable<Board_Info> GetAll()
        {
            return new Board_Repo().GetAll();
        }

        public IEnumerable<Board_Info> GetByParameter(Board_Filter Filter, string _orderby = "")
        {
            return new Board_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(Board_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Board_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long BoardSN, Board_Info data, IEnumerable<string> columns)
        {
            return new Board_Repo().Update(BoardSN, data, columns) > 0;
        }

        public bool Update(Board_Info data)
        {
            return new Board_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long BoardSN)
        {
            return new Board_Repo().Delete(BoardSN);
        }
        #endregion

        #region public functions
        public bool IsExist(long BoardSN)
        {
            return (GetBySN(BoardSN) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}