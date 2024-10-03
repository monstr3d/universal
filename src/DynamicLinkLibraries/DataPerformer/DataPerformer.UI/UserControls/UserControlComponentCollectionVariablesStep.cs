using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI.Interfaces;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Editor of properties of colletion of components and step
    /// </summary>
    public partial class UserControlComponentCollectionVariablesStep : UserControl
    {
       event Action<double> act = (double a) => {};

        /// <summary>
        /// Construtor
        /// </summary>
        public UserControlComponentCollectionVariablesStep()
        {
            InitializeComponent();
            double a = 0;
            textBox.Text = a + "";
        }

        /// <summary>
        /// Collection
        /// </summary>
        public IComponentCollection Collection
        {
            get
            {
                return userControlComponentCollectionVariables.Collection;
            }
            set
            {
                userControlComponentCollectionVariables.Collection = value;
            }
        }

        /// <summary>
        /// St
        /// </summary>
        public double Step
        {
            get
            {
               return  Double.Parse(textBox.Text);
            }
            set
            {
                textBox.Text = value + "";
            }
        }

        /// <summary>
        /// Set step event
        /// </summary>
        public event Action<double> SetStep
        {
            add
            {
                act += value;
            }
            remove
            {
                act -= value;
            }
        }


        private void buttonAccept_Click(object sender, EventArgs e)
        {
            act(Step);
        }

    }
}
