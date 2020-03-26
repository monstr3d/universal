using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;



using Diagram.UI.Interfaces;
using DataPerformer;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Editor of collection of variables
    /// </summary>
    public partial class UserControlComponentCollectionVariables : UserControl
    {
        #region Fields

        IComponentCollection collection;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlComponentCollectionVariables()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Collection
        /// </summary>
        public IComponentCollection Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                if (value == null)
                {
                    return;
                }
                Fill();
            }
        }


        private void Fill()
        {
            dataGridView.Rows.Clear();
            List<string[]> l = collection.GetDoubleVariables();
            foreach (string[] s in l)
            {
                dataGridView.Rows.Add(s[0], s[1]);
            }
        }

    }
}
