using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;

using BaseTypes.Interfaces;

using DataPerformer.Interfaces;

using FormulaEditor;

namespace DataPerformer.Formula
{
    /// <summary>
    /// Mesure derivation from formula
    /// </summary>
    public class FormulaMeasurementDerivation : FormulaMeasurement, IDerivation
    {
        #region Fields

        private FormulaMeasurement derivation;

        #endregion

        #region Ctor

        public FormulaMeasurementDerivation(ObjectFormulaTree tree,
            FormulaMeasurement derivation, string name, AssociatedAddition associated, object obj)
            : base(tree, name, associated, obj)
        {
            this.derivation = derivation;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <param name="name">Measure name</param>
        /// <param name="associated">Associated addition</param>
        protected FormulaMeasurementDerivation(ObjectFormulaTree tree,
            string name, AssociatedAddition associated, object obj)
            : base(tree, name, associated, obj)
        {
        }


        #endregion

        #region IDerivation Members

        IMeasurement IDerivation.Derivation
        {
            get { return derivation; }
        }

        #endregion

        #region Overridens
        /// <summary>
        /// Resets itself
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            derivation.Reset();
        }

        /// <summary>
        /// Updates itself
        /// </summary>
        public override void Update()
        {
            base.Update();
            derivation.Update();
        }

        /// <summary>
        /// Trees
        /// </summary>
        public override ObjectFormulaTree[] Trees
        {
            get
            {
                List<ObjectFormulaTree> l = new List<ObjectFormulaTree>(base.Trees);
                l.AddRange(derivation.Trees);
                return l.ToArray();
            }
        }

        /// <summary>
        /// Sets proxy to itself
        /// </summary>
        /// <param name="proxy">Proxy</param>
        public override void Set(FormulaEditor.Interfaces.ITreeCollectionProxy proxy)
        {
            base.Set(proxy);
            derivation.Set(proxy);
        }

        #endregion

        #region Members

        /// <summary>
        /// Iterates calculation of derivation
        /// </summary>
        /// <param name="next">The "next" msign</param>
        /// <param name="addition">Associated addition</param>
        /// <returns>Next derivation iteration</returns>
        public FormulaMeasurementDerivation Iterate(bool next, AssociatedAddition addition, object obj)
        {
            string dn = "D" + name;
            ObjectFormulaTree t = tree.Derivation("d/dt");
            IDistribution d = DeltaFunction.GetDistribution(t);
            AssociatedAddition aa = FormulaMeasurementDerivation.Create(associated);
            if (next)
            {
                FormulaMeasurementDerivation der = null;
                if (d != null)
                {
                    der = new FormulaMeasurementDerivationDistribution(t, dn, aa, obj);
                }
                else
                {
                    der = new FormulaMeasurementDerivation(t, dn, aa, obj);
                }
                derivation = der;
                return der;
            }
            if (d != null)
            {
                derivation = new FormulaMeasurementDistribution(t, dn, aa, obj);
            }
            else
            {
                derivation = new FormulaMeasurement(t, dn, aa, obj);
            }
            return null;
        }

        public static AssociatedAddition Create(AssociatedAddition associated)
        {
            object o = associated.Additional;
            object[] ot = null;
            if (o is object[])
            {
                object[] oa = o as object[];
                int k = (int)oa[1] + 1;
                ot = new object[] { oa[0], k };
            }
            else
            {
                ot = new object[] { o, 0 };
            }
            return new AssociatedAddition(associated.AssociatedObject, ot);

        }

        #endregion
    }
}
