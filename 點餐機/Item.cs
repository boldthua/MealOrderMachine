using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機
{
    internal class Item
    {
        public string name;
        public int price;
        public int quantity;
        public int subtotal;

        public Item()
        {
        }

        public Item(string name, int price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.subtotal = price * quantity;
        }   
    }
}
