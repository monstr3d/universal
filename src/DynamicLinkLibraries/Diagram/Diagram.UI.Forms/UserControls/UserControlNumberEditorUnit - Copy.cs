using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// Edit number unit
    /// </summary>
    public partial class UserControlNumberEditorUnit : UserControl
    {
        #region Fields

        int[] array;

        int number;

        event Action change = () => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="number">Number</param>
        /// <param name="name">Name</param>
        public UserControlNumberEditorUnit(int[] array, int number, string name)
        {
            InitializeComponent();
            this.array = array;
            this.number = number;
            numericUpDown.Value = array[number];
            numericUpDown.ValueChanged += numericUpDown_ValueChanged;
            labelName.Text = name;
        }

        #endregion

        #region Internal

        /// <summary>
        /// Change event
        /// </summary>
        internal event Action Change
        {
            add { change += value; }
            remove { change -= value; }
        }

        #endregion


        #region Event Handlers

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            array[number] = (int)numericUpDown.Value;
            change();
        }

        #endregion

    }
}
