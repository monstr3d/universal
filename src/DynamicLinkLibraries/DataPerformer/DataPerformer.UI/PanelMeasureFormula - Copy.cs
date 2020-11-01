using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows.Forms;

using Diagram.UI.Utils;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;


namespace DataPerformer.UI
{
	/// <summary>
	/// Panel of formula consumer
	/// </summary>
	public class PanelMeasureFormula : Panel
    {

        #region Field

        /// <summary>
		/// The input data
		/// </summary>
		protected IMeasurements measurements;

		/// <summary>
		/// Controls of measurements
		/// </summary>
		protected ArrayList measurementControls;

		/// <summary>
		/// The name of panel
		/// </summary>
		private string panelName;

		/// <summary>
		/// Variables of formula
		/// </summary>
		private string variables;

		/// <summary>
		/// The consumer that corresponds to this panel
		/// </summary>
		private IDataConsumer consumer;

        /// <summary>
        /// Extended labels
        /// </summary>
        private List<Label> extended = new List<Label>();

        #endregion


        #region Ctor

        /// <summary>
		/// Constructor
		/// </summary>
        /// <param name="measurements">The measurements that corresponds to this panel</param>
		/// <param name="variables">Variables of formula</param>
		/// <param name="consumer">The consumer that corresponds to this panel</param>
		public PanelMeasureFormula(IMeasurements measurements, string variables, IDataConsumer consumer)
		{
			//this.arrow = arrow;
            this.measurements = measurements;
			this.Width = 300;
			this.variables = variables;
			this.consumer = consumer;
			initialize();
            Resize += ResizePanel;
		}


        #endregion

        #region Public Members

        /// <summary>
		/// Name of panel
		/// </summary>
		public string PanelName
		{
			get
			{
				return panelName;
			}
		}

		/// <summary>
		/// Adds argument labels to list
		/// </summary>
		/// <param name="list">The list to add</param>
		public void AddArgumentLabels(List<string> list)
		{
			foreach (object[] o in measurementControls)
			{
				ComboBox cb = o[0] as ComboBox;
				object ob = cb.SelectedItem;
				if (ob == null)
				{
					continue;
				}
				string sn = cb.SelectedItem.ToString();
				if (sn.Length == 0)
				{
					continue;
				}
				IMeasurement m = o[1] as IMeasurement;
				string sm = m.Name;
				list.Add(sn + " = " + consumer.GetMeasurementsName(measurements) + "." + sm);
			}
		}

		/// <summary>
		/// Creates arguments to dynamical parameter
		/// </summary>
		/// <param name="par">The dynamical parameter</param>
		public void CreateArguments(DynamicalParameter par)
		{
			foreach (object[] o in measurementControls)
			{
				ComboBox cb = o[0] as ComboBox;
				object ob = cb.SelectedItem;
				if (ob == null)
				{
					continue;
				}
				string sn = ob.ToString();
				if (sn.Length == 0)
				{
					continue;
				}
				IMeasurement m = o[1] as IMeasurement;
				par.Add(sn[0], m);
			}
		}

		/// <summary>
		/// Creates arguments and writes them to list
		/// </summary>
		/// <param name="list">The list to write</param>
		public void CreateArguments(ArrayList list)
		{
			foreach (object[] o in measurementControls)
			{
				ComboBox cb = o[0] as ComboBox;
				object ob = cb.SelectedItem;
				if (ob == null)
				{
					continue;
				}
				string sn = ob.ToString();
				if (sn.Length == 0)
				{
					continue;
				}
				IMeasurement m = o[1] as IMeasurement;
                string s = sn[0] + " = " +
                    consumer.GetMeasurementsName(measurements)
					+ "." + m.Name;
				list.Add(s);
			}
		}

		/// <summary>
		/// Fills parameters comboboxes
		/// </summary>
		/// <param name="str">String of parameters</param>
		public void FillComboboxes(string str)
		{
			foreach (object[] o in measurementControls)
			{
				ComboBox cb = o[0] as ComboBox;
                cb.FillCombo(str);
			}
		}

		/// <summary>
		/// Resets comboboxes
		/// </summary>
		public void ResetCombo()
		{
			foreach (object[] o in measurementControls)
			{
				ComboBox cb = o[0] as ComboBox;
                cb.ClearItems();
			}

		}

        #endregion


        #region Private Members


        /// <summary>
		/// Initialization
		/// </summary>
		private void initialize()
		{
//			measurements = arrow.Measurements;
			Control panel = HeaderControl.Object.GetHeaderControl(consumer, measurements);
			panelName = panel.Name;
			Controls.Add(panel);
			measurementControls = new ArrayList();
			int y = panel.Height + 10;
			ICollection arguments = null;
			if (consumer is IArguments)
			{
				IArguments arg = consumer as IArguments;
				arguments = arg.Arguments;
			}
			else
			{
			/*	if (consumer is FormulaDataConsumer)
				{
					arguments = ((FormulaDataConsumer)consumer).Arguments;
				}*/
				if (consumer is DifferentialEquationSolver)
				{
					arguments = ((DifferentialEquationSolver)consumer).Arguments;
				}
				if (consumer is  VectorFormulaConsumer)
				{
					arguments = ((VectorFormulaConsumer)consumer).Arguments;
				}
			/*	if (consumer is TwoParameterTable)
				{
					arguments = ((TwoParameterTable)consumer).Arguments;
				}*/
			/*	if (consumer is FourierSeries)
				{
					arguments = new ArrayList();
					(arguments as ArrayList).Add(((FourierSeries)consumer).Argument);
				}*/
				/*
				if (consumer is SpatialUI.MassCenterDriver)
				{
					arguments = ((SpatialUI.MassCenterDriver)consumer).Arguments;
				}*/
				if (consumer is Recursive)
				{
					Recursive r = consumer as Recursive;
					arguments = r.ExternalArguments;
				}
			}
			for (int i = 0; i < measurements.Count; i++)
			{
				IMeasurement measure = measurements[i];
				Label lab = new Label();
				lab.Top = y;
				lab.Left = 20;
                try
                {
                    lab.Text = Measurement.GetTypeName(measure.Type);
                }
                catch
                {

                }
                lab.Size = new System.Drawing.Size(121, 21);
                y += lab.Height + 10;
				Controls.Add(lab);
				ComboBox cb = new ComboBox();
				cb.Location = new System.Drawing.Point(20, y);
				cb.Size = new System.Drawing.Size(121, 21);
				foreach (char c in variables)
				{
					cb.Items.Add(c + "");
				}
				if (consumer is DifferentialEquationSolver)
				{
					DifferentialEquationSolver s = consumer as DifferentialEquationSolver;
					string str = s.InputParameters;
					foreach (char c in str)
					{
						cb.Items.Add(c + "");
					}
				}
				Label l = new Label();
                extended.Add(l);
				l.Text = (string)measure.Name.Clone();
				l.Location = new System.Drawing.Point(cb.Left + cb.Width + 10, y);
				l.Width = Width - 20;
				measurementControls.Add(new object[]{cb, measure});
				Controls.Add(cb);
				Controls.Add(l);
				y = cb.Top + cb.Height + 5;
				if (arguments == null)
				{
					continue;
				}
                string argName = consumer.GetMeasurementsName(measurements) 
					+ "." + measure.Name;
				foreach (string arg in arguments)
				{
					if (arg.Length < 4)
					{
						continue;
					}
					if (arg.Substring(4).Equals(argName))
					{
						char c = arg[0];
						for (int j = 0; j < cb.Items.Count; j++)
						{
							char s = cb.Items[j].ToString()[0];
							if (c == s)
							{
								cb.SelectedIndex = j;
								goto A;
							}
						}
					}
				}
			A: continue;
			}
			Width = 100;
			Height = y + 10;

        }

        void ResizePanel(object sender, EventArgs args)
        {
            int w = Width;
            foreach (Label l in extended)
            {
                int x = l.Left;
                l.Width = w - x - 10;

            }
        }

        #endregion
    }


}
