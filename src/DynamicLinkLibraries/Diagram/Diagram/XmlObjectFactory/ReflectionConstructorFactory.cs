using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Reflection;

using CategoryTheory;



namespace Diagram.UI.XmlObjectFactory
{
    /// <summary>
    /// Factory from reflection constructor
    /// </summary>
    public class ReflectionConstructorFactory //: AbstractXmlCreateObjectFactory
    {

        #region Fields

        Dictionary<string, Type> typeDictionary = null;

        #endregion

        #region Ctor


        #endregion

        #region Members

        /// <summary>
        /// Creates object from element
        /// </summary>
        /// <param name="type">Object type</param>
        /// <param name="element">The element</param>
        /// <returns>The object</returns>
        public ICategoryObject Create(string type, XElement element)
        {
            if (!typeDictionary.ContainsKey(type))
            {
                return null;
            }
            Type t = typeDictionary[type];
            TypeInfo ti = System.Reflection.IntrospectionExtensions.GetTypeInfo(t);
            ConstructorInfo c = ti.GetConstructor(new Type[0]);
            return c.Invoke(new object[0]) as ICategoryObject;
        }

        #endregion

    }
}
