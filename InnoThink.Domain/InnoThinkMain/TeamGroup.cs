using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.TeamGroup
{
    /*
    #region interface
    public interface ITeamGroup_Info
    {
        string GroupName { get; set; }
        string LastUpdate { get; set; }
        int MaxUsers { get; set; }
        int TeamGroupSN { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("TeamGroup")]
    [Rest.Core.PetaPoco.PrimaryKey("TeamGroupSN")]
    public class TeamGroup_Info //: ITeamGroup_Info
    {
        #region private fields
        public string GroupName { get; set; }
        public string LastUpdate { get; set; }
        public int MaxUsers { get; set; }
        public int TeamGroupSN { get; set; }
        #endregion

        #region Constructor
        public TeamGroup_Info()
        {
        }
        #endregion
    }

    public class TeamGroup_Filter
    {
        //You can copy above TeamGroup_Info field for search criteria
    }
    #endregion
}
