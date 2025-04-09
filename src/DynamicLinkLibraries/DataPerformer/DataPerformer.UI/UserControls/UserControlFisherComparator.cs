using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using Regression;
using MathStatistics;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control for comparation by Fisher criterion
    /// </summary>
    public partial class UserControlFisherComparator : UserControl
    {

        #region Fields

        /// <summary>
        /// Collection of objects
        /// </summary>
        protected ObjectsCollection collection;

        Dictionary<string, Regression.AliasRegression> items = 
            new Dictionary<string, Regression.AliasRegression>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlFisherComparator()
        {
            InitializeComponent();
        }

        #endregion

        #region Members

        internal ObjectsCollection Collection
        {
            set
            {
                Type t = value.Type;
                if (!t.Equals(typeof(Regression.AliasRegression)))
                {
                    throw new ErrorHandler.OwnException("Illegal type");
                }
                collection = value;
                collection.Object = this;
            }
        }

        /// <summary>
        /// Updetes itself
        /// </summary>
        new protected void Update()
        {
            checkedListBox.Items.Clear();
            items.Clear();
            int n = collection.Count;
            for (int i = 0; i < n; i++)
            {
                Regression.AliasRegression ar = collection[i] as
                    Regression.AliasRegression;
                string name = collection.GetRelativeName(ar) 
                    + "("  + ar.Dimension + ")";
                checkedListBox.Items.Add(name);
                items[name] = ar;
            }
        }

        private void Compare()
        {
           CheckedListBox.CheckedItemCollection ch = checkedListBox.CheckedItems;
            if (ch.Count != 2)
            {
                return;
            }
            List<Regression.AliasRegression> arl = 
                new List<Regression.AliasRegression>();
            foreach (string s in ch)
            {
                arl.Add(items[s]);
            }
            int n1 = arl[0].Dimension;
            int n2 = arl[1].Dimension;
            int k1 = n1;
            int k2 = n2;
            Regression.AliasRegression[] arr = null;
            if (n1 > n2)
            {
                arr = new Regression.AliasRegression[] { arl[0], arl[1] };
            }
            else
            {
                arr = new Regression.AliasRegression[] { arl[1], arl[0] };
                k1 = n2;
                k2 = n1;
            }
            double[] ss = new double[2];
            int[] kk = new int[2];
            for (int i = 0; i < ss.Length; i++)
            {
                Regression.AliasRegression aa = arr[i];
                int dim = aa.DataDimension - aa.Dimension;
                ss[i] = aa.StandardDeviation / ((double)dim);
                kk[i] = dim;
            }
            double x = StatisticsFunctions.Fisher(kk[0], kk[1], ss[0] / ss[1], 1E-8);
            labelLevel.Text = x + "";
        }

        #endregion

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            Compare();
        }

    }
}
