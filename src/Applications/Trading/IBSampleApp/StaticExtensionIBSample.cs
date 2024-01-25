using IBApi;
using IBApi.messages;
using IBSampleApp.ui;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IBSampleApp
{



    public static class StaticExtensionIBSample
    {
        static StaticExtensionIBSample()
        {
            ExtendedClient.OnAdd += () =>
            {
                OrderManager.Set();
                OrderDialog.Set();
            };
        }

        #region Fields

        private static BinaryFormatter binaryFormatter = new BinaryFormatter();


        internal static OrderManager OrderManager
        {
            get;
            set;
        }

        internal static OrderDialog OrderDialog
        {
            get;
            set;
        }



        #endregion


        public static void Init()
        {

        }

   

      
   
        /// <summary>
        /// Invokes action if needed
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="doit">Action</param>
        public static void InvokeIfNeeded(this Control control, Action doit)
        {
            if (control.IsDisposed)
            {
                return;
            }
            if (control.InvokeRequired)
            {
                control.Invoke(doit);
                return;
            }
            doit();
        }

        /// <summary>
        /// Invokes action if needed
        /// </summary>
        /// <typeparam name="T">Argument type</typeparam>
        /// <param name="control">Control</param>
        /// <param name="doit">Action</param>
        /// <param name="arg">Argument</param>
        public static void InvokeIfNeeded<T>(this Control control, Action<T> doit, T arg)
        {
            if (control.IsDisposed)
            {
                return;
            }
            if (control.InvokeRequired)
            {
                control.Invoke(doit, new object[] { arg });
                return;
            }
            doit(arg);
        }

        public static List<HistoricalDataMessage> HistoryFromWorkDirectory =>
                 new DirectoryInfo(Application.StartupPath).GetHistoryFromDirectory();

        
        public static List<HistoricalDataMessageDateTime> Convert(this IEnumerable<HistoricalDataMessage> data)
        {
            var list = new List<HistoricalDataMessageDateTime>();
            foreach (var dataItem in data)
            {
                list.Add(dataItem.Convert);
            }
            return list;
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

        public static void SaveAllHistoryData()
        {
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            dir = dir.Parent;
            var path = Path.Combine(dir.FullName, "Data");
            dir = new DirectoryInfo(path);
            foreach (var di in dir.GetDirectories()) 
            {
                di.SaveHistoryData();
            }
        }

     
        public static void  SaveHistoryData(this DirectoryInfo directoryInfo)
        {
            var fileInfo = new FileInfo(Path.Combine(directoryInfo.FullName,"All.history"));
            if (fileInfo.Exists)
            {
                return;
            }
            var hist = directoryInfo.GetHistoryFromDirectory();
            var hd = hist.Convert();
            var k = hd.Check();
            if (k >= 0)
            {
                throw new Exception();
            }
            using (var stream = File.OpenWrite(fileInfo.FullName))
            {
                binaryFormatter.Serialize(stream, hd);
            }

        }


        public static List<HistoricalDataMessage> GetHistoryFromDirectory(this DirectoryInfo directoryInfo)
        {
            var list = new List<HistoricalDataMessage>();
            var files = new Dictionary<DateTime, FileInfo>();
            var ff = directoryInfo.GetFiles("*.history");
            var ld = new List<DateTime>();
            foreach (var f in ff)
            {
                var s = Path.GetFileNameWithoutExtension(f.Name);
                var y = int.Parse(s.Substring(0, 4));
                var m = int.Parse(s.Substring(4, 2));
                var d = int.Parse(s.Substring(6));
                DateTime dt = new DateTime(y, m, d);
                ld.Add(dt);
                files[dt] = f;
            }
            var bf = new BinaryFormatter();
            DateTime curr = DateTime.MinValue;
            foreach (var f in ld)
            {
                var fi = files[f];
                List<HistoricalDataMessage> l = null;
                using (Stream stream = File.OpenRead(fi.FullName))
                {
                    l = bf.Deserialize(stream) as List<HistoricalDataMessage>;
                }
                foreach (var hm in l)
                {
                    var dtt = hm.Date.Convert();
                    if (curr >= dtt)
                    {
                        continue;
                    }
                    list.Add(hm);
                }
                curr = l[l.Count - 1].Date.Convert();
            }

            return list;
        }


     

        public static AutoResetEvent ResetHisoryWrite
        {
            get;
            private set;
        } = new AutoResetEvent(false);

        public static string HistoryPath
        {
            get;
            set;
        }


    }
}
