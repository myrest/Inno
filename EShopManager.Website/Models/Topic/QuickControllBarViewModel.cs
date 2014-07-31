using System;
using System.Runtime.Serialization;
using EShopManager.Core.Utility;
using System.Collections.Generic;
using EShopManager.Core.DB;
using EShopManager.Core.Model.Topic;

namespace EShopManager.Website.Models
{
    public class QuickControllBarViewModel
    {
        public bool isFirstStep { get;set; }
        public bool isLastStep { get; set; }
        public string ControlMainTitle { get; set; }
        public string ControlSubTitle { get; set; }
    }
}