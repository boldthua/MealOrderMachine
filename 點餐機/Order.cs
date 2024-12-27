using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static 點餐機.Menus;

namespace 點餐機
{
    internal class Order
    {
        public static List<Item> items = new List<Item>();

        public static void GetOrdered(Discountstrategy discountType,Item item)
        {
            Item order = items.FirstOrDefault(x => x.name == item.name);
            if (order == null)
            {
                items.Add(item);
            }
            else if (item.quantity == 0)
            {
                items.Remove(order);
            }
            else
            {
                order.quantity = item.quantity;
            }
            DisCount.DicountOrder(discountType, items);
        }

        public static void ChangeDiscount(Discountstrategy discountType)
        {
            DisCount.DicountOrder(discountType, items);

        }
    }
}
