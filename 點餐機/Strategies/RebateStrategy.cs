using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Contexts;

namespace 點餐機.Strategies
{
    internal class RebateStrategy : APromotionStrategy
    {
        public RebateStrategy(List<Item> items, Menus.Discountstrategy strategy) : base(items, strategy)
        {
        }

        public override void DisCount()
        {   // 滿 X 送 Y
            // 之後也可以加入 gift 和 giftprice 來完成 滿額贈送 或 滿額加購價
            Menus.Rebate type = this.strategy.Rebate;
            int totalPrice = items.Sum(item => item.Subtotal);

            if (totalPrice >= type.price)
            {
                int rebateCount = totalPrice / type.price;
                if (type.cash > 0)
                {
                    items.Add(new Item("(折價)" + strategy.discountName, 0 - type.cash, rebateCount));
                }
                else if (type.persentage > 0)
                {
                    int result = (int)(totalPrice * type.persentage - totalPrice);
                    items.Add(new Item("(折價)" + strategy.discountName, result, 1));
                }
            }
        }
    }
}
