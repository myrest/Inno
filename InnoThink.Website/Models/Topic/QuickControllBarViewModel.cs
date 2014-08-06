using System;
using System.Runtime.Serialization;
using InnoThink.Core.Utility;
using System.Collections.Generic;
using InnoThink.Core.DB;
using InnoThink.Core.Model.Topic;

namespace InnoThink.Website.Models
{
    public class QuickControllBarViewModel
    {
        public bool isFirstStep { get;set; }
        public bool isLastStep { get; set; }
        public string ControlMainTitle { get; set; }
        public string ControlSubTitle { get; set; }
    }
}