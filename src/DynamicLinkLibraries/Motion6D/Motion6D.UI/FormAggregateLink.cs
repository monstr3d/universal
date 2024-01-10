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
using Diagram.UI.Interfaces;

using Motion6D;
using Motion6D.Interfaces;


namespace Motion6D.UI
{

    /// <summary>
    /// Editor of aggergate link
    /// </summary>
    public partial class FormAggregateLink : Form, IUpdatableForm
    {
        private IArrowLabel label;

        private MechanicalAggregateLink link;

        private IAggregableMechanicalObject source;

        private IAggregableMechanicalObject target;

        private bool first = true;

        private FormAggregateLink()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Arrow label</param>
        public FormAggregateLink(IArrowLabel label)
            : this()
        {
            this.label = label;
            UpdateFormUI();
            link = label.Arrow as MechanicalAggregateLink;
            try
            {
                pictureBoxParent.Image = label.Target.GetImage();
                pictureBoxChild.Image = label.Source.GetImage();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }   
            source = link.SourceObject;
            target = link.TargetObject;
            int nt = target.NumberOfConnections;
            int ns = source.NumberOfConnections;
            if (nt == 0)
            {
                numericUpDownChild.Enabled = false;
            }
            else
            {
                numericUpDownChild.Minimum = 1;
                numericUpDownChild.Maximum = source.NumberOfConnections;
                numericUpDownChild.Value = link.SourceConnection + 1;
            }
            if (nt == 0)
            {
                numericUpDownParent.Enabled = false;
            }
            else
            {
                numericUpDownParent.Minimum = 1;
                numericUpDownParent.Maximum = target.NumberOfConnections;
                numericUpDownParent.Value = link.TargetConnection + 1;
            }
            first = false;
        }

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
            labelP.Text = label.Target.Name;
            labelC.Text = label.Source.Name;
        }

        #endregion

        private void numericUpDownParent_ValueChanged(object sender, EventArgs e)
        {
            if (first)
            {
                return;
            }
            link.TargetConnection = (int)numericUpDownParent.Value - 1;
        }

        private void numericUpDownChild_ValueChanged(object sender, EventArgs e)
        {
            if (first)
            {
                return;
            }
            link.SourceConnection = (int)numericUpDownChild.Value - 1;
        }

    }
}