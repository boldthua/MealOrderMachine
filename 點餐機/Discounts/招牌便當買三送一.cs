using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Discounts
{
    internal class 招牌便當買三送一 : ADisCount
    {

        public 招牌便當買三送一(List<Item> items, string discountType) : base(items, discountType)
        {
        }

        public override void Discount()
        {
            Item item = items.FirstOrDefault(x => x.name == "招牌便當");
            if (item != null && item.quantity >= 3)
            {
                int freeCount = item.quantity / 3;
                items.Add(new Item("(贈送)" + item.name, 0, freeCount));
            }
        }
    }
}
