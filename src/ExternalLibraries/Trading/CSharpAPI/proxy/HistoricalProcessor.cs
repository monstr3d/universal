using IBApi;
using IBApi.messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAPI.proxy
{
    public class HistoricalProcessor : IOrderManager
    {
        public HistoricalProcessor(EWrapper wrapper)
        {
            this.wrapper = wrapper;
        }

        public  event Action<Contract, Order, HistoricalDataMessageDateTime> OrderReceived;


        public event Action<HistoricalDataMessageDateTime> HistoricalDataMessageReceived;



        HistoricalDataMessageDateTime current;

        EWrapper wrapper;

        void IOrderManager.PlaceOrder(Contract contract, Order order)
        {
            OrderReceived(contract, order, current);
        }

        public void Process(IEnumerable<HistoricalDataMessageDateTime> data, EWrapper wrapper) 
        { 
            this.wrapper = wrapper;
            (this as IOrderManager).Set();
            foreach (var item in data)
            {
                current = item;
                HistoricalDataMessageReceived(item);
                wrapper.historicalData(item.RequestId, item.Bar);
            }
        }
    }
}
