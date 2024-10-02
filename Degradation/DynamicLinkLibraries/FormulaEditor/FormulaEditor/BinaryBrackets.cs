using System;
using System.Collections.Generic;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Binary brackets operation
    /// </summary>
    public class BinaryBrackets : IMultiVariableOperationAcceptor, IMultiVariableOperation
    {
        #region Fields

    //    object type;

       object retType;

        object[] types = new object[2];

        internal static readonly BinaryBrackets Singleton = new BinaryBrackets();

        #endregion

        #region Ctor

        private BinaryBrackets(object type)
        {
         //   this.type = type;
            retType = new ArrayReturnType(type, new int[] { 2 }, true);
        }


        private BinaryBrackets(Tuple<object, object> tuple)
        {
            retType = tuple;
            types = new object[] { tuple.Item1, tuple.Item2 };
        }


        private BinaryBrackets(object[] o) :
            this(new Tuple<object, object>(o[0], o[1]))
        {
          
        }



        private BinaryBrackets()
        {
        }

        #endregion

        #region IObjectOperation Members

        object[] IObjectOperation.InputTypes
        {
            get { return types; }
        }

        object IObjectOperation.this[object[] x]
        {
            get { return x; }
        }

        object IObjectOperation.ReturnType
        {
            get { return retType; }
        }

        #endregion

        #region IMultiVariableOperationAcceptor Members

        IMultiVariableOperation IMultiVariableOperationAcceptor.AcceptOperation(MathSymbol symbol)
        {
            if (!(symbol is BinaryFunctionSymbol))
            {
                return null;
            }
            if (symbol.Symbol == '2')
            {
                return Singleton;
            }
            return null;
        }
  
        #endregion

        #region IOperationAcceptor Members

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            return null;
        }

        #endregion

        #region IMultiVariableOperation Members

        IObjectOperation IMultiVariableOperation.Accept(object[] types)
        {
            if (types.Length != 2)
            {
                return null;
            }
            if (!types[0].Equals(types[1]))
            {
                return new BinaryBrackets(types);
            }
            return new BinaryBrackets(types[0]);
        }

        #endregion

    }
}
