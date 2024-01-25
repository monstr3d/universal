using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBApi
{
    public class DefaultOrderManager : IOrderManager
    {
        public static readonly IOrderManager Instance = new DefaultOrderManager();

        private DefaultOrderManager() 
        { 
        
        }

 
        void IOrderManager.PlaceOrder(Contract contract, Order order)
        {
            
        }
    }
}
