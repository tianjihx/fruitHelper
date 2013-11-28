using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ExcelHelper.OrderClasses
{
    class FruitOrder : Order
    {
        Order order;
        double quantity;
        string reStr;

        public FruitOrder()
        {
        }
        public FruitOrder(Order order, double quan)
        {
            this.order = order;
            this.quantity = quan;
            this.reStr = ",";
        }

        public override string getOrder()
        {
            if (quantity >= 0)
            {
                reStr = order.getOrder();
                reStr += ",";
                reStr += quantity.ToString();
            }
            return reStr;
        }
    }
}
