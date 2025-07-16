using CategoryTheory;
using DataPerformer;
using DataPerformer.Interfaces;
using NamedTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataPerformer.UI
{
    internal class PanelConsumer : Panel
    {

        private Dictionary<string, string> selected;

        private IAssociatedObject obj;

        object vars;


        private IDataConsumer consumer;

        internal PanelConsumer(IDataConsumer consumer, Dictionary<string, string> selected, object vars)
        {
            this.consumer = consumer;
            obj = consumer as IAssociatedObject;
            this.selected = selected;
            this.vars = vars;
            Init();
        }

        internal void Init()
        {
            int y = 0;
            Controls.Clear();
            for (int i = 0; i < consumer.Count; i++)
            {
                IMeasurements m = consumer[i];
                Panel p = new PanelMeasurements(obj, m, vars, selected);
                p.Top = y;
                p.Width = Width;
                Controls.Add(p);
                y = p.Bottom;
                p = new Panel();
                p.BackColor = Color.Black;
                p.Top = y;
                p.Height = 3;
                Controls.Add(p);
                y = p.Bottom;
            }
            Height = y;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal object Vars
        {
            set
            {
                foreach (Control c in Controls)
                {
                    if (!(c is PanelMeasurements))
                    {
                        continue;
                    }
                    PanelMeasurements p = c as PanelMeasurements;
                    p.Vars = value;
                }
            }
        }

        internal Dictionary<string, string> Selected
        {
            get
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                foreach (Control c in Controls)
                {
                    if (!(c is PanelMeasurements))
                    {
                        continue;
                    }
                    PanelMeasurements p = c as PanelMeasurements;
                    Dictionary<string, string> dic = p.Selected;
                    foreach (string key in dic.Keys)
                    {
                        if (d.ContainsKey(key))
                        {
                            throw new ErrorHandler.OwnException("Measurement \"" + key + "\" already exists");
                        }
                        d[key] = dic[key];
                    }
                }
                return d;
            }
        }
    }
}
