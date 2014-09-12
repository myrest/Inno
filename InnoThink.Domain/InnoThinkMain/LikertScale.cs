using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InnoThink.Domain
{
    /*
    #region interface
    public interface ILikertScale_Info
    {
        int LikertScaleSN { get; set; }
        int LikertScaleType { get; set; }
        int ParentSN { get; set; }
        int Rank { get; set; }
        int UserSN { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("LikertScale")]
    [Rest.Core.PetaPoco.PrimaryKey("LikertScaleSN")]
    public class LikertScale_Info //: ILikertScale_Info
    {
        #region private fields
        public int LikertScaleSN { get; set; }
        public int LikertScaleType { get; set; }
        public int ParentSN { get; set; }
        public int Rank { get; set; }
        public int UserSN { get; set; }
        #endregion

        #region Constructor
        public LikertScale_Info()
        {
        }
        #endregion
    }

    public class LikertScale_Filter
    {
        public int? LikertScaleSN { get; set; }
        public int? LikertScaleType { get; set; }
        public int? ParentSN { get; set; }
        public int? Rank { get; set; }
        public int? UserSN { get; set; }
        public List<int> Parents { get; set; }
        //You can copy/modify above LikertScale_Info field for search criteria
    }
    #endregion
}