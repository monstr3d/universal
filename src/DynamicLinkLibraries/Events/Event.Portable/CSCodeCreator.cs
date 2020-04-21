using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Event.Interfaces;
using Event.Portable.Arrows;

namespace Event.Portable
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
            if ((obj is EventLink))
            {
                str = "Event.Portable.Arrows.EventLink";
            }
            if (str == null)
            {
                if (obj is ITimerEvent)
                {
                    str = "Event.Portable.Events.Timer";
                    l.Add(str);
                    l.Add("{");
                    l.Add("internal CategoryObject()");
                    l.Add("{");
                    TimeSpan ts = (obj as ITimerEvent).TimeSpan;
                    l.Add("var ts = this as Event.Interfaces.ITimerEvent;");
                    l.Add("ts.TimeSpan = TimeSpan.FromTicks(" + ts.Ticks + ");");
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
