using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Interfaces;


namespace Celestrak.NORAD.Satellites.UI.Forms
{
    public partial class FormNORADChild : Form, IUpdatableForm
    {

        #region Fields

        SatelliteData satellite;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        private FormNORADChild()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="satellite">Satellite</param>
        public FormNORADChild(SatelliteData satellite)
            : this()
        {
            this.satellite = satellite;
            userControlChild.Satellite = satellite;
            UpdateFormUI();
            FormClosed += (object s, FormClosedEventArgs e) =>
            {
                userControlChild.Delete();
            };
        }

        #endregion

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = satellite.GetName();
        }

        #endregion
    }
}
