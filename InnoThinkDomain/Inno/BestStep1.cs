using System;

namespace InnoThink.Domain.BestStep1
{
    #region interface

    public interface IBestStep1_Info
    {
        string Category { get; set; }

        string Description { get; set; }

        string Image { get; set; }

        DateTime LastUpdate { get; set; }

        string Related { get; set; }

        int SN { get; set; }

        int TopicSN { get; set; }

        int UserSN { get; set; }
    }

    #endregion interface

    #region Implementation

    [Rest.Core.PetaPoco.TableName("BestStep1")]
    [Rest.Core.PetaPoco.PrimaryKey("SN")]
    public class BestStep1_Info : IBestStep1_Info
    {
        #region private fields

        public string Category { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime LastUpdate { get; set; }

        public string Related { get; set; }

        public int SN { get; set; }

        public int TopicSN { get; set; }

        public int UserSN { get; set; }

        #endregion private fields

        #region Constructor

        public BestStep1_Info()
        {
        }

        #endregion Constructor
    }

    public class BestStep1_Filter
    {
        //You can copy above BestStep1_Info field for search criteria
    }

    #endregion Implementation
}