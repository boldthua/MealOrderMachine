using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐機
{
    public partial class Form1 : Form
    {
        int priceSum = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string words = "Hello123World456";
            Console.WriteLine(words.GetCharacters());
            
            
            string[] mainDiet = { "招牌便當$65", "鯖魚便當$85", "雞腿飯$90", "雞翅便當$95", "豬腳飯$120", "鰻魚飯$180" };
            string[] singelFood = { "鯖魚$60", "雞腿$65", "雞翅$60", "豬腳$80", "鰻魚$150" };
            string[] drinks = { "紅茶$25", "奶茶$35", "豆漿$30","咖啡$35", "肥宅快樂水$40" };
            string[] bites = { "雞塊$30", "薯條$40", "薯餅$45", "炸豆腐$40", "花枝丸$40", "毛豆$30" };

            flowLayoutPanel1.MenuLayout(mainDiet, CheckedChange, ValueChange);
            flowLayoutPanel2.MenuLayout(singelFood, CheckedChange, ValueChange);
            flowLayoutPanel3.MenuLayout(drinks, CheckedChange, ValueChange);
            flowLayoutPanel4.MenuLayout(bites, CheckedChange, ValueChange);

            string[] checkList = {"品項", "單價", "數量", "小計"};
            flowLayoutPanel5.MenuLayout(checkList);

            string divider = "=================================================";
            flowLayoutPanel5.MenuLayout(divider);

        }

        private void ShowDetail(List<string[]> foodLists)
        {
            foreach (string[] foodList in foodLists)
            {
                flowLayoutPanel5.MenuLayout(foodList);
            }
        }


        private void CheckedChange(object sender,EventArgs e)
        {
            CheckBox checkBox = (CheckBox) sender;
            NumericUpDown numChange = (NumericUpDown)checkBox.Parent.Controls[1];
            if (checkBox.Checked)
            {
                numChange.Value = 1;
            }
            else
            {
                numChange.Value = 0;
            }            
        }

        private void ValueChange(object sender, EventArgs e)
        {
            NumericUpDown numChange = (NumericUpDown) sender;
            CheckBox checkBox = (CheckBox)numChange.Parent.Controls[0];
            if(numChange.Value == 0)
            {
                checkBox.Checked = false;

            }
            else
            {
                int temp = (int)numChange.Value;
                checkBox.Checked = true;
                numChange.Value = temp;
            }
            flowLayoutPanel5.Controls.Clear();
            string[] checkList = { "品項", "單價", "數量", "小計" };
            flowLayoutPanel5.MenuLayout(checkList);

            string divider = "=================================================";
            flowLayoutPanel5.MenuLayout(divider);

            List<string[]> mainDietList = flowLayoutPanel1.OrderedList();
            List<string[]> singelFoodList = flowLayoutPanel2.OrderedList();
            List<string[]> drinksList = flowLayoutPanel3.OrderedList();
            List<string[]> bitesList = flowLayoutPanel4.OrderedList();

            ShowDetail(mainDietList);
            ShowDetail(singelFoodList);
            ShowDetail(drinksList);
            ShowDetail(bitesList);

            flowLayoutPanel5.MenuLayout(divider);
        }


        private void button1_Click(object sender, EventArgs e)
        {


            priceSum = 0;
            foreach (Control control in this.Controls)
            {
                if(control is FlowLayoutPanel panel && control.Tag == "menu")
                {
                    priceSum += panel.CalculatePrice();
                }
            }
               
            totalLab.Text = priceSum.ToString();
        }

    }
}
