using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


using Diagram.UI;
using Motion6D.Interfaces;

using WpfInterface.Objects3D;

namespace WpfInterface.UI.UserControls
{
    public partial class UserControlShape : UserControl
    {
        #region Fields
        private WpfShape shape;

        //private Motion6D.UI.FormFieldShape form;

        #endregion

        #region Ctor


        public UserControlShape()
        {
            InitializeComponent();
            openFileDialogFigure.Set();
        }

        #endregion

        #region Specific Members

        internal void SaveInverted()
        {
            shape.PublicVisual.InvertZ();
            string s = System.Windows.Markup.XamlWriter.Save(shape.PublicVisual);
            using (System.IO.TextWriter wr = new System.IO.StreamWriter(@"g:\2.xaml"))
            {
                wr.WriteLine(s);
            }
        }

        public WpfShape Shape
        {
            get
            {
                return shape;
            }
            set
            {
                shape = value;
                checkBoxScaled.Checked = value.IsScaled;
                showFilename();
            }
        }

        private void open()
        {
            try
            {
                if (openFileDialogFigure.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                shape.Load(openFileDialogFigure.FileName);
            }
            catch (Exception ex)
            {
                ex.ShowError(1);
            }
        }

        private void Save(string filename)
        {
            if (shape == null)
            {
                return;
            }
            string s = shape.Xaml;
            using (TextWriter w = new StreamWriter(filename))
            {
                w.Write(s);
            }
        }

        private void Save()
        {
            if (shape == null)
            {
                return;
            }
            if (saveFileDialogFigure.ShowDialog(this) == DialogResult.OK)
            {
                Save(saveFileDialogFigure.FileName);
            }
        }


        private void showFilename()
        {
            IFacet f = shape;
            checkBoxColored.Checked = f.IsColored;
            checkBoxScaled.CheckedChanged += checkBoxScaled_CheckedChanged;

        }

        #endregion

        #region Event Handlers

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            open();
        }


        private void checkBoxColored_CheckedChanged(object sender, EventArgs e)
        {
            IFacet f = shape;
            f.IsColored = checkBoxColored.Checked;
        }

        private void checkBoxScaled_CheckedChanged(object sender, EventArgs e)
        {
            shape.IsScaled = checkBoxScaled.Checked;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            //!!!!! TEMPORARY USAGE ============
            SaveInverted();
            //!!!!! TEMPORARY USAGE ============
        }

        #endregion
    }
}