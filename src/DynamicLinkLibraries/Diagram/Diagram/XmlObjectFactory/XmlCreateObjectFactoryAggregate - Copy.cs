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
    /// Aggregate create factory
    /// </summary>
    public class XmlCreateObjectFactoryAggregate : AbstractXmlCreateObjectFactory
    {
        #region Fields

        AbstractXmlCreateObjectFactory[] factories;

        #endregion

        #region Ctor

        private XmlCreateObjectFactoryAggregate(IDesktop desktop, string attrType, string attrName)
            : base(desktop, attrType, attrName)
        {
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Creates object from Xml element
        /// </summary>
        /// <param name="type">Strig repesentaqtion of object type</param>
        /// <param name="element">Xml element</param>
        /// <returns>Created object</returns>
        public override ICategoryObject Create(string type, XElement element)
        {
            foreach (AbstractXmlCreateObjectFactory factory in factories)
            {
                ICategoryObject co = factory.Create(type, element);
                if (co != null)
                {
                    return co;
                }
            }
            return null;
        }

        #endregion

        #region Public



        private XmlCreateObjectFactoryAggregate Create(AbstractXmlCreateObjectFactory[] factories)
        {
            AbstractXmlCreateObjectFactory factory = factories[0];
            string at = factory.AttributeType;
            string an = factory.AttributeName;
            IXmlObjectFactory fd = factory;
            IDesktop d = fd.Desktop;
            XmlCreateObjectFactoryAggregate agg =
                new XmlCreateObjectFactoryAggregate(d, at, an);
            agg.factories = factories;
            return agg;
        }

        #endregion
    }
}
