using System;
using System.Windows.Forms;
using System.IO;


using Diagram.UI;

using Motion6D.Interfaces;

using WpfInterface.Objects3D;

using Wpf.Loader;

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
            shape.Visual.InvertZ();
            string s = System.Windows.Markup.XamlWriter.Save(shape.Visual);
        /*    using (System.IO.TextWriter wr = new System.IO.StreamWriter(@"g:\2.xaml"))
            {
                wr.WriteLine(s);
            }*/
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
                checkBoxColored.Checked = value.HasLight;
                checkBoxColored.CheckedChanged += CheckBoxColored_CheckedChanged;
                
            }
        }

        void SetColorPanel()
        {
            if (!shape.HasLight)
            {
                panelColor.Visible = false;
                return;
            }
            panelColor.Visible = true;
            var c = shape.LightColor;
            panelColor.BackColor = System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);
        }

        private void CheckBoxColored_CheckedChanged(object? sender, EventArgs e)
        {
            shape.HasLight = checkBoxColored.Checked;
            if (!shape.HasLight)
            {
                SetColorPanel();
                return;
            }
            var res = colorDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                var c = colorDialog.Color;
                shape.LightColor = System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
            }
            SetColorPanel();
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
            var s = shape.Xaml;
            using (var w = new StreamWriter(filename))
            {
                w.Write(s);
            }
            var path = Path.GetDirectoryName(filename);
            shape.SaveTextures(path);
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