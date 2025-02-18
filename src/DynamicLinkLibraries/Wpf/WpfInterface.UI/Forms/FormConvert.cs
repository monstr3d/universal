using System;
using System.Windows.Forms;
using Diagram.UI.Labels;
using WpfInterface.UI.Labels;

namespace WpfInterface.UI.Forms
{
    public partial class FormConvert : Form
    {
        internal ShapeLabel Label
        {
            set;
            private get;
        }



        private FormConvert()
        {
            InitializeComponent();
        }

        internal FormConvert(ShapeLabel label) : this()
        {
            Label = label;
            INamedComponent component = label;
            Text = Text + " - " + component.Name;
            userControlConvert.Label = label;
            var c = label.ConversionData;
            if (c.Item5 == 0)
            {
                var t = new Tuple<string, string, string, bool, int, int>(c.Item1, c.Item2,
                c.Item3, c.Item4, Width, Height);
            }
            else
            {
                Width = c.Item5;
                Height = c.Item6;
            }
        }

        private void FormConvert_Resize(object sender, System.EventArgs e)
        {
            var c = Label.ConversionData;
            var t = new Tuple<string, string, string, bool, int, int>(c.Item1, c.Item2,
            c.Item3, c.Item4, Width, Height);
            Label.ConversionData = t;

        }
    }
}
