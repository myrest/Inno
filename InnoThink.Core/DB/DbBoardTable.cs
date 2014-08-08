using InnoThink.Core.Constancy;
using InnoThink.Core.Utility;
using Rest.Core.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Runtime.Serialization;

namespace InnoThink.Core.DB
{
    public class DbBoardTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbBoardTable));

        public DbBoardTable()
        {
            base.init(typeof(DbBoardTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private List<DbBoardTableModel> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbBoardTableModel> listResult = new List<DbBoardTableModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbBoardTableModel()
                    {
                        TopicSN = Convert.ToInt32(sdr["TopicSN"].ToString()),
                        UserSN = Convert.ToInt32(sdr["UsersSN"].ToString()),
                        Content = sdr["UsersSN"].ToString(),
                        DateCreated = (DateTime)sdr["DateCreated"],
                        PublishType = Convert.ToInt32(sdr["PublishType"].ToString())
                    });
                }
            }
            return listResult;
        }

        private List<DbBoardContent> getContentCallBack(SQLiteDataReader sdr)
        {
            List<DbBoardContent> listResult = new List<DbBoardContent>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbBoardContent()
                    {
                        TopicSN = Convert.ToInt32(sdr["TopicSN"].ToString()),
                        UserSN = Convert.ToInt32(sdr["UserSN"].ToString()),
                        Content = sdr["Content"].ToString(),
                        DateCreated = DateTime.Parse(sdr["DateCreated"].ToString()),
                        PublishType = Convert.ToInt32(sdr["PublishType"].ToString()),
                        UserIcon = StringUtility.ConvertPicturePath(sdr["Picture"].ToString()),
                        UserName = sdr["UserName"].ToString(),
                        UserLoginId = sdr["LoginId"].ToString()
                    });
                }
            }
            return listResult;
        }

        public List<DbBoardContent> GetContent(int TopicSN)
        {
            // PublishType --> 發布範圍，0 -> 內部，1 -> 外部
            int PublishType = 0;
            string strCMD = string.Empty;
            strCMD = @"select b.*, u.UserName, u.LoginId, b.UserSN, b.Picture
                        from board b inner join Users u on b.UserSN = U.SN
                        Where b.TopicSN = @TopicSN
                            and b.PublishType = @PublishType
                        ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            listPara.Add(new SQLiteParameter("@PublishType", PublishType));
            var itemList = ExecuteReader<DbBoardContent>(CommandType.Text, strCMD, listPara, getContentCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<DbBoardContent>() { };
            }
        }

        public List<DbBoardContent> GetAllDataByPublishType(int PublishType)
        {
            // PublishType --> 發布範圍，0 -> 內部，1 -> 外部
            string strCMD = string.Empty;
            strCMD = @"select b.*, u.UserName, u.LoginId, b.UserSN, u.Picture
                        from board b inner join Users u on b.UserSN = U.SN
                        Where b.PublishType = @PublishType
                        ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@PublishType", PublishType));
            var itemList = ExecuteReader<DbBoardContent>(CommandType.Text, strCMD, listPara, getContentCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<DbBoardContent>() { };
            }
        }

        /// <summary>
        /// Update board
        /// </summary>
        /// <param name="para">All the board need to insert into DB</param>
        /// <param name="PublishType">0 -> private, 1 -> Public</param>
        public void UpdateBoard(List<DbBoardTableModel> para, int TopicSN, int PublishType)
        {
            //Delete all the data
            string strCMD = "Delete from Board where TopicSN = @TopicSN and PublishType = @PublishType";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
            listPara.Add(new SQLiteParameter("@PublishType", PublishType));
            ExecuteNonQuery(strCMD, listPara);

            para.ForEach(x =>
            {
                strCMD = "Insert into Board (DateCreated, UserSN, Content, TopicSN, PublishType) values (@DateCreated, @UserSN, @Content, @TopicSN, @PublishType)";
                listPara = new List<SQLiteParameter>() { };
                listPara.Add(new SQLiteParameter("@DateCreated", DateTime.Now));
                listPara.Add(new SQLiteParameter("@UserSN", x.UserSN));
                listPara.Add(new SQLiteParameter("@Content", x.Content));
                listPara.Add(new SQLiteParameter("@TopicSN", TopicSN));
                listPara.Add(new SQLiteParameter("@PublishType", PublishType));
                ExecuteNonQuery(strCMD, listPara);
            });
        }
    }

    [DataContract]
    public class DbBoardContent : DbBoardTableModel
    {
        /// <summary>
        /// 使用者圖片
        /// </summary>
        [DataMember(Name = "icon")]
        public string UserIcon { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [DataMember(Name = "un")]
        public string UserName { get; set; }

        /// <summary>
        /// 使用者登入ID
        /// </summary>
        [DataMember(Name = "uid")]
        public string UserLoginId { get; set; }
    }

    [DataContract]
    public class DbBoardTableModel
    {
        /// <summary>
        /// 建立時間日期
        /// </summary>
        public DateTime DateCreated;

        /// <summary>
        /// 建立時間，專供UI顯示用
        /// </summary>
        [DataMember(Name = "dt")]
        public string DateCreatedUI
        {
            get
            {
                return DateCreated.ToString("HH:mm:ss");
            }
        }

        /// <summary>
        /// 使用者水號
        /// </summary>
        [DataMember(Name = "usn")]
        public int UserSN;

        /// <summary>
        /// 內容
        /// </summary>
        [DataMember(Name = "msg")]
        public string Content;

        /// <summary>
        /// 討論議題流水號
        /// </summary>
        public int TopicSN;

        /// <summary>
        /// 發布範圍，0 -> 內部，1 -> 外部
        /// </summary>
        public int PublishType;
    }
}