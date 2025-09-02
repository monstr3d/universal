using CutoutPro.Winforms;
using Diagram.UI;
using ErrorHandler;
using Motion6D.Interfaces;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Wpf.Loader;
using WpfInterface.Objects3D;
using WpfInterface.UI.Forms;
using WpfInterface.UI.Labels;


namespace WpfInterface.UI.UserControls
{
    public partial class UserControlShape : UserControl
    {
        #region Fields

        private WpfShape shape;

        private FormConvert formConvert = null;

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

        void Convert()
        {
            if (formConvert != null)
            {
                if (!formConvert.IsDisposed)
                {
                    formConvert.BringToFront();
                    return;
                }
            }
            var label = this.FindParent<ShapeLabel>();
            formConvert = new FormConvert(label);
            formConvert.Show(this);
        }

        void Export()
        {

        }

        internal void SaveInverted()
        {
            shape.Visual.InvertZ();
            string s = System.Windows.Markup.XamlWriter.Save(shape.Visual);
            /*    using (System.IO.TextWriter wr = new System.IO.StreamWriter(@"g:\2.xaml"))
                {
                    wr.WriteLine(s);
                }*/
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
                checkBoxLightColor.Checked = value.HasLight;
                checkBoxLightColor.CheckStateChanged += CheckBoxColored_CheckedChanged;
                SetColorPanel();
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
            shape.HasLight = checkBoxLightColor.Checked;
            if (!shape.HasLight)
            {
                SetColorPanel();
                return;
            }
            var dialog = new ArgbColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var c = dialog.Color;
                shape.LightColor = System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
            }
            SetColorPanel();
        }

        

        private void open()
        {
            try
            {
                openFileDialogFigure.Set();
                if (openFileDialogFigure.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                shape.Load(openFileDialogFigure.FileName);
            }
            catch (Exception ex)
            {
                ex.HandleException(1);
            }
        }

        private void Save(string filename)
        {
            if (shape == null)
            {
                return;
            }
            shape.Save(filename);
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

        private void toolStripButtonExport_Click(object sender, EventArgs e)
        {
            Export();
        }


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


        private void toolStripConvert_Click(object sender, EventArgs e)
        {
            Convert();
        }

        #endregion

    }
}