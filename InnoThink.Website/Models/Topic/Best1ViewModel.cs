using InnoThink.Core.DB;
using System.Collections.Generic;

namespace InnoThink.Website.Models
{
    public class Best1ViewModel : ResultBase
    {
        public int TopicSN { get; set; }

        public List<DbBestStep1Model> Listing { get; set; }
    }
}