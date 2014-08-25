using InnoThink.Core.Constancy;
using System.Collections.Generic;
using System.Runtime.Serialization;
using InnoThink.Domain.Constancy;

namespace InnoThink.Core.Model.Topic
{
    [DataContract]
    public class SignalRMessageUnitModel
    {
        [DataMember(Name = "t")]
        public SignalRMessageType MessageType { get; set; }

        [DataMember(Name = "d")]
        public MessageUnit data { get; set; }
    }

    [DataContract]
    public class MessageUnit
    {
        [DataMember(Name = "sn")]
        public int SN { get; set; }

        [DataMember(Name = "pic")]
        public string Picture { get; set; }

        [DataMember(Name = "n")]
        public string Name { get; set; }

        [DataMember(Name = "pro")]
        public string Professional { get; set; }

        [DataMember(Name = "des")]
        public string Description { get; set; }

        //Dictionary<使用者流水號, 得票數>
        [DataMember(Name = "ls")]
        public Dictionary<int, int> Votes { get; set; }

        [DataMember(Name = "ln")]
        public string LeaderName { get; set; }
    }
}