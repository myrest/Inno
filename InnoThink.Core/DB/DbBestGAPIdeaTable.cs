using CWB.Web.Configuration;
using InnoThink.Core.Constancy;
using InnoThink.Core.Utility;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using Rest.Core.Constancy;

namespace InnoThink.Core.DB
{
    public class DbBestGAPIdeaTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbBestGAPIdeaTable));

        //private readonly static DbBestIdeaTable dbBestIdea = new DbBestIdeaTable() { };
        private readonly static DbBestGAPTable dbBestGAP = new DbBestGAPTable() { };

        private static Dictionary<int, DbBestGAPModel> BestGAPCache = new Dictionary<int, DbBestGAPModel>() { };

        public DbBestGAPIdeaTable()
        {
            base.init(typeof(DbBestGAPIdeaTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private void ClearBestGAPCache()
        {
            BestGAPCache.Clear();
        }

        private string GetGAPBySN(int BestGAPSN)
        {
            if (BestGAPCache.Keys.Contains(BestGAPSN))
            {
                return BestGAPCache[BestGAPSN].MyGAP;
            }
            else
            {
                var idea = dbBestGAP.GetByBestGAPSN(BestGAPSN);
                if (idea != null)
                {
                    BestGAPCache.Add(BestGAPSN, idea);
                    return idea.MyGAP;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private List<DbBestGAPIdeaModel> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbBestGAPIdeaModel> listResult = new List<DbBestGAPIdeaModel>() { };
            if (sdr.HasRows)
            {
                ClearBestGAPCache();
                while (sdr.Read())
                {
                    //split BestGAPSNs.
                    List<DbBestGAPIdeaMemberModel> GroupMember = new List<DbBestGAPIdeaMemberModel>() { };
                    sdr["BestGAPSNs"].ToString().Split(new char[] { ',' }).ToList().ForEach(x =>
                    {
                        int sn = Convert.ToInt32(x);
                        var idea = GetGAPBySN(sn);
                        if (!string.IsNullOrEmpty(idea))
                        {
                            GroupMember.Add(new DbBestGAPIdeaMemberModel()
                            {
                                BestGAPSN = sn,
                                Idea = idea
                            });
                        }
                    });

                    listResult.Add(new DbBestGAPIdeaModel()
                    {
                        MyGAP = sdr["MyGAP"].ToString(),
                        IdeaDetails = GroupMember,
                        SN = Convert.ToInt32(sdr["BestGAPIdeaSN"].ToString()),
                        TopicSN = Convert.ToInt32(sdr["TopicSN"].ToString()),
                        Description = sdr["Description"].ToString(),
                        Document = sdr["Document"].ToString(),
                        LastUpdate = DateTime.Parse(sdr["LastUpdate"].ToString()),
                        UserSN = Convert.ToInt32(sdr["UserSN"].ToString())
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
        public int Add(DbBestGAPIdeaModel Model)
        {
            string[] BestGAPSNs_arr = Model.IdeaDetails.Select(x => x.BestGAPSN.ToString()).ToArray();
            string BestGAPSNs = string.Join(",", BestGAPSNs_arr);

            string strCMD = @"insert into BestGAPIdea
            (
                TopicSN, MyGAP, Description, Document, BestGAPSNs, UserSN, LastUpdate
            )
            values
            (
                @TopicSN, @MyGAP, @Description, @Document, @BestGAPSNs, @UserSN, @LastUpdate
            )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", Model.TopicSN));
            listPara.Add(new SQLiteParameter("@MyGAP", Model.MyGAP));
            listPara.Add(new SQLiteParameter("@Description", Model.Description));
            listPara.Add(new SQLiteParameter("@Document", Model.Document));
            listPara.Add(new SQLiteParameter("@BestGAPSNs", BestGAPSNs));
            listPara.Add(new SQLiteParameter("@UserSN", Model.UserSN));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            int newSN = ExecuteInsert(strCMD, listPara);

            if (!string.IsNullOrEmpty(Model.Document))
            {
                //Copy file
                string FileSource = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadTempFolder, Model.Document);
                string NewName = "Best6_1" + newSN + Path.GetExtension(FileSource);
                string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadBestGAP, NewName);
                FileInfo f = new FileInfo(FileSource);
                f.MoveTo(FileDisc);
                //Set the image to new filename.
                Model.Document = NewName;
                //Update image to new filename.
                strCMD = "Update BestGAPIdea set Document = @Document where BestGAPIdeaSN = @SN";
                listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@Document", NewName));
                listPara.Add(new SQLiteParameter("@SN", newSN));
                ExecuteNonQuery(strCMD, listPara);
            }

            return (newSN);
        }

        public List<DbBestGAPIdeaModel> GetALLByTopicSN(int TopicSN)
        {
            const string strCMD = "select * from BestGAPIdea where TopicSN = @TopicSN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            List<DbBestGAPIdeaModel> itemList = ExecuteReader<DbBestGAPIdeaModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return null;
            }
        }

        public DbBestGAPIdeaModel GetByBestGAPIdeaSN(int BestGAPIdeaSN)
        {
            const string strCMD = "select * from BestGAPIdea where BestGAPIdeaSN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", BestGAPIdeaSN));
            List<DbBestGAPIdeaModel> itemList = ExecuteReader<DbBestGAPIdeaModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                return null;
            }
        }

        public void InsertOrReplace(DbBestGAPIdeaModel Model)
        {
            var obj = GetByBestGAPIdeaSN(Model.SN);
            if (obj != null)
            {
                Update(Model);
            }
            else
            {
                Add(Model);
            }
        }

        private bool Update(DbBestGAPIdeaModel Model)
        {
            string[] BestGAPSNs_arr = Model.IdeaDetails.Select(x => x.BestGAPSN.ToString()).ToArray();
            string BestGAPSNs = string.Join(",", BestGAPSNs_arr);

            string strCMD = @"
                Update BestGAPIdea set
                    MyGAP = @MyGAP
                    ,BestGAPSNs = @BestGAPSNs
                    ,Description = @Description
                    ,Document = @Document
                Where BestGAPIdeaSN = @SN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@MyGAP", Model.MyGAP));
            listPara.Add(new SQLiteParameter("@BestGAPSNs", BestGAPSNs));
            listPara.Add(new SQLiteParameter("@Description", Model.Description));
            listPara.Add(new SQLiteParameter("@Document", Model.Document));
            listPara.Add(new SQLiteParameter("@SN", Model.SN));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }

        public void Delete(int SN)
        {
            const string strCMD = @"
                delete from BestGAPIdea Where BestGapIdeasn = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", SN));
            ExecuteNonQuery(strCMD, listPara);
        }
    }

    public class DbBestGAPIdeaMemberModel
    {
        public int BestGAPSN;
        public string Idea;
    }

    public class DbBestGAPIdeaModel
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
        /// 我的GAP
        /// </summary>
        public string MyGAP;

        /// <summary>
        /// 內容描述
        /// </summary>
        public string Description;

        /// <summary>
        /// 使用者流水號
        /// </summary>
        public int UserSN;

        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime LastUpdate;

        /// <summary>
        /// 附加檔案，目前限定圖檔
        /// </summary>
        public string Document;

        /// <summary>
        /// Best Idea 群組成員
        /// </summary>
        public List<DbBestGAPIdeaMemberModel> IdeaDetails;
    }
}