using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using ErrorHandler;

namespace ImageNavigation.Forms
{
    public partial class FormBitmapSelection : Form, IUpdatableForm
    {
        private IObjectLabel label;
        private BitmapSelection selection;

        private Bitmap bmp;

        
        private FormBitmapSelection()
        {
            InitializeComponent();
        }

        public FormBitmapSelection(IObjectLabel label)
            : this()
        {
            ResourceService.Resources.LoadControlResources(this, ImageNavigation.Utils.ControlUtilites.Resources);
            this.label = label;
            UpdateFormUI();
            selection = label.Object as BitmapSelection;
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


        new internal void Update()
        {
            refreshImage();
        }

        private void panelImage_Paint(object sender, PaintEventArgs e)
        {
            if (bmp == null)
            {
                return;
            }
            e.Graphics.DrawImage(bmp, 0, 0);

        }



        private void refreshImage()
        {
            bmp = selection.EdgeBitmap;
            Refresh();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            refreshImage();
        }

        void open()
        {
            try
            {
                if (openFileDialogBitmap.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                Bitmap bmp = new Bitmap(openFileDialogBitmap.FileName);
                selection.Bitmap = bmp;
                refreshImage();
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
                Diagram.UI.Utils.ControlUtilites.ShowError(this, ex, ImageNavigation.Utils.ControlUtilites.Resources);
            }
        }

        void save()
        {
            Bitmap bmp = selection.Bitmap;
            if (bmp == null)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Bitmap do not exist");
                return;
            }
            if (saveFileDialogBitmap.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            bmp.Save(saveFileDialogBitmap.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            open();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            save();
        }

    }
}