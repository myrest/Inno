using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.BackofficeUser;
using InnoThink.Domain;
using Rest.Core.Constancy;
using Rest.Core.Utility;

namespace InnoThink.BLL.BackofficeUser
{
    /*
    #region interface
    public interface IBackofficeUser_Manager
    {
        BackofficeUser_Info GetBySN(long BackofficeUserSN);
        IEnumerable<BackofficeUser_Info> GetAll();
        IEnumerable<BackofficeUser_Info> GetByParameter(BackofficeUser_Filter Filter, string _orderby = "");
        long Insert(BackofficeUser_Info data);
        bool Update(long BackofficeUserSN, BackofficeUser_Info data, IEnumerable<string> columns);
        bool Update(BackofficeUser_Info data);
        int Delete(long BackofficeUserSN);
        bool IsExist(long BackofficeUserSN);
    }
    #endregion
    */
    #region implementation
    public class BackofficeUser_Manager //: IBackofficeUser_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(BackofficeUser_Manager));
        #endregion

        #region Operation: Select
        public BackofficeUser_Info GetBySN(long BackofficeUserSN)
        {
            return new BackofficeUser_Repo().GetBySN(BackofficeUserSN);
        }

        public IEnumerable<BackofficeUser_Info> GetAll()
        {
            return new BackofficeUser_Repo().GetAll();
        }

        public IEnumerable<BackofficeUser_Info> GetByParameter(BackofficeUser_Filter Filter, string _orderby = "")
        {
            return new BackofficeUser_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(BackofficeUser_Info data)
        {
            long newID = 0;
            try
            {
                string encode = Encrypt.RandomStr(10);
                data.Encode = encode;
                data.Password = Encrypt.EncryptPassword(data.Password, encode);
                data.LastUpdate = DateTime.Now;
                newID = new BackofficeUser_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long BackofficeUserSN, BackofficeUser_Info data, IEnumerable<string> columns)
        {
            data.Password = Encrypt.EncryptPassword(data.Password, data.Encode);
            return new BackofficeUser_Repo().Update(BackofficeUserSN, data, columns) > 0;
        }

        public bool Update(BackofficeUser_Info data)
        {
            data.Password = Encrypt.EncryptPassword(data.Password, data.Encode);
            return new BackofficeUser_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long BackofficeUserSN)
        {
            return new BackofficeUser_Repo().Delete(BackofficeUserSN);
        }
        #endregion

        #region public functions
        public bool IsExist(long BackofficeUserSN)
        {
            return (GetBySN(BackofficeUserSN) != null);
        }
        #endregion

        #region private functions
        #endregion

        public bool isPasswordCorrect(string username, string password)
        {
            var user = new BackofficeUser_Repo().GetByParam(new BackofficeUser_Filter()
            {
                 LoginId = username
            }).FirstOrDefault();
            if (user != null)
            {
                string encPwd = Encrypt.EncryptPassword(password, user.Encode);
                return (string.Compare(encPwd, user.Password) == 0);
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
}