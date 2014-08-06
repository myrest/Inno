using System;
using System.Runtime.Serialization;
using InnoThink.Core.Utility;
using System.Collections.Generic;
using InnoThink.Core.DB;
using InnoThink.Core.Model.Topic;

namespace InnoThink.Website.Models
{
    public class ResultRankCommentListModel : ResultBase
    {
        public int TopicSN { get; set; }
        public List<ResultRankCommentUI> Listing { get; set; }
    }
}