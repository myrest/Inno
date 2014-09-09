using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnoThink.Domain.InnoThinkMain.Binding;
using Rest.Core;
using Rest.Core.Constancy;
using InnoThink.Domain.Constancy;

namespace InnoThink.DAL.InnoThinkMain.Binding
{
    public class LikerScaleBindingDAL
    {
        public List<LikerScaleBindingView> GetUserRankByType(int TopicSN, int UserSN, EnumLikertScale LSType)
        {
            var CategoaryTypes = GetCategoaryTypes(LSType);
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append(@"
                    select a.AnalysisSN as ItemSN, a.AnalysisType as CategoryType, ifnull(l.Rank,0) as Rank,
                    a.Column1 as ItemName, a.Column2 as ItemDescript
                     from analysis a left join LikertScale l on a.AnalysisSN = l.ParentSN and a.UserSN = l.UserSN
                    where a.TopicSN = @0 and a.UserSN = @1 and a.AnalysisType in (@Types)
                    order by a.AnalysisType, ItemSN
                ", TopicSN, UserSN, new { Types = CategoaryTypes });

                var result = db.Query<LikerScaleBindingFlate>(SQLStr);
                if (result != null && result.Count() > 0)
                {
                    List<LikerScaleBindingView> rtn = new List<LikerScaleBindingView>(){};
                    result.ToList().ForEach(x =>
                    {
                        LikerScaleBindingObject itemInLine = new LikerScaleBindingObject()
                        {
                            ItemName = x.ItemName,
                            ItemDescript = x.ItemDescript,
                            ItemSN = x.ItemSN,
                            Rank = x.Rank
                        };
                        if (!rtn.Any(y => y.CategoryType == x.CategoryType))
                        {
                            rtn.Add(new LikerScaleBindingView()
                            {
                                CategoryType = x.CategoryType,
                                Item = new List<LikerScaleBindingObject>()
                                {
                                    itemInLine
                                }
                            });
                        }
                        else
                        {
                            rtn.Where(y => y.CategoryType == x.CategoryType).FirstOrDefault().Item.Add(itemInLine);
                        }
                    });
                    GetCategoaryName(rtn);
                    return rtn;
                }
                else
                {
                    return null;
                }
            }
        }

        private int[] GetCategoaryTypes(EnumLikertScale LSType)
        {
            switch (LSType)
            {
                case EnumLikertScale.Analysis1:
                    List<int> ids = new List<int>() { 
                        (int)EnumAnalysisType.CurrentFuntional, 
                        (int)EnumAnalysisType.CurrentRequest,
                        (int)EnumAnalysisType.NewFuntional,
                        (int)EnumAnalysisType.NewRequest
                    };
                    return ids.ToArray();
                default:
                    return null;
            }
        }

        private void GetCategoaryName(List<LikerScaleBindingView> data)
        {
            data.ForEach(x =>
            {
                switch ((EnumAnalysisType)x.CategoryType)
                {
                    case EnumAnalysisType.CurrentFuntional:
                        x.CategoryName = "現有功能分析";
                        break;
                    case EnumAnalysisType.CurrentRequest:
                        x.CategoryName = "現有需求分析";
                        break;
                    case EnumAnalysisType.NewFuntional:
                        x.CategoryName = "新功能分析";
                        break;
                    case EnumAnalysisType.NewRequest:
                        x.CategoryName = "新需求分析";
                        break;
                }
            });

        }
    }
}
