using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI.Labels;
using Diagram.UI;
using BitmapIndicator;
using Diagram.UI.Interfaces;
using System.IO;
using ImageTransformations.Labels;

namespace ImageTransformations.Forms
{
    public partial class FormWebImage : Form, IUpdatableForm
    {


        #region Fields

        private IObjectLabel label;

 
   //     private BitmapIndicatorPerformer performer;

        private ExternalImage ei;


        #endregion
        
        private FormWebImage() 
        {
            InitializeComponent();

        }

        public FormWebImage(IObjectLabel label)
            : this()
        {
            ResourceService.Resources.LoadControlResources(this, ImageTransformations.Utils.ControlUtilites.Resources);
            this.label = label;
            ei = label.Object as ExternalImage;
            userControlWebImage.Url = ei.Url;
            UpdateFormUI();
            
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

        private void userControlWebImage_SetUrl(string obj)
        {
            try
            {
                ei.Url = userControlWebImage.Url;
                if (label is WebProviderLabel)
                {
                    WebProviderLabel l = label as WebProviderLabel;
                    l.UpdateImage();
                }
            }
            catch (Exception ex)
            {
                labelStatus.Text = ex.Message;
            }
        }
    }
}
