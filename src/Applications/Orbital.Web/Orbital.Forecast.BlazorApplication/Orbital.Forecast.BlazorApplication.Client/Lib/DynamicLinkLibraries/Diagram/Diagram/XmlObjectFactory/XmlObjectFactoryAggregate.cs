using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using CategoryTheory;
using Diagram.UI.Interfaces;


namespace Diagram.UI.XmlObjectFactory
{
    /// <summary>
    /// Aggregate factory
    /// </summary>
    public class XmlObjectFactoryAggregate : IXmlObjectFactory
    {
        #region Fields

        /// <summary>
        /// Childern factories
        /// </summary>
        IXmlObjectFactory[] factories;

        Dictionary<string, ICategoryObject> dictionary = new Dictionary<string, ICategoryObject>();

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factories">Childern factories</param>
        public XmlObjectFactoryAggregate(IXmlObjectFactory[] factories)
        {
            this.factories = factories;
        }

        #endregion

        #region IXmlObjectFactory Members

        void IXmlObjectFactory.Create(XElement element, ref ICategoryObject categoryObject)
        {
            foreach (IXmlObjectFactory factory in factories)
            {
                factory.Create(element, ref categoryObject);
            }
        }

        IDictionary<string, ICategoryObject> IXmlObjectFactory.Dictionary
        {
            get 
            {
                foreach (IXmlObjectFactory factory in factories)
                {
                    IDictionary<string, ICategoryObject> d = factory.Dictionary;
                    foreach (string key in d.Keys)
                    {
                        dictionary[key] = d[key];
                    }
                }
                return dictionary; 
            }
        }

        IDesktop IXmlObjectFactory.Desktop
        {
            get { return factories[0].Desktop; }
        }

        IList<string> IXmlObjectFactory.List
        {
            get 
            { 
                return factories[0].List; 
            }
        }

        #endregion
    }
}
