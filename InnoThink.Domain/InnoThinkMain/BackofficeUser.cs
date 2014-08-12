using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain
{
    /*
    #region interface
    public interface IBackofficeUser_Info
    {
        int BackofficeUserSN { get; set; }
        string Encode { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
        int Level { get; set; }
        string LoginId { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("BackofficeUser")]
    [Rest.Core.PetaPoco.PrimaryKey("BackofficeUserSN")]
    public class BackofficeUser_Info //: IBackofficeUser_Info
    {
        #region private fields
        public int BackofficeUserSN { get; set; }
        public string Encode { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        public int Level { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        #endregion

        #region Constructor
        public BackofficeUser_Info()
        {
        }
        #endregion
    }

    public class BackofficeUser_Filter
    {
        public int? BackofficeUserSN { get; set; }
        public string Encode { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        public int? Level { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        //You can copy/modify above BackofficeUser_Info field for search criteria
    }
    #endregion
}