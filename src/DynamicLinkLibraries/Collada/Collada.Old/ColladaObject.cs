using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf
{
    internal class ColladaObject : ICollada
    {

        #region Fields

        Dictionary<string, Func<XmlElement, object>> functions;

        Dictionary<Type, Func<XmlElement, object>> combined;

        #endregion
        public ColladaObject()
        {
        }

        #region ICollada Members

        Dictionary<string, Func<XmlElement, object>> ICollada.Functions => functions;

        Dictionary<Type, Func<XmlElement, object>> ICollada.Combined => combined;

        /// <summary>
        /// Clones object
        /// </summary>
        /// <param name="obj">The object to clone</param>
        /// <returns>CCloned object</returns>
        object ICollada.Clone(object obj)
        {
            return obj;
        }

        #endregion
    }
}
