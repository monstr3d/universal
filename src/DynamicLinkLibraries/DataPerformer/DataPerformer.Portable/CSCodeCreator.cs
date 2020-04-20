using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagram.UI.Interfaces;
using Diagram.UI;
using DataPerformer.Interfaces;

namespace DataPerformer.Portable
{
    class CSCodeCreator : IClassCodeCreator
    {

        internal CSCodeCreator()
        {
            this.AddCSharpCodeCreator();
        }


        #region IClassCodeCreator Members

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            List<string> l = new List<string>();
            string str = null;
            if ((obj is DataLink))
            {
                str = "DataPerformer.Portable.DataLink";
            }
            if (str == null)
            {
                string th = obj.GetType().Name;
                if (th.Equals("DataConsumer"))
                {
                    str = "DataPerformer.Portable.DataConsumer";
                    l.Add(str);
                    DataConsumer c = obj as DataConsumer;
                    l.Add("{");
                    l.Add("internal CategoryObject() : base(" + c.ConsumerType + ")");
                    l.Add("{");
                    l.Add("}");
                    l.Add("}");
                    return l;
                }
            }
            if (str == null)
            {
                return null;
            }
            l.Add(str);
            l.Add("{");
            l.Add("}");
            return l;
        }

        #endregion
    }
}
