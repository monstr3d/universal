using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;



using Diagram.UI.Interfaces;
using CategoryTheory;

namespace Diagram.UI.XmlObjectFactory
{
    /// <summary>
    /// Abstract Xml object factory
    /// </summary>
    public abstract class AbstractXmlObjectFactory : IXmlObjectFactory
    {
        #region Fields

        /// <summary>
        /// Dictionary of objects
        /// </summary>
        protected IDictionary<string, ICategoryObject> dictionary = new Dictionary<string, ICategoryObject>();

        /// <summary>
        /// Ordrered list of objects
        /// </summary>
        protected IList<string> list = new List<string>();

        /// <summary>
        /// Desktop
        /// </summary>
        protected IDesktop desktop;


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="desktop">The desktop</param>
        protected AbstractXmlObjectFactory(IDesktop desktop)
        {
            this.desktop = desktop;
        }

        #endregion

        #region IXmlObjectFactory Members

        /// <summary>
        /// Creates objects
        /// </summary>
        /// <param name="element">XmlElement</param>
        /// <param name="categoryObject">Object</param>
        public abstract void Create(XElement element, ref ICategoryObject categoryObject);

        IDictionary<string, ICategoryObject> IXmlObjectFactory.Dictionary
        {
            get { return dictionary; }
        }

        IDesktop IXmlObjectFactory.Desktop
        {
            get { return desktop; }
        }


        IList<string> IXmlObjectFactory.List
        {
            get { return list; }
        }

        #endregion
    }
}
