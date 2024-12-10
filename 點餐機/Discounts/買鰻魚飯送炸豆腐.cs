using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Discounts
{
    internal class 買鰻魚飯送炸豆腐 : ADisCount
    {

        public 買鰻魚飯送炸豆腐(List<Item> items, string discountType) : base(items, discountType)
        {
        }

        public override void Discount()
        {
            Item item = items.FirstOrDefault(x => x.name == "鰻魚飯");
            if (item != null)
            {
                items.Add(new Item("(贈送)" + discountType, 0, item.quantity));
            }
        }
    }
}
