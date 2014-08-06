using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.Core.Model.Topic
{
    //第1單元介紹：認識朋友-1 --> "團隊成員介紹"
    public class TeamMemberUIModel
    {
        public int UserSn { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Professional { get; set; }
        public string Picture { get; set; }
        public int LeaderVotoToSN { get; set; }
        public string LeaderVotoToUserName { get; set; }
        public string HandleJob { get; set; }
        public int VoteNums { get; set; }
    }
}
