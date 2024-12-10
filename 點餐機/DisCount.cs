using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 點餐機.Discounts;

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
            list.RemoveAll(x => x.name.Contains("折扣") || x.name.Contains("贈送"));

            // 變更list
            ADisCount discount = DiscountFactory.DisCount(list, discountType);

            if (discount != null)
            {
                discount.Discount();
            }
            ShowPanel.Show(list);
        }
    }
}
