using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;

using BaseTypes.Interfaces;

using SerializationInterface;

using OrdinaryDifferentialEquations;

using FormulaEditor;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

using ExtendedFormulaEditor;


using ControlSystems;
using ErrorHandler;
using NamedTree;

namespace ControlSystemsWrapper
{
    /// <summary>
    /// Wrapper of rational transformation function
    /// </summary>
    public class RationalTransformControlSystemFunctionWrapper : RationalTransformControlSystemFunction, ISerializable, ICategoryObject,
        IDictionary<string, object>, IVariableDetector
    {
        
        #region Fields

        public static readonly string NAME = "Filter - transform function";

        CategoryTheory.Performer performer = new();


        protected long time;


        protected Dictionary<string, double> variables = new Dictionary<string, double>();

        private string solver = "Runge-Kutt Method?Order=4";

        private static string arg = RationalTransformControlSystemFunction.LaplaceTransformChar + "";

        private double val;

        private static int maxorder = 100;

        private string formula;

        private Dictionary<string, double> old = new Dictionary<string, double>();

        private Dictionary<string, DoubleDictionaryVariable> dict
            = new Dictionary<string, DoubleDictionaryVariable>();

        IFormulaObjectCreator creator;


        protected object obj;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected RationalTransformControlSystemFunctionWrapper()
            : base(new double[] { 1 }, new double[] { 1 })
        {
            creator = this.GetCreator(new IOperationDetector[] { new DerivationDetector("p", "p") }, new IBinaryDetector[0]);
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected RationalTransformControlSystemFunctionWrapper(SerializationInfo info, StreamingContext context)
            : this()
        {
            formula = info.Deserialize<string>("Formula");
            variables = info.Deserialize<Dictionary<string, double>>("Variables");
            solver = info.Deserialize<string>("Solver");
            try
            {
                shouldStable = (bool)info.GetValue("ShouldStable", typeof(bool));
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            Initialize();
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Initialize();
            info.Serialize<string>("Formula", formula);
            info.Serialize<Dictionary<string, double>>("Variables", variables);
            info.Serialize<string>("Solver", solver);
            info.AddValue("ShouldStable", shouldStable, typeof(bool));
        }

        #endregion

        #region IVariableDetector Members

        IOperationAcceptor IVariableDetector.Detect(MathSymbol sym)
        {
            if (sym.SymbolType != (int)FormulaConstants.Variable)
            {
                return null;
            }
            string s = sym.Symbol + "";
            if (dict.ContainsKey(s))
            {
                return new DoubleDictionaryVariable(s, this);
            }
            return null;
        }

        #endregion

        #region IDictionary<string,object> Members

        void IDictionary<string, object>.Add(string key, object value)
        {
            throw new OwnException("The method or operation is not implemented.");
        }

        bool IDictionary<string, object>.ContainsKey(string key)
        {
            if (key.Equals(arg))
            {
                return true;
            }
            return variables.ContainsKey(key);
        }

        ICollection<string> IDictionary<string, object>.Keys
        {
            get { throw new OwnException("The method or operation is not implemented."); }
        }

        bool IDictionary<string, object>.Remove(string key)
        {
            throw new OwnException("The method or operation is not implemented.");
        }

        bool IDictionary<string, object>.TryGetValue(string key, out object value)
        {
            throw new OwnException("The method or operation is not implemented.");
        }

        ICollection<object> IDictionary<string, object>.Values
        {
            get { throw new OwnException("The method or operation is not implemented."); }
        }

        object IDictionary<string, object>.this[string key]
        {
            get
            {
                if (key.Equals(arg))
                {
                    return val;
                }
                return variables[key];
            }
            set
            {
                if (key.Equals(arg))
                {
                    val = (double)value;
                }
                variables[key] = (double)value;
            }
        }

        #endregion

        #region ICollection<KeyValuePair<string,object>> Members

        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
        {
            throw new OwnException("The method or operation is not implemented.");
        }

        void ICollection<KeyValuePair<string, object>>.Clear()
        {
            throw new OwnException("The method or operation is not implemented.");
        }

        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
        {
            throw new OwnException("The method or operation is not implemented.");
        }

        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new OwnException("The method or operation is not implemented.");
        }

        int ICollection<KeyValuePair<string, object>>.Count
        {
            get { throw new OwnException("The method or operation is not implemented."); }
        }

        bool ICollection<KeyValuePair<string, object>>.IsReadOnly
        {
            get { throw new OwnException("The method or operation is not implemented."); }
        }

        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
        {
            throw new OwnException("The method or operation is not implemented.");
        }

        #endregion

        #region IEnumerable<KeyValuePair<string,object>> Members

        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            throw new OwnException("The method or operation is not implemented.");
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new OwnException("The method or operation is not implemented.");
        }

        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        #endregion

        #region Members

        public MathFormula AcceptFormula(string formula)
        {
            MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, formula);
            string var = ElementaryObjectDetector.GetVariables(f);
            CreateVariables(var);
            return f;
        }


        public virtual void CreateSystem(string formula)
        {
            double[] no = new double[nom.Length];
            double[] dn = new double[denom.Length];
            try
            {
                Array.Copy(nom, no, nom.Length);
                Array.Copy(denom, dn, dn.Length);
                MathFormula f = AcceptFormula(formula);
                MathFormula form = f.FullTransform("");
                ObjectFormulaTree tree = ObjectFormulaTree.CreateTree(form, creator);
                IObjectOperation op = tree.Operation;
                if (!(op is ElementaryFraction))
                {
                    throw new OwnException("Operation should be fraction");
                }
                double[][] p = new double[2][];
                for (int i = 0; i < 2; i++)
                {
                    ObjectFormulaTree t = tree[i];
                    p[i] = CreatePolynom(tree[i]);
                }
                Set(p[0], p[1]);
                if (!IsStable & ShouldStable)
                {
                    throw new OwnException("System is not stable");
                }
                this.formula = formula;
                Solver = DifferentialEquationsPerformer.Default[solver];
            }
            catch (Exception e)
            {
                e.HandleException(10);
                nom = new double[no.Length];
                denom = new double[dn.Length];
                Array.Copy(no, nom, nom.Length);
                Array.Copy(dn, denom, dn.Length);
                this.Throw(e);
            }
        }


        /// <summary>
        /// Resets system
        /// </summary>
        public void Reset()
        {
            DifferentialEquationsPerformer.Initialize(this);
        }

        /// <summary>
        /// Formula
        /// </summary>
        public string Formula
        {
            get
            {
                return formula;
            }
        }

        /// <summary>
        /// Crates polynom from tree
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <returns>Polynom</returns>
        public double[] CreatePolynom(ObjectFormulaTree tree)
        {
            val = 0;
            ObjectFormulaTree t = tree;
            List<double> l = new List<double>();
            double coeff = 1;
            for (int i = 0; i < maxorder; i++)
            {
                if (t == ElementaryRealConstant.RealZero)
                {
                    break;
                }
                double a = (double)t.Result;
                a /= coeff;
                coeff *= (double)(i + 1);
                l.Add(a);
                ObjectFormulaTree tr = t;
                t = t.Derivation(arg);
            }
            if (t != ElementaryRealConstant.RealZero)
            {
                throw new OwnException("This not a polynom");
            }
            return l.ToArray();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        protected virtual void Initialize()
        {
            CreateSystem(formula);
        }


 

        private void CreateVariables(string var)
        {
            SaveConstants();
            variables.Clear();
            dict.Clear();
            foreach (char c in var)
            {
                string s = c + "";
                if (!s.Equals(arg))
                {
                    variables[s] = 1;
                }
                dict[s] = new DoubleDictionaryVariable(s, this);
            }
            Restore();
        }

        private void SaveConstants()
        {
            old.Clear();
            foreach (string key in variables.Keys)
            {
                old[key] = variables[key];
            }

        }

        private void Restore()
        {
            foreach (string key in old.Keys)
            {
                if (variables.ContainsKey(key))
                {
                    variables[key] = old[key];
                }
            }
        }

        public IDictionary<string, double> Variables
        {
            get
            {
                return variables;
            }
        }

        string INamed.Name { get => performer.GetAssociatedName(this); 
            set => throw new ErrorHandler.WriteProhibitedException(); }
       

        #endregion

    }
}
