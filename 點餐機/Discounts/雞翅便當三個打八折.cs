using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Discounts
{
    internal class 雞翅便當三個打八折 : ADisCount
    {

        public 雞翅便當三個打八折(List<Item> items, string discountType) : base(items, discountType)
        {
        }

        public override void Discount()
        {
            Item item = items.FirstOrDefault(x => x.name == "雞翅便當");
            if (item != null && item.quantity >= 3)
            {   // 雞翅便當單價$95 
                int freeCount = item.quantity / 3;
                int discount = (int)(item.price * 3 * 0.2 * freeCount) * -1;
                items.Add(new Item("(折扣)" + discountType, discount, freeCount));
            }
        }
    }
}
