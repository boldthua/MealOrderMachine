using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Discounts
{
    internal class DiscountFactory
    {
        public static ADisCount DisCount(List<Item> items, string discountType)
        {
            ADisCount discount = null;

            // 變更list
            switch (discountType)
            {
                case "請選擇以下折扣":
                    break;

                case "招牌便當買三送一":
                    discount = new 招牌便當買三送一(items, discountType);
                    break;

                case "雞腿飯加鰻魚$200(原價240)":
                    discount = new 雞腿飯加鰻魚200原價240(items, discountType);
                    break;

                case "雞翅便當三個打八折":
                    discount = new 雞翅便當三個打八折(items, discountType);
                    break;

                case "買鰻魚飯送炸豆腐":
                    discount = new 買鰻魚飯送炸豆腐(items, discountType);
                    break;

                case "豬腳飯搭配單點鯖魚送雞塊":
                    discount = new 豬腳飯搭配單點鯖魚送雞塊(items, discountType);
                    break;
                case "肥宅快樂水三杯100":
                    discount = new 肥宅快樂水三杯100(items, discountType);
                    break;

                case "紅茶, 奶茶 特價20": //"紅茶$25", "奶茶$35",
                    discount = new 紅茶奶茶特價20(items, discountType);
                    break;

                case "雞腿飯搭配炸豆腐打9折":
                    discount = new 雞腿飯搭配炸豆腐打9折(items, discountType);
                    break;
                case "全場消費滿399打八折":
                    discount = new 全場消費滿399打八折(items, discountType);
                    break;
                case "全場打75折":
                    discount = new 全場打75折(items, discountType);
                    break;
            }
            return discount;
        }
    }
}
