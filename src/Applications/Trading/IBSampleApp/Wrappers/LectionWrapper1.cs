using IBApi;
using Microsoft.Data.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSampleApp.Wrappers
{
    internal class LectionWrapper1 : BasicWrapper
    {


  

        public LectionWrapper1()
        {
           var columns = new DataFrameColumn[]
           {
                    new StringDataFrameColumn("Account", new string[0]),
                    new StringDataFrameColumn("Symbol", new string[0]),
                    new StringDataFrameColumn("SecType",new string[0]),
                    new StringDataFrameColumn("Currency",new string[0]),
                    new StringDataFrameColumn("Position",new string[0]),
                    new StringDataFrameColumn("Avg cost",new string[0])
                };

            pos_df = new DataFrame(columns);

            columns = new DataFrameColumn[]
           {
                    new StringDataFrameColumn("PermId", new string[0]),
                    new StringDataFrameColumn("ClientId", new string[0]),
                    new StringDataFrameColumn("OrderId",new string[0]),
                    new StringDataFrameColumn("Account",new string[0]),
                    new StringDataFrameColumn("Symbol",new string[0]),
                    new StringDataFrameColumn("SecType",new string[0]),
                    new StringDataFrameColumn("Symbol",new string[0]),
                    new StringDataFrameColumn("Exchange",new string[0]),
                    new StringDataFrameColumn("Action",new string[0]),
                    new StringDataFrameColumn("OrderType",new string[0]),
                    new StringDataFrameColumn("TotalQty",new string[0]),
                    new StringDataFrameColumn("CashQty",new string[0]),
                    new StringDataFrameColumn("AuxPrice",new string[0]),
                    new StringDataFrameColumn("Status",new string[0]),
                };
        }

        public override void historicalData(int reqId, Bar bar)
        {
            bar.ToDataFrame(reqId, data);
        }
    }
}
