using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機
{
    internal class Menus
    {
        public MenuSection[] Menu { get; set; }
        public Discountstrategy[] DiscountStrategy { get; set; }

        public class MenuSection
        {
            public string sectionName { get; set; }
            public Food[] foods { get; set; }
        }

        public class Food
        {
            public string foodName { get; set; }
            public int price { get; set; }
        }

        public class Discountstrategy
        {
            public string discountName { get; set; }
            public string strategy { get; set; }
            public Buymgetn BuyMGetN { get; set; }
            public Specialprice SpecialPrice { get; set; }
            public Flatprice FlatPrice { get; set; }
            public Rebate Rebate { get; set; }
            public Discountoff DiscountOff { get; set; }
            public Alldiscount AllDiscount { get; set; }
        }

        public class Buymgetn
        {
            public string item1 { get; set; }
            public int item1Amount { get; set; }
            public string item2 { get; set; }
            public int item2Amount { get; set; }
            public string freeItem1 { get; set; }
            public int freeItem1Amount { get; set; }
            public string freeItem2 { get; set; }
            public int freeItem2Amount { get; set; }
        }

        public class Specialprice
        {
            public string item1 { get; set; }
            public int item1Amount { get; set; }
            public string item2 { get; set; }
            public int item2Amount { get; set; }
            public int price { get; set; }
        }

        public class Flatprice
        {
            public string[] items { get; set; }
            public int price { get; set; }
        }

        public class Rebate
        {
            public int price { get; set; }
            public int cash { get; set; }
            public float persentage { get; set; }
        }

        public class Discountoff
        {
            public string item1 { get; set; }
            public int item1Amount { get; set; }
            public string item2 { get; set; }
            public int item2Amount { get; set; }
            public float discount { get; set; }
        }

        public class Alldiscount
        {
            public float persentage { get; set; }
        }

    }
}
