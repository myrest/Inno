using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SQLite;
using EShopManager.Core.Constancy;
using EShopManager.Core.Utility;
using EShopManager.Core.Model;
using EShopManager.Core.Model.Topic;
using Rest.Core.Utility;

namespace EShopManager.Core.DB
{
    public class DbTeamGroupTable : BaseDAO
    {
        private readonly static SysLog log = SysLog.GetLogger(typeof(DbTeamGroupTable));

        public DbTeamGroupTable()
        {
            base.init(typeof(DbTeamGroupTable).ToString(), DataBaseName.InnoThinkMain);
        }

        private List<DbTeamGroupModel> getModuleCallBack(SQLiteDataReader sdr)
        {
            List<DbTeamGroupModel> listResult = new List<DbTeamGroupModel>() { };
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    listResult.Add(new DbTeamGroupModel()
                    {
                        SN = Convert.ToInt32(sdr["SN"].ToString()),
                        LastUpdate = DateTime.Parse(sdr["LastUpdate"].ToString()),
                        GroupName = sdr["GroupName"].ToString()
                    });
                }
            }
            return listResult;
        }

        public bool AddNewGroupName(string Name)
        {
            const string strCMD = @"insert into TeamGroup 
            (
                GroupName, LastUpdate
            ) 
            values 
            (
                @GroupName, @LastUpdate
            )";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@GroupName", Name));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }

        public DbTeamGroupModel getTeamGroupBySN(int SN)
        {
            const string strCMD = "select * from TeamGroup where SN = @SN";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@SN", SN));
            List<DbTeamGroupModel> itemList = ExecuteReader<DbTeamGroupModel>(CommandType.Text, strCMD, listPara, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList[0];
            }
            else
            {
                log.Debug(string.Format("TeamGroup found. SN : [{0}]", SN));
                return new DbTeamGroupModel() { };
            }
        }

        public List<DbTeamGroupModel> getAllTeamGroup()
        {
            const string strCMD = "select * from TeamGroup";
            List<DbTeamGroupModel> itemList = ExecuteReader<DbTeamGroupModel>(strCMD, getModuleCallBack);
            if (itemList.Count > 0)
            {
                return itemList;
            }
            else
            {
                return new List<DbTeamGroupModel>() { };
            }
        }

        public bool CheckNameIsExist(string Name)
        {
            int nums = ExecuteReaderCount<string>("TeamGroup", "GroupName", Name);
            if (nums == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Update(DbTeamGroupModel obj)
        {
            string strCMD = @"
                Update TeamGroup set
                    GroupName = @GroupName
                    ,LastUpdate = @LastUpdate
                Where SN = @SN
            ";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>() { };
            listPara.Add(new SQLiteParameter("@GroupName", obj.GroupName));
            listPara.Add(new SQLiteParameter("@LastUpdate", DateTime.Now));
            listPara.Add(new SQLiteParameter("@SN", obj.SN));
            int icnt = ExecuteNonQuery(strCMD, listPara);
            return (icnt > 0);
        }
    }


    public class DbTeamGroupModel
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public int SN;
        /// <summary>
        /// 團隊名稱
        /// </summary>
        public string GroupName;
        /// <summary>
        /// 最後更新日期
        /// </summary>
        public DateTime LastUpdate;
    }


}
