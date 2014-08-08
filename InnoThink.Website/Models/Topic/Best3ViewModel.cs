using InnoThink.Core.DB;
using System.Collections.Generic;

namespace InnoThink.Website.Models
{
    public class Best3ViewModel : ResultBase
    {
        public int TopicSN { get; set; }

        public List<DbBestIdeaMemRankModel> Listing { get; set; }
    }
}