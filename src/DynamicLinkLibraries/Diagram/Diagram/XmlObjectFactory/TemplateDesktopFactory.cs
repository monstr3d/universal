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
    /// Creates from template
    /// </summary>
    public abstract class TemplateDesktopFactory : AbstractXmlCreateObjectFactory
    {
        #region Fields

        /// <summary>
        /// Patterns
        /// </summary>
        protected List<string> patterns = new List<string>();

        /// <summary>
        /// Current element
        /// </summary>
        protected XElement element;

        #endregion

        #region Ctor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="attrType">Type attribbute</param>
        /// <param name="attrName">Name attribute</param>
        protected TemplateDesktopFactory(IDesktop desktop, string attrType, string attrName)
            : base(desktop, attrType, attrName)
        {
        }

        #endregion


        #region Overriden

        /// <summary>
        /// Creates object from string type
        /// </summary>
        /// <param name="type">string type</param>
        /// <param name="element">Element</param>
        /// <returns>Required object</returns>
        public override ICategoryObject Create(string type, XElement element)
        {
            if (!patterns.Contains(type))
            {
                return null;
            }
            this.element = element;
            IDesktop d = Pattern;
            ICategoryObject co = d.GetObject(type) as ICategoryObject;
            string name = element.GetAttribute(attrName);
            dictionary[name] = co;
            if (!list.Contains(name))
            {
                list.Add(name);
            }
            return co;
        }

        #endregion

        /// <summary>
        /// Pattern desktop
        /// </summary>
        protected abstract IDesktop Pattern
        {
            get;
        }
    }
}
