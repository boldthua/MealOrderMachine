using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Contexts;
using static 點餐機.Menus;

namespace 點餐機.Strategies
{
    internal class BuyMGetNStrategy : APromotionStrategy
    {
        public BuyMGetNStrategy(List<Item> items, Menus.Discountstrategy strategy) : base(items, strategy)
        {

        }

        public override void DisCount()
        {
            Buymgetn type = this.strategy.BuyMGetN;
            Item item1 = items.FirstOrDefault(x => x.name == type.item1);
            Item item2 = items.FirstOrDefault(x => x.name == type.item2);

            if (item2 != null && item2.quantity < type.item2Amount) // item2 數量不足直接跳出
                return;
            if (item1 != null && item1.quantity >= type.item1Amount)
            {
                int freeCount = item1.quantity / type.item1Amount;
                if (item2.name != null)
                {
                    freeCount = Math.Min((item1.quantity / type.item1Amount), (item2.quantity / type.item2Amount));
                }
                items.Add(new Item("(贈送)" + type.freeItem1, 0, freeCount * type.freeItem1Amount));
                if (type.freeItem2 != "")
                {
                    items.Add(new Item("(贈送)" + type.freeItem2, 0, freeCount * type.freeItem2Amount));
                }
            }
        }   // 買 3個A + 2個 B 送 1個C  + 3個 D
    }     //30個 A + 7個 B 送  freecount 10 >> 3  C*3  D*3
}
