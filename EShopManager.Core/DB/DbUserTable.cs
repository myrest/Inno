using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using EShopManager.Core.Constancy;
using EShopManager.Core.Utility;
using EShopManager.Core.Model;
using Rest.Core.Utility;

namespace EShopManager.Core.DB
{
    public class DbUserTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbUserTable));

        public DbUserTable()
        {
            base.init(typeof(DbUserTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private List<DbUserModel> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbUserModel> listResult = new List<DbUserModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbUserModel()
                    {
                        SN = Convert.ToInt32(sdr["SN"].ToString()),
                        LoginId = sdr["LoginId"].ToString(),
                        Password = sdr["Password"].ToString(),
                        Status = Convert.ToInt32(sdr["Status"].ToString()),
                        Picture = sdr["Picture"].ToString(),
                        UserName = sdr["UserName"].ToString(),
                        Position = Convert.ToInt32(sdr["Position"].ToString()),
                        Professional = sdr["Professional"].ToString(),
                        TeamGroupSN = (string.IsNullOrEmpty(sdr["TeamGroupSN"].ToString())) ? 0 : Convert.ToInt32(sdr["TeamGroupSN"].ToString())
                    });
                }
            }
            return listResult;
        }

        public bool FBLoginCheck(FacebookPersonAuth FbObject)
        {
            if (FbObject.isLogined)
            {
                if (CheckIdIsExist(FbObject.Email))
                {
                    //Id is exist, need update user info
                    DbUserModel user = getUserByLoginId(FbObject.Email);
                    if (user.UserName != FbObject.Name || user.Picture != FbObject.Picture)
                    {
                        user.UserName = FbObject.Name;
                        user.Picture = FbObject.Picture;
                        UpdateUserInfo(user);
                    }
                }
                else
                {
                    //id not exist, need create new one.
                    DbUserModel user = new DbUserModel()
                    {
                        LoginId = FbObject.Email,
                        UserName = FbObject.Name,
                        Status = 1,
                        Password = "@@|FBLOGIN|@@",
                        Picture = FbObject.Picture,
                        Position = 1,
                    };
                    AddNewUser(user);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public DbUserModel getUserByLoginId(string LoginId)
        {
            const string strCMD = "select * from Users where LoginId = @LoginId";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@LoginId", LoginId));
            List<DbUserModel> itemList = ExecuteReader<DbUserModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                log.Debug(string.Format("Data not found. UserId : [{0}]", LoginId));
                return new DbUserModel() { };
            }
        }

        public DbUserModel getUserBySN(int SN)
        {
            const string strCMD = "select * from Users where SN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", SN));
            List<DbUserModel> itemList = ExecuteReader<DbUserModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                log.Debug(string.Format("Data not found. User SN : [{0}]", SN));
                return new DbUserModel() { };
            }
        }

        public bool CheckIdIsExist(string LoginId)
        {
            int nums = ExecuteReaderCount<string>("Users", "LoginId", LoginId);
            if (nums == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isPasswordCorrect(string LoginId, string password)
        {
            Dictionary<string, string> para = new Dictionary<string, string>() { };
            para.Add("LoginId", LoginId);
            para.Add("Password", password);

            int nums = ExecuteReaderCount("Users", para);
            if (nums == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool UpdateUserInfo(DbUserModel user)
        {
            //update base information
            string strCMD = @"
                Update Users set
                    Picture = @Picture
                    ,UserName = @UserName
                    ,Professional = @Professional
                    ,Position = @Position
                    ,TeamGroupSN = @TeamGroupSN
                    ,Password = @Password
                Where SN = @SN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", user.SN));
            listPara.Add(new SQLiteParameter("@Picture", user.Picture));
            listPara.Add(new SQLiteParameter("@UserName", user.UserName));
            listPara.Add(new SQLiteParameter("@Professional", user.Professional));
            listPara.Add(new SQLiteParameter("@Position", user.Position));
            listPara.Add(new SQLiteParameter("@TeamGroupSN", user.TeamGroupSN));
            listPara.Add(new SQLiteParameter("@Password", user.Password));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }

        public bool AddNewUser(DbUserModel obj)
        {
            const string strCMD = @"insert into Users 
                (
                    LoginId, Password, Status, UserName, Picture
                ) 
                values 
                (
                    @LoginId, @Password, @Status, @UserName, @Picture
                )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@LoginId", obj.LoginId));
            listPara.Add(new SQLiteParameter("@Password", obj.Password));
            listPara.Add(new SQLiteParameter("@Status", obj.Status));
            listPara.Add(new SQLiteParameter("@UserName", obj.UserName));
            listPara.Add(new SQLiteParameter("@Picture", obj.Picture));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }

        public List<DbUserModel> GetUserByTeamGroupSN(int TeamGroupSN)
        {
            const string strCMD = "select * from Users where TeamGroupSN = @TeamGroupSN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TeamGroupSN", TeamGroupSN));
            List<DbUserModel> itemList = ExecuteReader<DbUserModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<DbUserModel>() { };
            }
        }
    }


    public class DbUserModel
    {
        public int SN;
        public string LoginId;
        public string Password;
        public int Status;
        public string Picture;
        public string UserName;
        public int Position;
        public string Professional;
        public int TeamGroupSN;
    }


}
