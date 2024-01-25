using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using IBApi;

namespace IBApi.messages
{
    [Serializable]
    public class HistoricalDataMessageDateTime : ISerializable
    {
        protected int requestId;
        protected DateTime? date;
        protected double open;
        protected double high;
        protected double low;
        protected double close;
        protected decimal volume;
        protected int count;
        protected decimal wap;
        protected bool hasGaps;

        public Bar Bar
        {
            get => new Bar(((DateTime)Date).Convert(), Open, High, Low,
                  Close, Volume, Count, Wap);
        }


        public int RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }

        public DateTime? Date
        {
            get { return date; }
            set { date = value; }
        }

        public double Open
        {
            get { return open; }
            set { open = value; }
        }


        public double High
        {
            get { return high; }
            set { high = value; }
        }

        public double Low
        {
            get { return low; }
            set { low = value; }
        }

        public double Close
        {
            get { return close; }
            set { close = value; }
        }

        public decimal Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public decimal Wap
        {
            get { return wap; }
            set { wap = value; }
        }

        public bool HasGaps
        {
            get { return hasGaps; }
            set { hasGaps = value; }
        }

        public HistoricalDataMessageDateTime()
        {

        }

        public HistoricalDataMessage Convert
        {
            get
            {
                var bar = new Bar(Date?.Convert(), Open, High, Low, Close, Volume, Count, Wap);
                return new HistoricalDataMessage(RequestId, bar);
            }
        }

        public HistoricalDataMessageDateTime(int requestId, DateTime? date, double open,
            double high, double low, double close, decimal volume, int count, decimal wap,
            bool hasGaps)
        {
            RequestId = requestId;
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            Count = count;
            Wap = wap;
            HasGaps = hasGaps;
        }

        public HistoricalDataMessageDateTime(int reqId, Bar bar)
        {
            RequestId = reqId;
            Date = bar.Time.Convert();
            Open = bar.Open;
            High = bar.High;
            Low = bar.Low;
            Close = bar.Close;
            Volume = bar.Volume;
            Count = bar.Count;
            Wap = bar.WAP;
        }


        private HistoricalDataMessageDateTime(SerializationInfo info, StreamingContext context)
        {
            RequestId = info.GetInt32("RequestId");
            Date = info.GetDateTime("Date");
            if (Date == DateTime.MinValue)
            {
                Date = null;
            }
            Open = info.GetDouble("Open");
            High = info.GetDouble("High");
            Low = info.GetDouble("Low");
            Close = info.GetDouble("Close");
            Volume = info.GetDecimal("Volume");
            Count = info.GetInt32("Count");
            Wap = info.GetDecimal("Wap");
            HasGaps = info.GetBoolean("HasGaps");

        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("RequestId", RequestId);
            if (Date == null)
            {
                info.AddValue("Date", DateTime.MinValue);
            }
            else
            {
                info.AddValue("Date", Date);
            }
            info.AddValue("Open", Open);
            info.AddValue("High", High);
            info.AddValue("Low", Low);
            info.AddValue("Close", Close);
            info.AddValue("Volume", Volume);
            info.AddValue("Count", Count);
            info.AddValue("Wap", Wap);
            info.AddValue("HasGaps", HasGaps);
        }
    }
}
