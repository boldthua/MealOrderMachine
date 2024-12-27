using System;
using System.Collections.Generic;
using static 點餐機.Menus;

namespace 點餐機.Contexts
{
    abstract class APromotionStrategy
    {
        protected List<Item> items;
        protected Discountstrategy strategy;
        protected APromotionStrategy(List<Item> items, Discountstrategy strategy) { 
            this.items = items;
            this.strategy = strategy;
        }
        public abstract void DisCount();


    }
}