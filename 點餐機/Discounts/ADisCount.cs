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

        public ADisCount(List<Item> items)
        {
            this.items = items;
        }

        public abstract void Discount();
    }
}
