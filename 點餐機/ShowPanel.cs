using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐機
{
    internal class ShowPanel
    {
        public static void Show(List<Item> Orders) 
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Width = 400;
            panel.Height = 600; 
            string[] checkList = { "品項", "單價", "數量", "小計" };
            panel.MenuLayout(checkList);

            string divider = "=================================================";
            panel.MenuLayout(divider);
            foreach (Item oneMeal in Order.items)
            {
                int totalPrice = oneMeal.price * oneMeal.quantity;
                string[] detail = { oneMeal.name, oneMeal.price.ToString(), oneMeal.quantity.ToString(), totalPrice.ToString() };
                panel.MenuLayout(detail);
            }
            panel.MenuLayout(divider);
            RanderHandler.Notify(panel);
        }
    }
}
