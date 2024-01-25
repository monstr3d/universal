using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Diagram.Interfaces;
using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.UI;

using Chart.Drawing.Interfaces;
using Chart.Objects;
using Chart;
using Chart.Interfaces;
using Chart.UserControls;
using Chart.Drawing.TextPainters;


using Trading.Library.Forms.Interfaces;
using Trading.Library.Forms.Labels;
using Trading.Library.Objects;

namespace Trading.Library.Forms.UserControls
{
    public partial class UserControlOrderChart : UserControl,
        IOrderHolder, INamedComponentHolder, IPostSet
    {
        Order Order { get; set; }

        INamedComponent component;

        List<ChartPerformer> performers = new List<ChartPerformer>();

        OrderLabel orderLabel;

        UserControlChart userControlChartBig;

        UserControlChart userControlChartLittle;

        SplitContainer splitContainerCharts;


        public UserControlOrderChart()
        {
            InitializeComponent();

            var charts = this.FindChildren<UserControlChart>();
            foreach (var item in charts)
            {
                if (item.Name == "userControlChartBig")
                {
                    userControlChartBig = item;
                }
                if (item.Name == "userControlChartLittle")
                {
                    userControlChartLittle = item;
                }
            }
            // DELETE !!!
            panelChartChild.HorizontalScroll.Maximum = 50000;

            var splits = this.FindChildren<SplitContainer>();
            {
                foreach (var split in splits)
                {
                    splitContainerCharts = split;
                }
            }


            //       new int[,] { { 80, 30 }, { 10, 40 } }
            userControlChartBig.Prepare(new int[,] { { 80, 30 }, { 10, 60 } }, true);
            var p = userControlChartBig.Performer;
            performers.Add(p);
            ICoordPainter coord = new SimpleCoordinator(5, 5, p);
            p.Coordinator = coord;
            userControlChartLittle.Prepare(new int[,] { { 80, 30 }, { 10, 80 } }, true);
            p = userControlChartLittle.Performer;
            performers.Add(p);
            coord = new SimpleCoordinator(5, 5, p);
            p.Coordinator = coord;
        }

        #region Interface Members

        INamedComponent INamedComponentHolder.NamedComponent { get => component; set => Set(value); }

        void IPostSet.Post()
        {
            Post();
        }

        #endregion

        void Set(INamedComponent component)
        {
            this.component = component;
            if (component is OrderLabel)
            {
                orderLabel = (OrderLabel)component;
                try
                {
                    var sd = orderLabel.ChartSplit;
                    if (sd != 0)
                    {
                        splitContainerCharts.SplitterDistance = sd;
                    }
                    sd = orderLabel.LeftSplit;
                    if (sd != 0)
                    {
                        splitContainerLeft.SplitterDistance = sd;
                    }
                }
                catch { }
                splitContainerLeft.SplitterMoved += splitContainerLeft_SplitterMoved;
                splitContainerCharts.SplitterMoved += splitContainerCharts_SplitterMoved;
            }
        }

        void Post()
        {
            var mc = this.FindAll<IMouseChartIndicator>();
            foreach (var item in performers)
            {
                foreach (var mm in mc)
                {
                    item.Add(mm);
                }
            }

        }

        Order IOrderHolder.Order
        {
            get => Order;
            set => Set(value);
        }


        internal void Process(Dictionary<string, object> dicto, IMeasurements[] measurements,
             Dictionary<string, Dictionary<string, Color>> dColors)
        {
            var coll = Order.GetDependentCollection();
            coll.ForEach((IRunning s) => s.IsRunning = false);
            bool pr = true;
            if (dicto.Count > 0)
            {
                foreach (var kvp in dicto.Values)
                {
                    if (!(kvp is DataPerformer.SeriesTypes.ParametrizedSeries))
                    {
                        pr = false;
                    }
                    break;
                }
            }
            userControlChartBig.Performer.RemoveAll();
            userControlChartLittle.Performer.RemoveAll();
            {
                Dictionary<IMeasurement, Color> d = Order.GetColors(measurements, dColors);
                Dictionary<string, IMeasurement> dd = Order.GetAllMeasurementsByName();

                foreach (string key in dicto.Keys)
                {
                    var mea = dd[key];

                    if (pr)
                    {
                        DataPerformer.SeriesTypes.ParametrizedSeries ps = dicto[key] as DataPerformer.SeriesTypes.ParametrizedSeries;
                        ParametrizedSeries series = new ParametrizedSeries(null, null);
                        series.Add(ps);
                        userControlChartBig.Performer.AddSeries(series, d[mea], mea);
                        //  ownSeries.Add(series);
                        continue;
                    }
                    ISeries s = dicto[key] as ISeries;
                    if (mea.Name == "Income")
                    {
                        userControlChartLittle.Performer.AddSeries(s, d[mea], mea);
                        continue;
                    }
                    userControlChartBig.Performer.AddSeries(s, d[mea], mea);
                }
            }
            userControlChartBig.Performer.RefreshAll();
            userControlChartLittle.Performer.RefreshAll();
        }


        void Set(Order order)
        {
            Order = order;
            userControlMeasurementCollection.DataConsumer = Order;
            var measurements = order.GetAllMeasurements();
            /* var d = new Dictionary<string, Tuple<Color, bool>>();
             var t = new Tuple<List<IMeasurements>, Dictionary<string, Tuple<Color, bool>>>(
                  order.GetDataConsumerMeasurements().ToList(), d);*/
            var mmm = order.GetDataConsumerMeasurements().ToList();
            mmm.Add(Order);

            userControlMeasurementCollection.Measurements =
                mmm;
            order.Set(userControlMeasurementCollection);
            var time = Order.FindMeasurement(Order.Date, true);
            bool oatime = false;
            if (time != null)
            {
                if (time.GetType().FullName == "Trading.Library.Objects.DataQuery+FullTimeMeasurement")
                {
                    oatime = true;
                }
            }
            var coord = userControlChartBig.Performer.Coordinator;
            if (oatime)
            {
                coord.X = new DataTimeFromOATextPainter();
            }
            else
            {
                coord.X = new SimpleCoordTextPainter();
            }
            coord = userControlChartLittle.Performer.Coordinator;
            if (oatime)
            {
                coord.X = new DataTimeFromOATextPainter();
            }
            else
            {
                coord.X = new SimpleCoordTextPainter();
            }
            if (oatime)
            {
                var p = this.FindParent<UserControlOrderFull>();
                p.Show[0] = (o) =>
                {
                    double x = (double)o;
                    return DateTime.FromOADate(x);
                };
            }
        }

        object fdt(object obj)
        {
            double t = (double)obj;
            var dt = DateTime.FromOADate(t);
            return dt.ToString();
        }

        object f(object obj) => obj;




        private void splitContainerLeft_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (orderLabel != null)
            {
                orderLabel.LeftSplit = splitContainerLeft.SplitterDistance;
            }

        }

        private void splitContainerCharts_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (orderLabel != null)
            {
                orderLabel.ChartSplit = splitContainerCharts.SplitterDistance;
            }
        }

        private void panelChartParent_Resize(object sender, EventArgs e)
        {
            panelChartChild.Width = panelChartParent.Width -20;
            panelChartChild.Height = panelChartParent.Height -20;
        }
        /*
       internal class CoordTextPainter : SimpleCoordTextPainter
       {

           public CoordTextPainter()
           {
           }

           protected override void drawTextX(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
           {
               double sc = scale[0];
               if (sc == 0)
               {
                   return;
               }
               double k = Math.Floor(dSize[0, 0] / sc);
               double c = k * sc;
               Font font = new Font("Times", 13);
               Brush brush = new SolidBrush(Color.Black);
               int h = font.Height + insets[0, 1] + size[1];
               while (c < dSize[1, 0])
               {
                   if (c > dSize[0, 0])
                   {
                       performer.Transform(c, 0.0, p);
                       var s = "";
                       if (c < 0)
                       {
                           s = transformString(c, sc);
                       }
                       else
                       {
                           s = DateTime.FromOADate(c).ToString();
                       }
                       int w = (int)g.MeasureString(s, font).Width;
                       g.DrawString(s, font, brush, p[0] + insets[0, 0] - w / 2, h);
                   }
                   c += sc;
               }

           }


       }
*/

    }
}
