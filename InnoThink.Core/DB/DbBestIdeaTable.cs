using InnoThink.Core.Constancy;
using InnoThink.Core.Utility;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;

namespace InnoThink.Core.DB
{
    public class DbBestIdeaTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbBestIdeaTable));

        public DbBestIdeaTable()
        {
            base.init(typeof(DbBestIdeaTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private List<DbBestIdeaModel> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbBestIdeaModel> listResult = new List<DbBestIdeaModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbBestIdeaModel()
                    {
                        SN = Convert.ToInt32(sdr["BestIdeaSN"].ToString()),
                        LastUpdate = DateTime.Parse(sdr["LastUpdate"].ToString()),
                        TopicSN = Convert.ToInt32(sdr["TopicSN"].ToString()),
                        UserSN = Convert.ToInt32(sdr["UserSN"].ToString()),
                        Description = sdr["Description"].ToString(),
                        Idea = sdr["Idea"].ToString(),
                        Ranking = Convert.ToInt32(sdr["Ranking"].ToString()),
                        Type = (BestType)Convert.ToInt32(sdr["Type"].ToString())
                    });
                }
            }
            return listResult;
        }

        private List<DbBest4DataModel> getDataModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbBest4DataModel> listResult = new List<DbBest4DataModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbBest4DataModel()
                    {
                        BestIdeaSN = Convert.ToInt32(sdr["BestIdeaSN"].ToString()),
                        Idea = sdr["Idea"].ToString(),
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
        public int Add(DbBestIdeaModel Model)
        {
            string strCMD = @"insert into BestIdea
            (
                TopicSN, UserSN, LastUpdate, Type, Idea, Description
            )
            values
            (
                @TopicSN, @UserSN, @LastUpdate, @Type, @Idea, @Description
            )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", Model.TopicSN));
            listPara.Add(new SQLiteParameter("@UserSN", Model.UserSN));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            listPara.Add(new SQLiteParameter("@Description", Model.Description));
            listPara.Add(new SQLiteParameter("@Type", (int)Model.Type));
            listPara.Add(new SQLiteParameter("@Idea", Model.Idea));
            int newSN = ExecuteInsert(strCMD, listPara);
            return (newSN);
        }

        public DbBestIdeaModel GetBySN(int SN)
        {
            const string strCMD = "select * from BestIdea where BestIdeaSN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", SN));
            List<DbBestIdeaModel> itemList = ExecuteReader<DbBestIdeaModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                return null;
            }
        }

        public List<DbBestIdeaModel> GetAllByTopicSN(int TopicSN)
        {
            const string strCMD = "select * from BestIdea where TopicSN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", TopicSN));
            List<DbBestIdeaModel> itemList = ExecuteReader<DbBestIdeaModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<DbBestIdeaModel>() { };
            }
        }

        public bool Update(DbBestIdeaModel Model)
        {
            string strCMD = @"
                Update BestIdea set
                    Idea = @Idea
                    ,Description = @Description
                    ,Ranking = @Ranking
                    ,LastUpdate = @LastUpdate
                Where BestIdeaSN = @SN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@Idea", Model.Idea));
            listPara.Add(new SQLiteParameter("@Description", Model.Description));
            listPara.Add(new SQLiteParameter("@Ranking", Model.Ranking));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            listPara.Add(new SQLiteParameter("@SN", Model.SN));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }

        public List<DbBest4DataModel> GetAllViewDataByTopicSN(int TopicSN)
        {
            const string strCMD = @"
                Select b.Type, m.BestIdeaSN, Idea, avg(m.Rank) as Ranking
                From bestidea b inner join bestideamemberrank m
                    on b.bestideaSN = m.BestIdeaSN
                Where b.TopicSN = @TopicSN
                Group by m.BestIdeaSN, b.Idea, b.Type order by avg(m.Rank) desc";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            List<DbBest4DataModel> itemList = ExecuteReader<DbBest4DataModel>(CommandType.Text, strCMD, listPara, getDataModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<DbBest4DataModel>() { };
            }
        }

        public void Delete(int BESTSN)
        {
            const string strCMD = @"
                delete bestidea Where b.bestideasn = @BESTSN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@BESTSN", BESTSN));
            ExecuteNonQuery(strCMD, listPara);
        }
    }

    public class DbBestIdeaModel
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
        /// 建立者流水號
        /// </summary>
        public int UserSN;

        /// <summary>
        /// 最後修改時間
        /// </summary>
        public DateTime LastUpdate;

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
        /// 想法
        /// </summary>
        public string Idea;

        /// <summary>
        /// 說明
        /// </summary>
        public string Description;

        /// <summary>
        /// 重要性
        /// </summary>
        public int Ranking;
    }

    public class DbBest4DataModel
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
        public int BestIdeaSN;

        /// <summary>
        /// 想法
        /// </summary>
        public string Idea;

        /// <summary>
        /// 重要性
        /// </summary>
        public decimal Ranking;
    }
}