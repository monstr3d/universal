using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;


namespace FormulaEditor
{
    /// <summary>
    /// Binary brackets operation
    /// </summary>
    public class TernaryBrackets : IMultiVariableOperationAcceptor, IMultiVariableOperation
    {
        #region Fields

    //    object type;

        object retType;

        object[] types = new object[3];

        internal static readonly TernaryBrackets Singleton = new TernaryBrackets();

        #endregion

        #region Ctor

        private TernaryBrackets(object type)
        {
            retType = new ArrayReturnType(type, new int[] { 3 }, true);
        }

        private TernaryBrackets(Tuple<object, object, object> tuple)
        {
            retType = tuple;
            types = new object[] { tuple.Item1, tuple.Item2, tuple.Item3 };
        }

        private TernaryBrackets(object[] o) : 
            this(new Tuple<object,object,object>(o[0], o[1], o[2]))
        {

        }

        private TernaryBrackets()
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
            if (!(symbol is TernaryFunctionSymbol))
            {
                return null;
            }
            if (symbol.Symbol == '3')
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
            if (types.Length != 3)
            {
                return null;
            }
            if (!types[0].Equals(types[1]))
            {
                return new TernaryBrackets(types);
            }
            if (!types[0].Equals(types[2]))
            {
                return new TernaryBrackets(types);
            }
            return new TernaryBrackets(types[0]);
        }

        #endregion

        #region Private Members


        #endregion

    }
}
