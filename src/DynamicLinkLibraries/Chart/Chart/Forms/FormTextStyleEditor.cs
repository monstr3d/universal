using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Chart;
using Chart.Classes;

namespace Chart.Forms
{
    /// <summary>
    /// Editor of text style
    /// </summary>
    public partial class FormTextStyleEditor : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public FormTextStyleEditor()
        {
            InitializeComponent();
            Action<Control> l = DataTextChooser.Localize;
            if (l != null)
            {
                l(this);
            }
        }

        /// <summary>
        /// Chart performer
        /// </summary>
        public ChartPerformer Performer
        {
            get
            {
                return userControlFullCoordinateIndication.Performer;
            }
            set
            {
                userControlFullCoordinateIndication.Performer = value;
            }
        }
    }
}