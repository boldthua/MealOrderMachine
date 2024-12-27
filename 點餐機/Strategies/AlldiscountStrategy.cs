using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Contexts;

namespace 點餐機.Strategies
{
    internal class AlldiscountStrategy : APromotionStrategy
    {
        public AlldiscountStrategy(List<Item> items, Menus.Discountstrategy strategy) : base(items, strategy)
        {
        }

        public override void DisCount()
        {
            throw new NotImplementedException();
        }
    }
}
