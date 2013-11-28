using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelHelper.OrderClasses
{
    class Order
    {
        string reStr;

        public Order()
        {
            reStr = "In Order";
        }

        public virtual string getOrder()
        {
            return reStr;
        }
    }
}
