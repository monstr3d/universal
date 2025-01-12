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
    class IndexOfDetector : IBinaryDetector, IBinaryAcceptor, IChildTreeCreator
    {
        #region Fileds

        public static IndexOfDetector Singleton = new IndexOfDetector();

        #endregion

        #region Ctor

        IndexOfDetector()
        {

        }

        #endregion

        #region IOperationDetector members

        public BinaryAssociationDirection AssociationDirection
        {
            get
            {
                return BinaryAssociationDirection.LeftRight;
            }
        }

        public IBinaryAcceptor Detect(MathSymbol symbol)
        {
            if (symbol.Symbol == '@')
            {
                if (symbol.String == "IndexOf")
                {
                    return new IndexOfDetector();
                }
            }
            return null;
        }

        #endregion

        #region IOperationAcceptor members

        public IObjectOperation Accept(object typeA, object typeB)
        {
            return null;
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



        #endregion

        #region Own members

        #endregion

        #region Variable class

        class Variable : IObjectOperation
        {
            #region Fields

            private ObjectFormulaTree[] children;

            private IObjectOperation variable;

            private ObjectFormulaTree tree;

            private object value;

            object[] types;

            object type;

            object retType;

            #endregion

            #region Ctor

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

            #endregion

            #region Own members

            static internal ObjectFormulaTree Create(Variable variable, ObjectFormulaTree[] children)
            {
                IndexOf indexOf = new IndexOf(variable);
                return new ObjectFormulaTree(indexOf, new List<ObjectFormulaTree> { children[0] });
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

            #region IObjectOpertion members

            public object this[object[] arguments]
            {
                get
                {
                    return value;
                }
            }

            public object[] InputTypes
            {
                get
                {
                    return new object[0];
                }
            }

            public object ReturnType
            {
                get
                {
                    return retType;
                }
            }
            #endregion

            #region IndexOf class

            class IndexOf : IObjectOperation
            {
                #region Fields

                Variable variable;

                #endregion

                #region Ctor

                internal IndexOf(Variable variable)
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
                        int i = Array.IndexOf(o, variable.tree.Result);
                        return i;
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
                        return variable.tree.ReturnType;
                    }
                }


                #endregion

            }

            #endregion
        }

        #endregion

    }
}
