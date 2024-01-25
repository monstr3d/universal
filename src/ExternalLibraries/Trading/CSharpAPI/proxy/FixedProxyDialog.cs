using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBApi.proxy
{
    public class FixedProxyDialog : IOrderDialog
    {
        Order order;

        Contract contract;



        public FixedProxyDialog(Order order, Contract contract) 
        { 
            this.order = order;
            this.contract = contract;
        }


        Order IOrderDialog.GetOrder()
        {
            return order.Clone() as Order;
        }

        Contract IOrderDialog.GetOrderContract()
        {
            return contract.Clone() as Contract;
        }
    }
}
