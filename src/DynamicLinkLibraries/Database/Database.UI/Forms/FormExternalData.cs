using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using DataSetService;


namespace Database.UI.Forms
{
    public partial class FormExternalData : Form, IUpdatableForm
    {
        #region Fields

        IObjectLabel label;

        #endregion

        #region Ctor

        public FormExternalData()
        {
            InitializeComponent();
        }


        internal FormExternalData(IObjectLabel label, Control control)
            : this()
        {
            this.label = label;
            UpdateFormUI();
            data.Provider = label.Object as IDataSetProvider;
            data.Add(control);
        }

        #endregion

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion
    }
}
