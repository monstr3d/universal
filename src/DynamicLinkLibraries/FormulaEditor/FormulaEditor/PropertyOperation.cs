using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using BaseTypes.Interfaces;
using BaseTypes;
using ErrorHandler;

namespace FormulaEditor
{
    /// <summary>
    /// Operation of property
    /// </summary>
    class PropertyOperation : IObjectOperation
    {
        private PropertyInfo propertyInfo;
        private Type objectType;

        private object retType;

        private object ob;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="propertyName">Propety name</param>
        private PropertyOperation(Type type, PropertyInfo propertyInfo, object o)
        {
            objectType = type;
            ob = o;
            TypeInfo ti = IntrospectionExtensions.GetTypeInfo(type);
            this.propertyInfo = propertyInfo;
            if (propertyInfo == null)
            {
                throw new OwnException();
            }
            retType = propertyInfo.PropertyType.ToObjectType();
        }

        internal static IObjectOperation GetPropertyOperation(object o, string propertyName)
        {
            Type t = o.GetType();
            if (o is Type)
            {
                t = o as Type;
            }
            TypeInfo ti = IntrospectionExtensions.GetTypeInfo(t);
            PropertyInfo propertyInfo = null;
            while (true)
            {
                propertyInfo = ti.GetDeclaredProperty(propertyName);
                if (propertyInfo != null)
                {
                    return new PropertyOperation(t, propertyInfo, o);
                }
                if (t.Equals(typeof(object)))
                {
                    break;
                }
                t = ti.BaseType;
                ti = IntrospectionExtensions.GetTypeInfo(t);
            }
            return null;
        }




        #region IObjectOperation Members

        /// <summary>
        /// Arity of this operation
        /// </summary>
        object[] IObjectOperation.InputTypes
        {
            get
            {
                return new object[] { ob };
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                object obj = x[0];
                object ret = propertyInfo.GetValue(x[0], null);
                return ret;
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                return retType;
            }
        }

        #endregion
    }
}
