using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using BaseTypes.Utils;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Elementary binary operation
    /// </summary>
    public class ElementaryBinaryOperation : IObjectOperation, ICloneable, IDerivationOperation,
        IFormulaCreatorOperation, IString
    {

 

        /// <summary>
        /// Type of operation
        /// </summary>
        private object type;


        /// <summary>
        /// Types of left 
        /// </summary>
        private object[] types;

        /// <summary>
        /// Type of operation
        /// </summary>
        private const Double a = 0;

        /// <summary>
        /// Operation symbol
        /// </summary>
        private char symbol;

        /// <summary>
        /// Calculator
        /// </summary>
        private Func<object[], object> calculate;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Operation symbol</param>
        /// <param name="types">Type of operation</param>
        public ElementaryBinaryOperation(char symbol, object[] types)
        {
            this.symbol = symbol;
            this.types = types;
            if (types[0].Equals(a) | types[1].Equals(a))
            {
                type = a;
            }
            calculate = CreateDelegate();
        }

        /// <summary>
        /// Creates formula
        /// </summary>
        /// <param name="tree">Operation tree</param>
        /// <param name="level">Formula level</param>
        /// <param name="sizes">Sizes of symbols</param>
        /// <returns>The formula</returns>
        public MathFormula CreateFormula(ObjectFormulaTree tree, byte level, int[] sizes)
        {
            MathFormula form = new MathFormula(level, sizes);
            for (int i = 0; i < 2; i++)
            {
                IFormulaCreatorOperation op = tree[i].Operation as IFormulaCreatorOperation;
                MathFormula f = op.CreateFormula(tree[i], level, sizes);
                MathFormula fp = null;
                if (op.OperationPriority < OperationPriority)
                {
                    fp = new MathFormula(level, sizes);
                    MathSymbol s = new BracketsSymbol();
                    s.Append(fp);
                    fp.First[0] = f;
                }
                else
                {
                    fp = f;
                }
                form.Add(fp);
                if (i == 0)
                {
                    MathSymbol s = new BinarySymbol(symbol);
                    s.Append(form);
                }
            }
            return form;
        }



        /// <summary>
        /// Operation priority
        /// </summary>
        public int OperationPriority
        {
            get
            {
                if (symbol == '*')
                {
                    return (int)ElementaryOperationPriorities.Multiply;
                }
                return (int)ElementaryOperationPriorities.PlusMinus;
            }
        }


        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>A clone</returns>
        public object Clone()
        {
            return new ElementaryBinaryOperation(symbol, types);
        }

        /// <summary>
        /// Calculates derivation
        /// </summary>
        /// <param name="tree">The function for derivation calculation</param>
        /// <param name="variableName">Name of variable</param>
        /// <returns>The derivation</returns>
        ObjectFormulaTree IDerivationOperation.Derivation(ObjectFormulaTree tree, string variableName)
        {
            bool[] b = new bool[] { false, false };
            if ((symbol == '+') | (symbol == '-')) // "+" or "-" operation
            {
                IObjectOperation op = new ElementaryBinaryOperation(symbol,
                    new object[] { tree[0].ReturnType, tree[1].ReturnType });
                List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
                for (int i = 0; i < tree.Count; i++)
                {
                    ObjectFormulaTree t = tree[i].Derivation(variableName);
                    b[i] = ZeroPerformer.IsZero(t);
                    l.Add(t);
                }
                if (b[0])
                {
                    if (b[1])
                    {
                        return ElementaryRealConstant.RealZero;
                    }
                    if (symbol == '+')
                    {
                        return l[1];
                    }
                    List<ObjectFormulaTree> ll = new List<ObjectFormulaTree>();
                    ll.Add(l[1]);
                    return new ObjectFormulaTree(new ElementaryFunctionOperation('-'), ll);
                }
                if (b[1])
                {
                    return l[0];
                }
                return new ObjectFormulaTree(op, l);
            }
            ObjectFormulaTree[] der = new ObjectFormulaTree[2];
            for (int i = 0; i < 2; i++)
            {
                der[i] = tree[i].Derivation(variableName);
                b[i] = ZeroPerformer.IsZero(der[i]);
            }
            if (symbol == '*') // "*" - operation
            {
                List<ObjectFormulaTree> list = new List<ObjectFormulaTree>();
                for (int i = 0; i < 2; i++)
                {
                    List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
                    l.Add(tree[i]);
                    l.Add(der[1 - i]);
                    ElementaryBinaryOperation o = new ElementaryBinaryOperation('*',
                        new object[] { l[0].ReturnType, l[1].ReturnType });
                    list.Add(new ObjectFormulaTree(o, l));
                }
                if (b[0] & b[1])
                {
                    return ElementaryRealConstant.RealZero;
                }
                for (int i = 0; i < b.Length; i++)
                {
                    if (b[i])
                    {
                        return list[i];
                    }
                }
                ElementaryBinaryOperation op = new ElementaryBinaryOperation('+',
                    new object[] { list[0].ReturnType, list[1].ReturnType });
                return new ObjectFormulaTree(op, list);
            }
            return null;
        }

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] IObjectOperation.InputTypes
        {
            get
            {
                return types;
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                return calculate(x);
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

 
        #region Specific Members

        /// <summary>
        /// Detects whether object type is integer
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>True if type is integer and false otherwise</returns>
        public static bool IsInteger(object o)
        {
            return (o is SByte) | (o is Byte) | (o is Int16) | (o is UInt16)
                | (o is Int32) | (o is UInt32) | (o is Int64) | (o is UInt64);
        }

        /// <summary>
        /// Detects whether object type is unsigned
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>True if type is unsigned and false otherwise</returns>
        public static bool IsUnsigned(object o)
        {
            return (o is Byte) | (o is UInt16) | (o is UInt32) | (o is UInt64);
        }

        /// <summary>
        /// Detects whether object type is double
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>True if type is double and false otherwise</returns>
        public static bool IsDouble(object o)
        {
            return (o is Double);
        }

        public static bool IsSingle(object o)
        {
            return (o is Single);
        }

        /// <summary>
        /// Detects whether object type is numercial
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>True if type is numercial and false otherwise</returns>
        public static bool IsNumber(object o)
        {
            return IsDouble(o) | IsSingle(o) | IsInteger(o);
        }

        /// <summary>
        /// Detects whether object is 64 bit integer
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>True if object is 64 bit integer and false otherwise</returns>
        public static bool IsInteger64(object o)
        {
            return (o is UInt64) | (o is Int64);
        }

        /// <summary>
        /// Detects whether object is negative
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>True if object is negative and false otherwise</returns>
        public static bool IsNegative(object o)
        {
            return Converter.ToDouble(o) < 0;
        }

        /// <summary>
        /// Calculates number of object bits
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>Number of bits</returns>
        public static int NBits(object o)
        {
            if ((o is Byte) | (o is SByte))
            {
                return 8;
            }
            if ((o is Int16) | (o is UInt16))
            {
                return 16;
            }
            if ((o is Int32) | (o is UInt32))
            {
                return 32;
            }
            if ((o is Int64) | (o is UInt64))
            {
                return 64;
            }
            return 0;
        }

        /// <summary>
        /// Operation symbol
        /// </summary>
        public char Symbol
        {
            get
            {
                return symbol;
            }
        }


        /// <summary>
        /// Detects type of binary
        /// </summary>
        /// <param name="typeA">Type of first argument</param>
        /// <param name="typeB">Type of second argument</param>
        /// <returns>Return type</returns>
        public static object DetectType(object typeA, object typeB)
        {
            if (!IsNumber(typeA) | !IsNumber(typeB))
            {
                return null;
            }
            if (IsDouble(typeA) | IsSingle(typeA) | IsDouble(typeB) | IsSingle(typeB))
            {
                return a;
            }
/*            if (IsSingle(typeA) | IsSingle(typeB))
            {
                return (Single)0;
            }*/
            int nA = NBits(typeA);
            int nB = NBits(typeB);
            if (nA > nB)
            {
                return typeA;
            }
            if (nB > nA)
            {
                return typeB;
            }
            if (IsUnsigned(typeA) & IsUnsigned(typeB))
            {
                return typeA;
            }
            if (!IsUnsigned(typeA))
            {
                return typeA;
            }
            if (!IsUnsigned(typeB))
            {
                return typeB;
            }
            return null;
        }


        /// <summary>
        /// Creates delegate
        /// </summary>
         /// <returns>Created delegate</returns>
        private Func<object[], object> CreateDelegate()
        {
            Int32 it = 0;
            if (type == null)
            {
                return null;
            }
            if (IsDouble(type))
            {
                if (types[0].Equals(a) & types[1].Equals(a))
                {
                    switch (symbol)
                    {
                        case '+':
                            return dplus;
                        case '-':
                            return dminus;
                        case '*':
                            return dmult;
                    }
                }
                if (types[0].Equals(it))
                {
                    switch (symbol)
                    {
                        case '+':
                            return i32dplus;
                        case '-':
                            return i32dminus;
                        case '*':
                            return i32dmult;
                    }
                }
                if (types[1].Equals(it))
                {
                    switch (symbol)
                    {
                        case '+':
                            return di32plus;
                        case '-':
                            return di32minus;
                        case '*':
                            return di32mult;
                    }
                }
            }
            if (type is SByte)
            {
                switch (symbol)
                {
                    case '+':
                        return i8plus;
                    case '-':
                        return i8minus;
                    case '*':
                        return i8mult;
                }
            }
            if (type is Int16)
            {
                switch (symbol)
                {
                    case '+':
                        return i16plus;
                    case '-':
                        return i16minus;
                    case '*':
                        return i16mult;
                }
            }
            if (type is Int32)
            {
                switch (symbol)
                {
                    case '+':
                        return i32plus;
                    case '-':
                        return i32minus;
                    case '*':
                        return i32mult;
                }
            }
            if (type is Int64)
            {
                switch (symbol)
                {
                    case '+':
                        return i64plus;
                    case '-':
                        return i64minus;
                    case '*':
                        return i64mult;
                }
            }
            if (type is Byte)
            {
                switch (symbol)
                {
                    case '+':
                        return ui8plus;
                    case '-':
                        return ui8minus;
                    case '*':
                        return ui8mult;
                }
            }
            if (type is UInt16)
            {
                switch (symbol)
                {
                    case '+':
                        return ui16plus;
                    case '-':
                        return ui16minus;
                    case '*':
                        return ui16mult;
                }
            }
            if (type is UInt32)
            {
                switch (symbol)
                {
                    case '+':
                        return ui32plus;
                    case '-':
                        return ui32minus;
                    case '*':
                        return ui32mult;
                }
            }
            if (type is UInt64)
            {
                switch (symbol)
                {
                    case '+':
                        return ui64plus;
                    case '-':
                        return ui64minus;
                    case '*':
                        return ui64mult;
                }
            }
            return null;
        }








        #endregion


        #region Delegates

        #region Double

        object dplus(object[] x)
        {
            double a = (double)x[0];
            double b = (double)x[1];
            return a + b;
        }

        object dminus(object[] x)
        {
            double a = (double)x[0];
            double b = (double)x[1];
            return a - b;
        }

        object dmult(object[] x)
        {
            double a = (double)x[0];
            double b = (double)x[1];
            return a * b;
        }
        
        object i32dplus(object[] x)
        {
            int a = (int)x[0];
            double b = (double)x[1];
            return (double)a + b;
        }

        object i32dminus(object[] x)
        {
            int a = (int)x[0];
            double b = (double)x[1];
            return (double)a - b;
        }

        object i32dmult(object[] x)
        {
            int a = (int)x[0];
            double b = (double)x[1];
            return (double)a * b;
        }


        object di32plus(object[] x)
        {
            double a = (double)x[0];
            int b = (int)x[1];
            return a + (double)b;
        }

        object di32minus(object[] x)
        {
            double a = (double)x[0];
            int b = (int)x[1];
            return a - (double)b;
        }

        object di32mult(object[] x)
        {
            double a = (double)x[0];
            int b = (int)x[1];
            return a * (double)b;
        }





        #endregion

        #region Single



        #endregion

        #region SByte

        object i8plus(object[] x)
        {
            sbyte a = (sbyte)x[0];
            sbyte b = (sbyte)x[1];
            return a + b;
        }

        object i8minus(object[] x)
        {
            sbyte a = (sbyte)x[0];
            sbyte b = (sbyte)x[1];
            return a - b;
        }

        object i8mult(object[] x)
        {
            sbyte a = (sbyte)x[0];
            sbyte b = (sbyte)x[1];
            return a * b;
        }


        #endregion

        #region Byte

        object ui8plus(object[] x)
        {
            byte a = (byte)x[0];
            byte b = (byte)x[1];
            return a + b;
        }

        object ui8minus(object[] x)
        {
            byte a = (byte)x[0];
            byte b = (byte)x[1];
            return a - b;
        }

        object ui8mult(object[] x)
        {
            byte a = (byte)x[0];
            byte b = (byte)x[1];
            return a * b;
        }


        #endregion

        #region Int16

        object i16plus(object[] x)
        {
            short a = (short)x[0];
            short b = (short)x[1];
            return a + b;
        }

        object i16minus(object[] x)
        {
            short a = (short)x[0];
            short b = (short)x[1];
            return a - b;
        }

        object i16mult(object[] x)
        {
            short a = (short)x[0];
            short b = (short)x[1];
            return a * b;
        }


        #endregion

        #region UInt16

        object ui16plus(object[] x)
        {
            ushort a = (ushort)x[0];
            ushort b = (ushort)x[1];
            return a + b;
        }

        object ui16minus(object[] x)
        {
            ushort a = (ushort)x[0];
            ushort b = (ushort)x[1];
            return a - b;
        }

        object ui16mult(object[] x)
        {
            ushort a = (ushort)x[0];
            ushort b = (ushort)x[1];
            return a * b;
        }


        #endregion

        #region Int32

        object i32plus(object[] x)
        {
            int a = (int)x[0];
            int b = (int)x[1];
            return a + b;
        }

        object i32minus(object[] x)
        {
            int a = (int)x[0];
            int b = (int)x[1];
            return a - b;
        }

        object i32mult(object[] x)
        {
            int a = (int)x[0];
            int b = (int)x[1];
            return a * b;
        }


        #endregion

        #region UInt32

        object ui32plus(object[] x)
        {
            uint a = (uint)x[0];
            uint b = (uint)x[1];
            return a + b;
        }

        object ui32minus(object[] x)
        {
            uint a = (uint)x[0];
            uint b = (uint)x[1];
            return a - b;
        }

        object ui32mult(object[] x)
        {
            uint a = (uint)x[0];
            uint b = (uint)x[1];
            return a * b;
        }


        #endregion

        #region Int64

        object i64plus(object[] x)
        {
            long a = (long)x[0];
            long b = (long)x[1];
            return a + b;
        }

        object i64minus(object[] x)
        {
            long a = (long)x[0];
            long b = (long)x[1];
            return a - b;
        }

        object i64mult(object[] x)
        {
            long a = (long)x[0];
            long b = (long)x[1];
            return a * b;
        }


        #endregion

        #region UInt64

        object ui64plus(object[] x)
        {
            double a = (double)x[0];
            double b = (double)x[1];
            return a + b;
        }

        object ui64minus(object[] x)
        {
            double a = (double)x[0];
            double b = (double)x[1];
            return a - b;
        }

        object ui64mult(object[] x)
        {
            double a = (double)x[0];
            double b = (double)x[1];
            return a * b;
        }


        #endregion


        #endregion

        #region IString Members

        string IString.String
        {
            get { return symbol + ""; }
        }

        #endregion
    }
}
