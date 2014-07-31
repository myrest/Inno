using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.Users
{
    #region interface
    public interface IUsers_Info
    {
        string LastUpdate { get; set; }
        string LoginId { get; set; }
        string Password { get; set; }
        string Picture { get; set; }
        int Position { get; set; }
        string Professional { get; set; }
        int SN { get; set; }
        int Status { get; set; }
        string TeamGroupSN { get; set; }
        string UserName { get; set; }
    }
    #endregion

    #region Implementation
    [Rest.Core.PetaPoco.TableName("Users")]
    [Rest.Core.PetaPoco.PrimaryKey("SN")]
    public class Users_Info : IUsers_Info
    {
        #region private fields
        public string LastUpdate { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public int Position { get; set; }
        public string Professional { get; set; }
        public int SN { get; set; }
        public int Status { get; set; }
        public string TeamGroupSN { get; set; }
        public string UserName { get; set; }
        #endregion

        #region Constructor
        public Users_Info()
        {
        }
        #endregion
    }

    public class Users_Filter
    {
        //You can copy above Users_Info field for search criteria
    }
    #endregion
}
