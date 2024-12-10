using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Discounts
{
    internal class 紅茶奶茶特價20 : ADisCount
    {

        public 紅茶奶茶特價20(List<Item> items, string discountType) : base(items, discountType)
        {
        }

        public override void Discount()
        {
            Item item = items.FirstOrDefault(x => x.name == "紅茶");
            Item item2 = items.FirstOrDefault(x => x.name == "奶茶");
            int blackTea = 0;
            int milkTea = 0;
            int blackTeaPrice = 25;
            int milkTeaPrice = 35;
            if (item != null)
                blackTea = item.quantity;
            if (item2 != null)
                milkTea = item2.quantity;
            int freeCount = blackTea + milkTea;
            if (freeCount > 0)
            {
                int discount = (((blackTeaPrice - 20) * blackTea) + ((milkTeaPrice - 20) * milkTea)) * -1;
                items.Add(new Item("(贈送)" + discountType, discount, freeCount));
            }
        }
    }
}
