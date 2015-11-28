using CWB.Web.Configuration;
using InnoThink.Core.BLLModel;
using InnoThink.Core.Constancy;
using InnoThink.Core.Utility;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using InnoThink.Domain.Constancy;
using Rest.Core.Constancy;

namespace InnoThink.Core.DB
{
    public class DbScenarioTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbScenarioTable));

        public DbScenarioTable()
        {
            base.init(typeof(DbScenarioTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private List<DbScenarioCharModel> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbScenarioCharModel> listResult = new List<DbScenarioCharModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbScenarioCharModel()
                    {
                        SN = Convert.ToInt32(sdr["ScenarioCharSN"].ToString()),
                        LastUpdate = DateTime.Parse(sdr["LastUpdate"].ToString()),
                        AgeRang = (AgeRangType)Convert.ToInt32(sdr["AgeRang"].ToString()),
                        Career = sdr.IsDBNull(7) ? "" : sdr.GetString(7),// sdr["Career"].ToString(),
                        Edu = (EduType)Convert.ToInt32(sdr["Edu"].ToString()),
                        Gender = (GenderType)Convert.ToInt32(sdr["Gender"].ToString()),
                        NickName = sdr["NickName"].ToString(),
                        Personality = sdr["Personality"].ToString(),
                        Salary = (SalaryType)Convert.ToInt32(sdr["Salary"].ToString()),
                        Subject = sdr["Subject"].ToString(),
                        IsImage = Convert.ToInt32(sdr["IsImage"].ToString()),
                        ServerFileName = sdr["ServerFileName"].ToString(),
                        UserFileName = sdr["UserFileName"].ToString(),
                        TopicSN = Convert.ToInt32(sdr["TopicSN"].ToString()),
                        UserSN = Convert.ToInt32(sdr["UserSN"].ToString()),
                        UserName = sdr["UserName"].ToString(),
                        Type = (ScenarioType)Convert.ToInt16(sdr["ScenarioType"].ToString())
                    });
                    //listResult.Last().LastUpdate = DateTime.Parse(sdr["LastUpdate"].ToString());
                }
            }
            return listResult;
        }

        private List<DbScenarioCharValueModel> getVPModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbScenarioCharValueModel> listResult = new List<DbScenarioCharValueModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbScenarioCharValueModel()
                    {
                        LastUpdate = DateTime.Parse(sdr["LastUpdate"].ToString()),
                        Description = sdr["Description"].ToString(),
                        ScenarioCharSN = Convert.ToInt32(sdr["ScenarioCharSN"].ToString()),
                        UserSN = Convert.ToInt32(sdr["UserSN"].ToString()),
                        SN = Convert.ToInt32(sdr["ScenarioCharValuesSN"].ToString()),
                    });
                    //listResult.Last().LastUpdate = DateTime.Parse(sdr["LastUpdate"].ToString());
                }
            }
            return listResult;
        }

        private List<ScenarioRankModel> getScenarioRankAvgUICallBack(SQLiteDataReader sdr)
        {
            List<ScenarioRankModel> rtn = new List<ScenarioRankModel>() { };
            List<KeyValue> listResult = new List<KeyValue>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    string Title = sdr["Title"].ToString();
                    string ItemName = sdr["ItemName"].ToString();
                    string ItemValue = sdr["ItemValue"].ToString();
                    ScenarioRankModel obj = rtn.Where(x => x.Title == Title).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.Data.Add(new KeyValue()
                        {
                            Key = ItemName,
                            Value = ItemValue
                        });
                    }
                    else
                    {
                        List<KeyValue> subitem = new List<KeyValue>() { };
                        subitem.Add(new KeyValue()
                        {
                            Key = ItemName,
                            Value = ItemValue
                        });
                        obj = new ScenarioRankModel()
                        {
                            Title = Title,
                            Data = subitem
                        };
                        rtn.Add(obj);
                    }
                }
            }
            return rtn;
        }

        /// <summary>
        /// Insert new record.
        /// </summary>
        /// <param name="Model">object which will be inserted.</param>
        /// <returns>The new record's SN.</returns>
        public int Add(DbScenarioCharModel Model)
        {
            string strCMD = @"insert into ScenarioChar
            (
                TopicSN, NickName, Gender, AgeRang, Edu, Salary, Personality, Subject, Career, ServerFileName, UserFileName, IsImage, UserSN, LastUpdate, ScenarioType
            )
            values
            (
                @TopicSN, @NickName, @Gender, @AgeRang, @Edu, @Salary, @Personality, @Subject, @Career, @ServerFileName, @UserFileName, @IsImage, @UserSN, @LastUpdate, @ScenarioType
            )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", Model.TopicSN));
            listPara.Add(new SQLiteParameter("@AgeRang", Model.AgeRang));
            listPara.Add(new SQLiteParameter("@Career", Model.Career));
            listPara.Add(new SQLiteParameter("@Edu", Model.Edu));
            listPara.Add(new SQLiteParameter("@Gender", Model.Gender));
            listPara.Add(new SQLiteParameter("@NickName", Model.NickName));
            listPara.Add(new SQLiteParameter("@Personality", Model.Personality));
            listPara.Add(new SQLiteParameter("@Salary", Model.Salary));
            listPara.Add(new SQLiteParameter("@Subject", Model.Subject));
            listPara.Add(new SQLiteParameter("@ServerFileName", Model.ServerFileName));
            listPara.Add(new SQLiteParameter("@UserFileName", Model.UserFileName));
            listPara.Add(new SQLiteParameter("@IsImage", Model.IsImage));
            listPara.Add(new SQLiteParameter("@UserSN", Model.UserSN));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            listPara.Add(new SQLiteParameter("@ScenarioType", Model.Type));

            int newSN = ExecuteInsert(strCMD, listPara);
            Model.SN = newSN;
            if (!string.IsNullOrEmpty(Model.ServerFileName))
            {
                //Copy file
                string targetSetting = AppConfigManager.SystemSetting.FileUpLoadScenario;
                string FileSource = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, AppConfigManager.SystemSetting.FileUpLoadTempFolder, Model.ServerFileName);
                string NewName = string.Format("{0}{1}_{2}{3}", "Scenario", Model.TopicSN, Model.SN, Path.GetExtension(Model.ServerFileName));
                string FileDisc = string.Format("{0}/{1}/{2}", HttpRuntime.AppDomainAppPath, targetSetting, NewName);
                FileInfo f = new FileInfo(FileSource);
                f.MoveTo(FileDisc);
                //Set the image to new filename.
                Model.ServerFileName = NewName;
                //Update image to new filename.
                strCMD = @"Update ScenarioChar set
                            ServerFileName = @ServerFileName
                            , UserFileName = @UserFileName
                            , IsImage = @IsImage
                            Where ScenarioCharSN = @SN";
                listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@ServerFileName", Model.ServerFileName));
                listPara.Add(new SQLiteParameter("@UserFileName", Model.UserFileName));
                listPara.Add(new SQLiteParameter("@IsImage", Model.IsImage));
                listPara.Add(new SQLiteParameter("@SN", newSN));
                ExecuteNonQuery(strCMD, listPara);
            }
            return (newSN);
        }

        public DbScenarioCharModel GetBySN(int SN)
        {
            const string strCMD = "select a.*, b.UserName from ScenarioChar a inner join User b on a.UserSN = b.UserSN where a.ScenarioCharSN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", SN));
            List<DbScenarioCharModel> itemList = ExecuteReader<DbScenarioCharModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                return null;
            }
        }

        public List<DbScenarioCharModel> GetAllByTopicSN(int TopicSN, ScenarioType Type)
        {
            const string strCMD = "select a.*, b.UserName from ScenarioChar a inner join User b on a.UserSN = b.UserSN where a.TopicSN = @TopicSN and a.ScenarioType = @ScenarioType";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            listPara.Add(new SQLiteParameter("@ScenarioType", Type));
            List<DbScenarioCharModel> itemList = ExecuteReader<DbScenarioCharModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return null;
            }
        }

        public bool Update(DbScenarioCharModel Model)
        {
            string strCMD = @"
                Update ScenarioChar set
                    ServerFileName = @ServerFileName
                    , UserFileName = @UserFileName
                    , IsImage = @IsImage
                    , LastUpdate = @LastUpdate
                    , NickName = @NickName
                    , Gender = @Gender
                    , AgeRang = @AgeRang
                    , Edu = @Edu
                    , Salary = @Salary
                    , Personality = @Personality
                    , Subject = @Subject
                    , Career = @Career
                Where ScenarioCharSN = @SN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@ServerFileName", Model.ServerFileName));
            listPara.Add(new SQLiteParameter("@UserFileName", Model.UserFileName));
            listPara.Add(new SQLiteParameter("@IsImage", Model.IsImage));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            listPara.Add(new SQLiteParameter("@NickName", Model.NickName));
            listPara.Add(new SQLiteParameter("@Gender", Model.Gender));
            listPara.Add(new SQLiteParameter("@AgeRang", Model.AgeRang));
            listPara.Add(new SQLiteParameter("@Edu", Model.Edu));
            listPara.Add(new SQLiteParameter("@Salary", Model.Salary));
            listPara.Add(new SQLiteParameter("@Personality", Model.Personality));
            listPara.Add(new SQLiteParameter("@Career", Model.Career));
            listPara.Add(new SQLiteParameter("@Subject", Model.Subject));
            listPara.Add(new SQLiteParameter("@SN", Model.SN));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }

        #region Scenario char values

        /// <summary>
        /// Insert new record.
        /// </summary>
        /// <param name="Model">object which will be inserted.</param>
        /// <returns>The new record's SN.</returns>
        public int AddValue(DbScenarioCharValueModel Model)
        {
            string strCMD = @"insert into ScenarioCharValues
            (
                ScenarioCharSN, Description, LastUpdate, UserSN
            )
            values
            (
                @ScenarioCharSN, @Description, @LastUpdate, @UserSN
            )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@ScenarioCharSN", Model.ScenarioCharSN));
            listPara.Add(new SQLiteParameter("@Description", Model.Description));
            listPara.Add(new SQLiteParameter("@UserSN", Model.UserSN));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));

            int newSN = ExecuteInsert(strCMD, listPara);
            return (newSN);
        }

        public bool UpdateValue(DbScenarioCharValueModel Model)
        {
            string strCMD = @"
                Update ScenarioCharValues set
                    Description = @Description
                    , LastUpdate = @LastUpdate
                    , UserSN = @UserSN
                    , ScenarioCharSN = @ScenarioCharSN
                Where ScenarioCharValuesSN = @SN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@Description", Model.Description));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            listPara.Add(new SQLiteParameter("@UserSN", Model.UserSN));
            listPara.Add(new SQLiteParameter("@ScenarioCharSN", Model.ScenarioCharSN));
            listPara.Add(new SQLiteParameter("@SN", Model.SN));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }

        public List<DbScenarioCharValueModel> GetAllVPByScenarioCharSN(int ScenarioCharSN)
        {
            const string strCMD = "select * from ScenarioCharValues where ScenarioCharSN = @ScenarioCharSN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@ScenarioCharSN", ScenarioCharSN));
            List<DbScenarioCharValueModel> itemList = ExecuteReader<DbScenarioCharValueModel>(CommandType.Text, strCMD, listPara, getVPModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return null;
            }
        }

        #endregion Scenario char values

        #region Scenario char values Rank

        private List<DbScenarioCharValueRankModel> getScenarioCharValueRankCallBack(SQLiteDataReader sdr)
        {
            List<DbScenarioCharValueRankModel> listResult = new List<DbScenarioCharValueRankModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbScenarioCharValueRankModel()
                    {
                        //LastUpdate = DateTime.Parse(sdr["LastUpdate"].ToString()),
                        Rank = Convert.ToInt32(sdr["Rank"].ToString()),
                        ScenarioCharValueSN = Convert.ToInt32(sdr["ScenarioCharValueSN"].ToString()),
                        UserSN = Convert.ToInt32(sdr["UserSN"].ToString()),
                        Description = sdr["Description"].ToString(),
                        Subject = sdr["Subject"].ToString(),
                        UserName = sdr["UserName"].ToString()
                    });
                    //listResult.Last().LastUpdate = DateTime.Parse(sdr["LastUpdate"].ToString());
                }
            }
            return listResult;
        }

        private List<ScenarioCharValueRankUI> getScenarioCharValueRankUICallBack(SQLiteDataReader sdr)
        {
            List<ScenarioCharValueRankUI> rtn = new List<ScenarioCharValueRankUI>() { };
            List<DbScenarioCharValueRankModel> listResult = getScenarioCharValueRankCallBack(sdr);
            if (listResult != null && listResult.Count > 0)
            {
                listResult.ForEach(x =>
                {
                    var ui = rtn.Where(y => y.Subject == x.Subject).FirstOrDefault();
                    if (ui == null)
                    {
                        List<DbScenarioCharValueRankModel> item = new List<DbScenarioCharValueRankModel>() { };
                        item.Add(x);
                        rtn.Add(new ScenarioCharValueRankUI()
                        {
                            Subject = x.Subject,
                            Values = item
                        });
                    }
                    else
                    {
                        ui.Values.Add(x);
                    }
                });
            }
            return rtn;
        }

        public List<ScenarioCharValueRankUI> GetRankByUserSN(int TopicSN, ScenarioType type, int UserSN)
        {
            const string strCMD = @"
                Select ifnull(y.ScenarioCharValuesSN, 0) as ScenarioCharValueSN,
                    u.UserName, x.UserSN,
                    ifnull((select rank from ScenarioCharValuesRank where ScenarioCharValueSN = y.ScenarioCharValuesSN and UserSN = @UserSN),0) as rank,
                    x.subject, y.Description
                from ScenarioChar x left join ScenarioCharValues y
                    on x.ScenarioCharSN = y.ScenarioCharSN
                    inner join User u on u.UserSN = x.UserSN
                where x.TopicSN = @TopicSN and ScenarioType = @ScenarioType
                order by x.ScenarioCharSN, y.ScenarioCharValuesSN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            listPara.Add(new SQLiteParameter("@ScenarioType", type));
            listPara.Add(new SQLiteParameter("@UserSN", UserSN));
            List<ScenarioCharValueRankUI> itemList = ExecuteReader<ScenarioCharValueRankUI>(CommandType.Text, strCMD, listPara, getScenarioCharValueRankUICallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return null;
            }
        }

        public void InsertOrReplaceScenarioCharValueRank(DbScenarioCharValueRankModel model)
        {
            Dictionary<string, string> para = new Dictionary<string, string>() { };
            para.Add("UserSN", model.UserSN.ToString());
            para.Add("ScenarioCharValueSN", model.ScenarioCharValueSN.ToString());
            int rcnt = ExecuteReaderCount("ScenarioCharValuesRank", para);
            if (rcnt == 0)
            {
                //Add
                const string strCMD = @"insert into ScenarioCharValuesRank
                    (
                        ScenarioCharValueSN, Rank, LastUpdate, UserSN
                    )
                    values
                    (
                        @ScenarioCharValueSN, @Rank, @LastUpdate, @UserSN
                    )";
                List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@ScenarioCharValueSN", model.ScenarioCharValueSN));
                listPara.Add(new SQLiteParameter("@Rank", model.Rank));
                listPara.Add(new SQLiteParameter("@UserSN", model.UserSN));
                listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
                int newSN = ExecuteInsert(strCMD, listPara);
            }
            else
            {
                //Update
                const string strCMD = @"Update ScenarioCharValuesRank
                                        Set Rank = @Rank,
                                            LastUpdate = @LastUpdate
                                        Where ScenarioCharValueSN = @ScenarioCharValueSN
                                        And UserSN = @UserSN
                ";
                List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@ScenarioCharValueSN", model.ScenarioCharValueSN));
                listPara.Add(new SQLiteParameter("@Rank", model.Rank));
                listPara.Add(new SQLiteParameter("@UserSN", model.UserSN));
                listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
                ExecuteNonQuery(strCMD, listPara);
            }
        }

        public List<ScenarioRankModel> GetCharValueAvgRankByTopic(int TopicSN, ScenarioType type)
        {
            const string strCMD = @"
                    Select u.UserName as Title, b.Description as ItemName, Avg(c.Rank) as ItemValue
                    From  ScenarioChar a
                        Inner join ScenarioCharValues b on a.ScenarioCharSN = b.ScenarioCharSN
                        Inner join ScenarioCharValuesRank c on c.ScenarioCharValueSN = b.ScenarioCharValuesSN
                        Inner join User u on u.UserSN = a.UserSN
                    Where a.TopicSN = @TopicSN and a.ScenarioType = @ScenarioType
                    Group by u.UserName, c.ScenarioCharValueSN
                    Order by u.UserSN, Avg(c.Rank) desc
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            listPara.Add(new SQLiteParameter("@ScenarioType", type));
            List<ScenarioRankModel> itemList = ExecuteReader<ScenarioRankModel>(CommandType.Text, strCMD, listPara, getScenarioRankAvgUICallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return null;
            }
        }

        #endregion Scenario char values Rank

        #region Scenario char rank

        public List<ScenarioCharValueRankUI> GetCharRankByTopic(int TopicSN, ScenarioType type, int UserSN)
        {
            //Here ScenarioCharValueSN actually is ScenarioCharSN
            const string strCMD = @"
                Select x.ScenarioCharSN as ScenarioCharValueSN,
                    u.UserName, x.UserSN,
                    ifnull(	(select rank from ScenarioCharRank where ScenarioCharSN = x.ScenarioCharSN and UserSN = @UserSN),0) as Rank,
                    '' as subject, u.UserName as Description
                from User u left join ScenarioChar x
                    on u.UserSN = x.UserSN
                where x.TopicSN = @TopicSN and x.ScenarioType = @ScenarioType
                order by x.ScenarioCharsn
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            listPara.Add(new SQLiteParameter("@ScenarioType", type));
            listPara.Add(new SQLiteParameter("@UserSN", UserSN));
            List<ScenarioCharValueRankUI> itemList = ExecuteReader<ScenarioCharValueRankUI>(CommandType.Text, strCMD, listPara, getScenarioCharValueRankUICallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return null;
            }
        }

        public void InsertOrReplaceScenarioCharRank(DbScenarioCharValueRankModel model)
        {
            //in Char voteting, ScenarioCharValueSN eq ScenarioCharSN
            Dictionary<string, string> para = new Dictionary<string, string>() { };
            para.Add("UserSN", model.UserSN.ToString());
            para.Add("ScenarioCharSN", model.ScenarioCharValueSN.ToString());
            int rcnt = ExecuteReaderCount("ScenarioCharRank", para);
            if (rcnt == 0)
            {
                //Add
                const string strCMD = @"insert into ScenarioCharRank
                    (
                        ScenarioCharSN, Rank, LastUpdate, UserSN
                    )
                    values
                    (
                        @ScenarioCharSN, @Rank, @LastUpdate, @UserSN
                    )";
                List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@ScenarioCharSN", model.ScenarioCharValueSN));
                listPara.Add(new SQLiteParameter("@Rank", model.Rank));
                listPara.Add(new SQLiteParameter("@UserSN", model.UserSN));
                listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
                int newSN = ExecuteInsert(strCMD, listPara);
            }
            else
            {
                //Update
                const string strCMD = @"Update ScenarioCharRank
                                        Set Rank = @Rank,
                                            LastUpdate = @LastUpdate
                                        Where ScenarioCharSN = @ScenarioCharSN
                                        And UserSN = @UserSN
                ";
                List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@ScenarioCharSN", model.ScenarioCharValueSN));
                listPara.Add(new SQLiteParameter("@Rank", model.Rank));
                listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
                listPara.Add(new SQLiteParameter("@UserSN", model.UserSN));
                ExecuteNonQuery(strCMD, listPara);
            }
        }

        public List<ScenarioRankModel> GetCharAvgRankByTopic(int TopicSN, ScenarioType type)
        {
            const string strCMD = @"
                    Select '' as Title, u.UserName as ItemName, Avg(a.Rank) as ItemValue from ScenarioCharRank a
                        Inner Join ScenarioChar b on a.ScenarioCharSN = b.ScenarioCharSN
                        Inner Join User u on b.UserSN = u.UserSN
                    Where b.TopicSN = @TopicSN and b.ScenarioType = @ScenarioType
                    Group by b.UserSN
                    Order by Avg(a.Rank) Desc
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            listPara.Add(new SQLiteParameter("@ScenarioType", type));
            List<ScenarioRankModel> itemList = ExecuteReader<ScenarioRankModel>(CommandType.Text, strCMD, listPara, getScenarioRankAvgUICallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return null;
            }
        }

        #endregion Scenario char rank
    }

    [DataContract]
    public class DbScenarioCharModel
    {
        /// <summary>
        /// 流水號
        /// </summary>
        [DataMember(Name = "sn")]
        public int SN;

        /// <summary>
        /// 議題流水號
        /// </summary>
        public int TopicSN;

        /// <summary>
        /// 暱稱
        /// </summary>
        [DataMember(Name = "nk")]
        public string NickName;

        /// <summary>
        /// 性別
        /// </summary>
        public GenderType Gender;

        [DataMember(Name = "gui")]
        public string GenderUI
        {
            set { throw new Exception("This method is blocked."); }
            get
            {
                if (Gender == GenderType.Male)
                {
                    return "男";
                }
                else
                {
                    return "女";
                }
            }
        }

        /// <summary>
        /// 年齡
        /// </summary>
        public AgeRangType AgeRang;

        [DataMember(Name = "aui")]
        public string AgeRangUI
        {
            set { throw new Exception("This method is blocked."); }
            get
            {
                switch (AgeRang)
                {
                    case AgeRangType.Be11_17:
                        return "11~17歲";

                    case AgeRangType.Be18_25:
                        return "11~25歲";

                    case AgeRangType.Be26_30:
                        return "26~30歲";

                    case AgeRangType.Be31_40:
                        return "31~40歲";

                    case AgeRangType.Be41_50:
                        return "41~50歲";

                    case AgeRangType.Be51_60:
                        return "51~60歲";

                    case AgeRangType.Over61:
                        return "60歲以上";

                    case AgeRangType.Under10:
                        return "10歲以下";

                    case AgeRangType.Be11_20:
                        return "11~20歲";

                    case AgeRangType.Be21_30:
                        return "21~30歲";
                    default:
                        return "未知";
                }
            }
        }

        /// <summary>
        /// 教育程度
        /// </summary>
        public EduType Edu;

        [DataMember(Name = "eui")]
        public string EduUI
        {
            set { throw new Exception("This method is blocked."); }
            get
            {
                switch (Edu)
                {
                    case EduType.Doctor:
                        return "博士";

                    case EduType.Elementary:
                        return "國小";

                    case EduType.JuniorHighSchool:
                        return "國中";

                    case EduType.Kindergarten:
                        return "幼稚園";

                    case EduType.Master:
                        return "研究所";

                    case EduType.SeniorHighSchool:
                        return "高中";

                    case EduType.University:
                        return "大學";

                    default:
                        return "其它";
                }
            }
        }

        /// <summary>
        /// 月薪
        /// </summary>
        public SalaryType Salary;

        [DataMember(Name = "saui")]
        public string SalaryUI
        {
            set { throw new Exception("This method is blocked."); }
            get
            {
                switch (Salary)
                {
                    case SalaryType.Over70k:
                        return "70,001 以上";

                    case SalaryType.Under10k:
                        return "10,000 以下";

                    case SalaryType.Under20k:
                        return "10,001 ~ 20,000";

                    case SalaryType.Under30k:
                        return "20,001 ~ 30,000";

                    case SalaryType.Under40k:
                        return "30,001 ~ 40,000";

                    case SalaryType.Under50k:
                        return "40,001 ~ 50,000";

                    case SalaryType.Under60k:
                        return "50,001 ~ 60,000";

                    case SalaryType.Under70k:
                        return "60,001 ~ 70,000";

                    default:
                        return "未知";
                }
            }
        }

        /// <summary>
        /// 人格
        /// </summary>
        [DataMember(Name = "p")]
        public string Personality;

        /// <summary>
        /// 議題
        /// </summary>
        [DataMember(Name = "su")]
        public string Subject;

        /// <summary>
        /// 職業
        /// </summary>
        [DataMember(Name = "c")]
        public string Career;

        /// <summary>
        /// 長相
        /// </summary>
        [DataMember(Name = "fn")]
        public string ServerFileName;

        /// <summary>
        /// 長相
        /// </summary>
        [DataMember(Name = "ufn")]
        public string UserFileName;

        /// <summary>
        /// 附件是否為圖檔? 0:否, 1:是
        /// </summary>
        [DataMember(Name = "isi")]
        public int IsImage;

        /// <summary>
        /// 建立者流水號
        /// </summary>
        public int UserSN;

        /// <summary>
        /// 最後修改時間
        /// </summary>
        public DateTime LastUpdate;

        /// <summary>
        /// 使者者名稱
        /// </summary>
        [DataMember(Name = "un")]
        public string UserName;

        public ScenarioType Type;
    }

    [DataContract]
    public class ScenarioRankModel
    {
        [DataMember(Name = "t")]
        public string Title;

        [DataMember(Name = "d")]
        public List<KeyValue> Data;
    }

    [DataContract]
    public class DbScenarioCharValueRankModel
    {
        /// <summary>
        /// When subject is emtpy, the ScenarioCharValueSN is mean ScenarioCharSN, it for vote Char which is import.
        /// </summary>
        [DataMember(Name = "scvsn")]
        public int ScenarioCharValueSN;

        [DataMember(Name = "usn")]
        public int UserSN;

        [DataMember(Name = "r")]
        public int Rank;

        [DataMember(Name = "un")]
        public string UserName;

        //Below is for UI using purpose.
        public string Subject;

        public string Description;
    }

    [DataContract]
    public class ScenarioCharValueRankUI
    {
        [DataMember(Name = "vs")]
        public List<DbScenarioCharValueRankModel> Values;

        [DataMember(Name = "s")]
        public string Subject;
    }

    [DataContract]
    public class DbScenarioCharValueModel
    {
        [DataMember(Name = "sn")]
        public int SN;

        [DataMember(Name = "scsn")]
        public int ScenarioCharSN;

        [DataMember(Name = "usn")]
        public int UserSN;

        [DataMember(Name = "des")]
        public string Description;

        public DateTime LastUpdate;
    }
}