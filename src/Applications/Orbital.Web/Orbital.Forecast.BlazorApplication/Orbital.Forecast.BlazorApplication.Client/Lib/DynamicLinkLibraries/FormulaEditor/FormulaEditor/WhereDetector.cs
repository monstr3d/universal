using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes;
using BaseTypes.Interfaces;
using FormulaEditor;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Detector of "where" operation
    /// </summary>
    public class WhereDetector : IBinaryDetector, IBinaryAcceptor, IChildTreeCreator
    {
        /// <summary>
        /// Singleton
        /// </summary>
        public static WhereDetector Singleton = new WhereDetector();

        private WhereDetector()
        {

        }

        BinaryAssociationDirection IBinaryDetector.AssociationDirection
        {
            get
            {
                return BinaryAssociationDirection.LeftRight;
            }
        }

 
        IBinaryAcceptor IBinaryDetector.Detect(MathSymbol symbol)
        {
           if (symbol.String.Equals("where"))
            {
                return new WhereDetector();
            }
            return null;
        }

        IObjectOperation IBinaryAcceptor.Accept(object typeA, object typeB)
        {
            return null;
        }

        ObjectFormulaTree IChildTreeCreator.this[ObjectFormulaTree[] children]
        {
            get
            {
                if (children.Length != 2)
                {
                    return null;
                }
                ArrayReturnType[] types = new ArrayReturnType[2];
                for (int i = 0; i < 2; i++)
                {
                    object t = children[i].ReturnType;
                    if (t is ArrayReturnType)
                    {
                        ArrayReturnType art = t as ArrayReturnType;
                        int[] d = art.Dimension;
                        if (d.Length == 1)
                        {
                            if (d[0] == -1)
                            {
                                types[i] = art;
                            }
                        }
                        continue;
                    }
                    return null;
                }
                if (types[1].ElementType.Equals(false))
                {
                    return Create(children);
                }
                return null;
            }
        }

        ObjectFormulaTree Create(ObjectFormulaTree[] children)
        {
                Variable v = new Variable(children[0].Operation, children);
                return Variable.Create(v, children);
        }

        class Variable : IObjectOperation
        {
            private ObjectFormulaTree[] children;

            private IObjectOperation variable;

            private ObjectFormulaTree tree;

            private object value;

            object[] types;

            object type;

            object retType;

            static internal ObjectFormulaTree  Create(Variable variable, ObjectFormulaTree[] children)
            {
                Where where = new Where(variable);
                return new ObjectFormulaTree(where, new List<ObjectFormulaTree> { children[0] });
            }

            internal Variable(IObjectOperation variable, ObjectFormulaTree[] children)
            {
                this.variable = variable;
                this.children = children;
                type = children[0].ReturnType;
                types = new object[] { type };
                ArrayReturnType art = children[0].ReturnType as ArrayReturnType;
                retType = art.ElementType;
                tree = Convert(children[1]);
            }

            object IObjectOperation.this[object[] arguments]
            {
                get
                {
                    return value;
                }
            }

            object[] IObjectOperation.InputTypes
            {
                get
                {
                    return new object[0];
                }
            }

            object IObjectOperation.ReturnType
            {
                get
                {
                    return retType;
                }
            }

            internal bool Predicate(object o)
            {
                value = o;
                return (bool)tree.Result;
            }

            private ObjectFormulaTree Convert(ObjectFormulaTree t)
            {
                
                IObjectOperation op = t.Operation;
                if (op == variable)
                {
                    op = this;
                }
                if (op is IInternalOperation)
                {
                    op = (op as IInternalOperation).Operation;
                }
                List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
                for (int i = 0; i < t.Count; i++)
                {
                    l.Add(Convert(t[i]));
                }
                return new ObjectFormulaTree(op, l);

            }



            class Where : IObjectOperation
            {
                Variable variable;

                internal Where(Variable variable)
                {
                    this.variable = variable;
                }

                object IObjectOperation.this[object[] arguments]
                {
                    get
                    {
                        object[] o = arguments[0] as object[];
                        object[] ob = o.Where(variable.Predicate).ToArray();
                        return ob;
                    }
                }

                object[] IObjectOperation.InputTypes
                {
                    get
                    {
                        return variable.types;
                    }
                }

                object IObjectOperation.ReturnType
                {
                    get
                    {
                       return  variable.children[0].ReturnType;
                    }
                }
            }
        }
    }
}
