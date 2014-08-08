namespace InnoThink.Domain.TeamGroup
{
    #region interface

    public interface ITeamGroup_Info
    {
        string GroupName { get; set; }

        string LastUpdate { get; set; }

        int SN { get; set; }
    }

    #endregion interface

    #region Implementation

    [Rest.Core.PetaPoco.TableName("TeamGroup")]
    [Rest.Core.PetaPoco.PrimaryKey("SN")]
    public class TeamGroup_Info : ITeamGroup_Info
    {
        #region private fields

        public string GroupName { get; set; }

        public string LastUpdate { get; set; }

        public int SN { get; set; }

        #endregion private fields

        #region Constructor

        public TeamGroup_Info()
        {
        }

        #endregion Constructor
    }

    public class TeamGroup_Filter
    {
        //You can copy above TeamGroup_Info field for search criteria
    }

    #endregion Implementation
}