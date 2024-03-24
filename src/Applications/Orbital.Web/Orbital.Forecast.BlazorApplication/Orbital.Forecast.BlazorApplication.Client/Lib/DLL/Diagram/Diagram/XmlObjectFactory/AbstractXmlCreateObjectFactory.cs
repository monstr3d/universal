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
    /// Abstract factory of objects
    /// </summary>
    public abstract class AbstractXmlCreateObjectFactory : AbstractXmlObjectFactory
    {
       #region Fields


        /// <summary>
        /// Type attribute
        /// </summary>
        protected string attrType;

        /// <summary>
        /// Name attribute
        /// </summary>
        protected string attrName;

 

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="attrType">Type attribbute</param>
        /// <param name="attrName">Name attribute</param>
        protected AbstractXmlCreateObjectFactory(IDesktop desktop, string attrType, string attrName)
            : base(desktop)
        {
            this.desktop = desktop;
            this.attrType = attrType;
            this.attrName = attrName;
        }



        #endregion


        #region IXmlObjectFactory Members

        /// <summary>
        /// Creates or edits object from Xml element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="categoryObject">The object</param>
        public override void Create(XElement element, ref ICategoryObject categoryObject)
        {
            if (categoryObject != null)
            {
                return;
            }
            string type = element.GetAttribute(attrType);
            categoryObject = Create(type, element);
            if (categoryObject == null)
            {
                return;
            }
            string name = element.GetAttribute(attrName);
            if (!list.Contains(name))
            {
                list.Add(name);
            }
        }

  
        #endregion


        #region Members

        /// <summary>
        /// Creates object from string type
        /// </summary>
        /// <param name="type">string type</param>
        /// <param name="element">Element</param>
        /// <returns>Required object</returns>
        public abstract ICategoryObject Create(string type, XElement element);

        /// <summary>
        /// Type arribute
        /// </summary>
        public string AttributeType
        {
            get
            {
                return attrType;
            }
        }

        /// <summary>
        /// Name arrtibute
        /// </summary>
        public string AttributeName
        {
            get
            {
                return attrName;
            }
        }

        /// <summary>
        /// Gets name of object
        /// </summary>
        /// <param name="factory">Factory</param>
        /// <param name="obj">Object</param>
        /// <returns>Name of object</returns>
        public static string GetName(IXmlObjectFactory factory, ICategoryObject obj)
        {
            IDictionary<string, ICategoryObject> d = factory.Dictionary;
            foreach (string key in d.Keys)
            {
                if (d[key] == obj)
                {
                    return key;
                }
            }
            return null;
        }

        #endregion
    }
}
