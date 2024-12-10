using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Discounts
{
    internal class 全場消費滿399打八折 : ADisCount
    {

        public 全場消費滿399打八折(List<Item> items, string discountType) : base(items, discountType)
        {
        }

        public override void Discount()
        {
            int sum = items.Sum(x => x.subtotal);
            if (sum >= 399)
            {
                int discount = (int)(sum * 0.2) * -1;
                items.Add(new Item("(折扣)" + discountType, -discount, 1));
            }
        }
    }
}
