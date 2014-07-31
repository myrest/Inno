using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.Board;
using InnoThink.Domain.Board;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace InnoThink.BLL.Board
{
    #region interface
    public interface IBoard_Manager
    {
        Board_Info GetByID(long NoPk);
        IEnumerable<Board_Info> GetAll();
        IEnumerable<Board_Info> GetByParameter(Board_Filter Filter, string _orderby = "");
        long Insert(Board_Info data);
        bool Update(long NoPk, Board_Info data, IEnumerable<string> columns);
        int Delete(long NoPk);
        bool IsExist(long NoPk);
    }
    #endregion

    #region implementation
    public class Board_Manager : IBoard_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(Board_Manager));
        #endregion

        #region Operation: Select
        public Board_Info GetByID(long NoPk)
        {
            return new Board_Repo().GetByID(NoPk);
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
        public bool Update(long NoPk, Board_Info data, IEnumerable<string> columns)
        {
            return new Board_Repo().Update(NoPk, data, columns) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long NoPk)
        {
            return new Board_Repo().Delete(NoPk);
        }
        #endregion

        #region public functions
        public bool IsExist(long NoPk)
        {
            return (GetByID(NoPk) != null);
        }
        #endregion

        #region private functions
        #endregion
    }
    #endregion
}