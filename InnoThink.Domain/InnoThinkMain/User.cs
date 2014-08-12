using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.User
{
    /*
    #region interface
    public interface IUser_Info
    {
        string Encode { get; set; }
        DateTime LastUpdate { get; set; }
        string LoginId { get; set; }
        string Password { get; set; }
        string Picture { get; set; }
        string Professional { get; set; }
        int Status { get; set; }
        int TeamGroupSN { get; set; }
        string UserName { get; set; }
        int UserSN { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("User")]
    [Rest.Core.PetaPoco.PrimaryKey("UserSN")]
    public class User_Info //: IUser_Info
    {
        #region private fields
        public string Encode { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public string Professional { get; set; }
        public int Status { get; set; }
        public int TeamGroupSN { get; set; }
        public string UserName { get; set; }
        public int UserSN { get; set; }
        #endregion

        #region Constructor
        public User_Info()
        {
            LastUpdate = DateTime.Now;
        }
        #endregion
    }

    public class User_Filter
    {
        public string LoginId { get; set; }
        public int? Status { get; set; }
        public int? TeamGroupSN { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    #endregion
}
