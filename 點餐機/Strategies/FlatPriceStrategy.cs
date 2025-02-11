using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Contexts;

namespace 點餐機.Strategies
{
    internal class FlatPriceStrategy : APromotionStrategy
    {
        public FlatPriceStrategy(List<Item> items, Menus.Discountstrategy strategy) : base(items, strategy)
        {
        }

        public override void DisCount()
        {
            Menus.Flatprice type = this.strategy.FlatPrice;
            List<Item> specialPriceItems = new List<Item>();

            foreach (var item in items) 
            {
                if (type.items.Contains(item.name))
                {
                    string itemName = item.name;

                    int priceInterval = type.price - item.price;

                    specialPriceItems.Add(new Item($"(特價) {strategy.discountName} ({itemName})", priceInterval, item.quantity));
                }
            }
            items.AddRange(specialPriceItems);
        }
    }
}
