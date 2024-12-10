using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Discounts
{
    internal abstract class ADisCount
    {
        protected List<Item> items;
        protected string discountType;

        public ADisCount(List<Item> items, string discountType)
        {
            this.items = items;
            this.discountType = discountType;
        }


        public abstract void Discount();
    }
}
