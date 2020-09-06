using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineRules
{
    public abstract class SetRule
    {
        public abstract int setRules(int len, List<char> skuID = null);
    }

    class SetRuleOfA:SetRule
    {
        public override int setRules(int len, List<char> skuID)
        {
            int temp = 0;
            int cost = 0;
            int rem = 0;
            temp = len / 3;
            rem = len % 3;

            if (temp >= 1)
                cost = temp * 130;

            return cost + rem * 50;
        }
    }

    class SetRuleOfB : SetRule
    {
        public override int setRules(int len, List<char> skuID)
        {
            int temp = 0;
            int cost = 0;
            int rem = 0;
            temp = len / 2;
            rem = len % 2;

            if (temp >= 1)
                cost = temp * 45;

            return cost + rem * 30;

        }
    }

    class SetRuleOfC : SetRule
    {
        public override int setRules(int len, List<char> skuID)
        {
            return len * 15;
        }
    }

    class SetRuleOfD : SetRule
    {
        public override int setRules(int len, List<char> skuID)
        {
            return len * 15;
        }
    }

    class SetRuleOfCAndD : SetRule
    {
        public override int setRules(int len, List<char> skuID)
        {
            var ob = skuID.GroupBy(x => x).Where(x => x.Key == 'C' || x.Key == 'D').Select(y => new
            {
                PromotionName = y.Key,
                PromotionCount = y.Count()
            }).ToList();

            int cost = 0;
            int temp = 0;
            int cCount = ob.Count() >= 1 ? ob[0].PromotionCount : 0;
            int dCount = ob.Count() == 2 ? ob[1].PromotionCount : 0;

            if (cCount == dCount)
            {
                cost = cost + cCount * 30;
            }
            else if(cCount > dCount)
            {
                temp = cCount - dCount;
                cost = cost + dCount * 30;
                cost = cost + new SetRuleOfC().setRules(temp, null);
            }
            else if (dCount > cCount)
            {
                temp = dCount - cCount;
                cost = cost + cCount * 30;
                cost = cost + new SetRuleOfC().setRules(temp, null);
            }

            return cost;
        }
    }
}
