using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InnoThink.Domain.InnoThinkMain.Binding;
using Rest.Core;
using Rest.Core.Utility;
using Rest.Core.Constancy;
using InnoThink.Domain.Constancy;

namespace InnoThink.DAL.InnoThinkMain.Binding
{
    public class LikerScaleBindingDAL
    {
        public List<LikerScaleBindingView> GetUserRankByType(int TopicSN, int UserSN, EnumLikertScaleType LSType)
        {
            var CategoaryTypes = GetCategoaryTypes(LSType);
            using (var db = new DBExecutor().GetDatabase(DataBaseName.InnoThinkMain))
            {
                var SQLStr = Rest.Core.PetaPoco.Sql.Builder
                .Append(@"
                        SELECT A.AnalysisSN AS ItemSN,
                                A.AnalysisType AS CategoryType,
                                A.Column1 AS ItemName,
                                A.Column2 AS ItemDescript,
                                IFNULL((SELECT SLS.rank FROM LikertScale sls WHERE SLS.UserSN = @0 AND SLS.ParentSN = L.ParentSN limit 1),0) AS Rank,
                                (SELECT GROUP_CONCAT(UserName) FROM 
                                        (SELECT UserName FROM LikertScale SLS INNER JOIN User SU ON SLS.UserSN = SU.UserSN 
                                        WHERE SLS.ParentSN = L.ParentSN
                                        GROUP BY UserName )
                                ) AS UserNames
                        FROM Analysis A LEFT JOIN LikertScale L ON A.AnalysisSN = L.ParentSN
                        WHERE A.TopicSN = @1  AND A.AnalysisType IN (@Types)
                        GROUP BY A.AnalysisSN , A.AnalysisType  ,A.Column1 , A.Column2
                ", UserSN, TopicSN, new { Types = CategoaryTypes });

                var result = db.Query<LikerScaleBindingFlate>(SQLStr);
                if (result != null && result.Count() > 0)
                {
                    List<LikerScaleBindingView> rtn = new List<LikerScaleBindingView>(){};
                    result.ToList().ForEach(x =>
                    {
                        var itemInLine = new LikerScaleBindingObject();
                        /*
                        LikerScaleBindingObject itemInLine = new LikerScaleBindingObject()
                        {
                            ItemName = x.ItemName,
                            ItemDescript = x.ItemDescript,
                            ItemSN = x.ItemSN,
                            Rank = x.Rank,
                            UserNames = x.UserNames
                        };*/
                        itemInLine.CloneObject(x);
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

        private int[] GetCategoaryTypes(EnumLikertScaleType LSType)
        {
            switch (LSType)
            {
                case EnumLikertScaleType.Analysis1:
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
