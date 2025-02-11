using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Contexts;
using static 點餐機.Menus;

namespace 點餐機.Strategies
{
    internal class AllDiscountStrategy : APromotionStrategy
    {
        public AllDiscountStrategy(List<Item> items, Menus.Discountstrategy strategy) : base(items, strategy)
        {
        }

        public override void DisCount()
        {
            Alldiscount type = this.strategy.AllDiscount;

            int totalPrice = items.Sum(item => item.Subtotal);

            int totalDiscount = (int)(totalPrice * type.persentage - totalPrice);

            items.Add(new Item("(折扣)" + strategy.discountName, totalDiscount, 1));
            }
        }
    }

