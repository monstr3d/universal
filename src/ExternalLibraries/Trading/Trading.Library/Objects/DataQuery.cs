using BaseTypes;
using CategoryTheory;
using DataPerformer.Interfaces;
using IBApi;
using IBApi.messages;
using System;
using TradingDatabase;

namespace Trading.Library.Objects
{
    public class DataQuery : CategoryObject, IIterator, IMeasurements
    {

        #region Fields


        IMeasurement[] measurements;

        Dictionary<int, HistoricalDataMessageDateTime> messages = new Dictionary<int, HistoricalDataMessageDateTime>();

        internal HistoricalDataMessageDateTime message;

        int step;

        double realTime;


        double[] vector = new double[4];

        IEnumerable<HistoricalDataMessageDateTime> enu;

        IEnumerator<HistoricalDataMessageDateTime> enumerator;

        bool isUpdated = false;

        #endregion

        #region Proprerties

        public Guid Guid { get; set; } = Guid.NewGuid();

        public DateTime Begin { get; set; } = DateTime.Now;

        public DateTime End { get; set; } = DateTime.Now;

        public string Period { get; set; } = "1 day";

        #endregion

        #region Ctor


        public DataQuery()
        {
            measurements =
                [
                new RealTimeMeasurement(this),
                    new LowMeasurement(this),
                    new HighMeasurement(this),
                    new OpenMeasurement(this),
                    new CloseMeasurement(this),
                    new CandleMeasurement(this),
                    new IntegerTimeMeasurement(this),
                    new DateTimeMeasurement(this),
                    new FullTimeMeasurement(this)
                ];


        }

        #endregion

        #region IMeasurements Members

        IMeasurement IMeasurements.this[int number] => measurements[number];

        int IMeasurements.Count => measurements.Length;

        bool IMeasurements.IsUpdated { get => isUpdated; set => isUpdated = value; }

        void IMeasurements.UpdateMeasurements()
        {

        }

        #endregion

        #region IIterator Members


        void IIterator.Reset()
        {
            step = 0;
            messages.Clear();
            var bs = Period.ToBarSize();
            var dt = Guid.GetHistoricalDataMessageDateTimes(Begin, End);
            enu = dt.Convert(bs);
            enumerator = enu.GetEnumerator();
            enumerator.MoveNext();
            message = enumerator.Current;
            messages[step] = message;
            Set();
        }

        bool IIterator.Next()
        {
            if (!enumerator.MoveNext())
            { return false; }
            message = enumerator.Current;
            Set();
            ++step;
            messages[step] = message;
            return true;
        }

        #endregion

        #region Private

        void Set()
        {
            message.FillVector(vector);
            realTime = (double)step;
        }

        object CoordX(object obj)
        {
            double k = (double)obj;
            int p = (int)Math.Round(k);
            if (messages.ContainsKey(p))
            {
                var dt = messages[p];

                return ((DateTime)dt.Date).ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
            }
            return "";
        }

        #endregion

        #region Measurements
        class BasicMeasurement : IMeasurement, IAssociatedObject
        {
            protected object type;

            string name;

            protected DataQuery query;

            protected Func<object> func;

            public BasicMeasurement(string name, DataQuery query)
            {
                this.name = name;
                this.query = query;
                type = (double)0;
            }


            Func<object> IMeasurement.Parameter => func;

            string IMeasurement.Name => name;

            object IMeasurement.Type => type;

            object IAssociatedObject.Object { get => query; set { } }
        }


        class LowMeasurement : BasicMeasurement
        {
            public LowMeasurement(DataQuery query) : base("Low", query)
            {

                func = () => query.message.Low;
            }
        }


        class HighMeasurement : BasicMeasurement
        {
            public HighMeasurement(DataQuery query) : base("High", query)
            {

                func = () => query.message.High;
            }
        }

        class OpenMeasurement : BasicMeasurement
        {
            public OpenMeasurement(DataQuery query) : base("Open", query)
            {

                func = () => query.message.Open;
            }
        }

        class CloseMeasurement : BasicMeasurement
        {
            public CloseMeasurement(DataQuery query) : base("Close", query)
            {

                func = () => query.message.Close;
            }
        }

        class RealTimeMeasurement : BasicMeasurement, IAssociatedObject
        {
            Func<object, object>[] f;
            public RealTimeMeasurement(DataQuery query) : base("RealTime", query)
            {

                func = () => query.realTime;
                f = [query.CoordX, null];
            }



            object IAssociatedObject.Object { get => f; set { } }
        }

        class IntegerTimeMeasurement : BasicMeasurement
        {
            public IntegerTimeMeasurement(DataQuery query) : base("Step", query)
            {
                type = (int)0;

                func = () => query.step;
            }
        }

        class DateTimeMeasurement : BasicMeasurement
        {
            public DateTimeMeasurement(DataQuery query) : base("DateTime", query)
            {
                type = typeof(DateTime);
                func = () => query.message.Date;
            }
        }

        class FullTimeMeasurement :  BasicMeasurement
        {
            public FullTimeMeasurement(DataQuery query) : base("FullTime", query)
            {
                type = (double)0;

                func = f;
             }
            object f()
            {
                var d = query.message.Date;
                if (d == null)
                {
                    return null;
                }
                return d.Value.ToOADate();
            }
    }





    class CandleMeasurement : BasicMeasurement
        {

            public CandleMeasurement(DataQuery query) : base("Candle", query)
            {
                type = new ArrayReturnType((double)0, new int[4], false);
                func = () => query.vector;
            }

        }


        #endregion


    }
}

