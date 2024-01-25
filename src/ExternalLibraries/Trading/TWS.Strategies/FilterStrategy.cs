using IBApi;
using IBApi.Wrappers;
using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TWS.Strategies
{
    public enum DataTypes
    {
        Open,
        Close,
        High,
        Low, 
        HihgLowDiff
    };

    public enum TradeAction
    {
        None = 0,
        Open,
        Close
    };





    public class FilterStrategy : RealTimeBar
    {
  
        IFilter<double> filterLow;
        IFilter<double> filterHigh;
        DataTypes low;
        DataTypes high;
        Func<Bar, double> lowF;
        Func<Bar, double> highF;
        double lastLong = 0;
        double lastShort = 0;

        public FilterStrategy(DataTypes low, DataTypes high,
            IFilter<double> filterLow, IFilter<double> filterHigh)
        {
            this.filterLow = filterLow;
            this.filterHigh = filterHigh;
            this.low = low;
            this.high = high;
            lowF = low.GetFunc();
            highF = high.GetFunc();
        }

        public override void realtimeBar(int reqId, long time, double open, double high, double low, double close, decimal volume, decimal WAP, int count)
        {
            base.realtimeBar(reqId, time, open, high, low, close, volume, WAP, count);
            var currentShort  = filterLow[lowF(bar)];
            var currentLong  = filterHigh[highF(bar)];
            if ((currentShort != null) | (currentLong == null)) 
            {
                return;
            }
            var b1 = currentShort > currentLong;
            var b2 = currentLong > lastLong;
            var c = lastLong == 0;
            lastLong = (double)currentLong;
            lastShort = (double)currentShort;
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
        }
    }
}
