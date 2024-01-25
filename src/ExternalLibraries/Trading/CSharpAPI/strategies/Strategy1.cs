using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBApi.Wrappers
{
    public class Strategy1 : BasicWrapper
    {

        public int Short
        { 
            get; 
          private set; 
        } = 10;

        public int Long
        { 
            get; 
           private set; 
        } = 20;

        Queue<double> longq = new Queue<double>();
        Queue<double> shortq = new Queue<double>();
        double lastLong = 0;
        double lastShort = 0;

        public event Action<long, double, double> OnMiddle;

        Dictionary<DateTime, string> operarions = new Dictionary<DateTime, string>();
        public Strategy1()
        {
            OnMiddle += (long arg1, double arg2, double arg3) =>
            {
            };
        }


        public override void realtimeBar(int reqId, long time, double open, double
            high, double low, double close, decimal volume, decimal WAP, int count)
        {
            longq.Enqueue(close);
            shortq.Enqueue(close);
            if (shortq.Count > Short)
            {
                shortq.Dequeue();
            }
            if (longq.Count < Long)
            {
                return;
            }
            if (longq.Count > Long)
            {
                longq.Dequeue();
            }
            var currentLong = longq.Average();
            var currentShort = shortq.Average();
            var b1 = currentShort > currentLong;
            var b2 = lastShort > lastLong;
            var c = lastLong == 0;
            lastLong = currentLong;
            lastShort = currentShort;
            OnMiddle(time, currentLong, currentShort);
            if (c)
            {
                return;
            }
            if (b1 == b2)
            {
                return;
            }
            var action = b1 ? "SELL" : "BUY";
            var order = StaticExtensionIBApi.Order;
            order.Action = action;
            order.OrderId = nextValidOrderId;
            var contract = StaticExtensionIBApi.Contract;
            order.SetOrder(contract);
            operarions[DateTime.Now] = action;
        }

    }
}
