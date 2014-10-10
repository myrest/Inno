using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace InnoThink.Domain
{
    /*
    #region interface
    public interface IBoard_Info
    {
        int BoardSN { get; set; }
        string Content { get; set; }
        int ContentType { get; set; }
        DateTime DateCreated { get; set; }
        int PublishType { get; set; }
        int TopicSN { get; set; }
        int UserSN { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("Board")]
    [Rest.Core.PetaPoco.PrimaryKey("BoardSN")]
    [DataContract]
    public class Board_Info //: IBoard_Info
    {
        #region private fields
        public int BoardSN { get; set; }
        [DataMember(Name = "msg")]
        public string Content { get; set; }
        public int ContentType { get; set; }
        public DateTime DateCreated { get; set; }
        public int PublishType { get; set; }
        public int TopicSN { get; set; }
        public int UserSN { get; set; }
        #endregion

        #region Constructor
        public Board_Info()
        {
        }
        #endregion
    }

    public class Board_Filter
    {
        public int? BoardSN { get; set; }
        public string Content { get; set; }
        public int? ContentType { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? PublishType { get; set; }
        public int? TopicSN { get; set; }
        public int? UserSN { get; set; }
        //You can copy/modify above Board_Info field for search criteria
    }
    #endregion
}