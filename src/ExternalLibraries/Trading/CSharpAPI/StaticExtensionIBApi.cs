
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using IBApi.messages;
using Microsoft.Data.Analysis;
using Numpy;
using static System.Net.Mime.MediaTypeNames;
using static Numpy.np;


namespace IBApi
{
    public static class StaticExtensionIBApi
    {


        static private readonly double?[] testDouble = new double?[] { 420, 380, 390, 400, 410 };
        private static readonly string[] format = { "yyyyMMdd-HH:mm:ss" };

        private static readonly string eastern = "US/Eastern";

        public static DataFrame ToDataFrame(this Bar bar)
        {

            DataFrameColumn[] columns = {
                new StringDataFrameColumn("Date", new string[] { bar.Time }),
                new PrimitiveDataFrameColumn<double>("Open", new double[] { bar.Open }),
                new PrimitiveDataFrameColumn<double>("High", new double[] { bar.High }),
                new PrimitiveDataFrameColumn<double>("Low", new double[] { bar.Low }),
                new PrimitiveDataFrameColumn<double>("Close", new double[] { bar.Close }),
                new PrimitiveDataFrameColumn<decimal>("Valume", new decimal[] { bar.Volume })
            };
            return new DataFrame(columns);
        }

        public static DataFrame ToDataFrame(this Bar bar, DataFrame frame)
        {
           var f =  frame.Append(new object[] { bar.Time, bar.Open, bar.High, bar.Low, bar.Close, bar.Volume });
           return f;
        }

        public static void ToDataFrame(this Bar bar, int reqId, Dictionary<int, DataFrame> dic)
        {
            if (dic.ContainsKey(reqId))
            {
                dic[reqId] = bar.ToDataFrame(dic[reqId]);
                return;
            }
            dic[reqId] = bar.ToDataFrame();
        }

        public static IOrderDialog OrderDialog
        { get; private set; }

        public static IOrderManager OrderManager
        { get; private set; }

        public static void Set(this IOrderDialog dialog)
        {
            OrderDialog = dialog;
        }

        public static void Set(this IOrderManager manager)
        {
            OrderManager = manager;
        }

        public static int ToIndex(this string span)
        {
            int i = 0;
            foreach (var symbol in spans.Keys)
            {
                if (symbol == span)
                {
                    return i;
                }
                ++i;

            }
            return -1;
        }



        private static readonly Dictionary<string, TimeSpan> spans = new Dictionary<string, TimeSpan>()
        {
            { "1 sec", TimeSpan.FromSeconds(5) },
                       { "5 secs", TimeSpan.FromSeconds(5) },
                       { "15 secs", TimeSpan.FromSeconds(15) },
          { "30 secs", TimeSpan.FromSeconds(30) },
          { "1 min", TimeSpan.FromMinutes(1) },
          { "2 mins", TimeSpan.FromMinutes(2) },
          { "3 mins", TimeSpan.FromMinutes(3) },
          { "5 mins", TimeSpan.FromMinutes(5) },
          { "15 mins", TimeSpan.FromMinutes(15) },
          { "30 mins", TimeSpan.FromMinutes(30) },
          { "1 hour", TimeSpan.FromHours(1)},
          { "1 day", TimeSpan.FromDays(1)},
          { "1 week", TimeSpan.FromDays(7)},
          { "1 month", TimeSpan.FromDays(31)},
        };

        public static string[] Barsizes
        {
            get => spans.Keys.ToArray();
        }

        public static TimeSpan ToBarSize(this string key)
        {
            if (spans.ContainsKey(key))
            {
                return spans[key];
            }
            return TimeSpan.Zero;
        }

        public static void FillVector(this HistoricalDataMessageDateTime message, double[] vector)
        {
            vector[0] = message.High;
            vector[1] = message.Low;
            vector[2] = message.Open;
            vector[3] = message.Close;
        }

        public static IEnumerable<HistoricalDataMessageDateTime> Convert(this IEnumerable<HistoricalDataMessageDateTime> items, TimeSpan span)
        {
            var last = DateTime.MinValue;
            double high = 0;
            double low = double.MaxValue;
            double open = 0;
            decimal volume = 0;
            int count = 0;
            Queue<decimal> queue = new Queue<decimal>();
            foreach (var item in items)
            {
                var dt = (DateTime)item.Date;
                if (last == DateTime.MinValue)
                {
                    last = dt;
                    open = item.Open;
                }
                if (item.High > high)
                {
                    high = item.High;
                }
                if (item.Low < low)
                {
                    low = item.Low;
                }
                volume += item.Volume;
                count += item.Count;
                queue.Enqueue(item.Wap);
                if (dt - last >= span)
                {
                    var t = dt.Convert();
                    var close = item.Close;
                    var bar = new Bar(t, open, high, low, close, volume, count,
                        queue.Average());
                    var meassage = new HistoricalDataMessageDateTime(item.RequestId, bar);
                    high = 0;
                    low = double.MaxValue;
                    last = DateTime.MinValue;
                    open = 0;
                    volume = 0;
                    count = 0;
                    queue.Clear();
                    yield return meassage;
                }

            }
        }







        public static IEnumerable<HistoricalDataMessage> Convert(this IEnumerable<HistoricalDataMessageDateTime> items)
        {
            foreach (var item in items) 
            {
       
                yield return item.Convert;
            }
        }

        public static Order Order
        {
            get => OrderDialog.GetOrder();
        }

        public static Contract Contract
        {
            get => OrderDialog.GetOrderContract();
        }

        public static void SetOrder(this Order order, Contract contract)
        {
            OrderManager.PlaceOrder(contract, order);
        }

        private static Action<HistoryWriteState> histWriteChange = (HistoryWriteState st) => { };

        public static event Action<HistoryWriteState> HistoryWriteStateEvent
        {
            add { histWriteChange += value; }
            remove { histWriteChange -= value; }
        }

        public static HistoryWriteState HistoryWriteState
        {
            get;
            set;
        } = HistoryWriteState.Stopped;

        public static void IndicateHistoryWriteState()
        {
            histWriteChange(HistoryWriteState);
        }




        public static string Convert(this DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMdd-HH:mm:ss");
        }

        public static void TestGAGR()
        {
            var g = testDouble.GAGR();
        }

        public static void TestComprod()
        {
            var p = testDouble.Percent();
            var arr = p.ToNPArray();
        }

        public static void TestComprod2() 
        {
            DataFrameColumn[] columns = {
                    new PrimitiveDataFrameColumn<double>("Open", testDouble),
                    new PrimitiveDataFrameColumn<double>("High",testDouble),
                    new PrimitiveDataFrameColumn<double>("Low",testDouble),
                    new PrimitiveDataFrameColumn<double>("Close", testDouble),
            };

           var a = (columns[0] + 1).CumulativeProduct();

        }

        public static IEnumerable<T?> ConvertReadOnly<T>(this IReadOnlyList<object> l) where T : struct
        {
            foreach (var item in l) 
            { 
                yield return (T)item;
            }
        }

        public static IEnumerable<double?> Percent(this IEnumerable<double?> values)
        {
            yield return null;
            var enu = values.GetEnumerator();
            enu.MoveNext();
            var a = enu.Current;
            while (enu.MoveNext())
            {
                var c = enu.Current;
                var x = (c - a) / a;
                a = c;
                yield return x;
            }
        }

        public static PrimitiveDataFrameColumn<double> Percent(this PrimitiveDataFrameColumn<double> column)
        {
            var dcr = new PrimitiveDataFrameColumn<double>("C", new double[0]);
            var a = column[0];
            var n = column.Count();
            for (int i = 1; i < n; i++)
            {
                var c = column[i];
                var x = (c - a) / a;
                a = c;
                dcr.Append(x);

            }
            return dcr;
        }

        static public IEnumerable<T> NotNull<T>(this IEnumerable<T?> values) where T : struct
        {
            foreach (var value in values) 
            {
                if (value != null)
                {
                    yield return (T)value;
                }
            
            }
        }

        static private double GAGR1(this IEnumerable<double?> values)
        {
            var arr = values.Percent();
            var na = arr.ToNPArray();
            var cp = np.cumprod(1 + na);
            var ou = cp.GetData<double>();
            var a = ou[ou.Length - 1];
            var n = (double)cp.len + 1;
            var m = 256 / n;
            var x = Math.Pow(a, m) - 1;
            return x;
        }

        static public double GAGR(this PrimitiveDataFrameColumn<double> column)
        {
            var cps = column.Percent();
            var cp = (1 + cps).CumulativeProduct();
            var n = cp.Length;
            var a = (double)cp[n - 1];
            var m = 256 / n;
            var x = Math.Pow(a, m) - 1;
            return x;
        }

        static private readonly double a_252_26 = Math.Sqrt(256 * 26);

        static public double Volatility(this PrimitiveDataFrameColumn<double> column)
        {
            var cps = (double)column.Average();
            var tt = column - cps;
            tt = tt * tt;
            var ave = (double)(tt as PrimitiveDataFrameColumn<double>).Average();
            ave = Math.Sqrt((double)ave);
            return ave * a_252_26;
        }

        public static double Sharpe(this PrimitiveDataFrameColumn<double> column, double rtf)
        {
            var a = column.GAGR();
            var b = column.Volatility();
            return (a - rtf) /b;        
        }




        static public double GAGR(this IEnumerable<double?> values)
        {
            var arr = values.Percent().NotNull();
            var col = new PrimitiveDataFrameColumn<double>("High", arr);
            return col.GAGR();
          //  var na = arr.ToNPArray();
          }

        static public NDarray<T> ToNPArray<T>(this IEnumerable<T?> values) where T : struct
        {
            var l = new List<T>(values.NotNull());
            T[] a = l.ToArray();
            var arr = np.array(a);
            return arr;
        }

        public static T[] Cumprod<T>(this IEnumerable<T?> values) where T : struct
        {
            var l = new List<T>(values.NotNull());
            T[] a = l.ToArray();
            var arr = np.array(a);
            var cm = np.cumprod(arr);
            var mm = cm.GetData<T>();
            return mm;
        }



        public static List<HistoricalDataMessageDateTime> Convert(this IEnumerable<HistoricalDataMessage> data)
        {
            var list = new List<HistoricalDataMessageDateTime>();
            foreach (var dataItem in data)
            {
                list.Add(dataItem.Convert);
            }
            return list;
        }




        public static DateTime Convert(this string str)
        {
            var s = str;
            DateTime dateTime;
            if (s.Length == 8)
            {
                s = s.Replace(eastern, "").Trim();
                var y = int.Parse(s.Substring(0, 4));
                var m = int.Parse(s.Substring(4, 2));
                var d = int.Parse(s.Substring(6, 2));
                return new DateTime(y, m, d);

            }
            if (s.Contains(eastern))
            {
                s = s.Replace(eastern, "").Trim();
                var y = int.Parse(s.Substring(0, 4));
                var m = int.Parse(s.Substring(4, 2));
                var d = int.Parse(s.Substring(6, 2));
                var h = int.Parse(s.Substring(9, 2));
                var mi = int.Parse(s.Substring(12, 2));
                var ss = int.Parse(s.Substring(15));
                var dt = new DateTime(y, m, d, h, mi, ss);
                return dt;//.ConvertToEasternTime();
    /*            DateTimeFormatInfo dtfi = CultureInfo.GetCultureInfo("en-US").DateTimeFormat;
                if (DateTime.TryParse(s, format, CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out dateTime))
                {
                    return dateTime.ConvertToEasternTime();
                }*/ 

            }
            CultureInfo enUS = new CultureInfo("en-US");
            
            if (DateTime.TryParseExact(str, "yyyyMMdd-HH:mm:ss", enUS, 
                DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }
            throw new Exception();
        }


        public static void ProcessHistoricalData(this IEnumerable<HistoricalDataMessage> messages, EWrapper wrapper)
        {

            foreach (var message in messages) 
            {
                    wrapper.historicalData(message.RequestId, message.Bar);
            }
        }

        public static void CloseIncome(this HistoricalDataMessage message, Order order, 
            ref double value)
        {
            double cost = message.Close * (double)order.TotalQuantity;
            if (order.Action == "BUY")
            {
                cost = -cost;
            }
            value += cost;
        }

        private static TimeZoneInfo GetEasternTimeZoneInfo()
        {
            TimeZoneInfo tz = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
               ? TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
               : TimeZoneInfo.FindSystemTimeZoneById("America/New_York");

            return tz;
        }

        public static DateTime ConvertToEasternTime(this DateTime value)
        {
            TimeZoneInfo tz = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
                : TimeZoneInfo.FindSystemTimeZoneById("America/New_York");

            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
        }



 
        public static int Check(this List<HistoricalDataMessageDateTime> list)
        {
            var curr = DateTime.MinValue;
            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i].Date;
                if (item <= curr)
                {
                    return i;
                }
                curr = (DateTime)item;
            }
            return -1;
         }


    }

    public enum HistoryWriteState
    {
        Stopped,
        Stopping,
        Active
    }

}
