using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace InnoThink.Core.BLLModel
{
    [DataContract]
    public class KeyValue
    {
        [DataMember(Name = "k")]
        public string Key { get; set; }

        [DataMember(Name = "v")]
        public string Value { get; set; }

    }
}
