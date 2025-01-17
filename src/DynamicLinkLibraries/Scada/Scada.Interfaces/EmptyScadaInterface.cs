using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ErrorHandler;

namespace Scada.Interfaces
{
    /// <summary>
    /// Empty scada interface
    /// </summary>
    public class EmptyScadaInterface : ScadaInterface
    {

        #region Fields

        XElement doc;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="doc">XML Document</param>
        /// <param name="typeDetector">Detector of type</param>
        public EmptyScadaInterface(XElement doc, Dictionary<string, Type> typeDetector = null)
        {
         
            this.doc = doc;
            Tuple<Dictionary<string, object>[], List<string>> t = doc.Convert();
            inputs = t.Item1[0];
            outputs = t.Item1[1];
            events = t.Item2;
            List<XElement> objs = doc.GetElementsByTagName("Objects");
            if (objs.Count == 1)
            {
                XElement obj = objs[0];
                List<XElement> l = obj.GetElementsByTagName("Object");
                foreach (XElement e in l)
                {
                    string key = e.GetItems("Name")[0];
                    objects[key] = e.GetItems("Item");
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="typeDetector">Detector of type</param>
        public EmptyScadaInterface(string filename, Dictionary<string, Type> typeDetector = null)
            : this(Load(filename), typeDetector)
        {

        }

        #endregion

        #region Overriden

        /// <summary>
        /// Gets inputs
        /// </summary>
        /// <param name="names">Input names</param>
        /// <returns>Input names</returns>
        public override Action<object[]> GetInput(string[] names)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets outputs
        /// </summary>
        /// <param name="names">Names</param>
        /// <returns>Outputs</returns>
        public override Func<object[]> GetOutput(string[] names)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets a constant
        /// </summary>
        /// <param name="name">Constant name</param>
        /// <param name="constant">Constant value</param>
        public virtual void SetConstant(string name, object constant)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// The "is enabled" sign
        /// </summary>
        public override bool IsEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Xml document
        /// </summary>
        public override XElement XmlDocument
        {
            get
            {
                return doc;
            }
        }

  
        /// <summary>
        /// Gets object of type 
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="name">Object name</param>
        /// <returns>The object</returns>
        public override T GetObject<T>(string name)
        {
            return null;
        }

        /// <summary>
        /// Refresh
        /// </summary>
        public override void Refresh()
        {

        }

        /// <summary>
        /// On refresh event
        /// </summary>
        public override event Action OnRefresh
        {
            add { }
            remove { }
        }

       #endregion

        static XElement Load(string fileName)
        {
            return XElement.Load(fileName);
        }


        /// <summary>
        /// Gets constant value
        /// </summary>
        /// <param name="name">The name of constant</param>
        /// <returns>The value of constant</returns>
        public override object GetConstantValue(string name)
        {
            throw new NotImplementedException();
        }

        public override IErrorHandler ErrorHandler { get; set; }
    }
}
