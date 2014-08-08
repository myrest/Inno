using InnoThink.DAL.Users;
using InnoThink.Domain.Users;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;

namespace InnoThink.BLL.Users
{
    #region interface

    public interface IUsers_Manager
    {
        Users_Info GetByID(long SN);

        IEnumerable<Users_Info> GetAll();

        IEnumerable<Users_Info> GetByParameter(Users_Filter Filter, string _orderby = "");

        long Insert(Users_Info data);

        bool Update(long SN, Users_Info data, IEnumerable<string> columns);

        int Delete(long SN);

        bool IsExist(long SN);
    }

    #endregion interface

    #region implementation

    public class Users_Manager : IUsers_Manager
    {
        #region private fields

        private readonly static SysLog log = SysLog.GetLogger(typeof(Users_Manager));

        #endregion private fields

        #region Operation: Select

        public Users_Info GetByID(long SN)
        {
            return new Users_Repo().GetByID(SN);
        }

        public IEnumerable<Users_Info> GetAll()
        {
            return new Users_Repo().GetAll();
        }

        public IEnumerable<Users_Info> GetByParameter(Users_Filter Filter, string _orderby = "")
        {
            return new Users_Repo().GetByParam(Filter, _orderby);
        }

        #endregion Operation: Select

        #region Operation: Raw Insert

        public long Insert(Users_Info data)
        {
            long newID = 0;
            try
            {
                newID = new Users_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }

        #endregion Operation: Raw Insert

        #region Operation: Raw Update

        public bool Update(long SN, Users_Info data, IEnumerable<string> columns)
        {
            return new Users_Repo().Update(SN, data, columns) > 0;
        }

        #endregion Operation: Raw Update

        #region Operation: Delete

        public int Delete(long SN)
        {
            return new Users_Repo().Delete(SN);
        }

        #endregion Operation: Delete

        #region public functions

        public bool IsExist(long SN)
        {
            return (GetByID(SN) != null);
        }

        #endregion public functions
    }

    #endregion implementation
}