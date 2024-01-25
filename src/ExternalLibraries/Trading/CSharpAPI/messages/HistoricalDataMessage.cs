/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */


using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using IBApi.messages;

namespace IBApi.messages
{
    [Serializable()]
    public class HistoricalDataMessage : ISerializable
    {
        protected int requestId;
        protected string date;
        protected double open;
        protected double high;
        protected double low;
        protected double close;
        protected decimal volume;
        protected int count;
        protected decimal wap;
        protected bool hasGaps;

        public Bar Bar { get => new Bar(Date, Open, High, Low,
                    Close, Volume, Count, Wap); }

        public int RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }
        
        public string Date
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

        public HistoricalDataMessage(int reqId, Bar bar)
        {
            RequestId = reqId;
            Date = bar.Time;
            Open = bar.Open;
            High = bar.High;
            Low = bar.Low;
            Close = bar.Close;
            Volume = bar.Volume;
            Count = bar.Count;
            Wap = bar.WAP;
        }

        public HistoricalDataMessageDateTime Convert
        {
            get => new HistoricalDataMessageDateTime
            {
                RequestId = this.RequestId,
                Date = this.Date.Convert(),
                Open = this.Open,
                High = this.High,
                Low = this.Low,
                Close = this.Close,
                Volume = this.Volume,
                Count = this.Count,
                Wap = this.Wap

            };
        }


        private HistoricalDataMessage(SerializationInfo info, StreamingContext context)
        {
            RequestId = info.GetInt32("RequestId");
            Date = info.GetString("Date");
            if (Date == "NULL")
            {
                Date = null;
            }
            Open = info.GetDouble("Open");
            High = info.GetDouble("High");
            Low =  info.GetDouble("Low");
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
                info.AddValue("Date", "NULL");
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
