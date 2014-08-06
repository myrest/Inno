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
using Rest.Core.Utility;

namespace InnoThink.Core.DB
{
    public class DbBestGAPTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbBestGAPTable));
        //private readonly static DbBestIdeaTable dbBestIdea = new DbBestIdeaTable() { };
        private readonly static DbBestIdeaGroupTable dbBestIdeaGrp = new DbBestIdeaGroupTable() { };
        private static Dictionary<int, DbBestIdeaGroup> BestIdeaGroupCache = new Dictionary<int, DbBestIdeaGroup>() { };

        public DbBestGAPTable()
        {
            base.init(typeof(DbBestGAPTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private void ClearBestIdeaGroupCache()
        {
            BestIdeaGroupCache.Clear();
        }

        private string GetIdeaBySN(int BestIdeaGroupSN)
        {
            if (BestIdeaGroupCache.Keys.Contains(BestIdeaGroupSN))
            {
                return BestIdeaGroupCache[BestIdeaGroupSN].GroupName;
            }
            else
            {
                var idea = dbBestIdeaGrp.GetALLByBestIdeaGroupSN(BestIdeaGroupSN);
                BestIdeaGroupCache.Add(BestIdeaGroupSN, idea);
                return idea.GroupName;
            }
        }

        private List<DbBestGAPModel> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbBestGAPModel> listResult = new List<DbBestGAPModel>() { };
            if (sdr.HasRows)
            {
                ClearBestIdeaGroupCache();
                while (sdr.Read())
                {
                    //split BestIdeaGroupSNs.
                    List<DbBestGAPMemberModel> GroupMember = new List<DbBestGAPMemberModel>() { };
                    sdr["BestIdeaGroupSNs"].ToString().Split(new char[] { ',' }).ToList().ForEach(x =>
                    {
                        int sn = Convert.ToInt32(x);
                        GroupMember.Add(new DbBestGAPMemberModel()
                        {
                            BestIdeaGroupSN = sn,
                            Idea = GetIdeaBySN(sn)
                        });
                    });

                    listResult.Add(new DbBestGAPModel()
                    {
                        MyGAP = sdr["MyGAP"].ToString(),
                        IdeaDetails = GroupMember,
                        SN = Convert.ToInt32(sdr["SN"].ToString()),
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
        public int Add(DbBestGAPModel Model)
        {
            string[] BestIdeaGroupSNs_arr = Model.IdeaDetails.Select(x => x.BestIdeaGroupSN.ToString()).ToArray();
            string BestIdeaGroupSNs = string.Join(",", BestIdeaGroupSNs_arr);

            string strCMD = @"insert into BestGAP
            (
                TopicSN, MyGAP, Description, Document, BestIdeaGroupSNs, UserSN, LastUpdate
            ) 
            values 
            (
                @TopicSN, @MyGAP, @Description, @Document, @BestIdeaGroupSNs, @UserSN, @LastUpdate
            )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", Model.TopicSN));
            listPara.Add(new SQLiteParameter("@MyGAP", Model.MyGAP));
            listPara.Add(new SQLiteParameter("@Description", Model.Description));
            listPara.Add(new SQLiteParameter("@Document", Model.Document));
            listPara.Add(new SQLiteParameter("@BestIdeaGroupSNs", BestIdeaGroupSNs));
            listPara.Add(new SQLiteParameter("@UserSN", Model.UserSN));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            int newSN = ExecuteInsert(strCMD, listPara);

            if (!string.IsNullOrEmpty(Model.Document))
            {
                //Copy file
                string FileSource = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadTempFolder, Model.Document);
                string NewName = "Best6" + newSN + Path.GetExtension(FileSource);
                string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadBestGAP, NewName);
                FileInfo f = new FileInfo(FileSource);
                f.MoveTo(FileDisc);
                //Set the image to new filename.
                Model.Document = NewName;
                //Update image to new filename.
                strCMD = "Update BestGAP set Document = @Document where SN = @SN";
                listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@Document", NewName));
                listPara.Add(new SQLiteParameter("@SN", newSN));
                ExecuteNonQuery(strCMD, listPara);
            }

            return (newSN);
        }

        public List<DbBestGAPModel> GetALLByTopicSN(int TopicSN)
        {
            const string strCMD = "select * from BestGAP where TopicSN = @TopicSN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            List<DbBestGAPModel> itemList = ExecuteReader<DbBestGAPModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return null;
            }
        }

        public DbBestGAPModel GetByBestGAPSN(int BestGAPSN)
        {
            const string strCMD = "select * from BestGAP where SN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", BestGAPSN));
            List<DbBestGAPModel> itemList = ExecuteReader<DbBestGAPModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                return null;
            }
        }

        public void InsertOrReplace(DbBestGAPModel Model)
        {
            var obj = GetByBestGAPSN(Model.SN);
            if (obj != null)
            {
                Update(Model);
            }
            else
            {
                Add(Model);
            }
        }

        private bool Update(DbBestGAPModel Model)
        {
            string[] BestIdeaGroupSNs_arr = Model.IdeaDetails.Select(x => x.BestIdeaGroupSN.ToString()).ToArray();
            string BestIdeaGroupSNs = string.Join(",", BestIdeaGroupSNs_arr);

            string strCMD = @"
                Update BestGAP set
                    MyGAP = @MyGAP
                    ,BestIdeaGroupSNs = @BestIdeaGroupSNs
                    ,Description = @Description
                    ,Document = @Document
                Where SN = @SN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@MyGAP", Model.MyGAP));
            listPara.Add(new SQLiteParameter("@BestIdeaGroupSNs", BestIdeaGroupSNs));
            listPara.Add(new SQLiteParameter("@Description", Model.Description));
            listPara.Add(new SQLiteParameter("@Document", Model.Document));
            listPara.Add(new SQLiteParameter("@SN", Model.SN));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }
    }

    public class DbBestGAPMemberModel
    {
        public int BestIdeaGroupSN;
        public string Idea;
    }

    public class DbBestGAPModel
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
        public List<DbBestGAPMemberModel> IdeaDetails;
    }


}
