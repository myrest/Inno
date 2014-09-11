using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnoThink.Domain.InnoThinkMain.Binding;
using InnoThink.Domain.Constancy;
using InnoThink.DAL.InnoThinkMain.Binding;

namespace InnoThink.BLL.InnoThinkMain.Binding
{
    public class LikerScaleBindingBLL
    {
        private LikerScaleBindingDAL repo = new LikerScaleBindingDAL();
        public List<LikerScaleBindingView> GetUserRankByType(int TopicSN, int UserSN, EnumLikertScaleType LSType)
        {
            return repo.GetUserRankByType(TopicSN, UserSN, LSType);
        }
    }
}
