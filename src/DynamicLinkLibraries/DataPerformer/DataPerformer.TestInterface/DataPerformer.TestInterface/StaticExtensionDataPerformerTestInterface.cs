using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPerformer.TestInterface
{

    public static class StaticExtensionDataPerformerTestInterface
    {
        /// <summary>
        /// Converts object to test list
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Test list</returns>
        public static List<string> ToTestStringList(this object obj)
        {
            List<string> l = new List<string>();
            CreateList(obj, l);
            return l;
        }

        static void CreateList(object o, List<string> l)
        {
            if (o == null)
            {
                return;
            }
            if (o is string)
            {
                l.Add(o + "");
                return;
            }
            if (o is IList<string>)
            {
                l.AddRange(o as IList<string>);
                return;
            }
            if (o is object[])
            {
                object[] ob = o as object[];
                foreach (object obj in ob)
                {
                    CreateList(obj, l);
                }
            }
        }
    }
}
