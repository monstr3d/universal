using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;


using Diagram.UI;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

namespace DataPerformer.UI
{
    /// <summary>
    /// Editor of measure for graph component
    /// </summary>
	public class PanelMeasureGraph : Panel
	{
        /// <summary>
        /// Measurements
        /// </summary>
		protected IMeasurements measurements;

        /// <summary>
        /// Colors for measurements
        /// </summary>
		protected ArrayList measurementControls;
		private string panelName;
        internal Dictionary<string, object[]> series = new Dictionary<string,object[]>();
		private Hashtable mea = new Hashtable();
        private Dictionary<Button, object> buttons = new Dictionary<Button, object>();
		private DataConsumer consumer;
        private Dictionary<string, Color[]> dic;
        //private Dictionary<string, bool> dicStep;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="measurements">Measurements</param>
        /// <param name="consumer">Data consumer</param>
        /// <param name="dic">Dictionary of colors</param>
        public PanelMeasureGraph(IMeasurements measurements, DataConsumer consumer,
            Dictionary<string, Color[]> dic)
		{
            this.measurements = measurements;
			this.consumer = consumer;
            this.dic = dic;
            //this.dicStep = dicStep;
			Initialize();
            Resize += panelMea_Resize;
		}

        new internal void Update()
        {
            buttons.Clear();
            series.Clear();
            foreach (object[] o in measurementControls)
            {
                CheckBox cb = o[0] as CheckBox;
                if (!cb.Checked)
                {
                    continue;
                }
                IMeasurement y = o[1] as IMeasurement;
                object t = y.Type;
                string sn = panelName + "." + y.Name;
                 OfficePickers.ColorPicker.ComboBoxColorPicker pic = o[3] as OfficePickers.ColorPicker.ComboBoxColorPicker;
                Button b = o[2] as Button;
                dic[sn] = new Color[] { pic.Color };
                object[] ob = new object[] { null, o[1], o[2], o[3] };
                series[sn] = ob;
                buttons[b] = ob;
            }
        }
		
		internal Dictionary<string, object[]> Series
		{
            get
            {
                return series;
             }
		}

        internal static Dictionary<string, object[]> GetSeries(Control control)
        {
            Dictionary<string, object[]> d = new Dictionary<string, object[]>();
            foreach (Control c in control.Controls)
            {
                if (!(c is PanelMeasureGraph))
                {
                    continue;
                }
                PanelMeasureGraph p = c as PanelMeasureGraph;
                p.Update();
                Dictionary<string, object[]> dic = p.Series;
                foreach (string key in dic.Keys)
                {
                    d[key] = dic[key];
                }
            }
            return d;
        }

        /// <summary>
        /// Creates table of measurements
        /// </summary>
        /// <param name="x">Input measure</param>
        /// <returns>Table of measurements</returns>
		public Hashtable CreateMeasurements(IMeasurement x)
		{
			mea.Clear();
			foreach(object[] o in measurementControls)
			{
				CheckBox cb = o[0] as CheckBox;
				if (!cb.Checked)
				{
					continue;
				}
				IMeasurement y = o[1] as IMeasurement;
				object t = y.Type;
				Double a = 0;
				if (t.Equals(a))
				{
					continue;
				}
                try
                {
                    DoubleArrayFunction f = new DoubleArrayFunction(y.Type);
                    mea[o[0]] = new object[] { f, x, y };
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
			}
			return mea;
		}
		
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
        /// Gets argument measure from name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The measure</returns>
		public IMeasurement GetArgument(string name)
		{
			foreach(object[] o in measurementControls)
			{
				IMeasurement m = o[1] as IMeasurement;
				if (name.Equals(panelName + "." + m.Name))
				{
					return m;
				}
			}
			return null;
		}


        internal Dictionary<IMeasurement, Color> MeasurementDictionary
        {
            get
            {
                Dictionary<IMeasurement, Color> d = new Dictionary<IMeasurement, Color>();
                foreach (object[] ob in measurementControls)
                {
                    CheckBox cb = ob[0] as CheckBox;
                    if (!cb.Checked)
                    {
                        continue;
                    }
                    d[ob[1] as IMeasurement] = (ob[3] as OfficePickers.ColorPicker.ComboBoxColorPicker).Color;
                }
                return d;
            }
        }


        private void panelMea_Resize(object sender, EventArgs e)
        {
            int w = Width;
            foreach (Control control in Controls)
            {
                if (control is CheckBox)
                {
                    control.Width = w - 10 - control.Left;
                }
            }
        }

        private Series GetSeries(IMeasurement measurement)
        {
            UserControls.UserControlGraph p = this.FindParent<UserControls.UserControlGraph>();
            if (p != null)
            {
                Dictionary<IMeasurement, Chart.Objects.ParametrizedSeries> d = p.SeriesDictionary;


                if (d != null)
                {
                    if (d.ContainsKey(measurement))
                    {
                        return d[measurement];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Initialize()
		{
			Control panel = HeaderControl.Object.GetHeaderControl(consumer, measurements);
            panelName = consumer.GetMeasurementsName(measurements);
			Controls.Add(panel);
			measurementControls = new ArrayList();
			int y = panel.Height + 10;
			for (int i = 0; i < measurements.Count; i++)
			{
				IMeasurement measurement = measurements[i];
                Label l = new Label();
                OfficePickers.ColorPicker.ComboBoxColorPicker pic = new OfficePickers.ColorPicker.ComboBoxColorPicker();
				CheckBox cb = new CheckBox();
                string nm = measurement.Name;
                cb.Text = nm;
                cb.Left = 20;
                cb.Width = Width - cb.Left - 10;
                cb.Top = y;
                string fn = panelName + "." + nm;
                if (dic.ContainsKey(fn))
                {
                    cb.Checked = true;
                    pic.Color = dic[fn][0];
                }
				pic.Left = cb.Left;
				pic.Top = cb.Bottom + 5;
				Button b = new Button();
				b.Top = pic.Top;
				b.Left = pic.Right + 10;
                b.Text = ResourceService.Resources.GetControlResource("Save", Utils.ControlUtilites.Resources);
				b.Click += new EventHandler(onButtonSaveClick);
				measurementControls.Add(new object[]{cb, measurement, b, pic, panelName});
                Controls.Add(pic);
                Controls.Add(cb);
                Control[] cc = new Control[] { pic, cb };
                //  Controls.Add(b);
                ContextMenu cm = new ContextMenu();
                MenuItem mi = new MenuItem("Copy to clipboard \"" + nm + "\"");
                cm.MenuItems.Add(mi);
                cm.Popup += (object sender, EventArgs args) =>
                {
                    bool cond =  GetSeries(measurement) != null;
                    foreach (MenuItem mit in cm.MenuItems)
                    {
                        mit.Visible = cond;
                    }
                };
                
                mi.Click += (object sender, EventArgs args) =>
                {
                    GetSeries(measurement).CopyToClipboard();
                };
                foreach (Control control in cc)
                {
                    control.ContextMenu = cm;
                }
                y = b.Bottom + 5;
			}
			Width = 250;
			Height = y + 10;
		}

      
        private void onButtonSaveClick(Object sender, EventArgs e)
		{
            Button b = sender as Button;
            object o = b.Tag;
            if (o == null)
            {
                return;
            }
            Form form = null;
            if (o is DataPerformer.Series)
            {
                form = new FormGraphSave(o as DataPerformer.Series, consumer.GraphControls);
                form.Show();
            }
            if (o is object[])
            {
                object[] ob = o as object[];
                form = new FormSaveVectorFunction(ob);
            }
            if (form != null)
            {
                form.Show();
            }

			/*foreach (object[] o in measurementControls)
			{
				if (o[2] == sender)
				{
					if (!mea.ContainsKey(o[0]))
					{
						continue;
					}
					object[] ob = mea[o[0]] as object[];
					Form form = new FormSaveVectorFunction(ob);
					form.Show();
					return;
				}
			}
			foreach (object[] o in series.Values)
			{
				if (o[1] != sender)
				{
					continue;
				}
				Form form = new FormGraphSave(o[0] as DataPerformer.Series, consumer.GraphControls);
				form.Show();
			}*/
		}
	}
}
