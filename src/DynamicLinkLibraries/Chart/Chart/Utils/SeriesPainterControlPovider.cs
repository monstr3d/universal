using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Drawing;


using Chart.Drawing.Interfaces;
using Chart.Drawing.Painters;

namespace Chart.Utils
{
    /// <summary>
    /// Provider of Series painter from controls
    /// </summary>
    public class SeriesPainterControlPovider : ISeriesPainterPovider
    {
        #region Fields

        private object[] array;

        private ToolStripComboBox tcb;

        private OfficePickers.ColorPicker.ToolStripColorPicker tsp;

        private static readonly string[] cbText = new string[]
            {"Linear", "Crosses", "Steps"};

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tcb">Combobox</param>
        /// <param name="tsp">Color picker</param>
        /// <param name="array">Settings</param>
        public SeriesPainterControlPovider(ToolStripComboBox tcb,
            OfficePickers.ColorPicker.ToolStripColorPicker tsp,
            object[] array)
        {
            tcb.Text = "<Series type>";
            foreach (string s in cbText)
            {
                tcb.Items.Add(s);
            }
            this.tcb = tcb;
            this.tsp = tsp;
            Array = array;
            tcb.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
               if (!tcb.SelectedIndex.Equals(array[0]))
               {
                    array[0] = tcb.SelectedIndex;
                }
            };
            this.array = array;
       }

 
        #endregion

        #region ISeriesPainterPovider Members

        ISeriesPainter ISeriesPainterPovider.Painter
        {
            get { return SeriesPainter; }
        }

        #endregion


        #region Protected Members

 
        /// <summary>
        /// Series painter
        /// </summary>
        protected virtual ISeriesPainter SeriesPainter
        {
            get
            {
                int mode = -1;
                if (tcb.SelectedItem == null)
                {
                    array[0] = mode;
                    return null;
                }
                mode = tcb.SelectedIndex;
                Color c = tsp.Color;
                array[0] = mode;
                array[1] = c;
                Color[] col = new Color[] { c };
                if (mode == 0)
                {
                    return new SimpleSeriesPainter(col);
                }
                if (mode == 1)
                {
                    return new CrossSeriesPainter(col);
                }
                return new StepSeriesPainter(col);
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Array
        /// </summary>
        public object[] Array
        {
            get
            {
                return array;
            }
            set
            {
                array = value;
                int mode = (int)array[0];
                Color c = (Color)array[1];
                if (mode >= 0)
                {
                    if (tcb.SelectedIndex != mode)
                    {
                        tcb.SelectedIndex = mode;
                    }
                }
                tsp.Color = c;
            }
        }

        #endregion
    }
}
