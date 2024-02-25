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
    /// Alias object factory
    /// </summary>
    public class AliasXmlObjectFactory : AbstractXmlObjectFactory
    {
        #region Fields

        /// <summary>
        /// Fills alias dictionary from Xml element
        /// </summary>
        protected FillAliasDictionary fillDictionary =
            (XElement element, IDictionary<string, object> dictionary, ICategoryObject categoryObject) =>
        {
        };

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="desktop">The desktop</param>
        protected AliasXmlObjectFactory(IDesktop desktop)
            : base(desktop)
        {
        }

        #endregion

        #region Overriden



        /// <summary>
        /// Creates objects
        /// </summary>
        /// <param name="element">XmlElement</param>
        /// <param name="categoryObject">Object</param>
        public override void Create(XElement element, ref ICategoryObject categoryObject)
        {
            if (!(categoryObject is IAlias))
            {
                return;
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            fillDictionary(element, d, categoryObject);
            IAlias a = categoryObject as IAlias;
            IList<string> an = a.AliasNames;
            foreach (string key in an)
            {
                if (d.ContainsKey(key))
                {
                    a[key] = d[key];
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Fills alias dictionary from Xml element
    /// </summary>
    /// <param name="element">The element</param>
    /// <param name="dictionary">The dictoonary</param>
    /// <param name="categoryObject">Category object</param>
    public delegate void FillAliasDictionary(XElement element, 
        IDictionary<string, object> dictionary,
    ICategoryObject categoryObject);
}
