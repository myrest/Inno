using InnoThink.Core.DB;
using System.Collections.Generic;

namespace InnoThink.Website.Models
{
    public class ResultRankCommentListModel : ResultBase
    {
        public int TopicSN { get; set; }

        public List<ResultRankCommentUI> Listing { get; set; }
    }
}