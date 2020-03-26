using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{

    /// <summary>
    /// Conditional operation
    /// </summary>
    public class OptionalOperation : IObjectOperation, ICloneable, IFormulaCreatorOperation
    {

        /// <summary>
        /// Type
        /// </summary>
        public object type;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        public OptionalOperation(object type)
        {
            this.type = type;
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
            return CreateFormula(this, tree, level, sizes, "?:");
        }



        /// <summary>
        /// Operation priority
        /// </summary>
        public int OperationPriority
        {
            get
            {
                return (int)ElementaryOperationPriorities.Optional;
            }
        }



        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>A clone</returns>
        public object Clone()
        {
            return new OptionalOperation(type);
        }

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return new object[] { false, type, type };
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                bool b = (bool)x[0];
                return b ? x[1] : x[2];
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
        /// Creates formula
        /// </summary>
        /// <param name="operation">Operation of formula creator</param>
        /// <param name="tree">Tree</param>
        /// <param name="level">Level</param>
        /// <param name="sizes">Sizes</param>
        /// <param name="str">Str of binrary</param>
        /// <returns>The formula</returns>
        public static MathFormula CreateFormula(IFormulaCreatorOperation operation, ObjectFormulaTree tree, byte level, int[] sizes, string str)
        {
            MathFormula form = new MathFormula(level, sizes);
            for (int i = 0; i < str.Length + 1; i++)
            {
                IFormulaCreatorOperation op = tree[i].Operation as IFormulaCreatorOperation;
                MathFormula f = op.CreateFormula(tree[i], level, sizes);
                MathFormula fp = null;
                if (op.OperationPriority < operation.OperationPriority)
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
                if (i < str.Length)
                {
                    MathSymbol s = new BinarySymbol(str[i]);
                    s.Append(form);
                }
            }
            return form;
        }
    }
}
