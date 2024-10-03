using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using DataPerformer.Portable;



namespace Motion6D.UI
{
    /// <summary>
    /// Editor of properties of accelerated point
    /// </summary>
    public partial class FormAcceleratedPoint : Form, IUpdatableForm
    {

        ComboBox[] boxes;

        IObjectLabel label;

        AcceleratedPosition pos;

        const Double a = 0;

        private FormAcceleratedPoint()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Object label</param>
        public FormAcceleratedPoint(IObjectLabel label)
            : this()
        {
            this.label = label;
            UpdateFormUI();
            pos = label.Object as AcceleratedPosition;
            boxes = new ComboBox[] { comboBoxX, comboBoxY, comboBoxZ };
            Fill();
        }


        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        void Fill()
        {
            propertyGridIC.SetAlias(pos);
            userControlRelativeField.Set(pos, pos.Field);
            ICollection<string> l = pos.GetAllMeasurements(a);
            boxes.FillCombo(l);
            Dictionary<int, string> d = pos.Measures;
            foreach (int i in d.Keys)
            {
                boxes[i].SelectCombo(d[i]);
            }
        }

        void Accept()
        {
            userControlRelativeField.Accept();
            Dictionary<int, string> d = pos.Measures;
            foreach (ComboBox b in boxes)
            {
                if (b.SelectedItem == null)
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal("You should fill all accelerations");
                }
            }
            for (int i = 0; i < boxes.Length; i++)
            {
                d[i] = boxes[i].SelectedItem + "";
            }
            pos.Post();

        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Accept();
        }
    }
}