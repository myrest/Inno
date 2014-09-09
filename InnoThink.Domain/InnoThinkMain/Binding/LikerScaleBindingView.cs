using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InnoThink.Domain.InnoThinkMain.Binding
{
    public class LikerScaleBindingFlate
    {
        public int ItemSN { get; set; }
        public string ItemDescript { get; set; }
        public int CategoryType { get; set; }
        public int Rank { get; set; }
        public string ItemName { get; set; }
    }

    public class LikerScaleBindingView
    {
        public int CategoryType { get; set; }
        public string CategoryName { get; set; }
        public List<LikerScaleBindingObject> Item { get; set; }
    }

    public class LikerScaleBindingObject
    {
        public string ItemName { get; set; }
        public string ItemDescript { get; set; }
        public int ItemSN { get; set; }
        public int Rank { get; set; }
    }
}
