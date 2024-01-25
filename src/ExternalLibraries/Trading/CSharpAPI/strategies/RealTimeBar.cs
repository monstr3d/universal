using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IBApi.Wrappers
{
    public class RealTimeBar : DefaultEWrapper
    {
        protected Bar bar;

        protected int nextValidOrderId = 0;


        protected RealTimeBar()
        {

        }

        public override void nextValidId(int orderId)
        {
            nextValidOrderId = orderId;
        }

        public override void realtimeBar(int reqId, long time, double open, double high, double low, double close, decimal volume, decimal WAP, int count)
        {
            var dt = DateTime.FromBinary(time).Convert();
            bar = new Bar(dt, open, high, low,
                                     close, volume, count, WAP);
        }
    }
}
