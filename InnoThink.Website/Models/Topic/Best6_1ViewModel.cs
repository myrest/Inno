using InnoThink.Core.DB;
using System.Collections.Generic;

namespace InnoThink.Website.Models
{
    public class Best6_1ViewModel : ResultBase
    {
        public int TopicSN { get; set; }

        public List<DbBestGAPModel> GAPListing { get; set; }

        public List<DbBestGAPIdeaModel> GAPIdeaListing { get; set; }
    }
}