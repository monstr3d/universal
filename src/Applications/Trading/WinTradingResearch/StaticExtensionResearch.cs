using IBApi;
using IBApi.messages;
using IBApi.proxy;
using MathOperations;
using MathOperations.Filters;
using MathOperations.Interfacses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TradingDatabase;

namespace WinTradingResearch
{
    internal static class StaticExtensionResearch
    {
        public static void SaveHistoryToDatabase(this string name)
        {
            throw new NotImplementedException();
            IEnumerable<HistoricalDataMessageDateTime> hist = null;
            var bf = new BinaryFormatter();
            using (var stream = File.OpenRead("All.history"))
            {
                hist = bf.Deserialize(stream) as IEnumerable<HistoricalDataMessageDateTime>;
                name.FillHisrory(hist.ToList());
            }
        }
        public static IFilter<double> FilterHigh
        { get; set; }

        public static IFilter<double> FilterLow
        { get; set; }

        public static IFilter<double> Create()
        {
            var atr = new ATRFilter(350);

            var atr7 = new MultFilter(atr, 7);

  
            var exp = new Exponential(0.8, 1);

            return new FilterComposition(atr7, exp);
        }

        static void CreateFilters()
        {
            FilterHigh = Create();
            var f = Create();
            var atr = new ATRFilter(350);

            var atr3 = new MultFilter(atr, 3);


            var exp = new Exponential(0.8, 1);

            var comp = new FilterComposition(atr3, exp);

            FilterLow = new BinaryOperationFilter(OperationType.Minus, f, comp);


        }

        static StaticExtensionResearch()
        {
   
            new FixedProxyDialog(new Order() { TotalQuantity = 1}, new Contract()).Set();
            CreateFilters();
        }

        

        static internal void Init()
        {

        }
    }
}
