using IBApi.messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TradingDatabase.DataSetTradingTableAdapters;
using static TradingDatabase.DataSetTrading;

namespace TradingDatabase
{
    public static class StaticExtensionTradingDatabase
    {

        static public void DeleteBySymbol(this string symbol)
        {
            var symbols = GetSymbols();
            if (!symbols.ContainsKey(symbol)) { return; }
            var guid = symbols[symbol];
            using (var ad = new QueriesTableAdapter())
            {
               var i = ad.DeleteHistoryBySymbolId(guid);
                int j = 0;
            }
        }



        static public void FillHisrory(this string name, List<HistoricalDataMessageDateTime> data)
        {
            Guid  guid = Guid.NewGuid();
            var symbols = GetSymbols();
            if (symbols.ContainsKey(name))
            {
                guid = symbols[name];
            }
            else
            {
                var histories = new DataHistoriesTableAdapter();
                histories.Insert(guid, name);
            }
            var d = new HistoryMessagesTableAdapter();
            var connection = d.Connection;
            connection.Open();
            var transaction = connection.BeginTransaction();
            d.Transaction = transaction;
            int i = 0;
            foreach (HistoricalDataMessageDateTime item in data)
            {
                ++i;
                d.Insert(Guid.NewGuid(), guid, i, item.RequestId, (DateTime)item.Date, item.Open,
                   item.High, item.Low, item.Close, item.Volume, item.Count, item.Wap, item.HasGaps);
            }
            transaction.Commit();

        }
   
        public static IEnumerable<HistoricalDataMessageDateTime> GetHistoricalDataMessageDateTimes(this Guid guid, 
            DateTime begin, DateTime end)
        {
            var adapter = new SelectHistoryByDateTableAdapter();
            var data = adapter.GetData(guid, begin, end);
            foreach (var item in data) 
            {
                yield return new HistoricalDataMessageDateTime(item.RequestId, item.Date, item.OpenF, 
                    item.High, item.Low, item.CloseF, item.Volume, item.Count, item.Wap,  item.HasGaps);

            }
        }

        public static Dictionary<string, Guid> Symbols
        { get; private set; } = GetSymbols();

        public static Guid ToGuid(this string symbol)
        {
            return Symbols[symbol];
        }
        
        public static  int ToIndex(this Guid guid)
        {
            int i = 0;
            foreach (var symbol in Symbols.Keys) 
            { 
                if (guid == Symbols[symbol])
                {
                    return i;
                }
                ++i;
            
            }
            return -1;
        }


        private static Dictionary<string, Guid> GetSymbols()
        {
            var d = new Dictionary<string, Guid>();
            var adapter = new SelectSymbolsTableAdapter();
            var data = adapter.GetData();
            foreach (var item in data)
            {
                d[item.Name] = item.Id;
            }
            return d;
        }

    }
}
