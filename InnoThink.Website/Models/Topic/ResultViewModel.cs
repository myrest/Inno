using InnoThink.Core.DB;
using System.Collections.Generic;

namespace InnoThink.Website.Models
{
    public class ResultViewModel : ResultBase
    {
        public int TopicSN { get; set; }

        public List<DbResultsModel> Listing { get; set; }
    }
}