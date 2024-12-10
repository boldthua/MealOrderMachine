using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Discounts
{
    internal class 雞腿飯加鰻魚200原價240 : ADisCount
    {

        public 雞腿飯加鰻魚200原價240(List<Item> items, string discountType) : base(items, discountType)
        {
        }

        public override void Discount()
        {
            Item item = items.FirstOrDefault(x => x.name == "雞腿飯");
            Item item2 = items.FirstOrDefault(x => x.name == "鰻魚");
            if (item != null && item2 != null && item.quantity > 0 && item2.quantity > 0)
            {
                int freeCount = Math.Min(item.quantity, item2.quantity);
                items.Add(new Item("(折扣)" + discountType, -40 * freeCount, freeCount));
            }
        }
    }
}
