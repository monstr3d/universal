using System;
using System.Collections;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{

	/// <summary>
	/// Operation of elementary functions
	/// </summary>
    public class ElementaryFunctionOperation : IObjectOperation, IPowered, IOperationAcceptor, IDerivationOperation,
		IFormulaCreatorOperation
	{

        /// <summary>
        /// Function
        /// </summary>
        protected Func<double,double> func;
		
		/// <summary>
		/// The initialization of elementary functions derivations
		/// </summary>
		private static readonly string[] formStrings = {"c4[]x1[]",
														   "-3s4[]x1[]",
														   "F2[15[]][x1[]]",
														   "Q2[15[]-3x1[25[]]][]",
														   "-3Q2[15[]-3x1[25[]]][]",
														   "e4[]x1[]",
														   "F2[15[]][c4[25[]]x1[]]",
														   "F2[-315[]][s4[25[]]x1[]]",
														   "F2[15[]][15[]+3x1[25[]]]",
														   "F2[-315[]][15[]+3x1[25[]]]",
														   "F2[-3s4[]x1[]][c4[25[]]x1[]]",
														   "F2[c4[]x1[]][s4[25[]]x1[]]",
														   "F2[05[].355[]][Q2[x1[]][]]",
														   "-3x1[]"};
		
		/// <summary>
		/// Derivations of elementary functions
		/// </summary>
		private static ObjectFormulaTree[] functionDerivations;

		static private readonly int[] MAX_SIZES = new int[20];



		/// <summary>
		/// Type of operation
		/// </summary>
		private const Double a = 0;

		/// <summary>
		/// Operation symbol
		/// </summary>
		private char symbol;

        static private readonly object[] types = new object[] { (double)0 };


		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="symbol"></param>
		public ElementaryFunctionOperation(char symbol)
		{
			this.symbol = symbol;
            CreateDelegate(symbol);
		}

		/// <summary>
		/// Initialization of derivation calculation functions
		/// </summary>
		public static void InitDeri()
		{
			functionDerivations = new ObjectFormulaTree[formStrings.Length];
			for (int i = 0; i < formStrings.Length; i++)
			{
				MathFormula f = MathFormula.FromString(MAX_SIZES, formStrings[i]);
				functionDerivations[i] = ObjectFormulaTree.CreateTree(f.FullTransform(null));
			}
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
			MathSymbol sym = null;
			if (symbol == '-')
			{
				sym = new BinarySymbol('-');
			}
			else
			{
				sym = new SimpleSymbol(symbol, false, (byte)FormulaConstants.Unary);
			}
			sym.Append(form);
			sym = new BracketsSymbol();
			sym.Append(form);
			form.Last.Children[0] = FormulaCreator.CreateFormula(tree[0], level, sizes);
			form.Last.Children[1] = new MathFormula((byte)(level + 1), sizes);
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
		/// Calculates derivation
		/// </summary>
		/// <param name="tree">The function for derivation calculation</param>
		/// <param name="s">Derivation string</param>
		/// <returns>The derivation</returns>
		public ObjectFormulaTree Derivation(ObjectFormulaTree tree, string s)
		{
			int i = 0;
			if (symbol == '-')
			{
				i = functionDerivations.Length - 1;
			}
			else
			{
				i = MathSymbol.FUNCTIONS.IndexOf(symbol);
			}
			return Derivation(tree, i, s);
		}

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return types;
            }
        }

		/// <summary>
		/// Calculates result of this operation
		/// </summary>
		public virtual object this[object[] x]
		{
			get
			{
				double y = (double)x[0];
                return func(y);// unaryValue(symbol, y);
			}
		}

		/// <summary>
		/// Return type
		/// </summary>
		public virtual object ReturnType
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
		public virtual IObjectOperation Accept(object type)
		{
			if (!(type is Double))
			{
				return null;
			}
            if (symbol == '\u03b4')
            {
                return new DeltaFunction();
            }
			return new ElementaryFunctionOperation(symbol);
		}

		/// <summary>
		/// The "is powered" sign
		/// </summary>
        bool IPowered.IsPowered
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Derivation of square root
		/// </summary>
		/// <param name="tree">Prototype tree</param>
		/// <param name="variableName">Name of variable</param>
		/// <returns>The derivation</returns>
        public static ObjectFormulaTree SquareRootDerivation(ObjectFormulaTree tree, string variableName)
        {
            ObjectFormulaTree co = ElementaryRealConstant.GetConstant(0.5);
            ObjectFormulaTree derNom = tree[0].Derivation(variableName);
            List<ObjectFormulaTree> lnom = new List<ObjectFormulaTree>() { co, derNom };
            Double a = 0;
            ElementaryBinaryOperation bo = new ElementaryBinaryOperation('*', new object[] { a, a });
            ObjectFormulaTree tn = new ObjectFormulaTree(bo, lnom);
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>() { tn, tree };
            return new ObjectFormulaTree(ElementaryFraction.Object, l);
        }


		/// <summary>
		/// Calculates derivation of i - th function
		/// </summary>
		/// <param name="tree">Object tree</param>
		/// <param name="i">Function number</param>
		/// <param name="variableName">Name of variable</param>
		/// <returns>The derivation</returns>
		static private ObjectFormulaTree Derivation(ObjectFormulaTree tree, int i, string variableName)
		{
			Double a = 0;
            ObjectFormulaTree f1 = tree[0].Derivation(variableName);
            if (ZeroPerformer.IsZero(f1))
            {
                return ElementaryRealConstant.RealZero;
            }
            ObjectFormulaTree fd = functionDerivations[i];
			ObjectFormulaTree f0 = InsertVariable(fd, tree[0]);
            IObjectOperation operation = new ElementaryBinaryOperation('*', new object[] { a, a });
			List<ObjectFormulaTree> children = new List<ObjectFormulaTree>();
			children.Add(f0);
			children.Add(f1);
			return new ObjectFormulaTree(operation, children);

		}


        private void CreateDelegate(char s)
        {
            switch (s)
            {
                case 's':
                    func = Math.Sin;
                    return;
                case 'c':
                    func = Math.Cos;
                    return;
                case 'l':
                    func = Math.Log;
                    return;
                case 'e':
                    func = Math.Exp;
                    return;
                case 't':
                    func = Math.Tan;
                    return;
                case 'q':
                    func = (double x) => { return Math.Tan(0.5 * Math.PI - x); };
                    return;
                case 'a':
                    func = Math.Atan;
                    return;
                case 'b':
                    func = (double x) => { return Math.PI / 2 - Math.Atan(x); };
                    return;
                case 'j':
                    func = (double x) => { return 1 / Math.Cos(x); };
                    return;
                case 'k':
                    func = (double x) => { return 1 / Math.Sin(x); };
                    return;
                case 'f':
                    func = Math.Asin;
                    return;
                case 'g':
                    func = Math.Acos;
                    return;
                case '?':
                    func = (double x) => { return x; };
                    return;
                case '-':
                    func = func = (double x) => { return -x; };
                    return;
            }
        }


		/// <summary>
		/// Opreation symbol
		/// </summary>
		public char Symbol
		{
			get
			{
				return symbol;
			}
		}

		/// <summary>
		/// Inserts formula instead variable
		/// </summary>
		/// <param name="tree">Prototype</param>
		/// <param name="insert">Inerted formula</param>
		/// <returns>Result of the operation</returns>
		private static ObjectFormulaTree InsertVariable(ObjectFormulaTree tree, ObjectFormulaTree insert)
		{
            Double a = 0;
			if (tree.Operation is ElementaryObjectVariable & tree.ReturnType.Equals(a))
			{
				return insert;//.Clone() as ObjectFormulaTree;
			}
			List<ObjectFormulaTree> children = new List<ObjectFormulaTree>();
			for (int i = 0; i < tree.Count; i++)
			{
				ObjectFormulaTree t = tree[i];//.Clone() as ObjectFormulaTree;
				children.Add(InsertVariable(t, insert));
			}
			return new ObjectFormulaTree(tree.Operation, children);
		}

	}

	/// <summary>
	/// Priorities of operations
	/// </summary>
	public enum ElementaryOperationPriorities
	{
        /// <summary>
        /// Optional
        /// </summary>
		Optional,
        
        /// <summary>
        /// Logical Immplication
        /// </summary>
        LogicalImpl,
        
        /// <summary>
        /// Logical OR
        /// </summary>
        LogicalOR,
        
        /// <summary>
        /// Logical AND
        /// </summary>
        LogicalAND, 
        
        /// <summary>
        /// Comparation
        /// </summary>
        Comparation, 
        
        /// <summary>
        /// Integer OR
        /// </summary>
        IntegerOR, 
        
        /// <summary>
        /// Integer AND
        /// </summary>
        IntegerAND, 
        
        /// <summary>
        /// Integer bitwise OR
        /// </summary>
        IntegerBitwiseOR, 
        
        /// <summary>
        /// Integer Shift
        /// </summary>
        IntegerShift, 
        
        /// <summary>
        /// Plus Minus
        /// </summary>
        PlusMinus,

        /// <summary>
        /// Division: inline, modulo
        /// </summary>
        Divide,

        /// <summary>
        /// Multiplication
        /// </summary>
        Multiply, 
        
        /// <summary>
        /// Function
        /// </summary>
        Function, 
        
        /// <summary>
        /// Power
        /// </summary>
        Power, 
        
        /// <summary>
        /// Variable
        /// </summary>
        Variable, 
        
        /// <summary>
        /// Brackets
        /// </summary>
        Brackets
	}


}


