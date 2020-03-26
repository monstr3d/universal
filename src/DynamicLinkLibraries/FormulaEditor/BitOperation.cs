using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Utils;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Conditional operation
    /// </summary>
    public class BitOperation : IObjectOperation, IBinaryAcceptor, ICloneable,
        IFormulaCreatorOperation
    {

        /// <summary>
        /// Type
        /// </summary>
        private object type;

        /// <summary>
        /// Type
        /// </summary>
        public char symbol;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol"></param>
        public BitOperation(char symbol)
        {
            this.symbol = symbol;
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
            return OptionalOperation.CreateFormula(this, tree, level, sizes, symbol + "");
        }



        /// <summary>
        /// Operation priority
        /// </summary>
        public int OperationPriority
        {
            get
            {
                if ((symbol == '\u2266') | (symbol == '\u2267'))
                {
                    return (int)ElementaryOperationPriorities.IntegerShift;
                }
                if (symbol == '^')
                {
                    return (int)ElementaryOperationPriorities.IntegerBitwiseOR;
                }
                if (symbol == '|')
                {
                    return (int)ElementaryOperationPriorities.IntegerOR;
                }
                return (int)ElementaryOperationPriorities.IntegerAND;
            }
        }



        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>A clone</returns>
        public object Clone()
        {
            return new BitOperation(symbol);
        }

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] IObjectOperation.InputTypes
        {
            get
            {
                return new object[] { type, type };
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                if ((symbol == '\u2266') | (symbol == '\u2267'))
                {
                    return shift(x[0], x[1]);
                }
                return perform(x);
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

         /// <summary>
        /// Acceptor of binary operation
        /// </summary>
        /// <param name="typeA">Type of left part</param>
        /// <param name="typeB">Type of right part</param>
        /// <returns>Accepted operation</returns>
        public IObjectOperation Accept(object typeA, object typeB)
        {
            if (!ElementaryBinaryOperation.IsInteger(typeA))
            {
                throw new Exception("Illegal integer argument");
            }
            if ((symbol == '\u2266') | (symbol == '\u2267'))
            {
                if (!ElementaryBinaryOperation.IsNumber(typeB))
                {
                    throw new Exception("Illegal integer argument");
                }
                type = typeA;
                return this;
            }
            if (!typeA.Equals(typeB))
            {
                throw new Exception("Different types of integer");
            }
            type = typeA;
            return this;
        }

        /// <summary>
        /// Shifts integer object
        /// </summary>
        /// <param name="o">The obhect</param>
        /// <param name="shift">The shift</param>
        /// <returns>Shift result</returns>
        private object shift(object o, object shift)
        {
            double s = Converter.ToDouble(shift);
            int i = (int)s;
            if (type is Byte)
            {
                byte x = (byte)o;
                switch (symbol)
                {
                    case '\u2266':
                        return x << i;
                    case '\u2267':
                        return x >> i;
                }
            }
            if (type is UInt16)
            {
                ushort x = (ushort)o;
                switch (symbol)
                {
                    case '\u2266':
                        return x << i;
                    case '\u2267':
                        return x >> i;
                }
            }
            if (type is UInt32)
            {
                uint x = (uint)o;
                switch (symbol)
                {
                    case '\u2266':
                        return x << i;
                    case '\u2267':
                        return x >> i;
                }
            }
            if (type is UInt64)
            {
                ulong x = (ulong)o;
                switch (symbol)
                {
                    case '\u2266':
                        return x << i;
                    case '\u2267':
                        return x >> i;
                }
            }
            if (type is SByte)
            {
                sbyte x = (sbyte)o;
                switch (symbol)
                {
                    case '\u2266':
                        return x << i;
                    case '\u2267':
                        return x >> i;
                }
            }
            if (type is Int16)
            {
                short x = (short)o;
                switch (symbol)
                {
                    case '\u2266':
                        return x << i;
                    case '\u2267':
                        return x >> i;
                }
            }
            if (type is Int32)
            {
                int x = (int)o;
                switch (symbol)
                {
                    case '\u2266':
                        return x << i;
                    case '\u2267':
                        return x >> i;
                }
            }
            if (type is Int64)
            {
                long x = (long)o;
                switch (symbol)
                {
                    case '\u2266':
                        return x << i;
                    case '\u2267':
                        return x >> i;
                }
            }
            return 0;
        }

        private object perform(object[] x)
        {
            if (type is Byte)
            {
                byte a = (byte)x[0];
                byte b = (byte)x[1];
                switch (symbol)
                {
                    case '|':
                        return a | b;
                    case '&':
                        return a & b;
                    case '^':
                        return a ^ b;
                }
            }
            if (type is UInt16)
            {
                ushort a = (ushort)x[0];
                ushort b = (ushort)x[1];
                switch (symbol)
                {
                    case '|':
                        return a | b;
                    case '&':
                        return a & b;
                    case '^':
                        return a ^ b;
                }
            }
            if (type is UInt32)
            {
                uint a = (uint)x[0];
                uint b = (uint)x[1];
                switch (symbol)
                {
                    case '|':
                        return a | b;
                    case '&':
                        return a & b;
                    case '^':
                        return a ^ b;
                }
            }
            if (type is UInt64)
            {
                ulong a = (ulong)x[0];
                ulong b = (ulong)x[1];
                switch (symbol)
                {
                    case '|':
                        return a | b;
                    case '&':
                        return a & b;
                    case '^':
                        return a ^ b;
                }
            }
            if (type is SByte)
            {
                sbyte a = (sbyte)x[0];
                sbyte b = (sbyte)x[1];
                switch (symbol)
                {
                    case '|':
                        return a | b;
                    case '&':
                        return a & b;
                    case '^':
                        return a ^ b;
                }
            }
            if (type is Int16)
            {
                short a = (short)x[0];
                short b = (short)x[1];
                switch (symbol)
                {
                    case '|':
                        return a | b;
                    case '&':
                        return a & b;
                    case '^':
                        return a ^ b;
                }
            }
            if (type is Int32)
            {
                int a = (int)x[0];
                int b = (int)x[1];
                switch (symbol)
                {
                    case '|':
                        return a | b;
                    case '&':
                        return a & b;
                    case '^':
                        return a ^ b;
                }
            }
            if (type is Int64)
            {
                long a = (long)x[0];
                long b = (long)x[1];
                switch (symbol)
                {
                    case '|':
                        return a | b;
                    case '&':
                        return a & b;
                    case '^':
                        return a ^ b;
                }
            }
            return null;
        }
    }
}
