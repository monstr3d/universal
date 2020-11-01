using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DataPerformer;
using CategoryTheory;
using Diagram.UI.Labels;
using DataPerformer.Interfaces;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control for alias for regression
    /// </summary>
	public partial class RegessionAliasMeasureUserControl : UserControl
	{
		private IMeasurements meas;
		private ArrayList num = new ArrayList();

        private RegessionAliasMeasureUserControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cons">Data consumer</param>
        /// <param name="meas">Measurements</param>
        public RegessionAliasMeasureUserControl(IDataConsumer cons, 
            IMeasurements meas) : this()
		{
			this.meas = meas;
			Control panel = HeaderControl.Object.GetHeaderControl(cons, meas);
			panel.Top = 0;
			panel.Left = 0;
			Controls.Add(panel);
			int y = panel.Height + 10;
			for (int i = 0; i < meas.Count; i++)
			{
				
				IMeasurement m = meas[i];
				Label l = new Label();
				l.Text = m.Name;
				l.Top = y;
				l.Left = 10;
				Controls.Add(l);
				y = l.Top + l.Height + 5;
				NumericUpDown n = new NumericUpDown();
				n.Minimum = -1;
				n.Value = -1;
				n.Left = 10;
				n.Top = y;
				y += n.Height + 20;
				Controls.Add(n);
				num.Add(n);
			}
			Height = y;
		}

        /// <summary>
        /// Table of measurements
        /// </summary>
		public Hashtable Table
		{
			get
			{
				Hashtable t = new Hashtable(); 
				IAssociatedObject ao = meas as IAssociatedObject;
				INamedComponent nc = ao.Object as INamedComponent;
				string name = nc.Name;
				for (int i = 0; i < meas.Count; i++)
				{
					NumericUpDown n = num[i] as NumericUpDown;
					n.Minimum = -1;
					int no = (int) n.Value;
					if (no < 0)
					{
						continue;
					}
					t[no] = name + "." + meas[i].Name;
				}
				return t;
			}
			set
			{
				IAssociatedObject ao = meas as IAssociatedObject;
				INamedComponent nc = ao.Object as INamedComponent;
				string name = nc.Name;
				for (int i = 0; i < value.Count; i++)
				{
					string s = value[i] as string;
					int np = s.LastIndexOf(".");
					if (!name.Equals(s.Substring(0, np)))
					{
						continue;
					}
					string suffix = s.Substring(np + 1);
					for (int j = 0; j < meas.Count; j++)
					{
						if (meas[j].Name.Equals(suffix))
						{
							NumericUpDown n = num[j] as NumericUpDown;
							n.Value = i;
							break;
						}
					}
				}
			}
		}

	}
}
