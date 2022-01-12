using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

namespace ImageTransformations.Forms
{
    public partial class FormCtxExternalImage : Form, IUpdatableForm
    {
        #region Fields

        private IObjectLabel label;

        

        #endregion

        #region Ctor

        public FormCtxExternalImage(IObjectLabel label)
            : this()
        {
            this.label = label;
            userControlContextImage.Image = label.Object as ExternalContextImage;
            UpdateFormUI();
        }

  
        private FormCtxExternalImage()
        {
            InitializeComponent();
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
