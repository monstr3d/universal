using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DataPerformer.Interfaces;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control for top object of data consumer
    /// </summary>
    public partial class UserControlTopObject : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlTopObject()
        {
            InitializeComponent();
        }

        internal void Set(IDataConsumer consumer, IMeasurements mea)
        {
            int h = userControlObject.Height;
            userControlObject.SetObjects(consumer, mea);
            int dh = userControlObject.Height - h;
            panelBottom.Height += dh;
            Height += dh;
        }
    }
}
