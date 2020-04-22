using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.XmlObjectFactory;



namespace Simulink.Proxy.Factory
{
    abstract class GenericFactory<T> : AbstractXmlObjectFactory where T : class
    {
        #region Fields

        protected XElement element;

        protected T obj;

        #endregion

        #region Ctor
        internal GenericFactory(IDesktop desktop)
            : base(desktop)
        {
        }
        #endregion

        #region Overriden


        public override void Create(XElement element, ref ICategoryObject categoryObject)
        {
            if (!(categoryObject is T))
            {
                return;
            }
            this.element = element;
            obj = categoryObject as T;
            Process();
        }

        #endregion

        #region Abstract

        protected abstract void Process();

        #endregion
    }
}
