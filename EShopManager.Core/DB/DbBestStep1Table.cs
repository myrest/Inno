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
    public class DbBestStep1Table : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbBestStep1Table));

        public DbBestStep1Table()
        {
            base.init(typeof(DbBestStep1Table).ToString(), DataBaseName.InnoThinkMain);
        }

        private List<DbBestStep1Model> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbBestStep1Model> listResult = new List<DbBestStep1Model>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbBestStep1Model()
                    {
                        SN = Convert.ToInt32(sdr["SN"].ToString()),
                        LastUpdate = DateTime.Parse(sdr["LastUpdate"].ToString()),
                        Category = sdr["Category"].ToString(),
                        Description = sdr["Description"].ToString(),
                        Image = sdr["Image"].ToString(),
                        Related = sdr["Related"].ToString(),
                        TopicSN = Convert.ToInt32(sdr["TopicSN"].ToString()),
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
        public int Add(DbBestStep1Model Model)
        {
            string strCMD = @"insert into BestStep1
            (
                TopicSN, Category, Description, Image, Related, UserSN, LastUpdate
            ) 
            values 
            (
                @TopicSN, @Category, @Description, @Image, @Related, @UserSN, @LastUpdate
            )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", Model.TopicSN));
            listPara.Add(new SQLiteParameter("@Category", Model.Category));
            listPara.Add(new SQLiteParameter("@Description", Model.Description));
            listPara.Add(new SQLiteParameter("@Image", Model.Image));
            listPara.Add(new SQLiteParameter("@Related", Model.Related));
            listPara.Add(new SQLiteParameter("@UserSN", Model.UserSN));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            int newSN = ExecuteInsert(strCMD, listPara);
            if (!string.IsNullOrEmpty(Model.Image))
            {
                //Copy file
                string FileSource = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadTempFolder, Model.Image);
                string NewName = "Best1" + newSN + Path.GetExtension(FileSource);
                string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadBest, NewName);
                FileInfo f = new FileInfo(FileSource);
                f.MoveTo(FileDisc);
                //Set the image to new filename.
                Model.Image = NewName;
                //Update image to new filename.
                strCMD = "Update BestStep1 set Image = @Image where SN = @SN";
                listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@Image", NewName));
                listPara.Add(new SQLiteParameter("@SN", newSN));
                ExecuteNonQuery(strCMD, listPara);
            }
            return (newSN);
        }

        public DbBestStep1Model GetBySN(int SN)
        {
            const string strCMD = "select * from BestStep1 where SN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", SN));
            List<DbBestStep1Model> itemList = ExecuteReader<DbBestStep1Model>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                return null;
            }
        }

        public List<DbBestStep1Model> GetAllByTopicSN(int TopicSN)
        {
            const string strCMD = "select * from BestStep1 where TopicSN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", TopicSN));
            List<DbBestStep1Model> itemList = ExecuteReader<DbBestStep1Model>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<DbBestStep1Model>() { };
            }
        }

        public bool Update(DbBestStep1Model Model)
        {
            string strCMD = @"
                Update BestStep1 set
                    Category = @Category
                    ,Description = @Description
                    ,Image = @Image
                    ,Related = @Related
                    ,LastUpdate = @LastUpdate
                Where SN = @SN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@Category", Model.Category));
            listPara.Add(new SQLiteParameter("@Description", Model.Description));
            listPara.Add(new SQLiteParameter("@Image", Model.Image));
            listPara.Add(new SQLiteParameter("@Related", Model.Related));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            listPara.Add(new SQLiteParameter("@SN", Model.SN));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }
    }


    public class DbBestStep1Model
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
        /// 類別
        /// </summary>
        public string Category;

        /// <summary>
        /// 說明
        /// </summary>
        public string Description;

        /// <summary>
        /// 相關圖檔
        /// </summary>
        public string Image;

        /// <summary>
        /// 參考文獻
        /// </summary>
        public string Related;

        /// <summary>
        /// 建立者流水號
        /// </summary>
        public int UserSN;

        /// <summary>
        /// 最後修改時間
        /// </summary>
        public DateTime LastUpdate;
    }


}
