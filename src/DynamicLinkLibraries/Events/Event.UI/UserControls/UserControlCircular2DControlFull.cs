using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;

using Event.Basic.Data.Events;
using Event.UI.Labels;

namespace Event.UI.UserControls
{
    /// <summary>
    /// Full control for circular 2D
    /// </summary>
    public partial class UserControlCircular2DControlFull : UserControl
    {

        #region Fields

        Circular2DControlLabel label;

        ForcedEventData forced;

        double[] data = new double[6];

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCircular2DControlFull()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Members

        internal Circular2DControlLabel Label
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                label = value;
                forced = (value as 
                    Diagram.UI.Labels.IObjectLabel).Object as ForcedEventData;
                userControlCircular2DControl.Set(forced, label.X1, label.Y1, label.X2, label.Y2);
                Set();
            }
        }

        #endregion

        #region Private Members

        void Set()
        {
            string[] texts =  { "x0", "y0" };
            object[] o = forced.Initial;
            for (int i = 0; i < 2; i++)
            {
                dataGridView.Rows.Add(new object[] { texts[i], o[i] + "" });
            }
            texts = new string[] { "x1", "y1", "x2", "y2" };
            double[] d = { label.X1, label.Y1, label.X2, label.Y2 };
            for (int i = 0; i < 4; i++)
            {
                dataGridView.Rows.Add(new object[] { texts[i], d[i] + "" });
            }

        }

        void Get()
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];
                data[i] = double.Parse(row.Cells[1].Value + "");
            }
            for (int i = 0; i < 2; i++)
            {
                forced.Initial[i] = data[i];
            }
            label.X1 = data[2];
            label.Y1 = data[3];
            label.X2 = data[4];
            label.Y2 = data[5];
        }

        #endregion

        #region Event Handlers

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Get();
        }

        #endregion
    }
}
