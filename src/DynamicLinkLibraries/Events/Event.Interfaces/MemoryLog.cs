﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Log to memory
    /// </summary>
    public class MemoryLog : IEventLog, IListLog
    {

        #region Fields

        protected List<object> list = new List<object>();


        List<object> l = new List<object>();

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public MemoryLog()
        {

        }

        #endregion

        #region IEventLog Members

        /// <summary>
        /// New log
        /// </summary>
        public virtual IEventLog NewLog
        {
            get
            {
                return new MemoryLog();
            }
        }

        void IEventLog.Write(Dictionary<string, object> data, DateTime time)
        {
       /*     foreach (object o in data.Values)
            {
                TypeInfo type = IntrospectionExtensions.GetTypeInfo(o.GetType());
                if (type.IsClass)
                {
                    if (!o.GetType().Equals((typeof(string))))
                    {

                        if (l.Contains(o))
                        {
                            j++; j++;
                            throw new OwnException("JJJ");
                        }
                        l.Add(o);
                    }
                }
            }*/
            list.Add(new Tuple<Dictionary<string, object>, DateTime>(data, time));
        }

        void IEventLog.Write(IEvent ev, string name, DateTime time)
        {
            list.Add(new Tuple<string, DateTime>(name, time));
        }

        void IEventLog.Write(IEventReader reader, string name, object[] output, DateTime time)
        {
            list.Add(new Tuple<string, object[], DateTime>(name, output, time)); 
        }

        #endregion

        #region IListLog Members

        List<object> IListLog.Log
        {
            get
            {
                return list;
            }
        }

        #endregion
    }
}
