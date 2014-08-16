using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.InnoThinkMain.Binding
{
    public class TopicMemberUI : TopicMember_Info
    {
        public string UserName { get; set; }

        public string Professional { get; set; }

        public string Picture { get; set; }

        public string LeaderVotoToUserName { get; set; }

        public int VoteNums { get; set; }
    }
}
