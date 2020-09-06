using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineRules
{
    class PromotionManager : IPromotion
    {
        public int SetPromotion(List<char> SkuId)
        {
            var ob = SkuId.GroupBy(x => x).Select(y => new
            {
                PromotionName = y.Key,
                PromotionCount = y.Count()
            }).ToList();

            int aCount = ob[0].PromotionCount;
            int bCount = ob[1].PromotionCount;
            List<SetRule> setRules = new List<SetRule>();
            setRules.Add(new SetRuleOfA());
            setRules.Add(new SetRuleOfB());
            setRules.Add(new SetRuleOfCAndD());

            int count = setRules[0].setRules(aCount) + setRules[1].setRules(bCount) + setRules[2].setRules(0, SkuId);

            return count;
        }
    }
}
