using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBApi
{
    public interface IOrderManager
    {
        void PlaceOrder(Contract contract, Order order);
    }
}
