using FormulaEditor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaEditor.Symbols;
using BaseTypes.Interfaces;
using BaseTypes;

namespace FormulaEditor
{
    /// <summary>
    /// Detector of orderby operation
    /// </summary>
    public class OrderByDetector : IBinaryDetector, IBinaryAcceptor, IChildTreeCreator
    {

        #region Fields

        public static OrderByDetector Singleton = new OrderByDetector();

        #endregion

        #region Ctor

        private OrderByDetector()
        {

        }

        #endregion

        #region IChildTreeCreator members
        public ObjectFormulaTree this[ObjectFormulaTree[] children]
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
                object et = types[1].ElementType;
                Type tt = et.GetType();
                if (et is Type)
                {
                    tt = et as Type;
                }
                if (System.Reflection.IntrospectionExtensions.GetTypeInfo(tt).ImplementedInterfaces.Contains(typeof(IComparable)))
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


        #endregion

        #region IBinaryAcceptor members

        public BinaryAssociationDirection AssociationDirection
        {
            get
            {
                return BinaryAssociationDirection.LeftRight;
            }
        }

        public IObjectOperation Accept(object typeA, object typeB)
        {
            return null;
        }

        #endregion

        #region IBinaryDetector members

        public IBinaryAcceptor Detect(MathSymbol symbol)
        {
            if (symbol.String.Equals("orderby"))
            {
                return new OrderByDetector();
            }
            return null;
        }

        #endregion

        #region Class Variable

        class Variable : IObjectOperation
        {
            private ObjectFormulaTree[] children;

            private IObjectOperation variable;

            private ObjectFormulaTree tree;

            private object value;

            object[] types;

            object type;

            object retType;

            static internal ObjectFormulaTree Create(Variable variable, ObjectFormulaTree[] children)
            {
                OrderBy orderby = new OrderBy(variable);
                return new ObjectFormulaTree(orderby, new List<ObjectFormulaTree> { children[0] });
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

            internal IComparable Predicate(object o)
            {
                value = o;
                return (IComparable)tree.Result;
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

            #endregion

            #region OrderBy class

            class OrderBy : IObjectOperation
            {
                #region Fields

                Variable variable;

                #endregion

                #region Ctor

                internal OrderBy(Variable variable)
                {
                    this.variable = variable;
                }

                #endregion

                #region IObjectOperation members

                public object this[object[] arguments]
                {
                    get
                    {
                        object[] o = arguments[0] as object[];
                        object[] ob = o.OrderBy(variable.Predicate).ToArray();
                        return ob;
                    }
                }

                public object[] InputTypes
                {
                    get
                    {
                        return variable.types;
                    }
                }

                public object ReturnType
                {
                    get
                    {
                        return variable.children[0].ReturnType;
                    }
                }

                #endregion

            }

            #endregion

        }
    }
}
