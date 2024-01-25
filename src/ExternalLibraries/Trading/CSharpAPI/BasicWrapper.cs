using Microsoft.Data.Analysis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBApi
{
    public class BasicWrapper : DefaultEWrapper, IParent, IClientHolder
    {
        protected EClient client;

        protected EWrapper parent;

        protected int nextValidOrderId = 0;



        protected DataFrame pos_df;

        protected DataFrame order_df;

        


        protected Dictionary<int, DataFrame> data = new Dictionary<int, DataFrame>();

        public BasicWrapper()
        {
            CreateDataFrames();
        }

        protected virtual void CreateDataFrames()
        {
            var columns = new DataFrameColumn[]
                {
                    new StringDataFrameColumn("Account", new string[0]),
                    new StringDataFrameColumn("Symbol", new string[0]),
                    new StringDataFrameColumn("SecType",new string[0]),
                    new StringDataFrameColumn("Currency",new string[0]),
                    new PrimitiveDataFrameColumn<decimal>("Position",new decimal[0]),
                    new PrimitiveDataFrameColumn<double>("Avg cost",new double[0])
         };

            pos_df = new DataFrame(columns);

            columns = new DataFrameColumn[]
            {
                    new PrimitiveDataFrameColumn<int>("PermId", new int[0]),
                    new PrimitiveDataFrameColumn<int>("ClientId", new int[0]),
                    new PrimitiveDataFrameColumn<int>("OrderId",new int[0]),
                    new StringDataFrameColumn("Account",new string[0]),
                    new StringDataFrameColumn("Symbol",new string[0]),
                    new StringDataFrameColumn("SecType",new string[0]),
                    new StringDataFrameColumn("Exchange",new string[0]),
                    new StringDataFrameColumn("Action",new string[0]),
                    new StringDataFrameColumn("OrderType",new string[0]),
                    new PrimitiveDataFrameColumn<decimal>("TotalQty",new decimal[0]),
                    new PrimitiveDataFrameColumn<double>("CashQty",new double[0]),
                    new PrimitiveDataFrameColumn<double>("AuxPrice",new double[0]),
                    new StringDataFrameColumn("Status",new string[0]),
            };
            order_df = new DataFrame(columns);
        }
  
        EWrapper IParent.Parent
        {
            get => parent;
            set => parent = value;
        }
        EClient IClientHolder.Client
        {
            get => client;
            set => client = value;
        }

        public override void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {

            var row = new object[] { order.PermId, order.ClientId, orderId, order.Account,
             contract.Symbol, contract.SecIdType, contract.Exchange, order.Action,
             order.OrderType, order.TotalQuantity, order.CashQty, order.AuxPrice, orderState.Status};
            order_df.Append(row);
        }

        public override void position(string account, Contract contract, decimal pos, double avgCost)
        {
            pos_df.Append(new object[] { account, contract.Symbol, contract.SecType, pos, avgCost });
        }

        public override void historicalData(int reqId, Bar bar)
        {
            bar.ToDataFrame(reqId, data);
        }

        public override void nextValidId(int orderId)
        {
            nextValidOrderId = orderId;
        }
        public override void positionEnd()
        {

        }

        public override void error(Exception e)
        {
        }

        public override void error(int id, int errorCode, string errorMsg, string advancedOrderRejectJson)
        {
        }

        public override void error(string str)
        {
        }


        public override void realtimeBar(int reqId, long time, double open, double high, double low, double close, decimal volume, decimal WAP, int count)
        {
            base.realtimeBar(reqId, time, open, high, low, close, volume, WAP, count);
        }

    }
}
