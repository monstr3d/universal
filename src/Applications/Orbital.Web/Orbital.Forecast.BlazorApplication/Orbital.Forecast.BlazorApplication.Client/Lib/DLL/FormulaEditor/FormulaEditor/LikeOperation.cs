using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Reflection;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Like operation
    /// </summary>
    public class LikeOperation : IObjectOperation, IBinaryAcceptor, IBinaryDetector
    {
        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly LikeOperation Object = new LikeOperation();

        static private readonly Boolean type = false;
        static private readonly string strType = "";

        List<IBinaryAcceptor> acceptors = new List<IBinaryAcceptor>();

        /// <summary>
        /// Like operation
        /// </summary>
        /// <param name="o1">First object</param>
        /// <param name="o2">Second object</param>
        /// <returns>True if o1 like o2 and false otherwise</returns>
        static public bool Like(object o1, object o2)
        {
            string s1 = o1 + "";
            string s2 = o2 + "";
            s1 = s1.ToLower();
            s2 = s2.ToLower();
            int n = s1.IndexOf(s2);
            return n >= 0;
        }


        IObjectOperation getOtherOperation(object typeA, object typeB)
        {
            foreach (IBinaryAcceptor acceptor in acceptors)
            {
                IObjectOperation op = acceptor.Accept(typeA, typeB);
                return op;
            }
            return null;
        }

        /// <summary>
        /// Adds acceptor
        /// </summary>
        /// <param name="acceptor">Acceptor to add</param>
        public void Add(IBinaryAcceptor acceptor)
        {
            acceptors.Add(acceptor);
        }

        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return new object[] { "", "" };
            }
        }


        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                return Like(x[0], x[1]);
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                return type;
            }
        }

        #endregion

        #region IBinaryAcceptor Members

        /// <summary>
        /// Acceptor of binary operation
        /// </summary>
        /// <param name="typeA">Type of left part</param>
        /// <param name="typeB">Type of right part</param>
        /// <returns>Accepted operation</returns>
        public IObjectOperation Accept(object typeA, object typeB)
        {
            if (typeA is object[])
            {
                object[] o = typeA as object[];
                TypeInfo t = o[0].ToTypeInfo();
                string prop = o[1] as string;
                PropertyInfo info = t.GetDeclaredProperty(prop);
                if (info == null)
                {
                    return getOtherOperation(typeA, typeB);
                }
            }
            else if (!typeA.Equals(strType))
            {
                return getOtherOperation(typeA, typeB);
            }
            if (typeB is object[])
            {
                object[] o = typeB as object[];
                TypeInfo t = o[0].ToTypeInfo();
                string prop = o[1] as string;
                PropertyInfo info = t.GetDeclaredProperty(prop);
                if (info == null)
                {
                    return getOtherOperation(typeA, typeB);
                }
            }
            else if (!typeB.Equals(strType))
            {
                return getOtherOperation(typeA, typeB);
            }
            return this;
        }

        #endregion

        #region IBinaryDetector Members

        /// <summary>
        /// Association direction
        /// </summary>
        public BinaryAssociationDirection AssociationDirection
        {
            get
            {
                return BinaryAssociationDirection.RightLeft;
            }
        }

        /// <summary>
        /// Detects operation acceptor
        /// </summary>
        /// <param name="s">Operation symbol</param>
        /// <returns>The acceptor</returns>
        public IBinaryAcceptor Detect(MathSymbol s)
        {
            if (s is BinarySymbol)
            {
                if (s.Symbol == '\u2270')
                {
                    return this;
                }
            }
            return null;
        }

        #endregion
    }
}
