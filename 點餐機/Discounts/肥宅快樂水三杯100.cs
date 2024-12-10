using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Discounts
{
    internal class 肥宅快樂水三杯100 : ADisCount
    {

        public 肥宅快樂水三杯100(List<Item> items, string discountType) : base(items, discountType)
        {
        }

        public override void Discount()
        {
            Item item = items.FirstOrDefault(x => x.name == "肥宅快樂水");
            if (item != null && item.quantity >= 3)
            {   // $40
                int freeCount = item.quantity / 3;
                items.Add(new Item("(折扣)" + discountType, -20 * freeCount, freeCount));
            }
        }
    }
}
