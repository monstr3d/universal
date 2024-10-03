using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;


using DataPerformer;
using Motion6D;



namespace Motion6D.UI.Forms
{
    /// <summary>
    /// Editor of reference frame linked to data
    /// </summary>
    public partial class FormFrameData : Form, IUpdatableForm
    {
        private IObjectLabel label;

        private ReferenceFrameData frame;

        private ComboBox[] boxes;

        private FormFrameData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Object label</param>
        public FormFrameData(IObjectLabel label)
        {
            InitializeComponent();
            this.label = label;
            Text = label.Name;
            frame = label.Object as ReferenceFrameData;
            List<ComboBox> l = new List<ComboBox>();
            boxes =
                userControl6D.Boxes;
            fill();
        }

        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        void fill()
        {
            List<string> p = frame.Parameters;
            List<string> l = frame.AllMeasurements;
            for (int i = 0; i < boxes.Length; i++ )
            {
                ComboBox box = boxes[i];
                box.FillCombo(l);
                if (i < p.Count)
                {
                    string s = p[i];
                    box.SelectCombo(s);
                }
            }
        }

        void accept()
        {
            List<string> p = new List<string>();
            foreach (ComboBox box in boxes)
            {
                string s = box.SelectedItem + "";
                if (s.Length == 0)
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Undefined parameter");
                    return;
                }
                p.Add(s);
            }
            frame.Parameters = p;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            accept();
        }
    }
}