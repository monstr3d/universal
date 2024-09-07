using System.Collections.Generic;

using CategoryTheory;

using Event.Interfaces;

namespace Event.Portable
{
    /// <summary>
    /// Holder of log
    /// </summary>
    public class LogHolder : CategoryObject
    {
        #region Fields

        object reader;

        string url = "";

        /// <summary>
        /// Begin
        /// </summary>
        protected uint begin;

        /// <summary>
        /// End
        /// </summary>
        protected uint end;

        /// <summary>
        /// Length
        /// </summary>
        protected int length = 0;

        #endregion

        #region Public Members

  
        /// <summary>
        /// Url
        /// </summary>
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (url.Equals(value))
                {
                    return;
                }
                reader = value.LoadLog();
                if (reader == null)
                {
                    reader = ZeroReader.Singleton;
                    url = "";
                    return;
                }
                url = value;
            }
        }

   
        /// <summary>
        /// Begin record
        /// </summary>
        public uint Begin
        {
            get
            {
                return begin;
            }
            set
            {
                if (begin == value)
                {
                    return;
                }
                begin = value;
            }
        }

        /// <summary>
        /// End record
        /// </summary>
        public uint End
        {
            get
            {
                return end;
            }
            set
            {
                if (end == value)
                {
                    return;
                }
                end = value;
            }
        }

        /// <summary>
        /// Reader
        /// </summary>
        public object Reader
        {
            get
            {
                return reader;
            }
        }

        #endregion

        #region Private Members
        /*
                void CutList(bool load)
                {
                    chanded = false;
                    if (list == null)
                    {
                        list = new List<object>();
                    }
                    if ((end == 0) | (begin >= end))
                    {
                      /*  if (list.Count != length)
                        {
                            list = url.LoadLog();
                        }
                        return;
                        */
        /*          }
                  if (load)
                  {
                      list = url.LoadLog(begin, end);
                      if (list == null)
                      {
                          list = new List<object>();
                      }
                      list.TransformLogLoad();
                      //length = list.Count;
                  }
                  List<object> l = new List<object>();
        /*          int i
                  for (int i = (int)begin; i < end; i++)
                  {
                      if (i < list.Count)
                      {
                          l.Add(list[i]);
                      }
                  }
                  list = l;*/
        //   }

        #endregion

        class ZeroReader : ILogReader
        {

            internal static readonly ZeroReader Singleton = new ZeroReader();

            List<object> l = new List<object>();

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
                return l;
            }
        }

    }
}
