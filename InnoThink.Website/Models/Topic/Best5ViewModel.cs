using InnoThink.Core.DB;
using System.Collections.Generic;

namespace InnoThink.Website.Models
{
    public class Best5ViewModel : ResultBase
    {
        public int TopicSN { get; set; }

        public List<DbBestIdeaGroupRankModel> Listing { get; set; }
    }
}