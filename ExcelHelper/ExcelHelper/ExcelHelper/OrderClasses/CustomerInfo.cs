using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExcelHelper.OrderClasses
{
    class CustomerInfo : Order
    {
        string reStr;
        string customerInfo;
        Order order;

        public CustomerInfo(Order order, string custInfo)
        {
            this.order = order;
            this.customerInfo = custInfo;
            this.reStr = "Error in CustomerInfo";
        }

        public override string getOrder()
        {
            Regex regex = new Regex(@".+[,].+");
            if (regex.IsMatch(customerInfo))
            {
                reStr = customerInfo;
            }
            return reStr;
        }
    }
}
