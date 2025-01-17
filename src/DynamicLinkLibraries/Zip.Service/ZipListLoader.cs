using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI;
using ErrorHandler;
using Event.Basic;
using Event.Interfaces;

using ZipUtils;

namespace Zip.Service
{
    class ZipListLoader : ILogLoader
    {
        internal static readonly ZipListLoader Singleton = new ZipListLoader();

        static Dictionary<string, List<object>> dictionary = new Dictionary<string, List<object>>();

        private ZipListLoader()
        {

        }

        List<object> Load(string url, uint begin, uint end)
        {
            if (!File.Exists(url))
            {
                return null;
            }
            string ext = Path.GetExtension(url);
            if (!ext.ToLower().Equals(".zip"))
            {
                return null;
            }
            string fn = url.UnZip();
            object o = null;
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (Stream stream = File.OpenRead(fn))
                {
                    o = formatter.Deserialize(stream);
                    stream.LogPostLoad();
                }
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
            try
            {
                File.Delete(fn);
            }
            catch
            {

            }
            return o as List<object>;
        }

        object ILogLoader.Load(string url, uint begin, uint end)
        {
            if (!File.Exists(url))
            {
                return null;
            }
            string ext = Path.GetExtension(url);
            if (!ext.ToLower().Equals(".zip"))
            {
                return null;
            }
            string fn = url.UnZip();
            object o = null;
            List<object> l = new List<object>();
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (Stream stream = File.OpenRead(fn))
                {
                    o = formatter.Deserialize(stream);
                    stream.LogPostLoad();
                    if (o is List<object>)
                    {
                        l = o as List<object>;
                    }
                }
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
            try
            {
                File.Delete(fn);
            }
            catch
            {

            }
            return new FileLogReader(l);
        }

        class FileLogReader : ILogReader
        {
            List<object> list = new List<object>();

            internal FileLogReader(List<object> list)
            {
                this.list = list;
            }

            int ILogReader.FullLength
            {
                get
                {
                    return list.Count;
                }
            }

            string ILogReader.Name
            {
                get
                {
                    return "";
                }
            }
            string ILogReader.FileName
            {
                get
                {
                    return "";
                }
            }

            IEnumerable<object> ILogReader.Load(uint begin, uint end)
            {
                int min = (int)begin;
                int max = (int)end;
                if (((begin == 0) & (end == 0)) | (max > list.Count))
                {
                    max = list.Count;
                }
                for (int i = min; i < max; i++)
                {
                    yield return list[i];
                }
            }

        }
    }
}
