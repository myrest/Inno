using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.Results
{
    #region interface
    public interface IResults_Info
    {
        string Column1 { get; set; }
        string Column2 { get; set; }
        string Column3 { get; set; }
        string Column4 { get; set; }
        int IsImage { get; set; }
        string LastUpdate { get; set; }
        int Result { get; set; }
        string ServerFileName { get; set; }
        int SN { get; set; }
        int TopicSN { get; set; }
        string UserFileName { get; set; }
        string UserSN { get; set; }
    }
    #endregion

    #region Implementation
    [Rest.Core.PetaPoco.TableName("Results")]
    [Rest.Core.PetaPoco.PrimaryKey("SN")]
    public class Results_Info : IResults_Info
    {
        #region private fields
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public int IsImage { get; set; }
        public string LastUpdate { get; set; }
        public int Result { get; set; }
        public string ServerFileName { get; set; }
        public int SN { get; set; }
        public int TopicSN { get; set; }
        public string UserFileName { get; set; }
        public string UserSN { get; set; }
        #endregion

        #region Constructor
        public Results_Info()
        {
        }
        #endregion
    }

    public class Results_Filter
    {
        //You can copy above Results_Info field for search criteria
    }
    #endregion
}
