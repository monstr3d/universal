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
                if (obj is Events.ForcedEventData)
                {
                    CreateForcedEventData(obj as Events.ForcedEventData, l);
                    return l;
                }
                if (obj is Events.ThresholdEvent)
                {
                    CreateThresholdEvent(obj as Events.ThresholdEvent, l);
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

        #region Private Members

        void CreateThresholdEvent(Events.ThresholdEvent thresholdEvent, List<string> l)
        {
            l.Add("Event.Portable.Events.ThresholdEvent");
            l.Add("{");
            l.Add("internal CategoryObject()");
            l.Add("{");
            l.Add("\tType = (double)0;");
            l.Add("\tMeasurement = \"" + thresholdEvent.Measurement + "\";"); 
            l.Add("\tDecrease = " + (thresholdEvent.Decrease + "").ToLower() + ";");
            l.Add("\t}");
            l.Add("}");
        }



        void CreateForcedEventData(Events.ForcedEventData forced, List<string> l)
        {
            l.Add("Event.Portable.Events.ForcedEventData");
            l.Add("{");
            l.Add("internal CategoryObject()");
            l.Add("{");
            List<Tuple<string, object>> types = forced.Types;
            l.Add("\tList<Tuple<string, object>> tt = new List<Tuple<string, object>>();");
            foreach (var type in types)
            {
                string name = "\"" + type.Item1 + "\", ";
                var tt = type.Item2;
                string val = "(" + tt.GetType() + ")" + tt.StringValue();
                string s = "\ttt.Add(new Tuple<string, object>(" + name + val + "));";
                l.Add(s);
            }
            l.Add("\tTypes = tt;");
            l.Add("\tList<object> ini = new List<object>();");
            object[] ini = forced.Initial; 
            foreach (object o in ini)
            {
                string s = "(" + o.GetType() + ")" + o.StringValue();
                l.Add("\tini.Add(" + s + ");");
            }
            l.Add("\tinitial = new object[ini.Count];");
            l.Add("\tfor (int i = 0; i < ini.Count; i++)");
            l.Add("\t{");
            l.Add("\t\tinitial[i] = ini[i];");
            l.Add("\t}");
            l.Add("}");
            l.Add("}");
        }

        #endregion
    }

}
