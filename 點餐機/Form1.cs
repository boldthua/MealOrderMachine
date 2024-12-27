using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static 點餐機.Menus;

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

            string path = ConfigurationManager.AppSettings["MenuPath"];
            string dataContent = File.ReadAllText(path);


            // 序列化 > 將物件(object) 轉成字串
            // 反序列化 > 將json字串轉回去物件(objct)

            Menus menus = JsonConvert.DeserializeObject<Menus>(dataContent);
            // 先設定菜單最外層的flowlayoutpanel的位置及大小
            FlowLayoutPanel bigMenuPanel = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.LeftToRight, // 橫向排列
                Location = new Point(15, 15),
                BackColor = Color.LightGray,
                Width = 600,
                Height = 550,
                AutoScroll = true
            };
            this.Controls.Add(bigMenuPanel);
            // 再依menus.Menu的數量決定要new 幾個flowlayoutpanel

            for (int i = 0; i < menus.Menu.Length; i++)
            {
                // 中flowlayoutpanel
                FlowLayoutPanel medianMenuPanel = new FlowLayoutPanel() {

                    FlowDirection = FlowDirection.LeftToRight, // 橫向排列
                    WrapContents = true,
                    BackColor = i % 2 == 0 ? Color.AliceBlue : Color.LightPink, // 交替顏色
                    Margin = new Padding(10),
                    Width = 275,
                    Height = 250,
                    AutoScroll = true
                };
                bigMenuPanel.Controls.Add(medianMenuPanel);
                // 在中panel內先放sectionName
                Label sectionNameLbl = new Label()
                {
                    Text = menus.Menu[i].sectionName,
                    Margin = new Padding(5),
                };
                medianMenuPanel.Controls.Add(sectionNameLbl);

                // 在中panel內放入裝foods的最小flowlayoutpanel
                medianMenuPanel.MenuLayout(menus.Menu[i].foods, CheckedChange, ValueChange);
            }

            //ViewModel <=> DTO(DAO)
            List<KeyValueModel> keyValueModels = menus.DiscountStrategy.Select(x => new KeyValueModel(x.discountName, x)).ToList();


            comboBox1.DataSource = keyValueModels;
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";





            string[] checkList = {"品項", "單價", "數量", "小計"};
            flowLayoutPanel5.MenuLayout(checkList);

            string divider = "=================================================";
            flowLayoutPanel5.MenuLayout(divider);

            RanderHandler.handler += ReceiveMenu;
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
            Order.GetOrdered((Discountstrategy)comboBox1.SelectedValue,item);                       
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
            Order.ChangeDiscount((Discountstrategy)comboBox1.SelectedValue);
        }

    }
}



