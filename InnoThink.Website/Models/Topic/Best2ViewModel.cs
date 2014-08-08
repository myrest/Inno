using InnoThink.Core.DB;
using System.Collections.Generic;

namespace InnoThink.Website.Models
{
    public class Best2ViewModel : ResultBase
    {
        public int TopicSN { get; set; }

        public List<DbBestIdeaModel> Listing { get; set; }
    }
}