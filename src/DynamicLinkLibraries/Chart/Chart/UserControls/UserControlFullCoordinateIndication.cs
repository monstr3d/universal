using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Chart.UserControls
{
    /// <summary>
    /// Indicator of full coordinates
    /// </summary>
    public partial class UserControlFullCoordinateIndication : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlFullCoordinateIndication()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Performer of chart drawing
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ChartPerformer Performer
        {
            get
            {
                return userControlCoordinateIndicationHorizontal.Performer;
            }
            set
            {
                userControlCoordinateIndicationHorizontal.Performer = value;
                userControlCoordinateIndicationVertical.Performer = value;
            }
        }
    }
}
