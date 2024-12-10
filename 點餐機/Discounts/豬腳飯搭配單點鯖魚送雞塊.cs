using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Discounts
{
    internal class 豬腳飯搭配單點鯖魚送雞塊 : ADisCount
    {

        public 豬腳飯搭配單點鯖魚送雞塊(List<Item> items, string discountType) : base(items, discountType)
        {
        }

        public override void Discount()
        {
            Item item = items.FirstOrDefault(x => x.name == "豬腳飯");
            Item item2 = items.FirstOrDefault(x => x.name == "鯖魚");
            if (item != null && item2 != null && item.quantity > 0 && item2.quantity > 0)
            {
                int freeCount = Math.Min(item.quantity, item2.quantity);
                items.Add(new Item("(贈送)" + discountType, 0, freeCount));
            }
        }
    }
}
