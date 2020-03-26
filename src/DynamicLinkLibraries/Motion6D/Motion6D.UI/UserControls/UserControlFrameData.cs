using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;



using Motion6D;


namespace Motion6D.UI.UserControls
{
    /// <summary>
    /// UserControl of "FrameData" object
    /// </summary>
    public class UserControlFrameData : UserControl6D, IEnabled
    {
        #region Fields

        const Double a = 0;

        private ReferenceFrameDataBase frame;

        private IDataConsumer dc;

        private bool canSelect = false;

        #endregion

        #region IEnabled Members

        bool IEnabled.Enabled
        {
            get
            {
                return (this as Control).Enabled;
            }
            set
            {
                (this as Control).Enabled = value;
                if (value)
                {
                    Fill();
                }
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing">Disposing field</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (dc != null)
            {
                dc.OnChangeInput -= Fill;
                dc = null;
            }
        }

        internal virtual ReferenceFrameDataBase Frame
        {
            set
            {
                frame = value;
                dc = value;
                foreach (ComboBox cb in boxes)
                {
                    cb.SelectedIndexChanged += cb_SelectedIndexChanged;
                }
                dc.OnChangeInput += Fill;
            }
        }

        internal void Fill()
        {
            canSelect = false;
            List<string> l = dc.GetAllMeasurements(a);
            l.Sort();
            boxes.FillCombo(l);
            List<string> p = frame.Parameters;
            for (int i = 0; i < p.Count; i++)
            {
                if (i < boxes.Length)
                {
                    boxes[i].SelectCombo(p[i]);
                }
            }
            canSelect = true;
        }

        void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!canSelect)
            {
                return;
            }
            List<string> l = new List<string>();
            foreach (ComboBox cb in boxes)
            {
                object o = cb.SelectedItem;
                if (o == null)
                {
                    return;
                }
                l.Add(o + "");
            }
            frame.Parameters = l;
        }


        #endregion
    }
}
