using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Event.Interfaces;

namespace Event.Basic.Logs
{
    /// <summary>
    /// Log writig to XML
    /// </summary>
    public class XmlLog : MemoryLog, ISaveLog
    {
        /// <summary>
        /// New log
        /// </summary>
        public override IEventLog NewLog
        {
            get
            {
                return new XmlLog();
            }
        }

        byte[] ISaveLog.Bytes
        {
            get
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                using (System.IO.StreamWriter wr = new System.IO.StreamWriter(stream))
                {
                    wr.Write(Xml + "");
                }
                return stream.GetBuffer();
            }
            set
            {

            }
        }


        string ISaveLog.Extension
        {
            get
            {
                return "xml";
            }
        }



        #region Private

        XElement Xml
        {
            get
            {
                XElement root = XElement.Parse("<Log/>");
                foreach (object o in list)
                {
                    if (o is Tuple<Dictionary<string, object>, DateTime>)
                    {
                        Tuple<Dictionary<string, object>, DateTime> td = o as 
                            Tuple<Dictionary<string, object>, DateTime>;
                          XElement data = XElement.Parse("<Data/>");
                        root.Add(data);
                        data.SetElementValue("Time", td.Item2);
                        Dictionary<string, object> d = td.Item1;
                        XElement els = XElement.Parse("<Elements/>");
                        data.Add(els);
                        foreach (string key in d.Keys)
                        {
                            XElement ed = XElement.Parse("<Element/>");
                            els.Add(ed);
                            ed.SetElementValue("Parameter", key);
                            ed.SetElementValue("Value", d[key]);
                        }
                        continue;
                    }
                    Tuple<string, DateTime> te = o as Tuple<string, DateTime>;
                    XElement ev = XElement.Parse("<Event/>");
                    root.Add(ev);
                    ev.SetElementValue("Name", te.Item1);
                    ev.SetElementValue("Time", te.Item2);
                }
                return root;
            }
        }

  
        #endregion

    }
}