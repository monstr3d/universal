using BaseTypes.Interfaces;
using FormulaEditor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaEditor.Symbols;
using FormulaEditor.Attributes;

namespace FormulaEditor
{
    /// <summary>
    /// Fiction property operation
    /// </summary>
    [Fiction]
    public class PropertyFictionOperation : IOperationDetector, IObjectOperation, IOperationAcceptor
    {
        string name;
        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly PropertyFictionOperation Singleton = new PropertyFictionOperation();

        private PropertyFictionOperation()
        {

        }

        private PropertyFictionOperation(string name)
        {
            this.name = name;
        }

   
        internal string Name
        {
            get
            {
                return name;
            }
        }

        object IObjectOperation.this[object[] arguments]
        {
            get
            {
                return new object();
            }
        }

        object[] IObjectOperation.InputTypes
        {
            get
            {
                return new object[0];
            }
        }

        object IObjectOperation.ReturnType
        {
            get
            {
                return new object();
            }
        }

        IOperationAcceptor IOperationDetector.Detect(MathSymbol symbol)
        {
            if (symbol.Symbol == '.')
            {
                if (!symbol.String.Equals("."))
                {
                    return new PropertyFictionOperation(symbol.String);
                }
            }
            return null;
        }

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            return this;
        }
    }
}
