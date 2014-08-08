using InnoThink.Core.DB;
using System.Collections.Generic;

namespace InnoThink.Website.Models
{
    public class Best6ViewModel : ResultBase
    {
        public int TopicSN { get; set; }

        public List<DbBestGAPModel> GAPListing { get; set; }

        public List<DbBest6DataModel> Listing { get; set; }
    }
}