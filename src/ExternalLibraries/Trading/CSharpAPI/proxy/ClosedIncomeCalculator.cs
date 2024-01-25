using IBApi.interfaces;
using IBApi.messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBApi.proxy
{
    public class ClosedIncomeCalculator : IHistoricalCalculator
    {

        Queue<double> buyqueue = new Queue<double>();

        Queue<double> sellqueue = new Queue<double>();

        double income = 0;


        public double Calculate(HistoricalDataMessageDateTime message, Order order, Contract contract)
        {
            bool b = order.Action == "BUY";
            var x = message.Close;
            if (b)
            {
                if (sellqueue.Count == 0)
                {
                    buyqueue.Enqueue(x);
                    return income;
                }
                var y = sellqueue.Dequeue();
                income += (y - x);
                return income;
            }
            if (buyqueue.Count == 0) 
            { 
                sellqueue.Enqueue(x);
                return income;
            }
            var z = buyqueue.Dequeue();
            income += (x - z);
            return income;

        }

    }
}