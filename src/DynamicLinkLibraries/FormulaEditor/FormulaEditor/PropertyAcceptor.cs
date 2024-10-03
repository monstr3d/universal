using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{

    /// <summary>
    /// Acceptor of property operation
    /// </summary>
    public class PropertyAcceptor : IBinaryAcceptor, IBinaryDetector, IOperationDetector
    {

        private Type objectType;

        private string[] propertyNames;

        string propertySeparator;

        private object obj;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectType">Type of object</param>
        /// <param name="propertyNames">Names of properties</param>
        /// <param name="propertySeparator">Separator of properties</param>
        public PropertyAcceptor(Type objectType, string[] propertyNames, string propertySeparator)
        {
            this.propertyNames = propertyNames;
            this.propertySeparator = propertySeparator;
            this.objectType = objectType;
        }

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
                TypeInfo type = o[0].ToTypeInfo();
                object[] ob = typeB as object[];
                string pName = ob[1] as string;
                IEnumerable<PropertyInfo> inform = type.DeclaredProperties;
                //	foreach (PropertyInfo info in inform)
                //	{
                foreach (string propertyName in propertyNames)
                {
                    if (propertyName.Equals(pName))
                    {
                        return null;
                    }
                }
                //	}
            }
            return null;
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
            if (s.String.Equals(propertySeparator))
            {
                return this;
            }
            return null;
        }

        #endregion

        #region IOperationDetector Members

        IOperationAcceptor IOperationDetector.Detect(MathSymbol s)
        {
            //PropertyInfo[] inform = objectType.GetProperties();
            //foreach (PropertyInfo info in inform)
            //{
            foreach (string propertyName in propertyNames)
            {
                if (propertyName.Equals(s.String))
                {
                    return new SinglePropertyOperation(this, propertyName);
                }
            }
            //}
            return null;
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Provider of properties
        /// </summary>
        public object Object
        {
            get
            {
                return obj;
            }
            set
            {
                if (!value.GetType().Equals(objectType))
                {
                    throw new Exception();
                }
                obj = value;
            }
        }

        /// <summary>
        /// Type of object
        /// </summary>
        public Type ObjectType
        {
            get
            {
                return objectType;
            }
        }

        /// <summary>
        /// Names of properties
        /// </summary>
        internal string[] PropertyNames
        {
            get
            {
                return propertyNames;
            }
        }

        #endregion
    }
}
