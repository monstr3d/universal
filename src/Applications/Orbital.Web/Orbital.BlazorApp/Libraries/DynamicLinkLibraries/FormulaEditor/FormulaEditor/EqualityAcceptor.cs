using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Acceptor of inequality opreation
    /// </summary>
    public class EqualityAcceptor : IBinaryAcceptor
    {
        /// <summary>
        /// The singleton
        /// </summary>
        public static readonly EqualityAcceptor Object = new EqualityAcceptor();

        /// <summary>
        /// Constructor
        /// </summary>
        private EqualityAcceptor()
        {
        }

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="typeA">Type of left part</param>
        /// <param name="typeB">Type of right part</param>
        /// <returns>Accepted operation</returns>
        public IObjectOperation Accept(object typeA, object typeB)
        {
            if ((typeA is object[]) & (typeB is object[]))
            {
                object[] oa = typeA as object[];
                object[] ob = typeB as object[];
                TypeInfo tA = oa[0].ToTypeInfo();
                TypeInfo tB = ob[0].ToTypeInfo();
                string pA = oa[1] as string;
                string pB = ob[1] as string;
                PropertyInfo iA = tA.GetDeclaredProperty(pA);
                PropertyInfo iB = tB.GetDeclaredProperty(pB);
                if (iA.GetValue(oa[0], null).GetType() == iA.GetValue(ob[0], null).GetType())
                {
                    return EqualityOperation.Object;
                }
            }
            if ((typeA is object[]))
            {
                object[] oa = typeA as object[];
                TypeInfo tA = oa[0].ToTypeInfo();
                string pA = oa[1] as string;
                PropertyInfo iA = tA.GetDeclaredProperty(pA);
                if (iA.GetValue(oa[0], null).GetType() == typeB.GetType())
                {
                    return EqualityOperation.Object;
                }
            }
            if ((typeB is object[]))
            {
                object[] ob = typeB as object[];
                TypeInfo tB = ob[0].ToTypeInfo();
                string pB = ob[1] as string;
                PropertyInfo iB = tB.GetDeclaredProperty(pB);
                if (iB.GetValue(ob[0], null).GetType() == typeA.GetType())
                {
                    return EqualityOperation.Object;
                }
            }
            if (!typeA.Equals(typeB))
            {
                throw new Exception("Different types in equality");
            }
            return EqualityOperation.Object;
        }
    }
}
