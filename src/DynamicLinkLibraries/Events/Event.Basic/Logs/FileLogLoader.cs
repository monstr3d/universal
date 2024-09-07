using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Event.Interfaces;

namespace Event.Basic.Logs
{
    class FileLogListLoader : ILogLoader
    {

        internal static readonly FileLogListLoader Singleton = new FileLogListLoader();

        static Dictionary<string, List<object>> dictionary = new Dictionary<string, List<object>>();


        private List<object> list = new List<object>();

        private FileLogListLoader()
        {

        }

        object ILogLoader.Load(string url)
        {
            if (!File.Exists(url))
            {
                return null;
            }
            string ext = Path.GetExtension(url);
            if (!ext.ToLower().Equals(".serializable"))
            {
                return null;
            }
            return new FileLogReader(url);
        }


        class FileLogReader : ILogReader
        {
            List<object> list = new List<object>();

            string name;

            internal FileLogReader(string filename)
            {
                name = Path.GetFileNameWithoutExtension(filename).ToLower();
                try
                {
                    using (Stream stream = File.OpenWrite(filename))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        list = formatter.Deserialize(stream) as List<object>;
                    }
                }
                catch
                {

                }

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
                    return name;
                }
            }

            string ILogReader.FileName
            {
                get
                {
                    return name;
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
                for (int i = (int)begin; i < max; i++)
                {
                    yield return list[i];
                }
            }
        }
    }
}