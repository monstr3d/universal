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
                if (!image.Context.IsEmpty())
                {
                    textBoxContext.Text = image.Context;
                }
                if (!image.ContextURL.IsEmpty())
                {
                    textBoxFull.Text = image.ContextURL;
                }
                SetURL(image.ContextURL, image.Url);

            }
        }

        #region Private


        void SetURL(string full, string img)
        {
            if (!full.IsEmpty())
            {
                userControlUrlPage.Url = full;
            }
            if (!img.IsEmpty())
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
                if (textBoxFull.Text.IsEmpty())
                {
                    return;
                }
                userControlUrlPage.Url = textBoxFull.Text;
                if (textBoxContext.Text.IsEmpty())
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
                exception.ShowError(10);
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
