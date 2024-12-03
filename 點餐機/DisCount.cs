using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐機
{
   
    //打折折扣，研究 combobox如何使用
    //"請選擇以下折扣"
    //"招牌便當買三送一"
    //"雞腿飯加鰻魚$200(原價240)"
    //"雞翅便當三個打八折"
    //"買鰻魚飯送炸豆腐"
    //"豬腳飯搭配單點鯖魚送雞塊"
    //"肥宅快樂水三杯100"
    //"紅茶, 奶茶 特價20"
    //"雞腿飯搭配炸豆腐打9折"
    //"全場消費滿399打八折"
    //"全場打75折"
    internal class DisCount
    {
        public static void DicountOrder(string discountType,List<Item> list)
        {
            string[] conditions = { "折扣","贈送" };
            list.RemoveAll(x => conditions.Contains(x.name));
            Item item = null;
            Item item2 = null;
            int freeCount = 0;
            int discount = 0;
            // 變更list
            switch (discountType)
            {
                case "請選擇以下折扣": 
                    break;
                case "招牌便當買三送一":
                    item = list.FirstOrDefault(x=>x.name == "招牌便當");
                    if(item != null && item.quantity>=3)
                    {
                        freeCount = item.quantity / 3;
                        list.Add(new Item("(贈送)"+item.name,0, freeCount));
                    }
                    break;
                case "雞腿飯加鰻魚$200(原價240)":
                    item = list.FirstOrDefault(x => x.name == "雞腿飯");
                    item2 = list.FirstOrDefault(x => x.name == "鰻魚");
                    if (item != null && item2 != null && item.quantity > 0 && item2.quantity > 0)
                    {
                        freeCount = Math.Min(item.quantity, item2.quantity);
                        list.Add(new Item("(折扣)" + discountType, -40 * freeCount, freeCount));
                    }
                    break;

                case "雞翅便當三個打八折":
                    item = list.FirstOrDefault(x => x.name == "雞翅便當");
                    if (item != null && item.quantity >= 3)
                    {   // 雞翅便當單價$95 
                        freeCount = item.quantity / 3;
                        discount = (int)(item.price * 3 * 0.2 * freeCount)*-1;
                        list.Add(new Item("(折扣)" + discountType, discount, freeCount));
                    }
                    break;

                case "買鰻魚飯送炸豆腐":
                    item = list.FirstOrDefault(x => x.name == "鰻魚飯");
                    if (item != null)
                    {
                        list.Add(new Item("(贈送)" + discountType, 0, item.quantity));
                    }
                    break;

                case "豬腳飯搭配單點鯖魚送雞塊":
                    item = list.FirstOrDefault(x => x.name == "豬腳飯");
                    item2 = list.FirstOrDefault(x => x.name == "鯖魚");
                    if (item != null && item2 != null && item.quantity > 0 && item2.quantity > 0)
                    {
                        freeCount = Math.Min(item.quantity, item2.quantity);
                        list.Add(new Item("(贈送)" + discountType, 0, freeCount));
                    }
                    break;
                case "肥宅快樂水三杯100":
                    item = list.FirstOrDefault(x => x.name == "肥宅快樂水");
                    if (item != null && item.quantity >= 3)
                    {   // $40
                        freeCount = item.quantity / 3;
                        list.Add(new Item("(折扣)" + discountType, -20 * freeCount, freeCount));
                    }
                    break;

                case "紅茶, 奶茶 特價20": //"紅茶$25", "奶茶$35",
                    item = list.FirstOrDefault(x => x.name == "紅茶");
                    item2 = list.FirstOrDefault(x => x.name == "奶茶");
                    int blackTea = 0;
                    int milkTea = 0;
                    int blackTeaPrice = 25;
                    int milkTeaPrice = 35;
                    if (item != null)
                        blackTea = item.quantity;
                    if (item2 != null)
                        milkTea = item2.quantity;
                    freeCount = blackTea + milkTea;
                    if (freeCount > 0)
                    {
                        discount = (((blackTeaPrice - 20) * blackTea) + ((milkTeaPrice - 20) * milkTea)) * -1;
                        list.Add(new Item("(贈送)" + discountType, discount, freeCount));
                    }
                    break;

                case "雞腿飯搭配炸豆腐打9折":
                    item = list.FirstOrDefault(x => x.name == "雞腿飯"); //$90
                    item2 = list.FirstOrDefault(x => x.name == "炸豆腐"); //$40
                    if (item != null && item2 != null && item.quantity > 0 && item2.quantity > 0)
                    {
                        freeCount = Math.Min(item.quantity, item2.quantity);
                        discount = (int)((item.price + item2.price) * 0.1 * freeCount) * -1;
                        list.Add(new Item("(折扣)" + discountType, -40 * freeCount, freeCount));
                    }
                    break;
                case "全場消費滿399打八折":
                    int sum = list.Sum(x => x.subtotal);
                    if (sum >= 399)
                    {
                        discount = (int)(sum * 0.2) * -1;
                        list.Add(new Item("(折扣)" + discountType, -discount, 1));
                    }
                    break;
                case "全場打75折":
                    int total = list.Sum(x => x.subtotal);
                    discount = (int)(total * 0.25) * -1;
                    list.Add(new Item("(折扣)" + discountType, -discount, 1));
                    break;
            }

            ShowPanel.Show(list);

        }
    }
}
