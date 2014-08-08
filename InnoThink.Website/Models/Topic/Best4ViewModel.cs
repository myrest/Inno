using InnoThink.Core.DB;
using System.Collections.Generic;

namespace InnoThink.Website.Models
{
    public class Best4ViewModel : ResultBase
    {
        public int TopicSN { get; set; }

        public List<DbBest4DataModel> Listing { get; set; }

        public List<DbBestIdeaGroup> GroupListing { get; set; }
    }
}