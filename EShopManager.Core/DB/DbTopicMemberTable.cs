using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SQLite;
using EShopManager.Core.Constancy;
using EShopManager.Core.Utility;
using EShopManager.Core.Model;
using Rest.Core.Utility;

namespace EShopManager.Core.DB
{
    public class DbTopicMemberTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbTopicMemberTable));

        public DbTopicMemberTable()
        {
            base.init(typeof(DbTopicMemberTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private List<DbTopicMemberModel> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbTopicMemberModel> listResult = new List<DbTopicMemberModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbTopicMemberModel()
                    {
                        SN = Convert.ToInt32(sdr["SN"].ToString()),
                        HandleJob = sdr["HandleJob"].ToString(),
                        LeaderSNVoteTo = (string.IsNullOrEmpty(sdr["LeaderSNVoteTo"].ToString())) ? 0 : Convert.ToInt32(sdr["LeaderSNVoteTo"].ToString()),
                        TopicSN = Convert.ToInt32(sdr["TopicSN"].ToString()),
                        UserSN = Convert.ToInt32(sdr["UsersSN"].ToString()),
                        Description = sdr["description"].ToString(),
                        UserName = sdr["UserName"].ToString(),
                        Picture = sdr["Picture"].ToString(),
                    });
                }
            }
            return listResult;
        }

        public bool AddNewTopicMember(int TopicSN, int UsersSN)
        {
            if (!CheckUsersSNIsExist(TopicSN, UsersSN))
            {
                string strCMD = @"insert into TopicMember 
                    (
                        TopicSN, UsersSN
                    ) 
                    values 
                    (
                        @TopicSN, @UsersSN
                    )";
                List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
                listPara.Add(new SQLiteParameter("@UsersSN", UsersSN));
                int icnt = ExecuteNonQuery(strCMD, listPara);
                return (icnt > 0);
            }
            else
            {
                return false;
            }
        }

        public bool CheckUsersSNIsExist(int TopicSN, int UsersSN)
        {
            Dictionary<string, string> para = new Dictionary<string, string>() { };
            para.Add("TopicSN", TopicSN.ToString());
            para.Add("UsersSN", UsersSN.ToString());
            int nums = ExecuteReaderCount("TopicMember", para);
            if (nums == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DbTopicMemberModel getTopicMember(int TopicSN, int UsersSN)
        {
            string strCMD = string.Empty;
            strCMD = "select tm.*, u.UserName from TopicMember tm inner join Users u on tm.UsersSN = u.SN where tm.UsersSN = @UsersSN and tm.TopicSN = @TopicSN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@UsersSN", UsersSN));
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            List<DbTopicMemberModel> itemList = ExecuteReader<DbTopicMemberModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                return new DbTopicMemberModel() { };
            }
        }

        public bool UpdateTopicMember(DbTopicMemberModel obj)
        {
            string strCMD = @"
                Update TopicMember set
                    HandleJob = @HandleJob
                    ,LeaderSNVoteTo = @LeaderSNVoteTo
                    ,Description =  @Description
                Where SN = @SN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@HandleJob", obj.HandleJob));
            listPara.Add(new SQLiteParameter("@LeaderSNVoteTo", obj.LeaderSNVoteTo));
            listPara.Add(new SQLiteParameter("@Description", obj.Description));
            listPara.Add(new SQLiteParameter("@SN", obj.SN));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }

        public List<DbTopicMemberModel> getALLTopicMember(int TopicSN)
        {
            string strCMD = string.Empty;
            strCMD = "select tm.*, u.UserName , u.Picture from TopicMember tm inner join Users u on tm.UsersSN = u.SN where tm.TopicSN = @TopicSN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            List<DbTopicMemberModel> itemList = ExecuteReader<DbTopicMemberModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<DbTopicMemberModel>() { };
            }
        }

        public List<int> GetAllJoinedTopicByUserSN(int UserSN)
        {
            string strCMD = string.Empty;
            strCMD = "select tm.*, u.UserName from TopicMember tm inner join Users u on tm.UsersSN = u.SN where tm.UsersSN = @UserSN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@UserSN", UserSN));
            List<DbTopicMemberModel> itemList = ExecuteReader<DbTopicMemberModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList.Select(x => x.TopicSN).ToList();
            }
            else
            {
                return null;
            }
        }

        public void LeaveTopic(int TopicSN, int UserSN)
        {
            string strCMD = string.Empty;
            strCMD = "Delete from TopicMember where TopicSN = @TopicSN and UsersSN = @UserSN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            listPara.Add(new SQLiteParameter("@UserSN", UserSN));
            ExecuteNonQuery(strCMD, listPara);
        }
    }


    public class DbTopicMemberModel
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public int SN;

        /// <summary>
        /// 議題流水號
        /// </summary>
        public int TopicSN;

        /// <summary>
        /// 成員於Users的流水號
        /// </summary>
        public int UserSN;

        /// <summary>
        /// 成員名稱
        /// </summary>
        public string UserName;

        /// <summary>
        /// 成員圖片
        /// </summary>
        public string Picture;

        /// <summary>
        /// 負責工作
        /// </summary>
        public string HandleJob;

        /// <summary>
        /// 隊長投給誰
        /// </summary>
        public int LeaderSNVoteTo;

        /// <summary>
        /// 自我介紹
        /// </summary>
        public string Description;
    }
}
