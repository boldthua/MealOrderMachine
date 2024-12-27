using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Contexts;
using static 點餐機.Menus;

namespace 點餐機.Strategies
{
    internal class SpecialpriceStrategy : APromotionStrategy
    {
        public SpecialpriceStrategy(List<Item> items, Menus.Discountstrategy strategy) : base(items, strategy)
        {
        }

        public override void DisCount()
        {
            Menus.Specialprice type = this.strategy.SpecialPrice;
            Item item1 = items.FirstOrDefault(x => x.name == type.item1);
            Item item2 = items.FirstOrDefault(x => x.name == type.item2);

            if (item2 != null && item2.quantity < type.item2Amount) // item2 數量不足直接跳出
                return;
            if (item1 != null && item1.quantity >= type.item1Amount)
            {
                int specialPriceCount = item1.quantity / type.item1Amount;
                if (item2.name != null)
                {
                    specialPriceCount = Math.Min((item1.quantity / type.item1Amount), (item2.quantity / type.item2Amount));
                }
                items.Add(new Item("(特價)" + strategy.discountName, type.price - (item1.price + item2.price), specialPriceCount));
            }
        }
    }
}
