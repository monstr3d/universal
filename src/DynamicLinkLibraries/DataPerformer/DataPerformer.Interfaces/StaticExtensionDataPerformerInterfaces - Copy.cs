using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using DataPerformer.Attributes;
using DataPerformer.Interfaces.BufferedData.Interfaces;
using DataPerformer.Interfaces.BufferedData;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionDataPerformerInterfaces
    {

        #region Fields

        /// <summary>
        /// Calculation
        /// </summary>
        public const string Calculation = "Calculation";

        internal static Dictionary<object, IBufferItem> items = 
            new Dictionary<object, IBufferItem>();

        static IDatabaseInterface data;

        static string connectionString = "";

        static IBufferDirectory root;

        static event Action<Exception> onError = (Exception e) => { };

        static List<Func<object, object>> typeConverters = new List<Func<object, object>>();

    
        #endregion

        #region Public Members

        #region Database buffer Members

        /// <summary>
        /// Adds conveter of type
        /// </summary>
        /// <param name="typeConverter"></param>
        public static void AddTypeConverter(this Func<object, object> typeConverter)
        {
            typeConverters.Add(typeConverter);
        }

        /// <summary>
        /// Database interface
        /// </summary>
        static public IDatabaseInterface Data
        {
            get
            {
                return data;
            }
            set
            {
                if (data == value)
                {
                    return;
                }
                data = value;
                try
                {
                    if (connectionString.Length > 0)
                    {
                        data.ConnectionString = connectionString;
                        root = data.CreateTree()[0];
                    }
                }
                catch (Exception exception)
                {
                    onError(exception);
                }
            }
        }

        /// <summary>
        /// Root of the tree
        /// </summary>
        static public IBufferDirectory Root
        {
            get
            {
                return root;
            }
        }

        /// <summary>
        /// Gets url of item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The url</returns>
        static public string GetUrl(this IBufferItem item)
        {
            return "database://ConnectionString=[" + connectionString + "]&Id=[" + item.Id + "]";
        }

        /// <summary>
        /// Item from url
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Item</returns>
        static public IBufferItem BufferItemFromUrl(this string url)
        {
            if (!url.Contains("]&Id=["))
            {
                return null;
            }
            string p = url.Substring(url.IndexOf("]&Id=["));
            p = p.Substring("]&Id=[".Length);
            p = p.Substring(0, p.Length - 1);
            foreach (object o in items.Keys)
            {
                if (o.ToString().ToLower().Contains(p))
                {
                    return items[o];
                }
            }
            return null;
        }

        /// <summary>
        /// Connection string
        /// </summary>
        static public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (connectionString.Equals(value))
                {
                    return;
                }
                try
                {
                    connectionString = value;
                    if (data != null)
                    {
                        data.ConnectionString = value;
                        root = data.CreateTree()[0];
                    }
                }
                catch (Exception exception)
                {
                    onError(exception);
                    connectionString = "";
                }
            }
        }

        /// <summary>
        /// Names of directory children
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        static public List<string> GetDirectoryNames(this IBufferDirectory directory)
        {
            List<string> list = new List<string>();
            foreach (IBufferItem it in directory.Children)
            {
                list.Add(it.Name);
            }
            return list;
        }

        /// <summary>
        /// Creates a  directory
        /// </summary>
        /// <param name="parent">Parent</param>
        /// <param name="name">Name</param>
        /// <param name="comment">Comment</param>
        /// <returns>Rhe directory</returns>
        static public IBufferDirectory Create(this IBufferDirectory parent, string name,
            string comment)
        {
            if (parent.GetDirectoryNames().Contains(name))
            {
                throw new Exception(name + " already exists");
            }
            IBufferDirectory result =  new BufferDirectoryWrapper(parent as BufferDirectoryWrapper,
                data.Create(parent.Id, name, comment));
            StaticExtensionDataPerformerInterfaces.Data.SubmitChanges();
            return result;
        }

        /// <summary>
        /// Creates data
        /// </summary>
        /// <param name="directory">Directory</param>
        /// <param name="data">Data</param>
        /// <param name="name"></param>
        /// <param name="fileName">File name</param>
        /// <param name="comment">Comment</param>
        /// <returns>The data</returns>
        public static IBufferData CreateData(this IBufferDirectory directory,
            IEnumerable<byte[]> data, string name, string fileName, string comment)
        {
            IDatabaseInterface d = StaticExtensionDataPerformerInterfaces.data;
      /*  !!!    if (d.Filenames.Contains(fileName))
            {
                throw new Exception("File " + fileName + " already exists");
            }*/
            if (directory.GetDirectoryNames().Contains(name))
            {
                throw new Exception(name + " already exists");
            }
            IBufferData ld = d.Create(data, directory.Id, name, fileName, comment);
            return new BufferItemWrapper(directory as BufferDirectoryWrapper, ld);
        }

        /// <summary>
        /// Full directory
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="action">Action</param>
        /// <returns>Full directory</returns>
        public static IEnumerable<IBufferItem> FullDirectory(this IBufferItem item, Action<IBufferItem> action = null)
        {
            if (action != null)
            {
                action(item);
            }
            yield return item;
            if (item is IBufferDirectory)
            {
                IBufferDirectory ld = item as IBufferDirectory;
                IEnumerable<IBufferItem> enu = ld.Children;
                foreach (IBufferItem it in enu)
                {
                    IEnumerable<IBufferItem> enn = it.FullDirectory(action);
                    foreach (IBufferItem itt in enn)
                    {
                        yield return itt;
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets the time
        /// </summary>
        /// <param name="Consumer">Consumer</param>
        /// <returns>Time</returns>
        public static double GetTime(this ITimeMeasurementConsumer consumer)
        {
            return (double)consumer.Time.Parameter();
        }

        /// <summary>
        /// Gets the measuremente
        /// </summary>
        /// <param name="measurements">Measurements</param>
        /// <param name="name">Measures name</param>
        /// <returns>The measure</returns>
        public static IMeasurement GetMeasurement(this IMeasurements measurements, string name)
        {
            int n = measurements.Count;
            for (int i = 0; i < n; i++)
            {
                IMeasurement m = measurements[i];
                if (name.Equals(m.Name))
                {
                    return m;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets names of measurements for designed type
        /// </summary>
        /// <param name="measurements">Measurements</param>
        /// <param name="type">Type</param>
        /// <returns>Names of measurements</returns>
        public static string[] GetMeasurements(this IMeasurements measurements, object type)
        {
            if (measurements == null)
            {
                return new string[0];
            }
            int n = measurements.Count;
            List<string> l = new List<string>();
            for (int i = 0; i < n; i++)
            {
                IMeasurement m = measurements[i];
                if (m.Type.Equals(type))
                {
                    l.Add(m.Name);
                }
            }
            return l.ToArray();
        }

        /// <summary>
        /// On Error event
        /// </summary>
        public static event Action<Exception> OnError
        {
            add
            {
                onError += value;
            }
            remove
            {
                onError -= value;
            }
        }

        /// <summary>
        /// Gets order of measurement derivative
        /// </summary>
        /// <param name="measure">The measurement</param>
        /// <returns>Order of derivative</returns>
        public static int GetDerivativeOrder(this IMeasurement measure)
        {
            if (measure is IDerivation)
            {
                IDerivation d = measure as IDerivation;
                IMeasurement m = d.Derivation;
                return GetDerivativeOrder(m) + 1;
            }
            return 0;
        }

        /// <summary>
        /// Once interrrupts
        /// </summary>
        /// <param name="calculation">Asynchronous calculation</param>
        /// <param name="interrupt">Interrupt action</param>
        public static void OnceInterrupt(IAsynchronousCalculation calculation, Action interrupt)
        {
            if ((calculation == null) | (interrupt == null))
            {
                return;
            }
            new InterruptHelper(calculation, interrupt);
        }

        /// <summary>
        /// Once interrrupts
        /// </summary>
        /// <param name="calculation">Asynchronous calculation</param>
        /// <param name="finish">Finish action</param>
        public static void OnceFinish(IAsynchronousCalculation calculation, Action finish)
        {
            if ((calculation == null) | (finish == null))
            {
                return;
            }
            new FinishHelper(calculation, finish);
        }

        /// <summary>
        /// Gets higher derivative of measurement
        /// </summary>
        /// <param name="measure">The measurement</param>
        /// <param name="order">Order of derivative</param>
        /// <returns>Higher derivative</returns>
        public static IMeasurement GetHigherDerivative(this IMeasurement measure, int order)
        {
            if (order == 0)
            {
                return measure;
            }
            if (measure is IDerivation)
            {
                IDerivation d = measure as IDerivation;
                IMeasurement m = d.Derivation;
                return GetHigherDerivative(m, order - 1);
            }
            return null;
        }

        /// <summary>
        /// Writes parameters
        /// </summary>
        /// <param name="dictionary">Dictionary of measurements</param>
        /// <returns>Dictionary of parameters</returns>
        public static Dictionary<string, object> WriteParameters(this Dictionary<string, IMeasurement> dictionary)
        {
            return Write(dictionary, GetParameter);
        }

        /// <summary>
        /// Writes parameters
        /// </summary>
        /// <param name="dictionary">Dictionary of measurements</param>
        /// <returns>Dictionary of parameters</returns>
        public static Dictionary<string, object> WriteTypes(this Dictionary<string, IMeasurement> dictionary)
        {
            return Write(dictionary, GetType);
        }

        /// <summary>
        /// Object to bytes covereter
        /// </summary>
        public static Func<object, byte[]> ObjectToBytes
        {
            get;
            set;
        }

        /// <summary>
        /// Bytes to object covereter
        /// </summary>
        public static Func<byte[], object> BytesToObject
        {
            get;
            set;
        }

        #endregion

        #region Private Members

        #region DataBuffer Members

        static object GetType(IMeasurement measurement)
        {
            object o = measurement.Type;
            foreach (Func<object, object> typeConverter in typeConverters)
            {
                o = typeConverter(o);
            }
            return o;
        }

        static object GetParameter(IMeasurement measurement)
        {
            return measurement.Parameter();
        }

        static Dictionary<string, object> Write(Dictionary<string, IMeasurement> dictionary, Func<IMeasurement, object> func)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (string oldName in dictionary.Keys)
            {
                IMeasurement measurement = dictionary[oldName];
                string newName = oldName.Replace(".", "_").Replace("/", "_");
                d[newName] = func(measurement);
            }
            return d;
        }

        /// <summary>
        /// Creates a tree
        /// </summary>
        /// <param name="data">Database interface</param>
        /// <returns>roots of trees</returns>
        static IBufferDirectory[] CreateTree(this IDatabaseInterface data)
        {
            Dictionary<object, IParentSet> dictionary = new Dictionary<object, IParentSet>();
            IEnumerable<object> list = data.Elements;
            List<IBufferDirectory> directories = new List<IBufferDirectory>();
            foreach (object o in list)
            {
                IBufferItem item = data[o];
                IParentSet ps = null;
                if (item is IBufferData)
                {
                    ps = new BufferItemWrapper(item as IBufferData);
                }
                else
                {
                    ps = new BufferDirectoryWrapper(item);
                }
                dictionary[o] = ps;
            }
            foreach (IParentSet ps in dictionary.Values)
            {
                IBufferItem it = (ps as IBufferItem);
                object o = it.ParentId;
                if (!o.Equals(it.Id))
                {
                    if (dictionary.ContainsKey(o))
                    {
                        ps.Parent = dictionary[o] as IBufferItem;
                    }
                }
            }
            List<IBufferDirectory> l = new List<IBufferDirectory>();
            foreach (IParentSet ps in dictionary.Values)
            {
                if (ps is IBufferDirectory)
                {
                    IBufferDirectory item = (ps as IBufferDirectory);
                    if (item.Parent == null)
                    {
                        l.Add(item);
                    }
                }
            }
            return l.ToArray();
        }

        #endregion

        #endregion

        #region Helper Classes

        #region InterruptHelper class

        class InterruptHelper
        {
            Action stop;
            IAsynchronousCalculation calc;
            internal InterruptHelper(IAsynchronousCalculation calc, Action stop)
            {
                this.calc = calc;
                this.stop = stop;
                calc.OnInterrupt += StopAction;
            }

            void StopAction()
            {
                stop();
                calc.OnInterrupt -= stop;
            }
        }

        #endregion

        #region FinishHelper class

        class FinishHelper
        {
            Action stop;
            IAsynchronousCalculation calc;
            internal FinishHelper(IAsynchronousCalculation calc, Action stop)
            {
                this.calc = calc;
                this.stop = stop;
                calc.Finish += StopAction;
            }

            void StopAction()
            {
                stop();
                calc.Finish -= stop;
            }
        }

        #endregion

        #endregion

     }

}
