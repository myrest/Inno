using System;
using System.Linq;
using System.Runtime.Serialization;
using EShopManager.Core.Utility;
using System.Collections.Generic;
using EShopManager.Core.DB;
using EShopManager.Core.Model.Topic;

namespace EShopManager.Website.Models
{
    [DataContract]
    public class ScenarioCharResultViewModel : ResultBase
    {
        private int _UserSN { get; set; }
        
        public ScenarioCharResultViewModel(int UserSN)
        {
            _UserSN = UserSN;
        }

        public int TopicSN { get; set; }
        //Char listing.
        public List<DbScenarioCharModel> Listing { get; set; }
        //Story listing.
        public List<DbResultsModel> Descriptions { get; set; }


        [DataMember(Name = "vp")]
        public List<DbScenarioCharValueModel> ValuePotion { get; set; }

        /**********Below method is for UI only, support get method.***************/
        //Current UserSN's Char. get the datat from Listing.
        [DataMember(Name = "info")]
        public DbScenarioCharModel Data
        {
            set { throw new Exception("This method is blocked."); }
            get
            {
                DbScenarioCharModel rtn = new DbScenarioCharModel() { };
                if (Listing != null && Listing.Count() > 0)
                {
                    rtn = Listing.Where(x => x.UserSN == _UserSN).FirstOrDefault();
                    if (rtn == null)
                    {
                        rtn = new DbScenarioCharModel() { };
                    }
                }
                return rtn;
            }
        }
        //Listing is for UI using purpose.
        [DataMember(Name = "d")]
        public List<ScenarioDescript> AllDescript
        {
            set { throw new Exception("This method is blocked."); }
            get
            {
                if (Descriptions != null && Descriptions.Count() > 0)
                {
                    return Descriptions.Select(x => new ScenarioDescript()
                    {
                        Descript = x.Column2,
                        IsImage = x.IsImage,
                        ServerFileName = x.ServerFileName,
                        UserFileName = x.UserFileName,
                        SN = x.SN,
                        UserSN = x.UserSN
                    }).ToList();
                }
                else
                {
                    return new List<ScenarioDescript>() { };
                }
            }
        }
    }

    [DataContract]
    public class ScenarioDescript
    {
        /// <summary>
        /// 流水號
        /// </summary>
        [DataMember(Name = "sn")]
        public int SN;

        /// <summary>
        /// 使用者流水號
        /// </summary>
        [DataMember(Name = "usn")]
        public int UserSN;

        /// <summary>
        /// 欄位2, 說明
        /// </summary>
        [DataMember(Name = "desc")]
        public string Descript;

        /// <summary>
        /// 附件位置
        /// </summary>
        [DataMember(Name = "fn")]
        public string ServerFileName;

        /// <summary>
        /// 使用者附件名稱
        /// </summary>
        [DataMember(Name = "ufn")]
        public string UserFileName;

        /// <summary>
        /// 附件是否為圖檔? 0:否, 1:是
        /// </summary>
        [DataMember(Name = "isim")]
        public int IsImage;
    }
}