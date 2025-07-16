using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;
using ErrorHandler;

namespace ImageTransformations.UserControls
{
    /// <summary>
    /// User control for context image
    /// </summary>
    public partial class UserControlContextImage : UserControl
    {
        #region Fields

        ExternalContextImage image;

        #endregion


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlContextImage()
        {
            InitializeComponent();
        }


        #endregion

        /// <summary>
        /// Image
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExternalContextImage Image
        {
            get
            {
                return image;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                image = value;
                if (!string.IsNullOrEmpty(image.Context))
                {
                    textBoxContext.Text = image.Context;
                }
                if (!string.IsNullOrEmpty(image.ContextURL))
                {
                    textBoxFull.Text = image.ContextURL;
                }
                SetURL(image.ContextURL, image.Url);

            }
        }

        #region Private


        void SetURL(string full, string img)
        {
            if (!string.IsNullOrEmpty(full))
            {
                userControlUrlPage.Url = full;
            }
            if (!string.IsNullOrEmpty(img))
            {
                userControlUrlCtx.Url = img;
            }
        }

        void UpdateUI()
        {
            string ctx = image.Context;
            string ctxURL = image.ContextURL;
            try
            {
                if (string.IsNullOrEmpty(textBoxFull.Text))
                {
                    return;
                }
                userControlUrlPage.Url = textBoxFull.Text;
                if (string.IsNullOrEmpty(textBoxContext.Text))
                {
                    return;
                }
                image.ContextURL = textBoxFull.Text;
                image.Context = textBoxContext.Text;
                userControlUrlCtx.Url = image.Url;
                return;
            }
            catch (Exception exception)
            {
                exception.HandleException(10);
            }
            image.Context = ctx;
            image.ContextURL = ctxURL;
        }

        #endregion

        #region Event Handlers

        private new void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateUI();
            }

        }

        #endregion


    }
}
