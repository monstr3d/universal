using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.Text;
using System.Xml;
using Diagram.UI.Interfaces;

namespace Diagram.UI.WCF
{
    /// <summary>
    /// Common service
    /// </summary>
    public class Service : IService, IErrorHandler
    {
        #region Fields

        private static bool first = true;

        /// <summary>
        /// List of exceptions
        /// </summary>
        private List<object[]> exceptions = new List<object[]>();

        private List<object[]> messages = new List<object[]>();

        private event Action<Exception, object> onException = (Exception ex, object ob) => { };

        private event Action<string, object> onMessage = (string message, object ob) => { };

        private static Uri uri;

        #endregion

        #region Ctor

        /// <summary>
        /// Service
        /// </summary>
        public Service()
        {
            StaticExtensionDiagramUI.ErrorHandler = this;
        }

        #endregion

        #region IService Members

        /// <summary>
        /// Executes task
        /// </summary>
        /// <param name="taskName">Task name</param>
        /// <param name="parametres">Parameters</param>
        /// <returns>Operation return</returns>
        public virtual string Execute(string taskName, string parametres)
        {
            StaticExtensionDiagramUI.ErrorHandler = this;
            return StaticExtensionDiagramUIWCF.Execute(taskName, parametres);
        }


        /// <summary>
        /// Names of tasks
        /// </summary>
        public virtual string[] TaskNames
        {
            get { return StaticExtensionDiagramUIWCF.TaskNames.ToArray(); }
        }

        #endregion

        #region IErrorHandler Menbers

        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="obj">Attached object</param>
        public virtual void ShowError(Exception exception, object obj)
        {
            exceptions.Add(new object[] { exception, obj + "" });
            onException(exception, obj);
        }

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="obj">Attached object</param>
        public virtual void ShowMessage(string message, object obj)
        {
            messages.Add(new object[]{message, obj + ""});
            onMessage(message, obj);
        }

        #endregion

        #region Menbers

        /// <summary>
        /// Exception event
        /// </summary>
        public event Action<Exception, object> OnException
        {
            add { onException += value; }
            remove { onException -= value; }
        }

        /// <summary>
        /// Message event
        /// </summary>
        public event Action<string, object> OnMessage
        {
            add { onMessage += value; }
            remove { onMessage -= value; }
        }

        /// <summary>
        /// Creates error report
        /// </summary>
        /// <param name="doc">report doocument</param>
        public void CreateErrorReport(XmlDocument doc)
        {
            if (exceptions.Count != 0)
            {
                XmlElement el = doc.CreateElement("Exceptions");
                doc.DocumentElement.AppendChild(el);
                foreach (object[] o in exceptions)
                {
                    XmlElement e = doc.CreateElement("Exception");
                    el.AppendChild(e);
                    XmlElement eo = doc.CreateElement("Object");
                    eo.InnerText = o[1] + "";
                    e.AppendChild(eo);
                    XmlElement eex = doc.CreateElement("StackTrace");
                    e.AppendChild(eex);
                    eex.InnerText = (o[0] as Exception).StackTrace;
                    XmlElement em = doc.CreateElement("ExceptionMessage");
                    e.AppendChild(em);
                    em.InnerText = (o[0] as Exception).Message;
                    XmlElement et = doc.CreateElement("ExceptionType");
                    e.AppendChild(et);
                    et.InnerText = (o[0] as Exception).GetType() + "";
                }
                exceptions.Clear();
            }
            if (messages.Count != 0)
            {
                XmlElement el = doc.CreateElement("Messages");
                doc.DocumentElement.AppendChild(el);
                foreach (object[] o in messages)
                {
                    XmlElement e = doc.CreateElement("Message");
                    el.AppendChild(e);
                    XmlElement eo = doc.CreateElement("Object");
                    eo.InnerText = o[1] + "";
                    e.AppendChild(eo);
                    XmlElement eex = doc.CreateElement("Text");
                    e.AppendChild(eex);
                    eex.InnerText = o[0] + "";
                }
            }
            messages.Clear();
        }

        /// <summary>
        /// Static construcor
        /// </summary>
        static Service()
        {
        }

        #endregion

    }
}
