using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBApi
{
    public interface IOrderDialog
    {
        Order GetOrder();
        Contract GetOrderContract();
    }
}
