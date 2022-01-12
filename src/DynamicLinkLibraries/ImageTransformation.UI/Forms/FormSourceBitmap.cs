using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Labels;
using Diagram.UI;
using BitmapIndicator;
using Diagram.UI.Interfaces;
using BitmapConsumer;
using ImageTransformations.Labels;


namespace ImageTransformations.Forms
{
    /// <summary>
    /// Bitmap form
    /// </summary>
    public partial class FormSourceBitmap : Form, IUpdatableForm
    {
        #region Fields
        
        private IObjectLabel label;
        
        private AbstractBitmap bitmap;

        private BitmapIndicatorPerformer performer;

        private Labels.ImageProviderLabel il;


        #endregion

        #region Ctor

        private FormSourceBitmap()
        {
            InitializeComponent();
        }

        public FormSourceBitmap(IObjectLabel label)
            : this()
        {
            ResourceService.Resources.LoadControlResources(this, ImageTransformations.Utils.ControlUtilites.Resources);
            panelBmp.Top = 0;
            panelBmp.Left = 0;
            this.label = label;
            bitmap = label.Object as AbstractBitmap;
            UpdateFormUI();
            performer = BitmapIndicator.Indicators.LabelIndicator.Create(
                new Label[] { labelX, labelY }, new Label[] { labelR, labelG, labelB }, bitmap.GetBitmap(), panelBmp);
            if (bitmap is SourceImage)
            {
                openFileDialogBmp.Filter = "Image files |*.bmp;*.jpg;*.jpeg;*.gif";
            }
            if (label is ImageProviderLabel)
            {
                il = label as ImageProviderLabel;
                toolStripButtonScale.Visible = true;
                toolStripButtonScale.Checked = il.IsScaled;
            }
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

        #region Members

        void open()
        {
            if (openFileDialogBmp.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            string fn = openFileDialogBmp.FileName;
            if (bitmap is SourceBitmap)
            {
                Bitmap bmp = new Bitmap(fn);
                bitmap.SetBitmap(bmp);
                performer.Bitmap = bmp;
                Refresh();
                return;
            }
            string ext = Path.GetExtension(fn);
            Image im = Image.FromFile(fn);
            bitmap.Image = im;
            performer.Bitmap = bitmap.GetBitmap();
            Refresh();
            if (label is ImageProviderLabel)
            {
                ImageProviderLabel pl = label as ImageProviderLabel;
                pl.UpdateImage();
            }

        }

        void save()
        {
            Bitmap bmp = bitmap.GetBitmap();
            if (bmp == null)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Load bitmap");
                return;
            }
            if (saveFileDialogBmp.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            bmp.Save(saveFileDialogBmp.FileName, 
                System.Drawing.Imaging.ImageFormat.Bmp);
        }

        #endregion

        #region Event Handlers

        private void panelBmp_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = bitmap.GetBitmap();
            if (bmp == null)
            {
                return;
            }
            e.Graphics.DrawImage(bmp, 0, 0);

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            open();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            save();
        }

  
        private void toolStripButtonScale_Click(object sender, EventArgs e)
        {
            il.IsScaled = toolStripButtonScale.Checked;
        }
        
        #endregion
    }
}
