using System.Collections.Generic;
using System.Reflection;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Attributes;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;
using NamedTree;

namespace FormulaEditor
{

	/// <summary>
	/// Tree of an object formula
	/// </summary>
	public class ObjectFormulaTree : IAssociatedObject
    {

        #region Fields

        protected static IEqualityComparer<ObjectFormulaTree> comparer;

        /// <summary>
		/// Children formulas
		/// </summary>
		protected List<ObjectFormulaTree> children = new List<ObjectFormulaTree>();

		/// <summary>
		/// Operation of this formula
		/// </summary>
		protected IObjectOperation operation;

		/// <summary>
		/// Temporary variables
		/// </summary>
		protected object[] y;

		/// <summary>
		/// Creator of formulas
		/// </summary>
		static protected IFormulaObjectCreator creator;

        /// <summary>
        /// Delegate of result
        /// </summary>
        protected ResultDelegate result;

        /// <summary>
        /// Tag
        /// </summary>
        protected object tag;

        static private readonly object[] emptyArray = new object[0];

        protected virtual object Object { get; set; }

        #endregion

        #region Ctor

        /// <summary>
		/// Default constructor
		/// </summary>
        protected ObjectFormulaTree()
        {
        }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="operation">Tree operation</param>
		/// <param name="children">Children trees</param>
		public ObjectFormulaTree(IObjectOperation operation, List<ObjectFormulaTree> children) 
		{
         	if (operation is ICloneable)
			{
				ICloneable c = operation as ICloneable;
				this.operation = c.Clone() as IObjectOperation;
			}
			else
			{
				this.operation = operation;
			}
			if (operation.InputTypes.Length != 0)
			{
				if (children == null)
				{
					this.children = children;
				}
                if (children.Count != operation.InputTypes.Length)
				{
					this.children = children;
				}
			}
			this.children = children;
            y = new object[operation.InputTypes.Length];
            CreateResult();
            Normalize();
		}

		/// <summary>
		/// Consructor from formula
		/// </summary>
		/// <param name="formula">The formula</param>
		/// <param name="creator">The formula object creator</param>
		private ObjectFormulaTree(MathFormula formula, IFormulaObjectCreator creator)
		{
			Init(formula, creator);
            CreateResult();
            Normalize();
		}

        #endregion
        
        #region Interfaces.ICloneable Members

 
        #endregion

        #region Overriden Members

        /// <summary>
        /// Overriden hash code
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Overriden equals
        /// </summary>
        /// <param name="obj">Xompared object</param>
        /// <returns>True if equal and false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (comparer == null)
            {
                return this == obj;
            }
            if (!(obj is ObjectFormulaTree))
            {
                return false;
            }
            return comparer.Equals(this, obj as ObjectFormulaTree);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Creates tree from formula
        /// </summary>
        /// <param name="formula">The formula</param>
        /// <param name="creator">The creator</param>
        /// <returns>The tree</returns>
        public static ObjectFormulaTree CreateTree(MathFormula formula, IFormulaObjectCreator creator)
        {
            ObjectFormulaTree tree = new ObjectFormulaTree(formula, creator);
            IObjectOperation op = tree.Operation;
            if (op is ITreeCreator)
            {
                ITreeCreator tc = op as ITreeCreator;
                ObjectFormulaTree tp = tc.Tree;
                if (tp != null)
                {
                    return tp;
                }
            }
            if (op == null)
            {
                return null;
            }
            return tree;
        }

        /// <summary>
        /// Creates tree from formula
        /// </summary>
        /// <param name="formula">The formula</param>
        /// <returns>The tree</returns>
        public static ObjectFormulaTree CreateTree(MathFormula formula)
        {
            return CreateTree(formula, creator);
        }

        /// <summary>
        /// Creator ot teers
        /// </summary>
        public static IFormulaObjectCreator Creator
		{
			set
			{
				creator = value;
			}
		}

		/// <summary>
		/// Result of calculation
		/// </summary>
		public object Result
		{
			get
			{
                return result();
			}
		}

		/// <summary>
		/// Access to i - th child
		/// </summary>
		public ObjectFormulaTree this[int i]
		{
			get
			{
				if (children.Count <= i | i < 0 | children == null)
				{
					return null;
				}
				return children[i] as ObjectFormulaTree;
			}
		}

        /// <summary>
        /// Calculates object
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns>Value</returns>
        public object Calculate(object[] x)
        {
            return operation[x];
        }

        /// <summary>
        /// Calculates object
        /// </summary>
        /// <returns>Value</returns>
        public object Calculate()
        {
            return operation[emptyArray];
        }

        /// <summary>
        /// Creates consequent list
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <param name="list">List</param>
        /// <param name="optional">List of optional operations</param>
        public static void CreateList(ObjectFormulaTree tree, IList<ObjectFormulaTree> list, 
            List<ObjectFormulaTree> optional)
        {
            /*!!! if (tree.Operation is OptionalOperation)
            {
                optional.Add(tree);
            }*/
             for (int i = 0; i < tree.Count; i++)
            {
                ObjectFormulaTree t = tree[i];
                if (t != null)
                {
                    CreateList(t, list, optional);
                }
            }
            if (!list.Contains(tree))
            {
                list.Add(tree);
            }
        }

        /// <summary>
        /// Creates list from array or trees
        /// </summary>
        /// <param name="trees">The array or trees</param>
        /// <param name="optional">List of optional opreations</param>
        /// <returns>The list</returns>
        public static IList<ObjectFormulaTree> CreateList(ObjectFormulaTree[] trees, List<ObjectFormulaTree> optional)
        {
            List<ObjectFormulaTree> list = new List<ObjectFormulaTree>();
            foreach (ObjectFormulaTree t in trees)
            {
                if (t.ReturnType.IsEmpty())
                {
                    continue;
                }
                CreateList(t, list, optional);
            }
            return list;
        }

        /// <summary>
        /// Sets null arity objects
        /// </summary>
        /// <param name="x">The object to set</param>
        public void SetNullArityObjects(object x)
		{
			for (int i = 0; i < Count; i++)
			{
				this[i].SetNullArityObjects(x);
			}
			if (!(operation is INullArityOperation))
			{
				return;
			}
			INullArityOperation n = operation as INullArityOperation;
			n.Object = x;
		}

		/// <summary>
		/// Calculates result by argument
		/// </summary>
		/// <param name="x">The argument</param>
		/// <returns>The result</returns>
		public object GetResult(object x)
		{
			SetNullArityObjects(x);
			return Result;
		}

		/// <summary>
		/// Children count
		/// </summary>
		public int Count
		{
			get
			{
				if (children == null)
				{
					return 0;
				}
                int n = 0;
                foreach (ObjectFormulaTree t in children)
                {
                    if (t != null)
                    {
                        if (!t.ReturnType.IsEmpty())
                        {
                            ++n;
                        }
                    }
                }
				return n;
			}
		}
		
		/// <summary>
		/// Return type
		/// </summary>
		public object ReturnType
		{
            get => operation.ReturnType;
		}

		/// <summary>
		/// Tree root operation
		/// </summary>
		public IObjectOperation Operation
		{
			get
			{
				return operation;
			}
		}

        /// <summary>
        /// Tag
        /// </summary>
        public object Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
            }
        }

        object IAssociatedObject.Object { get => Object; set => Object = value; }

        /// <summary>
        /// Gets binary operation
        /// </summary>
        /// <param name="acceptors">Array of acceptors</param>
        /// <param name="typeA">Return type of left subtree</param>
        /// <param name="typeB">Return type of right subtree</param>
        /// <returns>The operatiob</returns>
        public static IObjectOperation GetOperation(IBinaryAcceptor[] acceptors, 
            object typeA, object typeB)
        {
            foreach (IBinaryAcceptor acc in acceptors)
            {
                IObjectOperation op = acc.Accept(typeA, typeB);
                if (op != null)
                {
                    return op;
                }
            }
            return null;
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Copy from a prototype
        /// </summary>
        /// <param name="prototype">The prototype</param>
        protected void Copy(ObjectFormulaTree prototype)
        {
            operation = prototype.operation;
            children = prototype.children;
        }

        /// <summary>
		/// Processes binary operation
		/// </summary>
		/// <param name="formula">Input formula</param>
		/// <param name="creator">Creator of tree</param>
		protected bool processBinary(MathFormula formula, IFormulaObjectCreator creator)
        {
            Dictionary<int, ObjectFormulaTree[]> dic = new Dictionary<int, ObjectFormulaTree[]>();
            for (int i = 0; i < creator.BinaryCount; i++)
            {
                IBinaryDetector detector = creator.GetBinaryDetector(i);
                ObjectFormulaTree tA = null;
                ObjectFormulaTree tB = null;
                if (detector.AssociationDirection == BinaryAssociationDirection.LeftRight)
                {
                    int m = 0;
                    for (int j = 0; j < formula.Count - 1; j++)
                    {
                        MathSymbol symbol = formula[j];
                        if (creator.IsBra(symbol))
                        {
                            ++m;
                            continue;
                        }
                        if (creator.IsKet(symbol))
                        {
                            --m;
                            continue;
                        }
                        if (m < 0)
                        {
                            //FormulaEditorPerformer.ThrowErrorException(FormulaTree.ERRORS[1]);
                        }
                        if (j == 0 | m != 0)
                        {
                            continue;
                        }
                        IBinaryAcceptor acceptor = detector.Detect(symbol);
                        if (acceptor == null)
                        {
                            continue;
                        }
                        if (dic.ContainsKey(j))
                        {
                            tA = dic[j][0];
                            tB = dic[j][1];
                        }
                        else
                        {
                            tA = CreateTree(new MathFormula(formula, 0, j - 1), creator);
                            tB = CreateTree(new MathFormula(formula, j + 1, formula.Count - 1), creator);
                            if ((tA == null) | (tB == null))
                            {
                                continue;
                            }
                            dic[j] = new ObjectFormulaTree[] { tA, tB };
                        }
                        if (acceptor is IChildTreeCreator)
                        {
                            IChildTreeCreator cc = acceptor as IChildTreeCreator;
                            ObjectFormulaTree t = cc[new ObjectFormulaTree[] { tA, tB }];
                            if (t != null)
                            {
                                Copy(t);
                                y = new object[children.Count];
                                return true;
                            }
                        }
                        operation = acceptor.Accept(tA.ReturnType, tB.ReturnType);
                        if (operation != null)
                        {
                            goto start;
                        }
                    }
                }
                else
                {
                    int m = 0;
                    for (int j = formula.Count - 1; j > 0; j--)
                    {
                        MathSymbol symbol = formula[j];
                        if (creator.IsKet(symbol))
                        {
                            ++m;
                            continue;
                        }
                        if (creator.IsBra(symbol))
                        {
                            --m;
                            continue;
                        }
                        if (m < 0)
                        {
                            //!!! FormulaEditorPerformer.ThrowErrorException(FormulaTree.ERRORS[1]);
                        }
                        if (m != 0)
                        {
                            continue;
                        }
                        IBinaryAcceptor acceptor = detector.Detect(symbol);
                        if (acceptor == null)
                        {
                            continue;
                        }
                        if (dic.ContainsKey(j))
                        {
                            tA = dic[j][0];
                            tB = dic[j][1];
                        }
                        else
                        {
                            tA = CreateTree(new MathFormula(formula, 0, j - 1), creator);
                            tB = CreateTree(new MathFormula(formula, j + 1, formula.Count - 1), creator);
                            if ((tA == null) | (tB == null))
                            {
                                continue;
                            }
                            dic[j] = new ObjectFormulaTree[] { tA, tB };
                        }
                        if (acceptor is IChildTreeCreator)
                        {
                            IChildTreeCreator cc = acceptor as IChildTreeCreator;
                            ObjectFormulaTree t = cc[new ObjectFormulaTree[] { tA, tB }];
                            if (t != null)
                            {
                                Copy(t);
                                y = new object[children.Count];
                                return true;
                            }
                        }
                        operation = acceptor.Accept(tA.ReturnType, tB.ReturnType);
                        if (operation != null)
                        {
                            goto start;
                        }

                    }
                }
                start:
                if (operation != null)
                {
                    children.Add(tA);
                    children.Add(tB);
                    y = new object[2];
                    return true;
                }
            }
            return false;
        }

		/// <summary>
		/// Processes multi operation
		/// </summary>
		/// <param name="formula">Formula</param>
		/// <param name="creator">Formula creator</param>
		/// <returns>True if operation exists and false otherwise</returns>
		protected bool processMultiOperation(MathFormula formula, IFormulaObjectCreator creator)
		{
			for (int n = 0; n < creator.MultiOperationCount; n++)
			{
				IMultiOperationDetector detector = creator.GetMultiOperationDetector(n);
				int j = 0;
				int m = 0;
				int i = 0;
				//int opened = 0;
				int k = 0;
				List<ObjectFormulaTree> list = null;
				for(;i < formula.Count; i++)
				{
					MathSymbol symbol = formula[i];
					if (creator.IsBra(symbol))
					{
						++m;
						continue;
					}
					if (creator.IsKet(symbol))
					{
						--m;
						continue;
					}
					if (m != 0)
					{
						continue;
					}
					if (!detector.Detect(k, symbol))
					{
						continue;
					}
					if (list == null)
					{
						list = new List<ObjectFormulaTree>();
					}
					MathFormula f = new MathFormula(formula, j, i - 1);
					list.Add(CreateTree(f, creator));
					++k;
					j = i + 1;
					if (k == detector.Count)
					{
						f = new MathFormula(formula, j, formula.Count - 1);
						list.Add(CreateTree(f, creator));
						object[] types = new object[list.Count];
						int nOp = 0;
						foreach (ObjectFormulaTree tree in list)
						{
							types[nOp] = tree.ReturnType;
							++nOp;
						}
						IObjectOperation op = detector.Accept(types);
						if (op != null)
						{
							operation = op;
							children = list;
							y = new object[list.Count];
							return true;
						}
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Processes ordinary operation
		/// </summary>
		/// <param name="formula">Formula</param>
		/// <param name="creator">Formula creator</param>
		/// <returns>True if operation exists and false otherwise</returns>
		protected bool processOperation(MathFormula formula, IFormulaObjectCreator creator)
		{
            int braCount = 0;
            ObjectFormulaTree tree = null;
            for (int i = 0; i < creator.OperationCount; i++)
			{
				IOperationDetector detector = creator.GetDetector(i);
				IOperationAcceptor acceptor = detector.Detect(formula[braCount]);
				if (acceptor == null)
                {
                    continue;
				}
                TypeInfo dt = detector.ToTypeInfo();
                TreeTransformationAttribute attr = detector.GetAttribute<TreeTransformationAttribute>();
                if (attr != null)
                {
                    ITreeTransformation trans = acceptor as ITreeTransformation;
                    if (tree == null)
                    {
                        tree = CreateTree(new MathFormula(formula, 2 * braCount + 1, formula.Count - 1), creator);
                    }
                    if (tree != null)
                    {
                        ObjectFormulaTree tr = trans.Transform(tree);
                        if (tr != null)
                        {
                            operation = tr.operation;
                            children = tr.children;
                            y = tr.y;
                            return true;
                        }
                    }
                }
                object type = null;
				if (formula.Count > 1)
				{
                    if (tree == null)
                    {
                        tree = CreateTree(new MathFormula(formula, 2 * braCount + 1, formula.Count - 1), creator);
                    }
                    type = tree.ReturnType;
				}
                if (acceptor is IMultiVariableOperationAcceptor)
                {
                    IMultiVariableOperationAcceptor ma = acceptor as IMultiVariableOperationAcceptor;
                    IMultiVariableOperation multiOp = ma.AcceptOperation(formula[0]);
                    MathSymbol s = formula[0];
                    ObjectFormulaTree[] trees = null;
                    object[] types = null;
                    if (s.HasChildren)
                    {
                        int n = 0;
                        for (int j = 0; j < s.Count; j++)
                        {
                            if (s[j] != null)
                            {
                                if (!s[j].IsEmpty)
                                {
                                    ++n;
                                }
                            }
                        }
                        trees = new ObjectFormulaTree[n];
                        types = new object[n];
                        n = 0;
                        for (int j = 0; j < s.Count; j++)
                        {
                            if (s[j] != null)
                            {
                                if (!s[j].IsEmpty)
                                {
                                    ObjectFormulaTree tr = CreateTree(s[j], creator);
                                    if (tr == null)
                                    {
                                        operation = null;
                                        goto mo;
                                    }
                                    trees[j] = tr;
                                    types[j] = trees[j].ReturnType;
                                    ++n;
                                }
                            }
                        }
                    }
                    operation = multiOp.Accept(types);
                mo:
					if (operation == null)
					{
						continue;
					}
					y = new object[types.Length];
					if (trees != null)
					{
						foreach (ObjectFormulaTree t in trees)
						{
							if (t != null)
							{
								children.Add(t);
							}
						}
					}
					return true;
				}
				IObjectOperation op = acceptor.Accept(type);
     			if (op != null)
				{
					if (op.IsPowered())
					{
						if (formula.First.HasChildren)
						{
							ObjectFormulaTree pow = CreateTree(formula.First[0], creator);
							ObjectFormulaTree val = new ObjectFormulaTree();
							val.operation = op;
                            val.y = new object[op.InputTypes.Length];
                            val.CreateResult();
							if (tree != null)
							{
								val.children.Add(tree);
							}
							IObjectOperation powOp = creator.GetPowerOperation(val.ReturnType, pow.ReturnType);
							if (powOp == null)
							{
								return false;
							}
							operation = powOp;
							children.Add(val);
							children.Add(pow);
							y = new object[2];
							return true;
						}
					}
					operation = op;
					if (tree != null)
					{
						children.Add(tree);
						y = new object[1];
					}
					return true;
				}
     		}
			return false;
        }

        #endregion

        #region Internal Members

        internal static void Simplify(List<ObjectFormulaTree> l, IEqualityComparer<ObjectFormulaTree> comparer)
        {
            if (HasOptional(l))
            {
                return;
            }
            ObjectFormulaTree.comparer = comparer;
            List<ObjectFormulaTree> lu = new List<ObjectFormulaTree>();
            foreach (ObjectFormulaTree t in l)
            {
                AddUnique(t, lu);
            }
            Replace(l, lu);

            ObjectFormulaTree.comparer = null;
        }
   
        #endregion

        #region Private Members

        private static bool HasOptional(List<ObjectFormulaTree> trees)
        {
            foreach (ObjectFormulaTree tree in trees)
            {
                if (tree.Operation is OptionalOperation)
                {
                    return true;
                }
                if (HasOptional(tree.children))
                {
                    return true;
                }
            }
            return false;
        }

        private static void AddUnique(ObjectFormulaTree tree, List<ObjectFormulaTree> l)
        {
            foreach (ObjectFormulaTree t in tree.children)
            {
                if (l.Contains(t))
                {
                    continue;
                }
                AddUnique(t, l);
            }
            if (!l.Contains(tree))
            {
                l.Add(tree);
            }
        }
/*!!! UNFINISED CODE
        public static  List<ObjectFormulaTree

        private static void AddUnique(ObjectFormulaTree tree, List<ObjectFormulaTree> list,
            List<IObjectOperation> operations, 
            Func<IObjectOperation, IObjectOperation, bool> comparer)
        {
            IObjectOperation op = tree.Operation;
            foreach (IObjectOperation o in operations)
            {
                if (comparer(o, op))
                {
                    return;
                }
            }
            operations.Add(op);
            list.Add(tree);
        }
        */
 
        private static void Replace(List<ObjectFormulaTree> l, List<ObjectFormulaTree> lu)
        {
            foreach (ObjectFormulaTree t in l)
            {
                Replace(t.children, lu);
            }
            ObjectFormulaTree[] ta = l.ToArray();
            for (int i = 0; i < ta.Length; i++)
            {
                ObjectFormulaTree t = ta[i];
                foreach (ObjectFormulaTree tr in lu)
                {
                    if (tr.Equals(t))
                    {
                        l[i] = tr;
                        break;
                    }
                }
            }
        }

        public bool IsChild(ObjectFormulaTree child)
        {
            foreach (var c in children)
            {
                if (c == child)
                {
                    return true;
                }
                if (c.IsChild(child))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Selects operations
        /// </summary>
        /// <param name="selector">Selector</param>
        /// <param name="list">Result list</param>
        private void selectOperations(IObjectSelector selector, List<object> list)
		{
			object o = selector.Select(operation);
			if (o != null)
			{
				if (!list.Contains(o))
				{
					list.Add(o);
				}
			}
			for (int i = 0; i < Count; i++)
			{
				this[i].selectOperations(selector, list);
			}
		}

        private void Init(MathFormula formula, IFormulaObjectCreator creator)
        {
            if (formula.Count == 0)
            {
                return;
            }
            if (creator.IsBra(formula[0]) & creator.IsKet(formula[formula.Count - 1]))
            {
                MathSymbol sym = formula[formula.Count - 1];
                if (sym.Count > 0)
                {
                    if (sym[0].Count > 0)
                    {
                        MathFormula fp = new MathFormula(formula, 1, formula.Count - 2);
                        ObjectFormulaTree tp = CreateTree(fp, creator);
                        object rp = tp.ReturnType;
                        IObjectOperation opp = tp.Operation;
                        ObjectFormulaTree pow = CreateTree(sym[0], creator);
                        IObjectOperation powOp = creator.GetPowerOperation(tp.ReturnType, pow.ReturnType);
                        if (powOp == null)
                        {
                            return;
                        }
                        operation = powOp;
                        children.Add(tp);
                        children.Add(pow);
                        y = new object[2];
                        return;
                    }
                }
                if (formula[formula.Count - 1].Count >= 0)
                {
                    if (formula.Count > 2)
                    {
                        int m = 1;
                        for (int i = 1; i < formula.Count - 1; i++)
                        {
                            if (creator.IsBra(formula[i]))
                            {
                                ++m;
                            }
                            else if (creator.IsKet(formula[i]))
                            {
                                --m;
                            }
                            if (m == 0)
                            {
                                goto calc;
                            }
                        }
                        MathFormula f = new MathFormula(formula, 1, formula.Count - 2);
                        Init(f, creator);
                        return;
                    }
                }
            }
        calc:
            if (processMultiOperation(formula, creator))
            {
                return;
            }
            if (processBinary(formula, creator))
            {
                return;
            }
            if (processOperation(formula, creator))
            {
                return;
            }
            Normalize();
        }

        private void CreateResult()
        {
            if (operation is OptionalOperation)
            {
                result = GetOptionalResult;
            }
            else
            {
                result = GetTreeResult;
            }
        }

        private object GetTreeResult()
        {
            int n = operation.InputTypes.Length;
            for (int i = 0; i < n; i++)
            {
                object o = this[i].Result;
                if (o == null | o.IsDBNull())
                {
                    return null;
                }
                y[i] = o;
            }
            return operation[y];
        }

        private void Normalize()
        {
            if (operation is ElementaryBrackets)
            {
                ObjectFormulaTree tr = children[0];
                children = tr.children;
                operation = tr.Operation;
                y = tr.y;
                result = tr.result;
                tag = tr.tag;
            }
        }

        private object GetOptionalResult()
        {
            object o = this[0].Result;
            if (o == null)
            {
                return null;
            }
            bool b = (bool)o;
            if (b)
            {
                return this[1].Result;
            }
            return this[2].Result;

        }

        class Comparer : IComparer<ObjectFormulaTree>
        {
            int IComparer<ObjectFormulaTree>.Compare(ObjectFormulaTree x, ObjectFormulaTree y)
            {
                if (x.IsChild(y))
                {
                    return -1;
                }
                if (y.IsChild(x))
                {
                    return 1;
                }
                return 0;
            }
        }

        #endregion

        #region Helper Delegate
        /// <summary>
        /// The result delegate
        /// </summary>
        /// <returns></returns>
        protected delegate object ResultDelegate();

        #endregion
    }
}