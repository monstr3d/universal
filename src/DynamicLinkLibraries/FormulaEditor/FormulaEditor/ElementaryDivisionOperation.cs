using BaseTypes.Interfaces;
using BaseTypes.Utils;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor
{
    class ElementaryDivisionOperation : IObjectOperation, Interfaces.ICloneable, IDerivationOperation,
        IFormulaCreatorOperation, IString
    {
        #region Fields

        /// <summary>
        /// Operation symbol
        /// </summary>
        private char symbol;

        /// <summary>
        /// Type of operation
        /// </summary>
        private object type;

        /// <summary>
        /// Types of left 
        /// </summary>
        private object[] types;

        /// <summary>
        /// Calculator
        /// </summary>
        private Func<object[], object> calculate;

        #endregion

        #region Ctor

        public ElementaryDivisionOperation(char symbol, object[] types)
        {
            this.symbol = symbol;
            this.types = types;
            type = DetectType(types[0], types[1], symbol);
            calculate = CreateDelegate();
        }

        #endregion

        #region IObjectOperation members

        object IObjectOperation.this[object[] arguments]
        {
            get
            {
                return calculate(arguments);
            }
        }

        object[] IObjectOperation.InputTypes
        {
            get
            {
                return types;
            }
        }

        object IObjectOperation.ReturnType
        {
            get
            {
                return type;
            }
        }

        #endregion

        #region IFormulaCreatorOperation members

        int IFormulaCreatorOperation.OperationPriority
        {
            get
            {
                return (int)ElementaryOperationPriorities.Divide;
            }
        }

        MathFormula IFormulaCreatorOperation.CreateFormula(ObjectFormulaTree tree, byte level, int[] sizes)
        {
            MathFormula form = new MathFormula(level, sizes);
            for (int i = 0; i < 2; i++)
            {
                IFormulaCreatorOperation op = tree[i].Operation as IFormulaCreatorOperation;
                MathFormula f = op.CreateFormula(tree[i], level, sizes);
                MathFormula fp = null;
                if (op.OperationPriority < (int)ElementaryOperationPriorities.Divide)
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
        #endregion

        #region IString Members

        string IString.String
        {
            get
            {
                if (symbol == '﹪')
                {
                    return "%";
                }
                if (symbol == '/')
                {
                    return "/";
                }
                return symbol + "";
            }
        }

        #endregion

        #region IClonable members

        object Interfaces.ICloneable.Clone()
        {
            return new ElementaryDivisionOperation(symbol, types);
        }


        #endregion

        #region IDerivationOperation members

        ObjectFormulaTree IDerivationOperation.Derivation(ObjectFormulaTree tree, string variableName)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Specific members

        #region Symbol

        public char Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        #endregion

        #region Type detectors

        /// <summary>
        /// Detecting the type of the result
        /// </summary>
        /// <param name="typeA">Type of the divident</param>
        /// <param name="typeB">Type of the divisor</param>
        /// <returns></returns>
        internal static object DetectType(object typeA, object typeB, char symbol)
        {
            if (!IsNumber(typeA) | !IsNumber(typeB))
            {
                return null;
            }
             
            if (symbol == '/')
            {
                if (typeA is Double | typeB is Double)
                {
                    return (double)0;
                }

                //If the program passes this point, the input types and the output type may not be double i.e. is either float or of an integer type.

                if (typeA is Single | typeB is Single)
                {
                    return (float)0;
                }

                //If the program passes this point, the inputs (divident and divisor) and the output (remainder) are of integer type(s).

                //If both types are unsigend, then the output is of unsigned type

                if (IsUnsigend (typeA) & IsUnsigend(typeB))
                {
                    if (NBits(typeA) > NBits(typeB))
                    {
                        return typeA;
                    }
                    return typeB;
                }

                //At least one of the types is now signed, thus so is the type of the output

                object o = SignedInt(Math.Max(NBits(typeA), NBits(typeB)));

                return o;
            }

            if (symbol == '﹪')
            {

                if (typeA is Double | typeB is Double)
                {
                    return (double)0;
                }

                //If the program passes this point, the input types and the output type may not be double i.e. is either float or of an integer type.

                if (typeA is Single | typeB is Single)
                {
                    return (float)0;
                }

                //If the program passes this point, the inputs (divident and divisor) and the output (remainder) are of integer type(s).

                //If both types are unsigned, return the greatest suitable unsigend type.
                if ((IsUnsigend(typeA) & IsUnsigend(typeB)) | (!IsUnsigend(typeA) & !IsUnsigend(typeB)))
                {
                    if (NBits(typeA) > NBits(typeB))
                    {
                        return typeA;
                    }
                    return typeB;
                }

                //If the program passes this point, the one of the input types is unsigned and the other is signed. It remains to shoose a passing type for the remainder
                //!!! Attention! The function was made basin on general consideration about base types! It may produce unexpected mismatch exceptions

                if (IsUnsigend(typeA)) //and thus typeB is signed
                {
                    return UnsigendInt(Math.Max(NBits(typeA), NBits(typeB)));
                }

                if (IsUnsigend(typeB)) //superfluous condition left for the sake of uniformity
                {
                    if (NBits(typeA) > NBits(typeB))
                    {
                        return typeA;
                    }
                    else
                    {
                        return SignedInt(NBits(typeB)); //perhaps +1. For now handled in the delegates.
                                                        //!!! Made to make type conversion simpler. 
                                                        // Yet, for exampleInt16 % UInt16 will yield Int32. 
                                                        // This may lead to memory overuse, if applied repeateldy to large arrays of integer data.   
                    }
                }
            }
            
            return null;
        }

        /// <summary>
        /// Returns if object is a number
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static bool IsNumber(object o)
        {
            return (o is Single) | (o is Double) | IsInteger(o);
        }

        /// <summary>
        /// Returns true if the object is an integer
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns></returns>
        private static bool IsInteger(object o)
        {
            return (o is SByte) | (o is Byte) | (o is Int16) | (o is UInt16) | (o is Int32) | (o is UInt32) | (o is Int64) | (o is UInt64);
        }

        /// <summary>
        /// Returns true if the object is unsigend.
        /// Caution! Does not detect US
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns></returns>
        private static bool IsUnsigend(object o)
        {
            return (o is Byte) | (o is UInt16) | (o is UInt32) | (o is UInt64);
        }

        private static int NBits(object o)
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
        /// Auxiliary function for choosing the best suitable unsigned type for the remainder. 
        /// </summary>
        /// <param name="bitnum">Number of bytes in the type</param>
        /// <returns></returns>
        private static object UnsigendInt(int bitnum)
        {
            if (bitnum < 9)
            {
                return (Byte)0;
            }
            if (bitnum < 17)
            {
                return (UInt16)0;
            }
            if (bitnum < 33)
            {
                return (UInt32)0;
            }
            return (UInt64)0;
        }

        /// <summary>
        /// Auxiliary function for choosing the best suitable unsigned type for the remainder. 
        /// </summary>
        /// <param name="bytenum">Number of bytes in the type</param>
        /// <returns></returns>
        private static object SignedInt(int bytenum)
        {
            if (bytenum < 9)
            {
                return (SByte)0;
            }
            if (bytenum < 17)
            {
                return (Int16)0;
            }
            if (bytenum < 33)
            {
                return (Int32)0;
            }
            return (Int64)0;
        }

        #endregion


        #region Delegates

        private Func<object[], object> CreateDelegate()
        {
            if (symbol == '﹪')
            {
                if (type is Double)
                {
                    return modulod;
                }

                if (type is Single)
                {
                    return modulof;
                }

                if (type is SByte)
                {
                    return modulosb;
                }

                if (type is Byte)
                {
                    return modulob;
                }

                if (type is Int16)
                {
                    return moduloi16;
                }

                if (type is UInt16)
                {
                    return moduloui16;
                }

                if (type is Int32)
                {
                    return moduloi32;
                }

                if (type is UInt32)
                {
                    return moduloui32;
                }

                if (type is Int64)
                {
                    if (types[1] is UInt64)
                    {
                        return moduloi64true;
                    }
                    return moduloi64;
                }

                if (type is UInt64)
                {
                    if (types[1] is UInt64)
                    {
                        return moduloui64true;
                    }
                    return moduloui64;
                }
            }

            if (symbol == '/')
            {
                if (type is Double)
                {
                    return divided;
                }

                if (type is Single)
                {
                    return dividef;
                }

                if (type is SByte)
                {
                    if(types[0] is Byte)
                    {
                        return dividebl;
                    }
                    if(types[1] is Byte)
                    {
                        return dividebr;
                    }
                    return dividesb;
                }

                if (type is Byte)
                {
                    return divideb;
                }

                if (type is Int16)
                {
                    return dividei16;
                }

                if (type is UInt16)
                {
                    return divideui16;
                }

                if (type is Int32)
                {
                    return dividei32;
                }

                if (type is UInt32)
                {
                    return divideui32;
                }

                if (type is Int64)
                {
                    return dividei64;
                }

                if (type is UInt64)
                {
                    return divideui64;
                }
            }



            return null;
        }

        #endregion


        #region Division delegates

        private object divided(object[] args)
        {
            double a = (double)args[0].ToNullDouble();
            double b = (double)args[1].ToNullDouble();
            return a / b;
        }

        private object dividef(object[] args)
        {
            double a = Convert.ToSingle(args[0]);
            double b = Convert.ToSingle(args[1]);
            return Convert.ToSingle(a / b);
        }

        private object dividesb(object[] args)
        {
            double a = Convert.ToSByte(args[0]);
            double b = Convert.ToSByte(args[1]);
            return Convert.ToSByte(a / b);
        }

        private object divideb(object[] args)
        {
            double a = Convert.ToByte(args[0]);
            double b = Convert.ToByte(args[1]);
            return Convert.ToByte(a / b);
        }

        private object dividebl(object[] args)
        {
            double a = Convert.ToByte(args[0]);
            double b = Convert.ToSByte(args[1]);
            return Convert.ToSByte(a / b);
        }

        private object dividebr(object[] args)
        {
            double a = Convert.ToSByte(args[0]);
            double b = Convert.ToByte(args[1]);
            return Convert.ToSByte(a / b);
        }


        private object dividei16(object[] args)
        {
            double a = Convert.ToInt16(args[0]);
            double b = Convert.ToInt32(args[1]);
            return Convert.ToInt16(a / b);
        }

        private object divideui16(object[] args)
        {
            double a = Convert.ToUInt16(args[0]);
            double b = Convert.ToInt16(args[1]);
            return Convert.ToInt16(a / b);
        }

        private object dividei32(object[] args)
        {
            double a = Convert.ToInt32(args[0]);
            double b = Convert.ToInt32(args[1]);
            return Convert.ToInt16(a / b);
        }

        private object divideui32(object[] args)
        {
            double a = Convert.ToUInt32(args[0]);
            double b = Convert.ToUInt32(args[1]);
            return Convert.ToUInt16(a / b);
        }

        private object dividei64(object[] args)
        {
            double a = Convert.ToInt64(args[0]);
            double b = Convert.ToInt64(args[1]);
            return Convert.ToInt16(a / b);
        }

        private object dividei64true(object[] args)
        {
            double a = Convert.ToInt64(args[0]);
            double b = Convert.ToUInt64(args[1]);
            return Convert.ToInt16(a / b);
        }

        private object divideui64(object[] args)
        {
            double a = Convert.ToUInt64(args[0]);
            double b = Convert.ToInt64(args[1]);
            return Convert.ToUInt16(a / b);
        }

        private object divideui64true(object[] args)
        {
            double a = Convert.ToUInt64(args[0]);
            double b = Convert.ToUInt64(args[1]);
            return Convert.ToUInt16(a / b);
        }

        #region Modulo delegates

        private object modulod(object[] args)
        {
            double a = Convert.ToDouble(args[0]);
            double b = Convert.ToDouble(args[1]);
            return a % b;
        }

        private object modulof(object[] args)
        {
            double a = Convert.ToSingle(args[0]);
            double b = Convert.ToSingle(args[1]);
            return Convert.ToSingle(a % b);
        }

        private object modulosb(object[] args)
        {
            double a = Convert.ToSByte(args[0]);
            double b = Convert.ToInt16(args[1]);
            return Convert.ToSByte(a % b);
        }

        private object modulob(object[] args)
        {
            double a = Convert.ToByte(args[0]);
            double b = Convert.ToInt16(args[1]);
            return Convert.ToByte(a % b);
        }

        private object moduloi16(object[] args)
        {
            double a = Convert.ToInt16(args[0]);
            double b = Convert.ToInt32(args[1]);
            return Convert.ToInt16(a % b);
        }

        private object moduloui16(object[] args)
        {
            double a = Convert.ToUInt16(args[0]);
            double b = Convert.ToInt32(args[1]);
            return Convert.ToUInt16(a % b);
        }

        private object moduloi32(object[] args)
        {
            double a = Convert.ToInt32(args[0]);
            double b = Convert.ToInt64(args[1]);
            return Convert.ToInt16(a % b);
        }

        private object moduloui32(object[] args)
        {
            double a = Convert.ToUInt32(args[0]);
            double b = Convert.ToInt64(args[1]);
            return Convert.ToUInt16(a % b);
        }

        private object moduloi64(object[] args)
        {
            double a = Convert.ToInt64(args[0]);
            double b = Convert.ToInt64(args[1]);
            return Convert.ToInt16(a % b);
        }

        private object moduloi64true(object[] args)
        {
            double a = Convert.ToInt64(args[0]);
            double b = Convert.ToUInt64(args[1]);
            return Convert.ToInt16(a % b);
        }

        private object moduloui64(object[] args)
        {
            double a = Convert.ToUInt64(args[0]);
            double b = Convert.ToInt64(args[1]);
            return Convert.ToUInt16(a % b);
        }

        private object moduloui64true(object[] args)
        {
            double a = Convert.ToUInt64(args[0]);
            double b = Convert.ToUInt64(args[1]);
            return Convert.ToUInt16(a % b);
        }

        #endregion

        #endregion

        #endregion

    }
}
