using IBApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Analysis;
using System.Xml.Linq;


namespace IBSampleApp.Wrappers
{
    public class BacktestingWrapper : BasicWrapper
    {

        // DataTable dataTable = new DataTable();
        //   DataFrame dataFrame;

       // Dictionary<int, DataFrame> data = new Dictionary<int, DataFrame>();
        public BacktestingWrapper()
        {
        }


      /*  void reqHistoricalData(int tickerId, IBApi.Contract contract, string endDateTime,
            string durationStr, string barSizeSetting, string whatToShow,
            int useRTH, int formatDate, bool keepUpToDate, List<TagValue> chartOptions)
        {
            client.reqHistoricalData(tickerId, contract, endDateTime,
             durationStr, barSizeSetting, whatToShow,
             useRTH, formatDate, keepUpToDate, chartOptions);
        }*/

       /* void CreateTable()
        {
            dataTable.Columns.Add("reqId", typeof(int));
            dataTable.Columns.Add("time", typeof(string));
            dataTable.Columns.Add("open", typeof(double));
            dataTable.Columns.Add("high", typeof(double));
            dataTable.Columns.Add("low", typeof(double));
            dataTable.Columns.Add("close", typeof(double));
            dataTable.Columns.Add("volume", typeof(decimal));
            dataTable.Columns.Add("count", typeof(int));
            dataTable.Columns.Add("wap", typeof(decimal));

        }*/


   /*
        void historicalDataDT(int reqId, Bar bar)
        {
            dataTable.Rows.Add(reqId, bar.Time, bar.Open, bar.High,
                bar.Low, bar.Close, bar.Volume, bar.Count, bar.WAP);
        }*/

        void historicalDataDF(int reqId, Bar bar)
        {
            if (!data.ContainsKey(reqId))
            {
                string str = "{\'Date\': [" + bar.Time + "], \'Open\': [" + bar.Open + "], \'High\': [" +
                    bar.High + "], \'Low\': [" + bar.Low + "], \'Close\' : [" + bar.Close +
                    "], \'Volume\' : [" + bar.Volume + "]}";

                //  var df = pd.DataFrame.from_dict(str);

            }
        }

        void historicalDataDFM(int reqId, Bar bar)
        {
            bar.ToDataFrame(reqId, data);
        }
  
        public override void historicalDataEnd(int reqId, string start, string end)
        {
            var f = data[reqId];
            var pct = f["Close"];
            var dc = pct as PrimitiveDataFrameColumn<double>;
            var g = dc.GAGR();
            g = dc.Volatility();
            g = dc.Sharpe(0.1);
        }

        IBApi.Contract usTechStk(string symbol, string sec_type = "STK", string currency = "USD", string exchange = "ISLAND")
        {
            var contract = new IBApi.Contract()
            {
                Symbol = symbol,
                SecType = sec_type,
                Currency = currency,
                Exchange = exchange
            };
            return contract;
        }


    }
}
