using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using BaseTypes;

using Diagram.UI.Interfaces;
using Diagram.UI.WCF.Interfaces;

namespace Diagram.UI.WCF
{
    public static class StaticExtensionDiagramUIWCF
    {

        #region Fields

        static IDesktopTaskProvider desktopTaskProvider;

        static Dictionary<string, Func<string, string>> functions = new Dictionary<string,Func<string, string>>();

        public const string Desktop = "Desktop";

        public const string Aliases = "Aliases";



        static event Action<string, string> onBeforeExecute = (string name, string parametres)
            => { };

        #endregion

        #region Members

        #region Public

        /// <summary>
        /// Desktop task provider
        /// </summary>
        static public IDesktopTaskProvider DesktopTaskProvider
        {
            get
            {
                return desktopTaskProvider;
            }
            set
            {
                desktopTaskProvider = value;
            }
        }

        /// <summary>
        /// Gets task from string
        /// </summary>
        /// <param name="task">String</param>
        /// <returns>Task</returns>
        static public string GetTask(this string task)
        {
            return desktopTaskProvider.GetTask(task);
        }

        /// <summary>
        /// Gets Desktop form string
        /// </summary>
        /// <param name="desktop">String</param>
        /// <returns>Desktyop</returns>
        static public IDesktop GetDesktop(this string desktop)
        {
            return desktopTaskProvider[desktop];
        }

        /// <summary>
        /// Creates error report
        /// </summary>
        /// <param name="doc">Document</param>
        static public void CreateErrorReport(this XmlDocument doc)
        {
            if (StaticExtensionDiagramUI.ErrorHandler is Service)
            {
                Service s = StaticExtensionDiagramUI.ErrorHandler as Service;
                s.CreateErrorReport(doc);
            }
        }

        /// <summary>
        /// On before execute event
        /// </summary>
        public static event Action<string, string> OnBeforeExecute
        {
            add { onBeforeExecute += value; }
            remove { onBeforeExecute -= value; }
        }

        /// <summary>
        /// Adds request handler
        /// </summary>
        /// <param name="func">Request handler</param>
        /// <param name="name">Name of request</param>
        public static void Add(this Func<string, string> func, string name)
        {
            functions[name] = func;
        }

        /// <summary>
        /// Executes task
        /// </summary>
        /// <param name="taskName">Task name</param>
        /// <param name="parametres">Parameters</param>
        /// <returns>Operation return</returns>
        static public string Execute(string name, string parametres)
        {
            if (!functions.ContainsKey(name))
            {
                throw new Exception("Name \"" + name + "\" does not exist");
            }
            onBeforeExecute(name, parametres);
            return functions[name](parametres);
        }
   
        /// <summary>
        /// Names of tasks
        /// </summary>
        static public ICollection<string> TaskNames
        {
            get
            {
                return functions.Keys;
            }
        }
        
        /// <summary>
        /// Gets desktop from document
        /// </summary>
        /// <param name="doc">The document</param>
        /// <returns>The desktop</returns>
        static public IDesktop GetDesktop(this XmlDocument doc)
        {
            string name = doc.DocumentElement.GetAttribute(Desktop);
            return desktopTaskProvider[name];
        }

        /// <summary>
        /// Sets file desktop provider
        /// </summary>
        public static void SetFileDesktopTaskProvider()
        {
            if (desktopTaskProvider != null)
            {
                return;
            }
            onBeforeExecute += SetURLDesktopTask;
        }

        #endregion

        #region Private

        /// <summary>
        /// Sets url task provider
        /// </summary>
        /// <param name="name">Neme</param>
        /// <param name="parametres">Parameters</param>
        private static void SetURLDesktopTask(string name, string parametres)
        {
            if (desktopTaskProvider != null)
            {
                onBeforeExecute -= SetURLDesktopTask;
                return;
            }

            string s = OperationContext.Current.Channel.LocalAddress.Uri.AbsoluteUri;
            s = s.Substring(0, s.LastIndexOf("/") + 1);
            Uri uri = new Uri(s);
            DesktopTaskProvider = new Diagram.UI.TaskProviders.DesktopTaskProviderUri(uri);
            
        }

        static StaticExtensionDiagramUIWCF()
        {
              Func<string, string> f = GetAliases;
              f.Add("GetAliases");
        }

        static string Convert(this object o)
        {
            Type t = o.GetType();
            if (t.Equals(typeof(double)))
            {
                double a = (double)o;
                return a.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
            return o + "";
        }

        static private string GetAliases(string parametres)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(parametres);
            IDesktop d = doc.GetDesktop();
            XmlElement e = doc.DocumentElement;
            string ali = e.GetAttribute(Aliases);
            string alixml = desktopTaskProvider.GetTask(ali);
            XmlDocument docali = new XmlDocument();
            docali.LoadXml(alixml);
            XmlDocument response = new XmlDocument();
            response.LoadXml("<" + Aliases + "/>");
            XmlElement de = response.DocumentElement;
            XmlNodeList nl = docali.GetElementsByTagName("Item");
            foreach (XmlElement ep in nl)
            {
                XmlElement ei = response.CreateElement("Item");
                de.AppendChild(ei);
                foreach (XmlElement ec in ep.ChildNodes)
                {
                    string tag = ec.Name;
                    XmlElement dec = response.CreateElement(tag);
                    string text = ec.InnerText;
                    dec.InnerText = text;
                    ei.AppendChild(dec);
                    if (tag.Equals("Alias"))
                    {
                        XmlElement ev = response.CreateElement("Value");
                        ei.AppendChild(ev);
                        object o = d.GetAliasValue(text);
                        ev.InnerText = o.Convert();
                    }
                }
            }
            response.CreateErrorReport();
            return response.OuterXml;
        }

        #endregion

        #endregion
    }
}
