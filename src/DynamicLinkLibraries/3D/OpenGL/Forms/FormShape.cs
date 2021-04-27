using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using Motion6D;
using Motion6D.Interfaces;

namespace InterfaceOpenGL.Forms
{
    public partial class FormShape : Form, IUpdatableForm 
    {

        private ShapeGL shape;
        private IPosition position;


        private FormShape()
        {
            InitializeComponent();
           // toolStripButtonFilename.
        }

        internal FormShape(IPosition position, ShapeGL shape)
            : this()
        {
            ResourceService.Resources.LoadControlResources(this, InterfaceOpenGL.Utils.ControlUtilites.Resources);
            this.shape = shape;
            this.position = position;
            UpdateFormUI();
            showFilename();
        }

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            if (!(position is IAssociatedObject))
            {
                return;
            }
            IAssociatedObject ao = position as IAssociatedObject;
            object o = ao.Object;
            if (o == null)
            {
                return;
            }
            if (!(o is INamedComponent))
            {
                return;
            }
            INamedComponent nc = o as INamedComponent;
            Text = nc.Name;
        }

        #endregion

        #region Specific Members
        
        private void showFilename()
        {
            labelFilename.Text = shape.Filename;
        }

        private void open()
        {
            try
            {
                openFileDialogFigure.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Shapes";
                if (openFileDialogFigure.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                string fn = Path.GetFileName(openFileDialogFigure.FileName);
                shape.Filename = fn;
                showFilename();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            open();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}