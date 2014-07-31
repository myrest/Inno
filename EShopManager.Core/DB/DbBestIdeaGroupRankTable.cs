using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SQLite;
using EShopManager.Core.Constancy;
using EShopManager.Core.Utility;
using EShopManager.Core.Model;
using EShopManager.Core.Model.Topic;
using CWB.Web.Configuration;
using System.IO;
using System.Web;
using Rest.Core.Utility;

namespace EShopManager.Core.DB
{
    public class DbBestIdeaGroupRankTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbBestIdeaGroupRankTable));

        public DbBestIdeaGroupRankTable()
        {
            base.init(typeof(DbBestIdeaGroupRankTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private List<DbBestIdeaGroupRankModel> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbBestIdeaGroupRankModel> listResult = new List<DbBestIdeaGroupRankModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbBestIdeaGroupRankModel()
                    {
                        BestIdeaGroupSN = Convert.ToInt32(sdr["BestIdeaGroupSN"].ToString()),
                        Rank = Convert.ToInt32(sdr["Rank"].ToString())
                    });
                    if (sdr.GetOrdinal("Type") > -1)
                    {
                        listResult.Last().Type = (BestType)Convert.ToInt32(sdr["Type"].ToString());
                        listResult.Last().GroupName = sdr["GroupName"].ToString();
                    }
                }
            }
            return listResult;
        }

        /// <summary>
        /// Insert new record.
        /// </summary>
        /// <param name="Model">object which will be inserted.</param>
        /// <returns>The new record's SN.</returns>
        private int Add(DbBestIdeaGroupRankModel Model)
        {
            string strCMD = @"insert into BestIdeaGroupRank
            (
                BestIdeaGroupSN, Rank, UserSN
            ) 
            values 
            (
                @BestIdeaGroupSN, @Rank, @UserSN
            )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@BestIdeaGroupSN", Model.BestIdeaGroupSN));
            listPara.Add(new SQLiteParameter("@Rank", Model.Rank));
            listPara.Add(new SQLiteParameter("@UserSN", Model.UserSN));
            int newSN = ExecuteInsert(strCMD, listPara);
            return (newSN);
        }

        private DbBestIdeaGroupRankModel GetByBestIdeaGroupSN(int UserSN, int BestIdeaGroupSN)
        {
            const string strCMD = "select * from BestIdeaGroupRank where BestIdeaGroupSN = @BestIdeaGroupSN and UserSN = @UserSN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@BestIdeaGroupSN", BestIdeaGroupSN));
            listPara.Add(new SQLiteParameter("@UserSN", UserSN));
            List<DbBestIdeaGroupRankModel> itemList = ExecuteReader<DbBestIdeaGroupRankModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                itemList[0].UserSN = UserSN;
                return itemList[0];
            }
            else
            {
                return null;
            }
        }

        public List<DbBestIdeaGroupRankModel> GetAllByTopicSN(int TopicSN, int UserSN)
        {
            const string strCMD = @"select b.BestIdeaGroupSN as BestIdeaGroupSN, B.Type as Type, B.GroupName as GroupName, ifnull(A.Rank,0) as Rank from 
                                    (select bi.sn as BestIdeaGroupSN, bi.Type, GroupName from BestIdeaGroup bi
                                    where bi.TopicSN = @TopicSN) b
                                    left outer join 
                                    (select * from BestIdeaGroupRank br
                                    where br.UserSN = @UserSN) a
                                    on a.BestIdeaGroupSN = b.BestIdeaGroupSN
                                    ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            listPara.Add(new SQLiteParameter("@UserSN", UserSN));
            List<DbBestIdeaGroupRankModel> itemList = ExecuteReader<DbBestIdeaGroupRankModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                itemList.ForEach(x => x.UserSN = UserSN);
                return itemList;
            }
            else
            {
                return new List<DbBestIdeaGroupRankModel>() { };
            }
        }

        public void InsertOrReplace(DbBestIdeaGroupRankModel Model)
        {
            var obj = GetByBestIdeaGroupSN(Model.UserSN, Model.BestIdeaGroupSN);
            if (obj != null)
            {
                Update(Model);
            }
            else
            {
                Add(Model);
            }
        }

        private bool Update(DbBestIdeaGroupRankModel Model)
        {
            string strCMD = @"
                Update BestIdeaGroupRank set
                    Rank = @Rank
                Where UserSN = @UserSN and BestIdeaGroupSN = @BestIdeaGroupSN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@BestIdeaGroupSN", Model.BestIdeaGroupSN));
            listPara.Add(new SQLiteParameter("@UserSN", Model.UserSN));
            listPara.Add(new SQLiteParameter("@Rank", Model.Rank));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }
    }

    public class DbBestIdeaGroupRankModel
    {
        /// <summary>
        /// 使用者流水號
        /// </summary>
        public int UserSN;

        /// <summary>
        /// BestIdea 流水號
        /// </summary>
        public int BestIdeaGroupSN;

        /// <summary>
        /// 重要性
        /// </summary>
        public int Rank;

        #region 以下資料來源為BestIdeaGroup
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
        #endregion

        public string GroupName;
    }


}
