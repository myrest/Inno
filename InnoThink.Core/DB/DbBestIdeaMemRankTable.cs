using InnoThink.Core.Constancy;
using InnoThink.Core.Utility;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;

namespace InnoThink.Core.DB
{
    public class DbBestIdeaMemRankTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbBestIdeaMemRankTable));

        public DbBestIdeaMemRankTable()
        {
            base.init(typeof(DbBestIdeaMemRankTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private List<DbBestIdeaMemRankModel> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbBestIdeaMemRankModel> listResult = new List<DbBestIdeaMemRankModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbBestIdeaMemRankModel()
                    {
                        BestIdeaSN = Convert.ToInt32(sdr["BestIdeaSN"].ToString()),
                        Rank = Convert.ToInt32(sdr["Rank"].ToString())
                    });
                    if (sdr.GetOrdinal("Type") > -1)
                    {
                        listResult.Last().Type = (BestType)Convert.ToInt32(sdr["Type"].ToString());
                        listResult.Last().Idea = sdr["Idea"].ToString();
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
        private int Add(DbBestIdeaMemRankModel Model)
        {
            string strCMD = @"insert into BestIdeaMemberRank
            (
                BestIdeaSN, Rank, UserSN
            )
            values
            (
                @BestIdeaSN, @Rank, @UserSN
            )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@BestIdeaSN", Model.BestIdeaSN));
            listPara.Add(new SQLiteParameter("@Rank", Model.Rank));
            listPara.Add(new SQLiteParameter("@UserSN", Model.UserSN));
            int newSN = ExecuteInsert(strCMD, listPara);
            return (newSN);
        }

        private DbBestIdeaMemRankModel GetByBestIdeaSN(int UserSN, int BestIdeaSN)
        {
            const string strCMD = "select * from BestIdeaMemberRank where BestIdeaSN = @BestIdeaSN and UserSN = @UserSN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@BestIdeaSN", BestIdeaSN));
            listPara.Add(new SQLiteParameter("@UserSN", UserSN));
            List<DbBestIdeaMemRankModel> itemList = ExecuteReader<DbBestIdeaMemRankModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
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

        public List<DbBestIdeaMemRankModel> GetAllByTopicSN(int TopicSN, int UserSN)
        {
            const string strCMD = @"select b.BestIdeaSN as BestIdeaSN, B.Type as Type, B.Idea as Idea, ifnull(A.Rank,0) as Rank from
                                    (select bi.BestIdeasn as BestIdeaSN, bi.Type, Idea from BestIdea bi
                                    where bi.TopicSN = @TopicSN) b
                                    left outer join
                                    (select * from BestIdeaMemberRank br
                                    where br.UserSN = @UserSN) a
                                    on a.BestIdeaSN = b.BestIdeaSN
                                    ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            listPara.Add(new SQLiteParameter("@UserSN", UserSN));
            List<DbBestIdeaMemRankModel> itemList = ExecuteReader<DbBestIdeaMemRankModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                itemList.ForEach(x => x.UserSN = UserSN);
                return itemList;
            }
            else
            {
                return new List<DbBestIdeaMemRankModel>() { };
            }
        }

        public void InsertOrReplace(DbBestIdeaMemRankModel Model)
        {
            var obj = GetByBestIdeaSN(Model.UserSN, Model.BestIdeaSN);
            if (obj != null)
            {
                Update(Model);
            }
            else
            {
                Add(Model);
            }
        }

        private bool Update(DbBestIdeaMemRankModel Model)
        {
            string strCMD = @"
                Update BestIdeaMemberRank set
                    Rank = @Rank
                Where UserSN = @UserSN and BestIdeaSN = @BestIdeaSN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@BestIdeaSN", Model.BestIdeaSN));
            listPara.Add(new SQLiteParameter("@UserSN", Model.UserSN));
            listPara.Add(new SQLiteParameter("@Rank", Model.Rank));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }
    }

    public class DbBestIdeaMemRankModel
    {
        /// <summary>
        /// 使用者流水號
        /// </summary>
        public int UserSN;

        /// <summary>
        /// BestIdea 流水號
        /// </summary>
        public int BestIdeaSN;

        /// <summary>
        /// 重要性
        /// </summary>
        public int Rank;

        #region 以下資料來源為BestIdea

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

        public string Idea;

        #endregion 以下資料來源為BestIdea
    }
}