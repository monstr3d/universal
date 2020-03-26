using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;

using Diagram.UI;

using BaseTypes.Interfaces;
using BaseTypes;

using FormulaEditor;
using FormulaEditor.Interfaces;

using DataPerformer.Interfaces;


namespace DataPerformer.Formula
{
    /// <summary>
    /// Formula measure
    /// </summary>
    public class FormulaMeasurement : IMeasurement
    {

        delegate object GetParameter();

        #region Fields

        /// <summary>
        /// Associated tree
        /// </summary>
        protected ObjectFormulaTree tree;

        /// <summary>
        /// Return value
        /// </summary>
        protected object ret;

        /// <summary>
        /// Name
        /// </summary>
        protected string name;

        /// <summary>
        /// Parameter
        /// </summary>
        protected Func<object> par;

        /// <summary>
        /// Associated addition
        /// </summary>
        protected AssociatedAddition associated;

        ITreeCollectionProxy proxy;

        Func<object> proxyPar;

        //Action SetValueAction;

        static private Action<object> checkValue = (object o) => { };

        #endregion

        #region Ctor

        public FormulaMeasurement(ObjectFormulaTree tree, string name, 
            AssociatedAddition associated)
        {
            this.tree = tree;
            this.name = name;
            this.associated = associated;
            par = GetDefaultValue;
         }

        #endregion

        #region IMeasurement Members

        Func<object> IMeasurement.Parameter
        {
            get 
            {
                return par; 
            }
        }

        string IMeasurement.Name
        {
            get { return name; }
        }

        object IMeasurement.Type
        {
            get { return tree.ReturnType; }
        }

        #endregion

 
        #region Members

        /// <summary>
        /// Gets all trees for formula measures
        /// </summary>
        /// <param name="meas">Measures</param>
        /// <returns>Trees</returns>
        public static ObjectFormulaTree[] GetTrees(FormulaMeasurement[] meas)
        {
            List<ObjectFormulaTree> list = new List<ObjectFormulaTree>();
            List<FormulaMeasurement> globalList = new List<FormulaMeasurement>();
            return GetTreesLocal(meas, list, globalList);
        }


        private static ObjectFormulaTree[] GetTreesLocal(FormulaMeasurement[] meas, List<ObjectFormulaTree> list,
            List<FormulaMeasurement> globalList)
        {
            foreach (FormulaMeasurement m in meas)
            {
                if (!list.Contains(m.tree))
                {
                    list.Add(m.tree);
                }
            }
            List<FormulaMeasurement> l = new List<FormulaMeasurement>();
            foreach (FormulaMeasurement mea in meas)
            {
                if (mea is IDerivation)
                {
                    IDerivation d = mea as IDerivation;
                    if (d is FormulaMeasurement)
                    {
                        FormulaMeasurement fm = d.Derivation as FormulaMeasurement;
                        if (!globalList.Contains(fm))
                        {
                            globalList.Add(fm);
                            if (!list.Contains(fm.tree))
                            {
                                if (!l.Contains(fm))
                                {
                                    l.Add(fm);
                                    if (!list.Contains(fm.tree))
                                    {
                                        list.Add(fm.tree);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (l.Count > 0)
            {
                GetTreesLocal(l.ToArray(), list, globalList);
            }
            return list.ToArray();
        }

        /// <summary>
        /// Resets itself
        /// </summary>
        public virtual void Reset()
        {
            ret = null;
            par = GetDefaultValue;
        }

        /// <summary>
        /// Trees
        /// </summary>
        public virtual ObjectFormulaTree[]  Trees
        {
            get
            {
                return new ObjectFormulaTree[] { tree };
            }
        }

        /// <summary>
        /// Updates itself
        /// </summary>
        public virtual void Update()
        {
            try
            {
                object o = tree.Result;
                checkValue(o);
                ret = o;
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                object o = associated.Additional;
                object ot = null;
                if (o == null)
                {
                    ot = name;
                }
                else if (o is object[])
                {
                    List<object> l = new List<object>();
                    l.AddRange(o as object[]);
                    l.Add(name);
                    ot = l.ToArray();
                }
                else
                {
                    ot = new object[] { o, name };
                }
                AssociatedAddition aa =
                    new AssociatedAddition(associated.AssociatedObject, ot);
                AssociatedException.Throw(aa, ex);
            }
        }

        public virtual void Set(ITreeCollectionProxy proxy)
        {
            proxyPar = null;
            if (proxy != null)
            {
                this.proxy = proxy;
                proxyPar = new Func<object>(proxy[tree]);
            }
        }

        public static void Set(ICollection<IMeasurement> collection, ITreeCollectionProxy proxy)
        {
            foreach (FormulaMeasurement m in collection)
            {
                m.Set(proxy);
            }
        }

        internal static ObjectFormulaTree[] GetTrees(ICollection<IMeasurement> fm)
        {
            List<ObjectFormulaTree> t = new List<ObjectFormulaTree>();
            foreach (FormulaMeasurement f in fm)
            {
                ObjectFormulaTree[] tt = f.Trees;
                foreach (ObjectFormulaTree tree in tt)
                {
                    if (!t.Contains(tree))
                    {
                        t.Add(tree);
                    }
                    else
                    {

                    }
                }
            }
            return t.ToArray();
        }


        /// <summary>
        /// Creates measure
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <param name="n">Number of tree</param>
        /// <param name="name">Name</param>
        /// <param name="associated">Associated addition</param>
        /// <returns>Measurement</returns>
        public static FormulaMeasurement Create(ObjectFormulaTree tree, int n,
            string name, AssociatedAddition associated)
        {
            object ret = null;
            try
            {
                ret = tree.Result;
            }
            catch (Exception ex)
            {
                ex.ShowError(-1);
            }
            FormulaMeasurement fm;
            if (n == 0)
            {
                IDistribution d = DeltaFunction.GetDistribution(tree);
                if (d != null)
                {
                    return new FormulaMeasurementDistribution(tree, name, associated);
                }
                fm = new FormulaMeasurement(tree, name, associated);
                fm.ret = ret;
                return fm;
            }
            string dn = "D" + name;
            ObjectFormulaTree t = tree.Derivation("d/dt");
            if (t == null)
            {
                throw new Exception("VariableMeasure.Derivation");
            }
            AssociatedAddition aa = FormulaMeasurementDerivation.Create(associated);
            FormulaMeasurement der = Create(t, n - 1, dn, aa);
            fm = new FormulaMeasurementDerivation(tree, der, name, aa);
            try
            {
                fm.ret = t.Result;
            }
            catch (Exception exc)
            {
                exc.ShowError(10);
            }
            return fm;
        }

        /// <summary>
        /// Checks value
        /// </summary>
        public static Action<object> CheckValue
        {
            get
            {
                return checkValue;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception();
                }
                checkValue = value;
            }
        }

        /// <summary>
        /// Empty check of object
        /// </summary>
        /// <param name="o">The object</param>
        public static void EmptyCheck(object o)
        {
        }

        /// <summary>
        /// Checks an object
        /// </summary>
        /// <param name="o">The object for checking</param>
        public static void Check(object o)
        {
            if (o.GetType().Equals(typeof(double)))
            {
                double a = (double)o;
                if (double.IsInfinity(a))
                {
                    throw new Exception("Infinity");
                }
                if (double.IsNaN(a))
                {
                    throw new Exception("NaN");
                }
                if (double.IsNegativeInfinity(a))
                {
                    throw new Exception("NegativeInfinity");
                }
                if (double.IsPositiveInfinity(a))
                {
                    throw new Exception("PositiveInfinity");
                }
            }
        }

 
        /// <summary>
        /// Gets value of tree
        /// </summary>
        /// <returns>The value of tree</returns>
        protected object GetValue()
        {
            return tree.Result;
        }


        private void SetProxy()
        {
            ret = proxyPar();
        }

        private void SetTree()
        {
            ret = tree.Result;
        }


        private object GetDefaultValue()
        {
            object type = tree.ReturnType;
            bool b = proxyPar == null;
            if (b)
            {
                ret = tree.Result;
            }
            else
            {
               ret = proxyPar();
            }
            if (ret == null)
            {
                ret = tree.Result;
            }
            if (ret != null)
            {
                if (ret.GetType().Equals(typeof(double)))
                {
                    double dr = (double)ret;
                    if (double.IsInfinity(dr) | double.IsNaN(dr) |
                        double.IsNegativeInfinity(dr) | double.IsPositiveInfinity(dr))
                    {
                        dr = 0;
                        ret = dr;
                        try
                        {
                            ret = tree.Result;
                        }
                        catch (Exception ex)
                        {
                            ex.ShowError(10);
                        }
                    }
                }
            }
            else
            {
                if (type is ArrayReturnType)
                {
                }
                else
                {
                    ret = type;
                }
            }
            if (ret != null)
            {
                if (b)
                {
                    par = GetValue;
                }
                else
                {
                    par = proxyPar;
                }
            }
            return ret;
        }

        /// <summary>
        /// Gets result of formula
        /// </summary>
        /// <returns>Result of formula</returns>
        protected object GetFormulaResult()
        {
            return tree.Result;
        }
        
        

        #endregion
    }
}
