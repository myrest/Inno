using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SQLite;
using InnoThink.Core.Constancy;
using InnoThink.Core.Utility;
using InnoThink.Core.Model;
using InnoThink.Core.Model.Topic;
using CWB.Web.Configuration;
using System.IO;
using System.Web;
using System.Drawing;
using System.Runtime.Serialization;
using Rest.Core.Utility;

namespace InnoThink.Core.DB
{
    public class DbResultsTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbResultsTable));

        public DbResultsTable()
        {
            base.init(typeof(DbResultsTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private List<ResultRankCommentUI> getResultRankCommentUICallBack(SQLiteDataReader sdr)
        {
            List<ResultRankCommentUI> listResult = new List<ResultRankCommentUI>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new ResultRankCommentUI()
                    {
                        Comment = sdr["Comment"].ToString(),
                        Image = sdr["Picture"].ToString(),
                        Rank = Convert.ToInt32(sdr["Ranking"].ToString()),
                        UpdateDateTime = DateTime.Parse(sdr["LastUpdate"].ToString()),
                        UserName = sdr["UserName"].ToString()
                    });
                }
            }
            return listResult;
        }

        private List<DbResultsModel> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbResultsModel> listResult = new List<DbResultsModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int dbTotalVote = Convert.ToInt32(sdr["rcnt"].ToString());
                    decimal dbRanking = Convert.ToDecimal(sdr["Ranking"].ToString());
                    decimal RankingAvg = (dbTotalVote == 0) ? 0 : dbRanking / dbTotalVote;
                    RankingAvg = Math.Round(RankingAvg, 1, MidpointRounding.AwayFromZero);

                    listResult.Add(new DbResultsModel()
                    {
                        SN = Convert.ToInt32(sdr["SN"].ToString()),
                        LastUpdate = DateTime.Parse(sdr["LastUpdate"].ToString()),
                        Column1 = sdr["Column1"].ToString(),
                        Column2 = sdr["Column2"].ToString(),
                        Column3 = sdr["Column3"].ToString(),
                        Column4 = sdr["Column4"].ToString(),
                        IsImage = Convert.ToInt32(sdr["IsImage"].ToString()),
                        Result = EnumHelper.GetEnumByName<ResultType>(sdr["Result"].ToString()),
                        ServerFileName = sdr["ServerFileName"].ToString(),
                        UserFileName = sdr["UserFileName"].ToString(),
                        TopicSN = Convert.ToInt32(sdr["TopicSN"].ToString()),
                        UserSN = Convert.ToInt32(sdr["UserSN"].ToString()),
                        MyRank = Convert.ToInt32(sdr["MyRank"].ToString()),
                        ComNum = Convert.ToInt32(sdr["ComNum"].ToString()),
                        RankingAvg = RankingAvg,
                        TotalVote = dbTotalVote
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
        public int Add(DbResultsModel Model)
        {
            string strCMD = @"insert into Results
            (
                TopicSN, Result, Column1, Column2, Column3, Column4, ServerFileName, UserFileName, IsImage, UserSN, LastUpdate
            ) 
            values 
            (
                @TopicSN, @Result, @Column1, @Column2, @Column3, @Column4, @ServerFileName, @UserFileName, @IsImage, @UserSN, @LastUpdate
            )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", Model.TopicSN));
            listPara.Add(new SQLiteParameter("@Result", (int)Model.Result));
            listPara.Add(new SQLiteParameter("@Column1", Model.Column1));
            listPara.Add(new SQLiteParameter("@Column2", Model.Column2));
            listPara.Add(new SQLiteParameter("@Column3", Model.Column3));
            listPara.Add(new SQLiteParameter("@Column4", Model.Column4));
            listPara.Add(new SQLiteParameter("@ServerFileName", Model.ServerFileName));
            listPara.Add(new SQLiteParameter("@UserFileName", Model.UserFileName));
            listPara.Add(new SQLiteParameter("@IsImage", Model.IsImage));
            listPara.Add(new SQLiteParameter("@UserSN", Model.UserSN));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));

            int newSN = ExecuteInsert(strCMD, listPara);
            if (!string.IsNullOrEmpty(Model.ServerFileName))
            {
                //Copy file
                string FileSource = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadTempFolder, Model.ServerFileName);
                string NewName = string.Format("Result{0}_{1}", newSN, Model.ServerFileName);//Path.GetExtension(Model.UserFileName);
                string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadResult, NewName);
                FileInfo f = new FileInfo(FileSource);
                f.MoveTo(FileDisc);
                //Set the image to new filename.
                Model.ServerFileName = NewName;
                //Update image to new filename.
                strCMD = @"Update Results set 
                            ServerFileName = @ServerFileName
                            , UserFileName = @UserFileName
                            , IsImage = @IsImage
                            Where SN = @SN";
                listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@ServerFileName", Model.ServerFileName));
                listPara.Add(new SQLiteParameter("@UserFileName", Model.UserFileName));
                listPara.Add(new SQLiteParameter("@IsImage", Model.IsImage));
                listPara.Add(new SQLiteParameter("@SN", newSN));
                ExecuteNonQuery(strCMD, listPara);
            }
            return (newSN);
        }

        public DbResultsModel GetBySN(int SN)
        {
            const string strCMD = "select *, 0 as MyRank, 0 as Ranking, 0 as rcnt, 0 as ComNum from Results where SN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", SN));
            List<DbResultsModel> itemList = ExecuteReader<DbResultsModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                return null;
            }
        }

        public List<ResultRankCommentUI> GetAllCommentByResultSN(int ResultSN)
        {
            const string strCMD = @"select u.UserName, u.Picture, r.LastUpdate, r.Ranking, r.Comment
                                    from ResultsRank r inner join Users u on u.SN = r.User_SN
                                    where r.Results_sn = @ResultSN
                                    order by r.LastUpdate desc";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@ResultSN", ResultSN));
            List<ResultRankCommentUI> itemList = ExecuteReader<ResultRankCommentUI>(CommandType.Text, strCMD, listPara, getResultRankCommentUICallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<ResultRankCommentUI>() { };
            }
        }

        public List<DbResultsModel> GetDataByTopicSN_UserSN(int TopicSN, ResultType Result, int UserSN)
        {
            string strCMD = strAllResultCMD.Replace("Where TopicSN = @TopicSN and Result = @Result", "Where TopicSN = @TopicSN and Result = @Result and UserSN = @User_SN");
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@User_SN", UserSN));
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            listPara.Add(new SQLiteParameter("@Result", Result));
            List<DbResultsModel> itemList = ExecuteReader<DbResultsModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<DbResultsModel>() { };
            }
        }

        private readonly string strAllResultCMD = @"select
                                    count(case when length(comment) > 0 then 1 end ) as ComNum,
                                    ifnull((select Ranking from ResultsRank where ResultsRank.User_SN = @User_SN and ResultsRank.Results_SN = rr.Results_SN),0) as MyRank,
                                    r.sn ,r.TopicSN ,r.Result
                                    ,r.Column1 ,r.Column2 ,r.Column3 ,r.Column4
                                    ,r.ServerFileName ,r.UserFileName
                                    ,r.IsImage ,r.UserSN ,r.LastUpdate
                                    ,sum(ifnull(rr.Ranking, 0)) as Ranking
                                    ,count(rr.Ranking) as rcnt
                                    from Results r
                                    left join ResultsRank rr on
                                    r.sn = rr.Results_SN
                                    Where TopicSN = @TopicSN and Result = @Result
                                    group by r.sn ,r.TopicSN ,r.Result
                                    ,r.Column1 ,r.Column2 ,r.Column3 ,r.Column4
                                    ,r.ServerFileName ,r.UserFileName
                                    ,r.IsImage ,r.UserSN ,r.LastUpdate
                                    Order by r.LastUpdate desc
                                    ";

        public List<DbResultsModel> GetAllByTopicSN(int TopicSN, ResultType Result, int UserSN)
        {
            string strCMD = strAllResultCMD;
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@User_SN", UserSN));
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            listPara.Add(new SQLiteParameter("@Result", Result));
            List<DbResultsModel> itemList = ExecuteReader<DbResultsModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<DbResultsModel>() { };
            }
        }

        public bool Update(DbResultsModel Model)
        {
            string strCMD = @"
                Update Results set
                    Column1 = @Column1
                    , Column2 = @Column2
                    , Column3 = @Column3
                    , Column4 = @Column4
                    , ServerFileName = @ServerFileName
                    , UserFileName = @UserFileName
                    , IsImage = @IsImage
                    ,LastUpdate = @LastUpdate
                Where SN = @SN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@Column1", Model.Column1));
            listPara.Add(new SQLiteParameter("@Column2", Model.Column2));
            listPara.Add(new SQLiteParameter("@Column3", Model.Column3));
            listPara.Add(new SQLiteParameter("@Column4", Model.Column4));
            listPara.Add(new SQLiteParameter("@ServerFileName", Model.ServerFileName));
            listPara.Add(new SQLiteParameter("@UserFileName", Model.UserFileName));
            listPara.Add(new SQLiteParameter("@IsImage", Model.IsImage));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            listPara.Add(new SQLiteParameter("@SN", Model.SN));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }

        public DbResultsScoreModel InsertOrReplaceRank(int UserSN, int SN, int Rank, string Comment)
        {
            DbResultsScoreModel rtn = new DbResultsScoreModel() { };
            //check is has data.
            Dictionary<string, string> para = new Dictionary<string, string>() { };
            para.Add("Results_SN", SN.ToString());
            para.Add("User_SN", UserSN.ToString());
            int rcnt = ExecuteReaderCount("ResultsRank", para);
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@ResultsSN", SN));
            listPara.Add(new SQLiteParameter("@User_SN", UserSN));
            listPara.Add(new SQLiteParameter("@Ranking", Rank));
            listPara.Add(new SQLiteParameter("@Comment", Comment));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            if (rcnt == 0)
            {
                //Insert
                const string strCMD = "Insert into ResultsRank (Results_SN, User_SN, Ranking, Comment, LastUpdate) Values (@ResultsSN, @User_SN, @Ranking, @Comment, @LastUpdate)";
                ExecuteNonQuery(strCMD, listPara);
            }
            else
            {
                //Update
                const string strCMD = "Update ResultsRank set Ranking = @Ranking, Comment = @Comment, LastUpdate = @LastUpdate Where Results_SN = @ResultsSN and User_SN = @User_SN";
                ExecuteNonQuery(strCMD, listPara);
            }
            //Get the newst score
            var obj = GetBySN(SN);
            rtn.Result = obj.Result;

            obj = GetAllByTopicSN(obj.TopicSN, obj.Result, obj.UserSN).Where(x => x.SN == SN).FirstOrDefault();
            if (obj != null)
            {
                rtn = new DbResultsScoreModel()
                {
                    Result = obj.Result,
                    Count = obj.TotalVote,
                    ResultSN = obj.SN,
                    TopicSN = obj.TopicSN,
                    Avg = obj.RankingAvg,
                    ComNum = obj.ComNum
                };
            }
            return rtn;
        }
    }

    public class DbResultsScoreModel
    {
        public int TopicSN;
        public int ResultSN;
        public decimal Avg;
        public int Count;
        public int ComNum;
        public ResultType Result;
    }

    public class DbResultsModel
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
        /// 結果類別, 0:草槁, 1:表板, 2:發表 
        /// </summary>
        public ResultType Result;

        /// <summary>
        /// 欄位1, 主旨
        /// </summary>
        public string Column1;

        /// <summary>
        /// 欄位2, 說明
        /// </summary>
        public string Column2;

        /// <summary>
        /// 欄位3, 參考
        /// </summary>
        public string Column3;

        /// <summary>
        /// 欄位4, 備註
        /// </summary>
        public string Column4;

        /// <summary>
        /// 附件位置
        /// </summary>
        public string ServerFileName;

        /// <summary>
        /// 附件檔名
        /// </summary>
        public string UserFileName;

        /// <summary>
        /// 附件是否為圖檔? 0:否, 1:是
        /// </summary>
        public int IsImage;

        /// <summary>
        /// 建立者流水號
        /// </summary>
        public int UserSN;

        /// <summary>
        /// 最後修改時間
        /// </summary>
        public DateTime LastUpdate;


        //Add Ranking in
        //MyRank,Ranking,rcnt
        public int MyRank;
        public decimal RankingAvg;
        public int TotalVote;
        public int CommentNum;
        public int ComNum;
    }

    [DataContract]
    public class ResultRankCommentUI
    {
        [DataMember(Name = "un")]
        public string UserName { get; set; }

        [DataMember(Name = "icon")]
        public string Image { get; set; }

        private DateTime _UpdateDateTime { get; set; }
        public DateTime UpdateDateTime
        {
            get
            {
                return _UpdateDateTime;
            }
            set
            {
                _UpdateDateTime = value;
                DateTimeUI = value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        [DataMember(Name = "dt")]
        public string DateTimeUI{ get; set; }

        [DataMember(Name = "r")]
        public int Rank { get; set; }

        [DataMember(Name = "c")]
        public string Comment { get; set; }
    }

}
