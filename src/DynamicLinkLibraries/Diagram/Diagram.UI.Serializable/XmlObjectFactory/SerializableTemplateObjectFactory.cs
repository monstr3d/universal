using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using CategoryTheory;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

namespace Diagram.UI.XmlObjectFactory
{
    /// <summary>
    /// Temlpate object factory  from serialized objects
    /// </summary>
    public class SerializableTemplateObjectFactory : TemplateDesktopFactory
    {

        #region Fields

        IDesktop pattern;

        byte[] bytes;
        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="attrType">Type attribbute</param>
        /// <param name="attrName">Name attribute</param>
        /// <param name="bytes">Serialization bytes</param>
        public SerializableTemplateObjectFactory(IDesktop desktop, string attrType, string attrName,
            byte[] bytes)
            : base(desktop, attrType, attrName)
        {
            this.bytes = bytes;
            Load();
            IEnumerable<ICategoryObject> l = pattern.CategoryObjects;
            foreach (ICategoryObject co in l)
            {
                IObjectLabel la = co.Object as IObjectLabel;
                patterns.Add(la.Name);
            }
        }

        #endregion


        #region Overriden

        /// <summary>
        /// Pattern desktop
        /// </summary>
        protected override IDesktop Pattern
        {
            get
            {
                IDesktop d = pattern;
                Load();
                return d;

            }
        }

 
        #endregion

        

        private void Load()
        {
            PureDesktopPeer d = new PureDesktopPeer();
            d.Load(bytes);
            pattern = d;
        }
    }
}
