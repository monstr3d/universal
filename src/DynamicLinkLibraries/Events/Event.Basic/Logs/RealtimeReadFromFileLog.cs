using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using Event.Interfaces;

namespace Event.Basic.Logs
{
    class RealtimeReadFromFileLog : ILogLoader
    {
        static internal readonly RealtimeReadFromFileLog Singleton = new RealtimeReadFromFileLog();

        private RealtimeReadFromFileLog()
        {

        }

        static RealtimeReadFromFileLog()
        {
        }

        #region ILogLoader Members

        object ILogLoader.Load(string url)
        {
            if (!File.Exists(url))
            {
                return null;
            }
            string ext = Path.GetExtension(url);
            if (!ext.ToLower().Equals(".filelog"))
            {
                return null;
            }
            return new FileLoader(url);
        }

        #endregion

        #region FileReader class

        class FileLoader : ILogReader
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string fileName;

     
            internal FileLoader(string fileName)
            {
                this.fileName = fileName;
            }

            int ILogReader.FullLength
            {
                get
                {
                    return 0;
                }
            }

            string ILogReader.Name
            {
                get
                {
                    return Path.GetFileNameWithoutExtension(fileName).ToLower();
                }
            }

            string ILogReader.FileName
            {
                get
                {
                    return Path.GetFileNameWithoutExtension(fileName).ToLower();
                }
            }

            IEnumerable<object> ILogReader.Load(uint begin, uint end)
            {
                if (File.Exists(fileName))
                {
                    using (Stream stream = File.OpenRead(fileName))
                    {
                        long n = stream.Length;
                        int i = 0;
                        uint min = begin;
                        uint max = end;
                        if ((begin == 0) & (end == 0))
                        {
                            min = 0;
                            max = uint.MaxValue;
                        }
                        while (stream.Position < n & i < max)
                        {
                            object o = null;
                            try
                            {
                                o = formatter.Deserialize(stream);
                            }
                            catch
                            {

                            }
                            if (o == null)
                            {
                                break;
                            }
                            if (i >= min)
                            {
                                ++i;
                                yield return o;
                            }
                            else
                            {
                                ++i;
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}