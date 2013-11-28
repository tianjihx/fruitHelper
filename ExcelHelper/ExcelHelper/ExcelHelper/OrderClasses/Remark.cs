using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelHelper.OrderClasses
{
    class Remark : Order
    {
        Order order;
        string reStr;
        string remark;
        private Order newOreder;
        private string p;

        public Remark()
        {
            reStr = ",";
        }
        public Remark(Order order, string r)
        {
            this.order = order;
            this.remark = r;
            reStr = ",";
        }

        public override string getOrder()
        {
            reStr = order.getOrder();
            reStr += ",";
            reStr += remark;

            return reStr;
        }
    }
}
