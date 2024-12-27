using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 點餐機.Contexts;
using 點餐機.Discounts;
using static 點餐機.Menus;

namespace 點餐機
{

    //打折折扣，研究 combobox如何使用  1. 贈送 2.特價 3.折扣 
    //"請選擇以下折扣"
    //"招牌便當買三送一"              購買多個相同產品贈送相同產品
    //"雞腿飯加鰻魚$200(原價240)"     購買指定產品享特價
    //"雞翅便當三個打八折"            購買多個相同產品享折扣
    //"買鰻魚飯送炸豆腐"              購買指定產品贈送不同產品
    //"豬腳飯搭配單點鯖魚送雞塊"       購買指定餐點組合贈送指定產品
    //"肥宅快樂水三杯100"             購買多個相同產品享特價
    //"紅茶, 奶茶 特價20"             購買指定系列產品享單一價
    //"雞腿飯搭配炸豆腐打9折"          購買指定餐點組合享折扣
    //"全場消費滿399打八折"            滿額享折扣
    //"全場打75折"                    享折扣
    internal class DisCount
    {
        public static void DicountOrder(Discountstrategy discountType,List<Item> list)
        {
            list.RemoveAll(x => x.name.Contains("折扣") || x.name.Contains("贈送"));

            Type type = Type.GetType(discountType.strategy); // .strategy是字串
            APromotionStrategy strategy = (APromotionStrategy)Activator.CreateInstance(type, new object[] { list, discountType});
            DisCountContext context = new DisCountContext(strategy);
            ShowPanel.Show(list);

            // context.Discount();
            //// 變更list
            //ADisCount discount = DiscountFactory.DisCount(list, discountType);

            //if (discount != null)
            //{
            //    discount.Discount();
            //}
            //ShowPanel.Show(list);
        }
    }
}
