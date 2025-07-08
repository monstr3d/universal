using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Utils;

using DataPerformer.Helpers;
using DataPerformer.Interfaces;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Editor of properties of measure of collection variables
    /// </summary>
    public partial class UserControlComponentCollectionVariablesMeasure : UserControl
    {

        #region Fields

        DataPerformerCollectionStateTransformer transformer;

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlComponentCollectionVariablesMeasure()
        {
            InitializeComponent();
        }

        #endregion


        #region Members

        /// <summary>
        /// Transformer
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataPerformerCollectionStateTransformer Transformer
        {
            get
            {
                return transformer;
            }
            set
            {
                transformer = value;
                userControlComponentCollectionVariables.Collection = value;
                IEnumerable<string> l = transformer.GetAllNames<IMeasurements>();
                comboBox.FillCombo(l);
                comboBox.SelectCombo(transformer.Measurements);
            }
        }

        #endregion

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            object o = comboBox.SelectedItem;
            if (o == null)
            {
                return;
            }
            transformer.Measurements = o + "";
        }
    }
}
