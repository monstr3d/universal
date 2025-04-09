using Diagram.UI;
using ErrorHandler;
using Event.Interfaces;
using Event.Log.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Event.Log.Database
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    public static class StaticExtensionEventLogDatabase
    {

        #region Fields

        internal static Dictionary<object, ILogItem> items = new Dictionary<object, ILogItem>();

        static IDatabaseInterface data;

        static string connectionString = "";

        static ILogDirectory[] roots;

        #endregion

        #region Public Members

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
                        roots = data.CreateTree();
                    }
                }
                catch (Exception exception)
                {
                    exception.HandleException(); 
                }
            }
        }

        /// <summary>
        /// Roots of trees
        /// </summary>
        static public ILogDirectory[] Roots
        {
            get
            {
                return roots;
            }
        }

        /// <summary>
        /// Gets url of item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The url</returns>
        static public string GetUrl(this ILogItem item)
        {
            return "database://ConnectionString=[" + connectionString + "]&Id=[" + item.Id + "]";
        }

        /// <summary>
        /// Item from url
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Item</returns>
        static public ILogItem ItemFromUrl(this string url)
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
        /// Connection strind
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
                        roots = data.CreateTree();
                    }
                }
                catch (Exception exception)
                {
                    exception.HandleException();
                    connectionString = "";
                }
            }
        }

        /// <summary>
        /// Names of directory children
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        static public List<string> GetDirectoryNames(this ILogDirectory directory)
        {
            List<string> list = new List<string>();
            foreach (ILogItem it in directory.Children)
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
        static public ILogDirectory Create(this ILogDirectory parent, string name,
            string comment)
        {
            if (parent.GetDirectoryNames().Contains(name))
            {
                throw new OwnException(name + " already exists");
            }
            return new LogDirectoryWrapper(parent as LogDirectoryWrapper, 
                data.Create(parent.Id, name, comment));
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
        public static ILogData CreateData(this ILogDirectory directory, 
            IEnumerable<byte[]> data, string name, string fileName, string comment)
        {
            IDatabaseInterface d = StaticExtensionEventLogDatabase.data;
            if (d.Filenames.Contains(fileName))
            {
                throw new OwnException("File " + fileName + " already exists");
            }
            if (directory.GetDirectoryNames().Contains(name))
            {
                throw new OwnException(name + " already exists");
            }
            ILogData ld = d.Create(data, directory.Id, name, fileName, comment);
            d.Filenames.Add(fileName);
            return  new LogItemWrapper(directory as LogDirectoryWrapper, ld);
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
        public static ILogInterval CreateIntrerval(this ILogDirectory directory,
            ILogData data, string name, string comment, uint begin, uint end)
        {
            IDatabaseInterface d = StaticExtensionEventLogDatabase.data;
            if (directory.GetDirectoryNames().Contains(name))
            {
                throw new OwnException(name + " already exists");
            }
            ILogInterval interval = d.CreateInterval(directory.Id, name, comment, data, begin, end);
            return new LogIntervalWrapper(directory as LogDirectoryWrapper, interval, data);
        }


        /// <summary>
        /// Full directory
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="action">Action</param>
        /// <returns>Full directory</returns>
        public static IEnumerable<ILogItem> FullDirectory(this ILogItem item, Action<ILogItem> action = null)
        {
            if (action != null)
            {
                action(item);
            }
            yield return item;
            if (item is ILogDirectory)
            {
                ILogDirectory ld = item as ILogDirectory;
                IEnumerable<ILogItem> enu = ld.Children;
                foreach (ILogItem it in enu)
                {
                    IEnumerable<ILogItem> enn = it.FullDirectory(action);
                    foreach (ILogItem itt in enn)
                    {
                        yield return itt;
                    }
                }
            }
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Creates a tree
        /// </summary>
        /// <param name="data">Database interface</param>
        /// <returns>roots of trees</returns>
        static ILogDirectory[] CreateTree(this IDatabaseInterface data)
        {
            Dictionary<object, IParentSet> dictionary = new Dictionary<object, IParentSet>();
            IEnumerable<object> list = data.Elements;
            List<ILogDirectory> directories = new List<ILogDirectory>();
            foreach (object o in list)
            {
                ILogItem item = data[o];
                IParentSet ps = null;
                if (item is ILogInterval)
                {
                    ps = new LogIntervalWrapper(item as ILogInterval);
                }
                else if (item is ILogData)
                {
                    ps = new LogItemWrapper(item as ILogData);
                }
                else
                {
                    ps = new LogDirectoryWrapper(item);
                }
                dictionary[o] = ps;
            }
            foreach (IParentSet ps in dictionary.Values)
            {
                ILogItem it = (ps as ILogItem);
                object o = it.ParentId;
                if (!o.Equals(it.Id))
                {
                    if (dictionary.ContainsKey(o))
                    {
                        ps.Parent = dictionary[o] as ILogItem;
                    }
                }
                if (it is ILogInterval)
                {
                    ILogInterval interval = it as ILogInterval;
                    ILogData d = dictionary[interval.DataId] as ILogData;
                    (interval as LogIntervalWrapper).DataSet = d;
                }
            }
            List<ILogDirectory> l = new List<ILogDirectory>();
            foreach (IParentSet ps in dictionary.Values)
            {
                if (ps is ILogDirectory)
                {
                    ILogDirectory item = (ps as ILogDirectory);
                    if (item.Parent == null)
                    {
                        l.Add(item);
                    }
                }
            }
            return l.ToArray();
        }

        #endregion

    }
}