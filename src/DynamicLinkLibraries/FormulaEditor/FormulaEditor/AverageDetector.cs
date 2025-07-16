using System;
using System.Collections.Generic;
using System.Linq;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;
using BaseTypes.Interfaces;
using BaseTypes;

namespace FormulaEditor
{
    public class AverageDetector : IBinaryDetector, IBinaryAcceptor, IChildTreeCreator
    {
        #region Fields

        public static AverageDetector Singleton = new AverageDetector();

        #endregion

        #region Ctor

        private AverageDetector()
        {

        }

        #endregion

        #region IChildTreeCreator members
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
                object et = types[1].ElementType;
                if(et.Equals((float)0))//!!! return when VariableDouble is made if (et is double | et is float) 
                {
                    return Create(children);
                }
                return null;
            }
        }

        ObjectFormulaTree Create(ObjectFormulaTree[] children)
        {
            VariableSingle v = new VariableSingle(children[0].Operation, children);
            return VariableSingle.Create(v, children);
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
            if (symbol.String.Equals("average"))
            {
                return new AverageDetector();
            }
            return null;
        }

        #endregion

        #region Class VariableSingle

        class VariableSingle : IObjectOperation
        {
            private ObjectFormulaTree[] children;

            private IObjectOperation variable;

            private ObjectFormulaTree tree;

            private object value;

            object[] types;

            object type;

            object retType;

            static internal ObjectFormulaTree Create(VariableSingle variable, ObjectFormulaTree[] children)
            {
                Average average = new Average(variable);
                return new ObjectFormulaTree(average, new List<ObjectFormulaTree> { children[0] });
            }

            internal VariableSingle(IObjectOperation variable, ObjectFormulaTree[] children)
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

            internal float Predicate(object o)
            {
                value = o;
                return (float)tree.Result;
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

            #region Average class

            class Average : IObjectOperation
            {
                #region Fields

                VariableSingle variable;

                #endregion

                #region Ctor

                internal Average(VariableSingle variable)
                {
                    this.variable = variable;
                }

                #endregion

                #region IObjectOperation members

                public object this[object[] arguments]
                {
                    get
                    {
                        Func<object, float> f = variable.Predicate;
                        IEnumerable<object> o = arguments[0] as IEnumerable<object>;
                        float ob = 0;
                        if (o.Count() > 0)
                        {
                            ob = o.Average(f);
                        }
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
//!!! nice try                        return variable.retType;
                        return variable.tree.ReturnType;

                    }
                }

                #endregion

            }

            #endregion

        }
    }
}
