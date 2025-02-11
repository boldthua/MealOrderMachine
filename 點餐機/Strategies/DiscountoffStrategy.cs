using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Contexts;
using static 點餐機.Menus;

namespace 點餐機.Strategies
{
    internal class DiscountOffStrategy : APromotionStrategy
    {
        public DiscountOffStrategy(List<Item> items, Menus.Discountstrategy strategy) : base(items, strategy)
        {
        }

        public override void DisCount()
        { // 買A (及B) 打折
            Discountoff type = this.strategy.DiscountOff;
            Item item1 = items.FirstOrDefault(x => x.name == type.item1);
            Item item2 = items.FirstOrDefault(x => x.name == type.item2);

            if (item2 != null && item2.quantity < type.item2Amount) // item2 數量不足直接跳出
                return;
            if (item1 != null && item1.quantity >= type.item1Amount)
            {
                int disCountReturn = (int)((item1.Subtotal) * type.discount) - item1.Subtotal;
                if (item2 != null)
                {
                    int totalPrice = (item1.Subtotal + item2.Subtotal);
                    disCountReturn = (int)(totalPrice * type.discount - totalPrice);
                }
                items.Add(new Item("(折扣)" + strategy.discountName, disCountReturn, 1));
            }
        }

    }
}
