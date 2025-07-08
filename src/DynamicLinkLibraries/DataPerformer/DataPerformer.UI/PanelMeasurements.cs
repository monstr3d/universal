using CategoryTheory;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;
using Diagram.UI;
using Diagram.UI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace DataPerformer.UI
{
    /// <summary>
    /// Panerl which correspond to measurements
    /// </summary>
    public class PanelMeasurements : Panel
    {
        private ICollection<string> vars;

        private Dictionary<string, string> selected;

        private IAssociatedObject obj;

        private Dictionary<string, ComboBox> boxes = new Dictionary<string,ComboBox>();

        private IMeasurements measurements;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="obj">Base object</param>
        /// <param name="measurements">Measurements</param>
        /// <param name="vars">Variables</param>
        /// <param name="selected">Selected measurements</param>
        public PanelMeasurements(IAssociatedObject obj, 
            IMeasurements measurements, object vars, Dictionary<string, string> selected)
        {
            this.obj = obj;
            this.measurements = measurements;
            this.selected = selected;
            init();
            Vars = vars;
            Selected = selected;
        }


        private void init()
        {
            IDataConsumer cons = null;
            if (obj is IDataConsumer)
            {
                cons = obj as IDataConsumer;
            }
            Control panel = HeaderControl.Object.GetHeaderControl(cons, measurements);
            Controls.Add(panel);
            int y = panel.Height + 10;

            for (int i = 0; i < measurements.Count; i++)
            {
                IMeasurement measure = measurements[i];
                Label lab = new Label();
                lab.Top = y;
                lab.Left = 20;
                lab.Text = Measurement.GetTypeName(measure.Type);
                y = lab.Bottom + 10;
                Controls.Add(lab);
                ComboBox cb = new ComboBox();
                cb.Location = new System.Drawing.Point(20, y);
                cb.Size = new System.Drawing.Size(121, 21);
                Label l = new Label();
                l.Text = (string)measure.Name.Clone();
                l.Location = new System.Drawing.Point(cb.Left + cb.Width + 10, y);
                l.Width = Width - 20;
                Controls.Add(cb);
                Controls.Add(l);
                y = cb.Bottom + 5;
                string argName = obj.GetName(measurements)
                    + "." + measure.Name;
                cb.SelectCombo(argName);
                boxes[argName] = cb;
            }
            Width = 100;
            Height = y + 10;
       }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal object Vars
        {
            set
            {
                if (value is ICollection<string>)
                {
                    vars = value as ICollection<string>;
                }
                if (value is string)
                {
                    string s = value as string;
                    vars = new List<string>();
                    foreach (char c in s)
                    {
                        vars.Add(c + "");
                    }
                }
                foreach (ComboBox box in boxes.Values)
                {
                    box.Items.Clear();
                    box.FillCombo(vars);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Dictionary<string, string> Selected
        {
            get
            {
                Dictionary<string, string> vn = new Dictionary<string, string>();
                foreach (string key in boxes.Keys)
                {
                    ComboBox box = boxes[key];
                    string s = box.SelectedItem + "";
                    if (s.Length == 0)
                    {
                        continue;
                    }
                    if (vn.ContainsKey(s))
                    {
                        throw new ErrorHandler.OwnException("Measurement \"" + s + "\" already exists");
                    }
                    vn[s] = key;
                }
                return vn;
            }
            set
            {
                foreach (string key in value.Keys)
                {
                    string val = value[key];
                    if (!boxes.ContainsKey(val))
                    {
                        continue;
                    }
                    ComboBox box = boxes[value[key]];
                    box.SelectCombo(key);
                }
            }
        }
    }
}
