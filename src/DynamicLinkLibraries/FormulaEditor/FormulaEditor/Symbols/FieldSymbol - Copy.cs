using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;



namespace FormulaEditor.Symbols
{
    /// <summary>
    /// Symbol linked to field
    /// </summary>
    public class FieldSymbol : SimpleSymbol, IObjectOperation, IOperationAcceptor
    {
        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly FieldSymbol Object = new FieldSymbol();

        private IFieldSymbolFactory factory;

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="s"></param>
        public FieldSymbol(FieldSymbol s)
            : this(s.s)
        {
        }


        /// <summary>
        /// Constructor by name
        /// </summary>
        /// <param name="name">Field name</param>
        public FieldSymbol(string name)
            : base('f', (int)FormulaConstants.Field, true, name)
        {
        }

        private FieldSymbol()
            : base('f')
        {
        }

        /// <summary>
        /// Factory of field
        /// </summary>
        public IFieldSymbolFactory Factory
        {
            set
            {
                factory = value;
            }
        }

        /// <summary>
        /// Overriden conversion to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (factory == null)
            {
                return base.ToString();
            }
            return factory.GetValue(this) + "";
        }

        /// <summary>
        /// The Interfaces.ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            return new FieldSymbol(s + "");
        }

        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return new object[0];
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        object IObjectOperation.this[object[] x]
        {
            get
            {
                if (factory == null)
                {
                    return this;
                }
                return factory.GetValue(this);

            }
        }

        object IObjectOperation.ReturnType
        {
            get { return Object; }
        }

        #endregion

        #region IOperationAcceptor Members

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            return this;
        }

        #endregion
    }
}
