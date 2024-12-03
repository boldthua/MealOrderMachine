using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐機
{
    internal static class Extension
    {

        public static int GetCharacters(this string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    count++;
                }
            }
            return count;
        }

        public static void MenuLayout(this FlowLayoutPanel input, string[] menu,EventHandler checkedChange,EventHandler valueChange)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                FlowLayoutPanel panel = new FlowLayoutPanel() { Size = new Size(350,25)};
                CheckBox checkBox = new CheckBox() { Text = menu[i] };
                NumericUpDown numericUpDown = new NumericUpDown() { Size = new Size(80, 25) };
                checkBox.CheckedChanged += checkedChange;
                numericUpDown.ValueChanged += valueChange;
                input.Controls.Add(panel);
                panel.Controls.Add(checkBox);
                panel.Controls.Add(numericUpDown);
            }
        }

        public static void MenuLayout(this FlowLayoutPanel input, string[] checkList)
        {
            FlowLayoutPanel subFPanel = new FlowLayoutPanel();
            subFPanel.Width = input.Width;
            subFPanel.Height = 25;
            foreach (string str in checkList)
            {
                Label lbl = new Label() { Text = str, Size = new Size(70, 25) };
                if (int.TryParse(str, out _))
                {
                    lbl.Text = str + "          ";
                    lbl.TextAlign = ContentAlignment.TopRight;
                }
                subFPanel.Controls.Add(lbl);
            }
            input.Controls.Add(subFPanel);
        }

        public static void MenuLayout(this FlowLayoutPanel input, string divider)
        {
                Label lbl = new Label() { Text = divider, Size = new Size(350, 25) };
                input.Controls.Add(lbl);
        }

        //public static int CalculatePrice(this FlowLayoutPanel input)
        //{
        //    int price = 0;
        //    foreach (FlowLayoutPanel panel in input.Controls)
        //    {
        //        CheckBox checkbox = (CheckBox)panel.Controls[0];
        //        int quantity = (int)((NumericUpDown)panel.Controls[1]).Value;
        //        string[] temp = panel.Controls[0].Text.Split('$');
        //        int itemPrice = int.Parse(temp[1]);
        //        if (checkbox.Checked)
        //        {
        //            price += (itemPrice* quantity);
        //        }
        //    }
        //    return price;
        //}

        public static List<string[]> OrderedList(this FlowLayoutPanel input)
        {
            int price = 0;
            List<string[]> orderedDetail = new List<string[]>();
            foreach (FlowLayoutPanel panel in input.Controls)
            {
                int quantity = (int)((NumericUpDown)panel.Controls[1]).Value;
                if (quantity > 0)
                {
                    CheckBox checkbox = (CheckBox)panel.Controls[0];

                    string[] temp = panel.Controls[0].Text.Split('$');
                    int itemPrice = int.Parse(temp[1]);
                    if (checkbox.Checked)
                    {
                        price = (itemPrice * quantity);
                    }
                    orderedDetail.Add(new string[] { temp[0], temp[1], quantity.ToString(), price.ToString() });

                }
            }
            return orderedDetail;
        }
    }
}
