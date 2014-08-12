using System;
using System.Collections.Generic;
using System.Linq;
using InnoThink.DAL.User;
using InnoThink.Domain.User;
using Rest.Core.Constancy;
using Rest.Core.Utility;
using InnoThink.Domain.Facebook;

namespace InnoThink.BLL.User
{
    /*
    #region interface
    public interface IUser_Manager
    {
        User_Info GetBySN(long UserSN);
        IEnumerable<User_Info> GetAll();
        IEnumerable<User_Info> GetByParameter(User_Filter Filter, string _orderby = "");
        long Insert(User_Info data);
        bool Update(long UserSN, User_Info data, IEnumerable<string> columns);
        bool Update(User_Info data);
        int Delete(long UserSN);
        bool IsExist(long UserSN);
    }
    #endregion
    */
    #region implementation
    public class User_Manager //: IUser_Manager
    {
        #region public properties
        #endregion

        #region private fields
        private readonly static SysLog log = SysLog.GetLogger(typeof(User_Manager));
        #endregion

        #region Operation: Select
        public User_Info GetBySN(long UserSN)
        {
            return new User_Repo().GetByID(UserSN);
        }

        public IEnumerable<User_Info> GetAll()
        {
            return new User_Repo().GetAll();
        }

        public IEnumerable<User_Info> GetByParameter(User_Filter Filter, string _orderby = "")
        {
            return new User_Repo().GetByParam(Filter, _orderby);
        }
        #endregion

        #region Operation: Raw Insert
        public long Insert(User_Info data)
        {
            long newID = 0;
            try
            {
                newID = new User_Repo().Insert(data);
            }
            catch (Exception ex)
            {
                log.Exception(ex);
            }
            return newID;
        }
        #endregion

        #region Operation: Raw Update
        public bool Update(long UserSN, User_Info data, IEnumerable<string> columns)
        {
            return new User_Repo().Update(UserSN, data, columns) > 0;
        }

        public bool Update(User_Info data)
        {
            return new User_Repo().Update(data) > 0;
        }
        #endregion

        #region Operation: Delete
        public int Delete(long UserSN)
        {
            return new User_Repo().Delete(UserSN);
        }
        #endregion

        #region public functions
        public bool IsExist(long UserSN)
        {
            return (GetByID(UserSN) != null);
        }

        public bool FBLoginCheck(FacebookPersonAuth FbObject)
        {
            if (FbObject.isLogined)
            {
                User_Filter filter = new User_Filter()
                {
                    LoginId = FbObject.Email
                };
                var user = new User_Repo().GetByParam(filter).FirstOrDefault();
                if (user != null)
                {
                    user.UserName = FbObject.Name;
                    user.Picture = FbObject.Picture;
                    new User_Repo().Update(user);
                }
                else
                {
                    user = new User_Info()
                    {
                        LoginId = FbObject.Email,
                        UserName = FbObject.Name,
                        Status = 1,
                        Password = "@@|FBLOGIN|@@",
                        Picture = FbObject.Picture
                    };
                    Insert(user);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isPasswordCorrect(string LoginId, string password)
        {
            Dictionary<string, string> para = new Dictionary<string, string>() { };
            para.Add("LoginId", LoginId);
            para.Add("Password", password);

            var user = new User_Repo().GetByParam(new User_Filter()
            {
                LoginId = LoginId,
                Password = password
            });

            if (user.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        #endregion

        #region private functions
        #endregion
    }
    #endregion
}