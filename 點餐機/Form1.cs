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

            //打折折扣，研究 combobox如何使用
            // 招牌便當買三送一
            // 雞腿飯加鰻魚$200(原價240)
            // 雞翅便當三個打八折
            // 買鰻魚飯送炸豆腐
            // 豬腳飯搭配單點鯖魚送雞塊
            // 肥宅快樂水三杯100
            // 紅茶,奶茶 特價20
            // 雞腿飯搭配炸豆腐打9折
            // 全場消費滿399打八折
            // 全場打75折
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

            RanderHandler.handler += ReceiveMenu;
            comboBox1.SelectedIndex = 0;    
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

            
            string[] meal = numChange.Parent.Controls[0].Text.Split('$');
            int itemPrice = int.Parse(meal[1]);
            Item item = new Item(meal[0], itemPrice, (int)numChange.Value);
            Order.GetOrdered(comboBox1.Text,item);                       
        }


        private void button1_Click(object sender, EventArgs e)
        {
            priceSum = 0;
            foreach (Item oneMeal in Order.items)
            {
                int mealPrice = oneMeal.price * oneMeal.quantity;
                priceSum += mealPrice;
            }

            totalLab.Text = priceSum.ToString();
        }

        private void ReceiveMenu(object sender, FlowLayoutPanel fPanel)
        {
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel5.Controls.Add(fPanel);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string discountType = comboBox1.Text;
            Order.ChangeDiscount(discountType);
        }
    }
}



