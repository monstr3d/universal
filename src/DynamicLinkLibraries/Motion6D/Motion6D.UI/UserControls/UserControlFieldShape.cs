using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using DataPerformer.Portable.Measurements;
using DataPerformer.Portable;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;

using PhysicalField.Interfaces;

using ErrorHandler;

namespace Motion6D.UI.UserControls
{
    /// <summary>
    /// User control for field shape
    /// </summary>
    public partial class UserControlFieldShape : UserControl
    {

        #region Fields

        private FieldConsumer3D consumer;
        private List<ComboBox> outcoming = new List<ComboBox>();
        private IFacet facet;
        private List<ComboBox> facetCombo = new List<ComboBox>();
        private List<List<ComboBox>> fieldCombo = new List<List<ComboBox>>();
        private IBoxArray ba;
        private Control pb;

        private IObjectLabel label;

        private event Action close = () => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Default construtor
        /// </summary>
        public UserControlFieldShape()
        {
            InitializeComponent();
            pb = panelColor;

        }

        #endregion

        #region Public Members

        /// <summary>
        /// Label
        /// </summary>
        public IObjectLabel Label
        {
            get
            {
                return label;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                label = value;
                consumer = label.Object.GetObject<FieldConsumer3D>();
                facet = consumer.Facet;
                IAssociatedObject ao = consumer as IAssociatedObject;
                setFilename();
                numericUpDownDerived.Value = consumer.Outcoming.Count;
                fillField();
                checkBoxC.Checked = consumer.Colored;
                change();
                checkBoxProp.Checked = consumer.Proportional;
                checkBoxRainbow.Checked = consumer.RainbowScale;
                Motion6D.Interfaces.ILinear6DForecast forecast = 
                    label.Object.GetObject<Motion6D.Interfaces.ILinear6DForecast>();
                if (forecast == null)
                {
                    tabControlMain.TabPages.Remove(tabPageLinearForecast);
                }
                else
                {
                    userControlLinerar6DForecast.Forecast = forecast;
                }
                selectColor();
            }
        }

        /// <summary>
        /// Close event
        /// </summary>
        public event Action Close
        {
            add
            {
                close += value;
            }
            remove
            {
                close -= value;
            }
        }
        #endregion

        #region Private Members

        void fillField()
        {
            Panel p = panelFieldParameters;
            p.Controls.Clear();
            fieldCombo.Clear();
            IFieldConsumer cons = consumer;
            int y = 0;
            for (int i = 0; i < cons.Count; i++)
            {
                IPhysicalField ph = cons[i];
                Control h = DataPerformer.UI.HeaderControl.GetHeaderControl(consumer as IAssociatedObject, ph as IAssociatedObject);
                h.Left = 0;
                h.Top = y;
                p.Controls.Add(h);
                y = h.Bottom;
                List<ComboBox> lb = new List<ComboBox>();
                fieldCombo.Add(lb);
                for (int j = 0; j < ph.Count; j++)
                {
                    object t = ph.GetType(j);
                    string tn = " (" + Measurement.GetTypeName(t) + ")";
                    Label l = new Label();
                    l.Text = ResourceService.Resources.GetControlResource("Parameter", Motion6D.UI.Utils.ControlUtilites.Resources) + " " + (j + 1) + tn;
                    l.Left = 10;
                    l.Top = y;
                    l.Width = 400;
                    p.Controls.Add(l);
                    ComboBox cb = new ComboBox();
                    lb.Add(cb);
                    cb.Top = l.Bottom + 5;
                    cb.Left = l.Left + 50;
                    cb.Width = p.Width - cb.Left - 20;
                    p.Controls.Add(cb);
                    IList<string> list = consumer.GetAliases(t);
                    cb.FillCombo(list);
                    y = cb.Bottom + 5;
                }
                Panel sep = new Panel();
                sep.Width = p.Width - 20;
                sep.BackColor = Color.Black;
                sep.Height = 3;
                sep.Top = y;
                p.Controls.Add(sep);
                y = sep.Bottom;
            }
            selectField();
        }

        void selectField()
        {
            Dictionary<string, Dictionary<int, string>> ext = consumer.ExtAliases;
            IFieldConsumer c = consumer;
            for (int i = 0; i < fieldCombo.Count; i++)
            {
                IPhysicalField ph = c[i];
                string fn = consumer.GetRelativeName(ph as IAssociatedObject);
                if (!ext.ContainsKey(fn))
                {
                    continue;
                }
                Dictionary<int, string> d = ext[fn];
                List<ComboBox> lb = fieldCombo[i];
                for (int j = 0; j < ph.Count; j++)
                {
                    if (!d.ContainsKey(j))
                    {
                        continue;
                    }
                    string s = d[j];
                    ComboBox b = lb[j];
                    b.SelectCombo(s);
                }
            }
        }


        void setField()
        {
            Dictionary<string, Dictionary<int, string>> ext = consumer.ExtAliases;
            ext.Clear();
            IFieldConsumer c = consumer;
            for (int i = 0; i < fieldCombo.Count; i++)
            {
                IPhysicalField ph = c[i];
                string fn = consumer.GetRelativeName(ph as IAssociatedObject);
                Dictionary<int, string> d = null;
                List<ComboBox> lb = fieldCombo[i];
                for (int j = 0; j < ph.Count; j++)
                {
                    ComboBox cb = lb[j];
                    object it = cb.SelectedItem;
                    if (it == null)
                    {
                        continue;
                    }
                    if (d == null)
                    {
                        d = new Dictionary<int, string>();
                        ext[fn] = d;
                    }
                    d[j] = it + "";
                }
            }
        }

        void setOutNumber()
        {
            Panel p = panelDerivedParameters;
            p.Controls.Clear();
            List<string> outc = consumer.Outcoming;
            outcoming.Clear();
            int n = (int)numericUpDownDerived.Value;
            int y = 20;
            for (int i = 0; i < n; i++)
            {
                Label l = new Label();
                l.Text = ResourceService.Resources.GetControlResource("Parameter", Motion6D.UI.Utils.ControlUtilites.Resources) + " " + (i + 1);
                l.Left = 10;
                l.Top = y;
                p.Controls.Add(l);
                ComboBox cb = new ComboBox();
                outcoming.Add(cb);
                cb.Top = l.Top;
                cb.Left = l.Right + 50;
                cb.Width = p.Width - cb.Left - 20;
                p.Controls.Add(cb);
                y = cb.Bottom + 5;
            }
            fillOut();
            selectOut(outc);
        }

        void selectColor()
        {
            ComboBox[] cb = ba.Boxes;
            List<string> l = consumer.Colors;
            for (int i = 0; i < cb.Length; i++)
            {
                if (i >= l.Count)
                {
                    break;
                }
                cb[i].SelectCombo(l[i]);
            }
        }


        void fillOut()
        {
            IDataConsumer dc = consumer;
            List<string> l = dc.GetAllMeasurements(null);
            outcoming.FillCombo(l);
        }

        void selectOut(List<string> l)
        {
            for (int i = 0; i < outcoming.Count; i++)
            {
                if (i >= l.Count)
                {
                    break;
                }
                string s = l[i];
                outcoming[i].SelectCombo(s);
            }
        }

        void setFilename()
        {
            if (consumer.Facet.Id == null)
            {
                return;
            }
            labelFilename.Text = consumer.Facet.Id;
            setFacet();
        }

        string filename
        {
            set
            {
                if (consumer.Facet.Id == null)
                {
                    return;
                }
                consumer.Facet.Id = value;
                setFilename();
            }
        }

        void open()
        {
            if (openFileDialogFieldFigure.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            try
            {
                filename = openFileDialogFieldFigure.FileName; // Path.GetFileName(openFileDialogFieldFigure.FileName);
            }
            catch (Exception e)
            {
                e.HandleException(10);
                
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message, ResourceService.Resources.GetControlResource("Error", Motion6D.UI.Utils.ControlUtilites.Resources));
            }
        }

        void setOut()
        {
            List<string> l = new List<string>();
            int i = 1;
            foreach (ComboBox cb in outcoming)
            {
                object it = cb.SelectedItem;
                if (it == null)
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ResourceService.Resources.GetControlResource("Undefined parameter", Motion6D.UI.Utils.ControlUtilites.Resources) + " " + i);
                    return;
                }
                string s = it + "";
                if (l.Contains(s))
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ResourceService.Resources.GetControlResource("Parameter", Motion6D.UI.Utils.ControlUtilites.Resources) + " " + s + " " +
                        ResourceService.Resources.GetControlResource("is already defined", Motion6D.UI.Utils.ControlUtilites.Resources));
                    return;
                }
                ++i;
                l.Add(s);
            }
            consumer.Outcoming.Clear();
            consumer.Outcoming.AddRange(l);
        }

        void setFacet()
        {
            int n = facet.ParametersCount;
            Panel p = panelMaterialParameters;
            p.Controls.Clear();
            facetCombo.Clear();
            int y = 20;
            for (int i = 0; i < n; i++)
            {
                Label l = new Label();
                object type = facet.GetType(i);
                string tn = " (" + Measurement.GetTypeName(type) + ")";
                l.Text = ResourceService.Resources.GetControlResource("Parameter", Motion6D.UI.Utils.ControlUtilites.Resources) + " " + (i + 1) + tn;
                l.Left = 10;
                l.Top = y;
                l.Width = 400;
                p.Controls.Add(l);
                ComboBox cb = new ComboBox();
                facetCombo.Add(cb);
                cb.Top = l.Bottom + 5;
                cb.Left = l.Left + 50;
                cb.Width = p.Width - cb.Left - 20;
                p.Controls.Add(cb);
                IList<string> list = consumer.GetAliases(type);
                cb.FillCombo(list);
                y = cb.Bottom + 5;
            }
            fillFacet();
        }

        void fillFacet()
        {
            if (consumer.IntAliases == null)
            {
                return;
            }
            for (int i = 0; i < facetCombo.Count; i++)
            {
                if (consumer.IntAliases.ContainsKey(i))
                {
                    facetCombo[i].SelectCombo(consumer.IntAliases[i]);
                }
            }
        }

        void setMatAliases()
        {
            int n = facet.ParametersCount;
            Panel p = panelMaterialParameters;
            consumer.IntAliases.Clear();
            for (int i = 0; i < n; i++)
            {
                ComboBox cb = facetCombo[i];
                object it = cb.SelectedItem;
                if (it != null)
                {
                    consumer.IntAliases[i] = it + "";
                }
            }
        }

        void apply()
        {
            try
            {
                setOut();
                setField();
                setMatAliases();
                acceptColors();
                IPostSetArrow p = consumer;
                p.PostSetArrow();
            }
            catch (Exception e)
            {
                e.HandleException(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }

        }

        bool correspond
        {
            get
            {
                return ((consumer.Colored & ba is ColorUI.ColoredChooser) |
                    (!consumer.Colored & ba is ColorUI.SimpleIntesity));
            }
        }


        void change()
        {
            if (ba == null)
            {
                setColorBox();
                return;
            }
            if (correspond)
            {
                return;
            }
            Control c = ba as Control;
            pb.Controls.Remove(c);
            setColorBox();
        }

        void setColorBox()
        {
            if (consumer.Colored)
            {
                ba = new ColorUI.ColoredChooser();
            }
            else
            {
                ba = new ColorUI.SimpleIntesity();
            }
            Control c = ba as Control;
            c.Left = 0;
            c.Top = 0;
            pb.Controls.Add(c);
            fillColors();
        }

        void fillColors()
        {
            Double a = 0;
            IList<string> c = consumer.GetAllMeasurementsType(a);
            ba.FillCombo(c);
        }


        void acceptColors()
        {
            consumer.Colors.Clear();
            IList<string> l = ba.GetSelected();
            if (l.Count == 0)
            {
                return;
            }
            if (l.Count != ba.Boxes.Length)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Undefined colors");
            }
            foreach (string s in l)
            {
                consumer.Colors.Add(s);
            }
        }

        #endregion

        #region Event Handlers

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
            close();
        }

        private void numericUpDownDerived_ValueChanged(object sender, EventArgs e)
        {
            setOutNumber();
        }



        private void buttonApply_Click(object sender, EventArgs e)
        {
            apply();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            IFieldConsumer c = consumer;
            c.Consume();
            IDesktop r = label.Root.Desktop;
            if (r is PanelDesktop)
            {
                PanelDesktop d = r as PanelDesktop;
                d.Refresh();
            }
        }

        private void checkBoxC_CheckedChanged(object sender, EventArgs e)
        {
            consumer.Colored = checkBoxC.Checked;
            change();
        }

        private void checkBoxProp_CheckedChanged(object sender, EventArgs e)
        {
            consumer.Proportional = checkBoxProp.Checked;
        }

        private void checkBoxRainbow_CheckedChanged(object sender, EventArgs e)
        {
            consumer.RainbowScale = checkBoxRainbow.Checked;
        }


        #endregion
    }
}
