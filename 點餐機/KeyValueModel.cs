using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static 點餐機.Menus;

namespace 點餐機
{
    internal class KeyValueModel
    {
        public String Key { get; set; }
        public Discountstrategy Value { get; set; }
        public KeyValueModel(string key, Discountstrategy value) {
            this.Key= key;  
            this.Value= value;  
        }
    }
}
