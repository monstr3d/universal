using IBApi;
using IBApi.Wrappers;
using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWS.Strategies;

namespace WinTradingResearch
{
    public class TortoseStrategy : RealTimeBar
    {
        IFilter<double> filterHigh = StaticExtensionResearch.FilterHigh;
        IFilter<double> filterLow = StaticExtensionResearch.FilterLow;
        TradeAction trade = TradeAction.None; 
        double? lastH = 0;
        double? lastL = 0;

    
        public override void realtimeBar(int reqId, long time, double open, double high, double low, double close, decimal volume, decimal WAP, int count)
        {
            var s = "";

            if (trade == TradeAction.Open) 
            {
                s = "BUY";
            }
            if (trade == TradeAction.Close)
            {
                s = "SELL";
            }
            if (s.Length > 0)
            {
                var order = StaticExtensionIBApi.Order;
                order.Action = s;
                order.OrderId = nextValidOrderId;
                var contract = StaticExtensionIBApi.Contract;
                order.SetOrder(contract);
            }

            var l = filterLow[close];
            var h = filterHigh[close];
            trade = TradeAction.None;
            if ((l == null) | (h == null))
            {
                return;
            }
            if (close > h)
            {
                trade = TradeAction.Open;
            }
            if (close < l) 
            {
                trade = TradeAction.Close;
            }
        }

    }
}
