using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSampleApp.Wrappers
{
    internal class Strategy1 : BasicWrapper
    {
        static internal readonly Strategy1 Instance = new Strategy1();
        Queue<double> longq = new Queue<double>();
        Queue<double> shortq = new Queue<double>();
        int longS = 20;
        int shortS = 10;
        double lastLong = 0;
        double lastShort = 0;

        Dictionary<DateTime, string> operarions = new Dictionary<DateTime, string>();
        private Strategy1() 
        {
        }

        public override void realtimeBar(int reqId, long time, double open, double 
            high, double low, double close, decimal volume, decimal WAP, int count)
        {
            longq.Enqueue(close);
            shortq.Enqueue(close);
            if (shortq.Count > shortS)
            {
                shortq.Dequeue();
            }
            if (longq.Count < longS)
            {
                return;
            }
            if (longq.Count > longS) 
            {
                longq.Dequeue();
            }
            var currentLong = longq.Average();
            var currentShort = shortq.Average();
            var b1 = currentShort > currentLong;
            var b2 = lastShort  > lastLong;
            var c = lastLong == 0;
            lastLong = currentLong;
            lastShort = currentShort;
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
