using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI.Utils;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

using Event.Basic.Data.Events;

namespace Event.UI.UserControls
{
    /// <summary>
    /// User control for writer
    /// </summary>
    public partial class UserControlWriter : UserControl
    {
        #region Fields

        ImportedEventWriter writer;

        bool isSelect = false;

        List<ComboBox> boxes = new List<ComboBox>();

        string cond = "";

        List<string> measurements;

        string text = "";

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlWriter()
        {
            InitializeComponent();
            text = labelNumber.Text;
        }

        #endregion

        #region Internal Members

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ImportedEventWriter Writer
        {
            get
            {
                return writer;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                writer = value;
                IDataConsumer cons = value;
                cons.OnChangeInput += FillAndSelect;
                List<string> l = writer.Measurements;
                int n = l.Count;
                numericUpDown.Value = n;
                ChangeNum();
                Fill();
                SelectItems();
                numericUpDown.ValueChanged += numericUpDown_ValueChanged;
            }
        }

        #endregion

        #region Private Members

        private void ChangeNum()
        {
            userControlComboboxList.Count = (int)numericUpDown.Value;
            ICollection<ComboBox> c = userControlComboboxList.Boxes;
            List<string> texts = new List<string>();
            int i = 0;
            foreach (ComboBox b in c)
            {
                ++i;
                texts.Add("Item " + i);
                if (!boxes.Contains(b))
                {
                    boxes.Add(b);
                    b.SelectedIndexChanged += comboBox_SelectedIndexChanged;
                }
            }
            userControlComboboxList.Texts = texts.ToArray();
        }

        private void Fill()
        {
            isSelect = false;
            IDataConsumer c = writer;
            IList<string> cond = c.GetAllMeasurementsType(false);
            comboBoxCond.FillCombo(cond);
            Dictionary<string, object> d = c.GetSimpleTypeMeasurements();
            ICollection<ComboBox> cb = userControlComboboxList.Boxes;
            foreach (ComboBox b in cb)
            {
                b.Items.Clear();
                b.FillCombo(d.Keys);
            }
            isSelect = true;
        }

        void FillAndSelect()
        {
            Fill();
            Select();
        }

        private void SelectItems()
        {
            isSelect = false;
            comboBoxCond.SelectCombo(writer.Condition);
            cond = writer.Condition;
            List<ComboBox> cb = userControlComboboxList.Boxes;
            measurements = writer.Measurements;
            int n = (cb.Count < measurements.Count) ? cb.Count : measurements.Count;
            for (int i = 0; i < n; i++)
            {
                ComboBox b = cb[i];
                b.SelectCombo(measurements[i]);
            }
           isSelect = true;
        }

        private void Change()
        {
            if (!isSelect)
            {
                return;
            }
            List<string> mea = writer.Measurements;
            string cnd;
            if (comboBoxCond.SelectedItem == null)
            {
                return;
            }
            cnd = comboBoxCond.SelectedItem + "";
            List<string> l = new List<string>();
            List<ComboBox> cb = userControlComboboxList.Boxes;
            foreach (ComboBox b in cb)
            {
                object o = b.SelectedItem;
                if (o == null)
                {
                    return;
                }
                l.Add(o + "");
            }
            if (!cnd.Equals(writer.Condition))
            {
                writer.Condition = cnd;
            }
            if (l.Count != mea.Count)
            {
                writer.Measurements = l;
                if (cnd != null)
                {
                    if (cnd.Length > 0)
                    {
                        labelNumber.Text = "Ready!!!";
                    }
                }
                return;
            }
            for (int i = 0; i < l.Count; i++)
            {
                if (!l[i].Equals(mea[i]))
                {
                    writer.Measurements = l;
                    if (cnd != null)
                    {
                        if (cnd.Length > 0)
                        {
                            labelNumber.Text = "Ready!!!";
                        }
                    }
                    return;
                }
            }
        }

        #endregion

        #region Event Handlers

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ChangeNum();
            Fill();
            SelectItems();
            labelNumber.Text = text;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Change();
        }

        #endregion
    }
}
