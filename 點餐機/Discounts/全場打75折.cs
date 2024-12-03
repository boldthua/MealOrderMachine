using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Discounts
{
    internal class 全場打75折 : ADisCount
    {
        public 全場打75折(List<Item> items) : base(items)
        {
        }

        public override void Discount()
        {
            throw new NotImplementedException();
        }
    }
}
