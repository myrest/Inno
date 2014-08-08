using InnoThink.Core.Constancy;
using InnoThink.Core.Model.Topic;
using InnoThink.Core.Utility;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace InnoThink.Core.DB
{
    public class DbTopicTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbTopicTable));
        private readonly static DbUserTable dbUser = new DbUserTable() { };

        public DbTopicTable()
        {
            base.init(typeof(DbTopicTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private List<DbTopicModel> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbTopicModel> listResult = new List<DbTopicModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbTopicModel()
                    {
                        SN = Convert.ToInt32(sdr["SN"].ToString()),
                        CreatedLoginId = sdr["CreatedLoginId"].ToString(),
                        DateCreated = (DateTime)sdr["DateCreated"],
                        LeaderLoginId = sdr["LeaderLoginId"].ToString(),
                        LogoImg = sdr["LogoImg"].ToString(),
                        Step = string.IsNullOrEmpty(sdr["Step"].ToString()) ? 0 : Convert.ToInt32(sdr["Step"].ToString()),
                        Subject = sdr["Subject"].ToString(),
                        Target = sdr["Target"].ToString(),
                        TeamName = sdr["TeamName"].ToString(),
                        DateClosed = string.IsNullOrEmpty(sdr["DateClosed"].ToString()) ? DateTime.MinValue : (DateTime)sdr["DateClosed"],
                        PublishType = string.IsNullOrEmpty(sdr["PublishType"].ToString()) ? TopicPublishType.Private : EnumHelper.GetEnumByName<TopicPublishType>(sdr["PublishType"].ToString())
                    });
                }
            }
            return listResult;
        }

        private List<TeamMemberUIModel> getStep0ModelCallBack(SQLiteDataReader sdr)
        {
            List<TeamMemberUIModel> listResult = new List<TeamMemberUIModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new TeamMemberUIModel()
                    {
                        Description = sdr["Description"].ToString(),
                        Professional = sdr["Professional"].ToString(),
                        UserName = sdr["UserName"].ToString(),
                        UserSn = Convert.ToInt32(sdr["SN"].ToString()),
                        Picture = sdr["Picture"].ToString(),
                        LeaderVotoToSN = string.IsNullOrEmpty(sdr["LeaderSNVoteTo"].ToString()) ? 0 : Convert.ToInt32(sdr["LeaderSNVoteTo"].ToString()),
                        HandleJob = sdr["HandleJob"].ToString(),
                    });
                }
            }
            //Get user name from result.
            listResult.ForEach(x =>
                {
                    if (x.LeaderVotoToSN > 0)
                    {
                        var sub = listResult.Where(y => y.UserSn == x.LeaderVotoToSN).FirstOrDefault();
                        if (sub != null)
                        {
                            x.LeaderVotoToUserName = sub.UserName;
                        }
                    }
                });

            return listResult;
        }

        public List<TeamMemberUIModel> getStep0Description(int TopicSN)
        {
            string strCMD = string.Empty;
            strCMD = @"select u.Picture,m.Description,u.Professional, u.UserName, u.SN, m.LeaderSNVoteTo, m.HandleJob
                        from Users u inner join TopicMember m on
                        u.sn = m.UsersSN
                        where m.TopicSN = @TopicSN
                        order by u.UserName desc";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            List<TeamMemberUIModel> itemList = ExecuteReader<TeamMemberUIModel>(CommandType.Text, strCMD, listPara, getStep0ModelCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<TeamMemberUIModel>() { };
            }
        }

        public bool AddNewTopic(string Subject, string LoginId, TopicPublishType opento, int TeamGroupSN)
        {
            const string strCMD = @"insert into Topic
            (
                Subject, CreatedLoginId, DateCreated, PublishType, TeamGroupSN
            )
            values
            (
                @Subject, @CreatedLoginId, @DateCreated, @PublishType, @TeamGroupSN
            )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@Subject", Subject));
            listPara.Add(new SQLiteParameter("@CreatedLoginId", LoginId));
            listPara.Add(new SQLiteParameter("@DateCreated", DateTime.Now));
            listPara.Add(new SQLiteParameter("@PublishType", (int)opento));
            listPara.Add(new SQLiteParameter("@TeamGroupSN", TeamGroupSN));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }

        public DbTopicModel getTopicBySN(int SN)
        {
            const string strCMD = "select * from Topic where SN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", SN));
            List<DbTopicModel> itemList = ExecuteReader<DbTopicModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                log.Debug(string.Format("Topic not found. SN : [{0}]", SN));
                return new DbTopicModel() { };
            }
        }

        /*
        public bool IsLeader(int TopicSN, string UserLoginId)
        {
            var topic = getTopicBySN(TopicSN);
            return (string.Compare(UserLoginId, topic.LeaderLoginId, true) == 0);
        }
         * */

        public DbTopicModel getFirstTopicByUsersSN(int UsersSN)
        {
            const string strCMD = @"select t.* from Topic t
                                    inner join TopicMember tm on tm.TopicSN = t.SN
                                    where tm.UsersSN = @UsersSN
                                        and DateClosed is null
                                    order by t.SN desc
                                    limit 0,1 ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@UsersSN", UsersSN));
            List<DbTopicModel> itemList = ExecuteReader<DbTopicModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                log.Debug(string.Format("getFirstTopicByUsersSN not found. UsersSN : [{0}]", UsersSN));
                return new DbTopicModel() { };
            }
        }

        public List<DbTopicModel> GetAllMyTopicByStatus(TopicStatus Status, int Sn)
        {
            Paging p = new Paging();
            string strCMD = string.Empty;
            switch (Status)
            {
                case TopicStatus.InProcess:
                    strCMD = @"select t.* from Topic t
                                inner join TopicMember m on
                                t.sn = m.TopicSN
                                where DateClosed is null and m.UsersSn = " + Sn + @"
                                order by DateCreated desc  " + p.LimitSql;
                    break;

                case TopicStatus.Closed:
                    strCMD = @"select t.* from Topic t
                                inner join TopicMember m on
                                t.sn = m.TopicSN
                                where DateClosed is not null and m.UsersSn = " + Sn + @"
                                order by DateCreated desc  " + p.LimitSql;
                    break;

                default:
                    throw new Exception("The Topic Status not under control.");
            }
            List<DbTopicModel> itemList = ExecuteReader<DbTopicModel>(strCMD, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                log.Debug("Topic is empty");
                return new List<DbTopicModel>() { };
            }
        }

        public List<DbTopicModel> GetAllTopic_Admin()
        {
            string strCMD = "Select * from Topic";
            List<DbTopicModel> itemList = ExecuteReader<DbTopicModel>(strCMD, getModuleCallBack);
            return itemList;
        }

        public List<DbTopicModel> GetAllTopicByStatus(TopicStatus Status, int TeamGroupSN, string LoginId)
        {
            Paging p = new Paging();
            //TopicPublishType: Private->0, TeamGroup->1, All->2
            string strCMD = @"select * from Topic
                            where DateClosed is {0}
                                and (
                                    (PublishType = 1 and TeamGroupSN = {1})
                                    or (PublishType = 2)
                                    or (PublishType = 0 and CreatedLoginId = @LoginId)
                                )
                            order by DateCreated desc {3}";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@LoginId", LoginId));

            switch (Status)
            {
                case TopicStatus.InProcess:
                    strCMD = string.Format(strCMD, "null", TeamGroupSN, LoginId, p.LimitSql);
                    break;

                case TopicStatus.Closed:
                    strCMD = string.Format(strCMD, "not null", TeamGroupSN, LoginId, p.LimitSql);
                    break;

                default:
                    throw new Exception("The Topic Status not under control.");
            }
            List<DbTopicModel> itemList = ExecuteReader<DbTopicModel>(strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<DbTopicModel>() { };
            }
        }

        public bool CheckSubjectIsExist(string Subject)
        {
            int nums = ExecuteReaderCount<string>("Topic", "Subject", Subject);
            if (nums == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool UpdateTopic(DbTopicModel obj)
        {
            string strCMD = @"
                Update Topic set
                    Subject = @Subject
                    ,TeamName = @TeamName
                    ,Target = @Target
                    ,LogoImg = @LogoImg
                    ,LeaderLoginId = @LeaderLoginId
                    ,Step = @Step
                    ,PublishType = @PublishType
                Where SN = @SN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@Subject", obj.Subject));
            listPara.Add(new SQLiteParameter("@TeamName", obj.TeamName));
            listPara.Add(new SQLiteParameter("@Target", obj.Target));
            listPara.Add(new SQLiteParameter("@LogoImg", obj.LogoImg));
            listPara.Add(new SQLiteParameter("@LeaderLoginId", obj.LeaderLoginId));
            listPara.Add(new SQLiteParameter("@Step", obj.Step));
            listPara.Add(new SQLiteParameter("@SN", obj.SN));
            listPara.Add(new SQLiteParameter("@PublishType", (int)obj.PublishType));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }

        public bool CloseTopic(int TopicSN, string UserLoginId)
        {
            //need to check is Leader
            var topic = getTopicBySN(TopicSN);
            bool _isLeader = (string.Compare(UserLoginId, topic.LeaderLoginId, true) == 0);

            if (_isLeader)
            {
                string strCMD = @"
                Update Topic set
                    Step = @Step
                    ,DateClosed = @DateClosed
                Where SN = @SN ";
                List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@Step", 99));
                listPara.Add(new SQLiteParameter("@DateClosed", DateTime.Now));
                listPara.Add(new SQLiteParameter("@SN", TopicSN));
                int icnt = ExecuteNonQuery(strCMD, listPara);
                return (icnt > 0);
            }
            else
            {
                return false;
            }
        }

        public void DeleteTopic(int TopicSN)
        {
            //Delete Main Table
            string strCMD = "Delete from Topic Where SN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", TopicSN));
            ExecuteNonQuery(strCMD, listPara);

            //Delete related tables.
            List<string> DeleteTables = new List<string>() { };
            DeleteTables.Add("TopicMember");
            DeleteTables.Add("Board");
            DeleteTables.Add("BestStep1");
            DeleteTables.Add("BestIdea");
            //DeleteTables.Add("BestIdeaMemberRank");
            listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", TopicSN));
            DeleteTables.ForEach(x =>
            {
                strCMD = string.Format("Delete from {0} Where TopicSN = @SN", x);
                ExecuteNonQuery(strCMD, listPara);
            });

            strCMD = "Delete from BestIdeaMemberRank where BestIdeaSN not in(select sn from BestIdea )";
            ExecuteNonQuery(strCMD);
        }

        public bool IsTeamMember(int TopicSN, int UserSN)
        {
            Dictionary<string, string> paras = new Dictionary<string, string>() { };
            paras.Add("TopicSN", TopicSN.ToString());
            paras.Add("UsersSN", UserSN.ToString());
            int count = ExecuteReaderCount("TopicMember", paras);
            return (count > 0);
        }
    }

    public class DbTopicModel
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public int SN;

        /// <summary>
        /// 議題
        /// </summary>
        public string Subject;

        /// <summary>
        /// 隊名
        /// </summary>
        public string TeamName;

        /// <summary>
        /// 目地
        /// </summary>
        public string Target;

        /// <summary>
        /// 團隊Logo
        /// </summary>
        public string LogoImg;

        /// <summary>
        /// 隊長帳號
        /// </summary>
        public string LeaderLoginId;

        /// <summary>
        /// 現行步驟
        /// </summary>
        public int Step;

        /// <summary>
        /// 議題建立時間
        /// </summary>
        public DateTime DateCreated;

        /// <summary>
        /// 議題建立者
        /// </summary>
        public string CreatedLoginId;

        /// <summary>
        /// 議題關閉時間
        /// </summary>
        public DateTime DateClosed;

        /// <summary>
        /// 開放範圍
        /// </summary>
        public TopicPublishType PublishType;

        /// <summary>
        /// 開放至團體流水號
        /// </summary>
        public int TeamGroupSN;
    }
}