using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Strategies;

namespace 點餐機.Contexts
{
    internal class DisCountContext
    {
        private APromotionStrategy promotion;
        public DisCountContext(APromotionStrategy promotion) 
        {
            this.promotion = promotion;
        }

        public void DisCount()
        {
            promotion.DisCount();
        }
    }
}
