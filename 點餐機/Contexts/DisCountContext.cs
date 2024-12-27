using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Contexts
{
    internal class DisCountContext
    {
        private APromotionStrategy promotion;
        public DisCountContext(APromotionStrategy promotion) 
        {
            this.promotion = promotion;
        }

        public int GetResult(int price)
        {
            return 0;
        }
    }
}
