using System;

namespace InnoThink.Domain.ResultsRank
{
    #region interface

    public interface IResultsRank_Info
    {
        string Comment { get; set; }

        DateTime LastUpdate { get; set; }

        int Ranking { get; set; }

        int Results_SN { get; set; }

        int User_SN { get; set; }
    }

    #endregion interface

    #region Implementation

    [Rest.Core.PetaPoco.TableName("ResultsRank")]
    [Rest.Core.PetaPoco.PrimaryKey("")]
    public class ResultsRank_Info : IResultsRank_Info
    {
        #region private fields

        public string Comment { get; set; }

        public DateTime LastUpdate { get; set; }

        public int Ranking { get; set; }

        public int Results_SN { get; set; }

        public int User_SN { get; set; }

        #endregion private fields

        #region Constructor

        public ResultsRank_Info()
        {
        }

        #endregion Constructor
    }

    public class ResultsRank_Filter
    {
        //You can copy above ResultsRank_Info field for search criteria
    }

    #endregion Implementation
}