using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Abstract3DConverters;
using Diagram.UI.UserControls;
using Microsoft.Win32;
using WpfInterface.UI.Labels;

namespace WpfInterface.UI.UserControls
{
    public partial class UserControlConvert : UserControl
    {
        Dictionary<string, RadioButton> buttons = new();

        Performer p = new();

        RadioButton current;

        private ShapeLabel label;
        internal ShapeLabel Label
        {
            set
            {
                label = value;
                SetControls();
            }
            get => label;
        }

        public UserControlConvert()
        {
            InitializeComponent();
            openFileDialogInput.Set();

        }

        void SetControls()
        {
            var f = Abstract3DConverters.StaticExtensionAbstract3DConverters.FileTypes;
            int left = 10;
            int top = 10;
            int step = 25;
            foreach (var item in f)
            {
                var rb = new RadioButton();
                rb.Text = item.Key;
                rb.Left = left;
                rb.Top = top;
                panelRadio.Controls.Add(rb);
                top += step;
                rb.Tag = item.Value;
                buttons[item.Key] = rb;
                if (item.Key == label.ConversionData.Item1)
                {
                    rb.Checked = true;
                    current = rb;
                }
                rb.CheckedChanged += Rb_CheckedChanged;
                
            }
            textFile.Text = label.ConversionData.Item2;
            textDir.Text = label.ConversionData.Item3;
        }

        private void Rb_CheckedChanged(object? sender, EventArgs e)
        {
            current = sender as RadioButton;
            var c = label.ConversionData;
            var t = new Tuple<string, string, string, bool, int, int>(current.Text, c.Item2, c.Item3, c.Item4, c.Item5, c.Item6);
            label.ConversionData = t;

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Execute();
        }

        private void btnFile_Click(object sender, System.EventArgs e)
        {
            if (openFileDialogInput.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            var file = openFileDialogInput.FileName;
            textFile.Text = file;
            var c = label.ConversionData;
            var t = new Tuple<string, string, string, bool, int, int>(c.Item1, file, c.Item3, c.Item4, c.Item5, c.Item6);
            label.ConversionData = t;
        }


        private void btnDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog(this)!= DialogResult.OK)
            {
                return;
            }
            var dir  = folderBrowserDialog.SelectedPath;
            textDir.Text = dir;
            var c = label.ConversionData;
            var t = new Tuple<string, string, string, bool, int, int>(c.Item1, c.Item2, 
                dir, c.Item4, c.Item5, c.Item6);
            label.ConversionData = t;
        }

 
        void Execute()
        {
            var dir = textDir.Text;
            
            if (!Directory.Exists(dir))
            {
                return;
            }
            var file = textFile.Text;
            if (!File.Exists(file))
            {
                return;
            }
            if (current == null)
            {
                return;
            }
            var filename =  p.CreateAndSaveByUniqueName(file, current.Text, dir);
            label.LoadFile(filename);
        }
    }
}
