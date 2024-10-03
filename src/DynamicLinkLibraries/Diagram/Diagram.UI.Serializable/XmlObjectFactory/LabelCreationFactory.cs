using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Linq;


using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

namespace Diagram.UI.XmlObjectFactory
{
    /// <summary>
    /// Creator of labels
    /// </summary>
    public class LabelCreationFactory : AbstractXmlObjectFactory
    {
        #region Fields


 
        IXmlObjectFactory factory;

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory">Factory</param>
        public LabelCreationFactory(IXmlObjectFactory factory)
            : base(factory.Desktop)
        {
            this.factory = factory;
            desktop = factory.Desktop as PureDesktopPeer;
            dictionary = factory.Dictionary;
            list = factory.List;
        }

        #endregion

        #region IXmlObjectFactory Members

        /// <summary>
        /// Creates objects
        /// </summary>
        /// <param name="element">XmlElement</param>
        /// <param name="categoryObject">Object</param>
        public override void Create(XElement element, ref ICategoryObject categoryObject)
        {
            factory.Create(element, ref categoryObject);
            if (categoryObject == null)
            {
                return;
            }
            string name = AbstractXmlCreateObjectFactory.GetName(factory, categoryObject);
            INamedComponent nc = categoryObject.Object as INamedComponent; 
            PureObjectLabelPeer ol = new PureObjectLabelPeer(name, nc.Kind, categoryObject.GetType().FullName, 0, 0);
            desktop.AddObjectLabel(ol, categoryObject, true);
        }

 
        #endregion

    }
}