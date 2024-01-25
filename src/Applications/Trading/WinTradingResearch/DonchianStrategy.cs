using IBApi;
using IBApi.Wrappers;
using MathOperations.Filters;
using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTradingResearch
{
    public enum CurrentPosition
    {
        Short,
        Long,
        None
    }

    public class DonchianStrategy : RealTimeBar
    {


        IFilter<double> filterHigh;

        IFilter<double> filterLow;


        IFilter<double> averageShort;

        IFilter<double> averageLong;

        string lastAction = "";

        CurrentPosition currentPosition = CurrentPosition.None;



        public event Action<double, double, double> OnMiddle;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="donchianPeriod">Period of Donchian filter</param>
        /// <param name="shortPeriod">Period of short average filter</param>
        /// <param name="longPeriod">Period of long average filter</param>
        public DonchianStrategy(int donchianPeriod, int shortPeriod, int longPeriod)
        {
            filterHigh = new Donchian(donchianPeriod, true);
            filterLow = new Donchian(donchianPeriod, false);
            averageShort = new AverageFilter(shortPeriod);
            averageLong = new AverageFilter(longPeriod);
            OnMiddle += DonchianStrategy_OnMiddle;
        }

        private void DonchianStrategy_OnMiddle(double arg1, double arg2, double arg3)
        {
           
        }


        public override void realtimeBar(int reqId, long time, double open, double
           high, double low, double close, decimal volume, decimal WAP, int count)
        {
            var highDonchian = filterHigh[high];
            var lowDonchian = filterLow[low];
            var shortSMA = averageShort[close];
            var longSMA = averageLong[close];
            if (shortSMA == null | longSMA == null) 
            {
                return;
            }
            bool trendSell = shortSMA < longSMA;
            var action = "";
            if (trendSell) 
            {
                if (currentPosition == CurrentPosition.None)
                {
                    if ((low < lowDonchian))
                    {
                        action = "SELL";
                        currentPosition = CurrentPosition.Short;
                    }
                 }
                else if (currentPosition == CurrentPosition.Short) 
                {
                    if ((high > highDonchian))
                    {
                        action = "BUY";
                        currentPosition = CurrentPosition.None;
                    }
                }
                else
                {
                    action = "BUY";
                    currentPosition = CurrentPosition.None;
                }
            }
            else
            {
                if (currentPosition == CurrentPosition.None)
                {
                    if ((high > highDonchian))
                    {
                        action = "BUY";
                        currentPosition = CurrentPosition.Long;
                    }
                }
                else if (currentPosition == CurrentPosition.Long)
                {
                    if (low < lowDonchian)
                    {
                        action = "SELL";
                        currentPosition = CurrentPosition.None;
                    }
                }
                else
                {
                    action = "SELL";
                    currentPosition = CurrentPosition.None;
                }
            }
            if (action.Length == 0) 
            {
                return;
            }
            lastAction = action;
            var order = StaticExtensionIBApi.Order;
            order.Action = action;
            order.OrderId = nextValidOrderId;
            var contract = StaticExtensionIBApi.Contract;
            order.SetOrder(contract);

        }
    }
}
