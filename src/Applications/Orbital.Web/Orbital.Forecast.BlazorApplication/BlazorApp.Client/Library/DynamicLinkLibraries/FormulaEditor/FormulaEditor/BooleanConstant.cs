using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaseTypes.Interfaces;
using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Boolean constant
    /// </summary>
    public class BooleanConstant : IObjectOperation, IOperationAcceptor, IFormulaCreatorOperation, IStringConstantValue
    {
        #region Fields

        /// <summary>
        /// Return type
        /// </summary>
        private const Boolean a = false;

        /// <summary>
        /// Value
        /// </summary>
        private bool val;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val">Value of constant</param>
        public BooleanConstant(bool val)
        {
            this.val = val;
        }


        #endregion

        /// <summary>
        /// Creates formula
        /// </summary>
        /// <param name="tree">Operation tree</param>
        /// <param name="level">Formula level</param>
        /// <param name="sizes">Sizes of symbols</param>
        /// <returns>The formula</returns>
        public MathFormula CreateFormula(ObjectFormulaTree tree, byte level, int[] sizes)
        {
            return new MathFormula(level, sizes, val);
        }

        #region IStringConstantValue Members

        /// <summary>
        /// IStringConstantValue Members
        /// </summary>
        string IStringConstantValue.Value => StringValue.ToLower();

        #endregion




        /// <summary>
        /// Operation priority
        /// </summary>
        public int OperationPriority
        {
            get
            {
                return (int)ElementaryOperationPriorities.Variable;
            }
        }

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] IObjectOperation.InputTypes
        {
            get
            {
                return new object[0];
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                return val;
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                return a;
            }
        }


        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            return this;
        }

        /// <summary>
        /// Sets value
        /// </summary>
        public bool Value
        {
            set
            {
                val = value;
            }
            get
            {
                return val;
            }
        }

        /// <summary>
        /// Creates tree from double constant
        /// </summary>
        /// <param name="d">Double constant</param>
        /// <returns>Constant tree</returns>
        public static ObjectFormulaTree GetConstant(bool d)
        {
            BooleanConstant c = new BooleanConstant(d);
            return new ObjectFormulaTree(c, new List<ObjectFormulaTree>());
        }

        /// <summary>
        /// True tree
        /// </summary>
        static private ObjectFormulaTree TrueTree
        {
            get
            {
                BooleanConstant op = new BooleanConstant(true);
                return new ObjectFormulaTree(op, new List<ObjectFormulaTree>());

            }
        }

        /// <summary>
        /// False tree
        /// </summary>
        static private ObjectFormulaTree FalseTree
        {
            get
            {
                BooleanConstant op = new BooleanConstant(false);
                return new ObjectFormulaTree(op, new List<ObjectFormulaTree>());

            }
        }

        /// <summary>
        /// String representation of constant
        /// </summary>
        public virtual string StringValue
        {
            get
            {
                return val + "";
            }
        }
    }
}