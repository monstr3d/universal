using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using BaseTypes.Utils;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Operation of elementary functions
    /// </summary>
    public class ElementaryIntegerOperation : IObjectOperation, IOperationAcceptor,
        IFormulaCreatorOperation
    {

        #region Fields

        /// <summary>
        /// names of integer operations
        /// </summary>
        static private Dictionary<char, string> intNames = new Dictionary<char, string>();

        /// <summary>
        /// Type of operation
        /// </summary>
        private object type;

        object inputType;
        /// <summary>
        /// Operation symbol
        /// </summary>
        private char symbol;


        /// <summary>
        /// Additional acceptors
        /// </summary>
        private Dictionary<object, List<IOperationAcceptor>> addAcceptors
            = new Dictionary<object, List<IOperationAcceptor>>();

        Func<object, object> unaryValue;

        #endregion

        /// <summary>
        /// Calculates value of integer operation
        /// </summary>
        /// <param name="x">the argument</param>
        /// <returns>The value</returns>
        /*   private object UnaryValue(object x)
           {
              if (type is Double)
               {
                   return Converter.ToDouble(x);
               }
               if (type is SByte)
               {
                   return Converter.ToSByte(x);
               }
               if (type is UInt16)
               {
                   return Converter.ToUInt16(x);
               }
               if (type is UInt32)
               {
                   return Converter.ToUInt32(x);
               }
               if (type is UInt64)
               {
                   return Converter.ToUInt64(x);
               }
               if (type is Byte)
               {
                   return Converter.ToByte(x);
               }
               if (type is Int16)
               {
                   return Converter.ToInt16(x);
               }
               if (type is Int32)
               {
                   return Converter.ToInt32(x);
               }
               if (type is Int64)
               {
                   return Converter.ToInt64(x);
               }
               return null;
           }
       }*/

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol"></param>
        public ElementaryIntegerOperation(char symbol)
        {
            this.symbol = symbol;
            switch (symbol)
            {
                case 'A':
                    type = BaseTypes.StaticExtensionBaseTypes.ByteType;
                    break;
                case 'B':
                    type = BaseTypes.StaticExtensionBaseTypes.UInt16Type;
                    break;
                case 'C':
                    type = BaseTypes.StaticExtensionBaseTypes.UInt32Type;
                    break;
                case 'D':
                    type = BaseTypes.StaticExtensionBaseTypes.UInt64Type;
                    break;
                case 'E':
                    type = BaseTypes.StaticExtensionBaseTypes.SByteType;
                    break;
                case 'F':
                    type = BaseTypes.StaticExtensionBaseTypes.Int16Type;
                    break;
                case 'G':
                    type = BaseTypes.StaticExtensionBaseTypes.Int32Type;
                    break;
                case 'H':
                    type = BaseTypes.StaticExtensionBaseTypes.Int64Type;
                    break;
                case 'I':
                    type = BaseTypes.StaticExtensionBaseTypes.DoubleType;
                    break;
                case 'J':
                    type = BaseTypes.StaticExtensionBaseTypes.SingleType;
                    break;
            }
        }

        private ElementaryIntegerOperation(char symbol, object input) : 
            this(symbol)
        {
            inputType = input;
            unaryValue = input.Convert(type);
        }

        /// <summary>
        /// Adds acceptor
        /// </summary>
        /// <param name="type">Return type</param>
        /// <param name="acc">Acceptor to add</param>
        public void Add(object type, IOperationAcceptor acc)
        {
            List<IOperationAcceptor> l = null;
            if (addAcceptors.ContainsKey(type))
            {
                l = addAcceptors[type];
            }
            else
            {
                l = new List<IOperationAcceptor>();
                addAcceptors[type] = l;
            }
            l.Add(acc);
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
            MathFormula f = new MathFormula(level, sizes);
            MathSymbol sym = new SimpleSymbol(symbol, (byte)FormulaConstants.Unary, false, GetString(symbol));
            sym.Append(form);
            sym = new BracketsSymbol();
            sym.Append(form);
            form.Last[0] = FormulaCreator.CreateFormula(tree[0], level, sizes);
            return form;
        }

        /// <summary>
        /// Operation priority
        /// </summary>
        public int OperationPriority
        {
            get
            {
                return (int)ElementaryOperationPriorities.Function;
            }
        }

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] IObjectOperation.InputTypes
        {
            get
            {
                return new object[] { inputType };
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public virtual object this[object[] x]
        {
            get
            {
                return unaryValue(x[0]);
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
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            if (!ElementaryBinaryOperation.IsNumber(type))
            {
                if (!addAcceptors.ContainsKey(type))
                {
                    return null;
                }
                List<IOperationAcceptor> l = addAcceptors[type];
                foreach (IOperationAcceptor acc in l)
                {
                    IObjectOperation op = acc.Accept(type);
                    if (op != null)
                    {
                        return op;
                    }
                }
                return null;
            }
            return new ElementaryIntegerOperation(symbol, type);
        }

        /// <summary>
        /// Preparation
        /// </summary>
        public static void Prepare()
        {
            intNames['A'] = "Byte";
            intNames['B'] = "UInt16";
            intNames['C'] = "UInt32";
            intNames['D'] = "UInt64";
            intNames['E'] = "SByte";
            intNames['F'] = "Int16";
            intNames['G'] = "Int32";
            intNames['H'] = "Int64";
            intNames['I'] = "Double";
            intNames['J'] = "Single";
        }

        /// <summary>
        /// Gets function string that corresponds the symbol
        /// </summary>
        /// <param name="c">The symbol</param>
        /// <returns>The string</returns>
        public static string GetString(char c)
        {
            return intNames[c] as string;
        }


    }
}
