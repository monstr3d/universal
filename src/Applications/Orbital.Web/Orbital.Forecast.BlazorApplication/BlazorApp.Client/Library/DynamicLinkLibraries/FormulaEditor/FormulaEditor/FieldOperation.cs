using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using BaseTypes.Interfaces;
using BaseTypes;

namespace FormulaEditor
{
    /// <summary>
    /// Operation of property
    /// </summary>
    class FieldOperation : IObjectOperation
    {
        private FieldInfo fieldInfo;

        private Type objectType;

        private object retType;

        private object ob;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="propertyName">Propety name</param>
        private FieldOperation(Type type, FieldInfo fieldInfo, object o)
        {
            objectType = type;
            ob = o;
            TypeInfo ti = IntrospectionExtensions.GetTypeInfo(type);
            this.fieldInfo = fieldInfo;
            if (fieldInfo == null)
            {
                throw new Exception();
            }
            retType = fieldInfo.FieldType.ToObjectType();
        }

        internal static IObjectOperation GetFieldOperation(object o, string fieldName)
        {
            Type t = o.GetType();
            if (o is Type)
            {
                t = o as Type;
            }
            TypeInfo ti = IntrospectionExtensions.GetTypeInfo(t);
            FieldInfo fieldInfo = null;
            while (true)
            {
                fieldInfo = ti.GetDeclaredField(fieldName);
                if (fieldInfo != null)
                {
                    return new FieldOperation(t, fieldInfo, o);
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
                object ret = fieldInfo.GetValue(x[0]);
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
