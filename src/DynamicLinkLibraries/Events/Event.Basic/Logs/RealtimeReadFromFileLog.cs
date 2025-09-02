using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Event.Interfaces;

namespace Event.Basic.Logs
{
    public class RealtimeReadFromFileLog : ILogLoader
    {
        static internal readonly RealtimeReadFromFileLog Singleton = new RealtimeReadFromFileLog();

        private RealtimeReadFromFileLog()
        {

        }

        static RealtimeReadFromFileLog()
        {
        }

        #region ILogLoader Members

        object ILogLoader.Load(string url,  uint begin, uint end)
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
            return new FileLoader(url, begin, end);
        }

        #endregion

        #region FileReader class

        class FileLoader : ILogReader
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string fileName;

            private uint begin, end;
     
            internal FileLoader(string fileName, uint begin, uint end)
            {
                this.fileName = fileName;
                this.begin = begin;
                this.end = end; 
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
                        uint min = Math.Max(begin, this.begin);
                        uint max = (end == 0) ? this.end : end;
                        if ((min == 0) & (max == 0))
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
                            if (o is IEnumerable<object> enu)
                            {
                                foreach (var item in enu)
                                {
                                    if (i >=  max)
                                    {
                                        break;
                                    }
                                    if (i >= min)
                                    {
                                        ++i;
                                        yield return item;
                                    }
                                    else
                                    {
                                        ++i;
                                    }
                                }
                            }
                            else if (i >= min)
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