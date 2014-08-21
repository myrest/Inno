using InnoThink.Core.Constancy;
using InnoThink.Core.Utility;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace InnoThink.Core.DB
{
    public class DbBestIdeaGroupTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbBestIdeaGroupTable));
        private readonly static DbBestIdeaTable dbBestIdea = new DbBestIdeaTable() { };
        private static Dictionary<int, DbBestIdeaModel> BestIdeaCache = new Dictionary<int, DbBestIdeaModel>() { };

        public DbBestIdeaGroupTable()
        {
            base.init(typeof(DbBestIdeaGroupTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private void ClearBestIdeaCache()
        {
            BestIdeaCache.Clear();
        }

        private string GetIdeaBySN(int BestIdeaSN)
        {
            if (BestIdeaCache.Keys.Contains(BestIdeaSN))
            {
                return BestIdeaCache[BestIdeaSN].Idea;
            }
            else
            {
                var idea = dbBestIdea.GetBySN(BestIdeaSN);
                BestIdeaCache.Add(BestIdeaSN, idea);
                return idea.Idea;
            }
        }

        private List<DbBestIdeaGroup> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbBestIdeaGroup> listResult = new List<DbBestIdeaGroup>() { };
            if (sdr.HasRows)
            {
                ClearBestIdeaCache();
                while (sdr.Read())
                {
                    //split BestIdeaSNs.
                    List<DbBestIdeaGroupMember> GroupMember = new List<DbBestIdeaGroupMember>() { };
                    sdr["BestIdeaSNs"].ToString().Split(new char[] { ',' }).ToList().ForEach(x =>
                    {
                        int sn = Convert.ToInt32(x);
                        GroupMember.Add(new DbBestIdeaGroupMember()
                        {
                            BestIdeaSN = sn,
                            Idea = GetIdeaBySN(sn)
                        });
                    });

                    listResult.Add(new DbBestIdeaGroup()
                    {
                        GroupName = sdr["GroupName"].ToString(),
                        IdeaDetails = GroupMember,
                        SN = Convert.ToInt32(sdr["SN"].ToString()),
                        TopicSN = Convert.ToInt32(sdr["TopicSN"].ToString()),
                        Type = (BestType)Convert.ToInt32(sdr["Type"].ToString())
                    });
                }
            }
            return listResult;
        }

        private List<DbBest6DataModel> getDataModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbBest6DataModel> listResult = new List<DbBest6DataModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbBest6DataModel()
                    {
                        BestIdeaGroupSN = Convert.ToInt32(sdr["BestIdeaGroupSN"].ToString()),
                        GroupName = sdr["GroupName"].ToString(),
                        Ranking = Math.Round(Convert.ToDecimal(sdr["Ranking"].ToString()), 1, MidpointRounding.AwayFromZero),
                        Type = (BestType)Convert.ToInt32(sdr["Type"].ToString())
                    });
                }
            }
            return listResult;
        }

        /// <summary>
        /// Insert new record.
        /// </summary>
        /// <param name="Model">object which will be inserted.</param>
        /// <returns>The new record's SN.</returns>
        public int Add(DbBestIdeaGroup Model)
        {
            string[] BestIdeaSNs_arr = Model.IdeaDetails.Select(x => x.BestIdeaSN.ToString()).ToArray();
            string BestIdeaSNs = string.Join(",", BestIdeaSNs_arr);

            string strCMD = @"insert into BestIdeaGroup
            (
                GroupName, BestIdeaSNs, TopicSN, Type
            )
            values
            (
                @GroupName, @BestIdeaSNs, @TopicSN, @Type
            )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@GroupName", Model.GroupName));
            listPara.Add(new SQLiteParameter("@BestIdeaSNs", BestIdeaSNs));
            listPara.Add(new SQLiteParameter("@TopicSN", Model.TopicSN));
            listPara.Add(new SQLiteParameter("@Type", Model.Type));
            int newSN = ExecuteInsert(strCMD, listPara);
            return (newSN);
        }

        public List<DbBestIdeaGroup> GetALLByTopicSN(int TopicSN)
        {
            const string strCMD = "select * from BestIdeaGroup where TopicSN = @TopicSN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            List<DbBestIdeaGroup> itemList = ExecuteReader<DbBestIdeaGroup>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return null;
            }
        }

        public DbBestIdeaGroup GetALLByBestIdeaGroupSN(int BestIdeaGroupSN)
        {
            const string strCMD = "select * from BestIdeaGroup where SN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", BestIdeaGroupSN));
            List<DbBestIdeaGroup> itemList = ExecuteReader<DbBestIdeaGroup>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                return null;
            }
        }

        public void InsertOrReplace(DbBestIdeaGroup Model)
        {
            var obj = GetALLByBestIdeaGroupSN(Model.SN);
            if (obj != null)
            {
                Update(Model);
            }
            else
            {
                Add(Model);
            }
        }

        private bool Update(DbBestIdeaGroup Model)
        {
            string[] BestIdeaSNs_arr = Model.IdeaDetails.Select(x => x.BestIdeaSN.ToString()).ToArray();
            string BestIdeaSNs = string.Join(",", BestIdeaSNs_arr);

            string strCMD = @"
                Update BestIdeaGroup set
                    GroupName = @GroupName
                    ,BestIdeaSNs = @BestIdeaSNs
                Where SN = @SN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@BestIdeaSNs", BestIdeaSNs));
            listPara.Add(new SQLiteParameter("@GroupName", Model.GroupName));
            listPara.Add(new SQLiteParameter("@SN", Model.SN));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }

        public List<DbBest6DataModel> GetAllViewDataByTopicSN(int TopicSN)
        {
            const string strCMD = @"
                Select a.Type, b.BestIdeaGroupSN, a.GroupName, avg(b.Rank) as Ranking
                From BestIdeaGroup a inner join BestIdeaGroupRank b
                    on a.BestIdeaGroupSN = b.BestIdeaGroupSN
                Where a.TopicSN = @TopicSN
                Group by b.BestIdeaGroupSN, a.GroupName, a.Type ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            List<DbBest6DataModel> itemList = ExecuteReader<DbBest6DataModel>(CommandType.Text, strCMD, listPara, getDataModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<DbBest6DataModel>() { };
            }
        }
    }

    public class DbBestIdeaGroupMember
    {
        public int BestIdeaSN;
        public string Idea;
    }

    public class DbBestIdeaGroup
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
        /// 群組名稱
        /// </summary>
        public string GroupName;

        /// <summary>
        /// Best類別B, E, S, T -> 0, 1, 2, 3
        /// Only for UI display, wont' using in Insert and update
        /// </summary>
        public BestType Type;

        /// <summary>
        /// Best類別，由UI使用
        /// Only for UI display, wont' using in Insert and update
        /// </summary>
        public string TypeUI
        {
            get
            {
                return Type.ToString();
            }
        }

        /// <summary>
        /// Best Idea 群組成員
        /// </summary>
        public List<DbBestIdeaGroupMember> IdeaDetails;
    }

    public class DbBest6DataModel
    {
        /// <summary>
        /// Best類別B, E, S, T -> 0, 1, 2, 3
        /// </summary>
        public BestType Type;

        /// <summary>
        /// Best類別，由UI使用
        /// </summary>
        public string TypeUI
        {
            get
            {
                return Type.ToString();
            }
        }

        /// <summary>
        /// Idea SN
        /// </summary>
        public int BestIdeaGroupSN;

        /// <summary>
        /// 想法
        /// </summary>
        public string GroupName;

        /// <summary>
        /// 重要性
        /// </summary>
        public decimal Ranking;
    }
}