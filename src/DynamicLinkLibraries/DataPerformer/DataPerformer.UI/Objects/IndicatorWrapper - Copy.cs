using DataPerformer.Interfaces;
using Event.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataPerformer.Portable;
using System.Windows.Forms;

namespace DataPerformer.UI.Objects
{
    class IndicatorWrapper : IDisposable
    {
        #region Fields

        internal Dictionary<string, Size> sizes;

        Dictionary<IMeasurement, object> indicators = new Dictionary<IMeasurement, object>();


        #endregion

        internal void Show(IDataConsumer consumer, IEnumerable<IMeasurement> measurements, Dictionary<string, Size> sizes)
        {
            this.sizes = sizes;
            IMeasurementObjectFactory f = StaticExtensionDataPerformerUI.GraphCollection;
            IDataConsumer c = consumer;
            indicators.RemoveMeasurementObjects();
            Dictionary<IMeasurement, string> d = consumer.GetMeasurementsDictionary();
            //!!! ALL  INDICATORS c.GetMeasurementObjects(indicators, f);

            foreach (IMeasurement m in d.Keys)
            {
                if (measurements.Contains(m) & (!indicators.ContainsKey(m)))
                {
                    string name = d[m];
                    object o = f[d[m], m];
                    if (o == null)
                    {
                        continue;
                    }
                    indicators[m] = o;
                    Form form = o as Form;
                    if (sizes.ContainsKey(name))
                    {
                        form.Size = sizes[name];
                    }
                    if (name != null)
                    {
                        form.Text = name;
                    }
                    form.Resize += (object sender, EventArgs e) =>
                    {
                        sizes[form.Text] = form.Size;
                    };
                    if (o is IRealtimeUpdate)
                    {
                        (o as IRealtimeUpdate).Update();
                    }
                }
            }
            foreach (object o in indicators.Values)
            {
                if (o is Form)
                {
                    Form form = o as Form;
                    form.Show();
                    form.BringToFront();
                }
            }

        }

        internal void UpdateIndicators()
        {
            foreach (object o in indicators.Values)
            {
                if (o is IRealtimeUpdate)
                {
                    (o as IRealtimeUpdate).Update();
                }
            }
        }

        public void Dispose()
        {
            if (indicators != null)
            {
                foreach (object o in indicators.Values)
                {
                    if (o is System.Windows.Forms.Form)
                    {
                        System.Windows.Forms.Form f = o as System.Windows.Forms.Form;
                        if (!f.IsDisposed)
                        {
                            f.Close();
                        }
                    }
                }
            }
            indicators = null;
        }
    }
}