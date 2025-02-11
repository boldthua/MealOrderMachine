using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Contexts;
using static 點餐機.Menus;

namespace 點餐機.Strategies
{
    internal class VolumeDiscountStrategy : APromotionStrategy
    {
        public VolumeDiscountStrategy(List<Item> items, Menus.Discountstrategy strategy) : base(items, strategy)
        {
        }

        public override void DisCount()
        {
            Volume type = this.strategy.VolumeDiscount;
            List<Item> drinks = new List<Item>();

            foreach (Item item in items)
            {
                Item drinkItem = items.FirstOrDefault(x => x.name == item.name);
                drinks.Add(drinkItem);
            }
            int drinkSum = drinks.Sum(x => x.quantity);

            if (drinkSum >= type.volume)
            {
                items.Add(new Item("(折扣)" + strategy.discountName, drinkSum*type.discount*-1, 1));
            }
        }
    }
}
