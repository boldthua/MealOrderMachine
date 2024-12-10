using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Discounts
{
    internal class 全場打75折 : ADisCount
    {

        public 全場打75折(List<Item> items, string discountType) : base(items, discountType)
        {
        }

        public override void Discount()
        {
            int total = items.Sum(x => x.subtotal);
            int discount = (int)(total * 0.25) * -1;
            items.Add(new Item("(折扣)" + discountType, -discount, 1));
        }
    }
}
