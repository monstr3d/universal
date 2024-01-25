using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingDatabase;
using IBApi;
using IBApi.Wrappers;
using CSharpAPI.proxy;
using IBApi.proxy;
using System.Xml.Linq;
using MathOperations;
using MathOperations.Interfacses;
using MathOperations.Filters;
using System.Windows.Forms.DataVisualization.Charting;
using Chart.Drawing.Interfaces;
using Chart.Drawing.Series;
using Chart.Drawing.Painters;
using Chart.Drawing;
using Chart.Drawing.Coordinators;
using Chart;
using IBApi.messages;
using Chart.Interfaces;
using Trading.Charts;

namespace WinTradingResearch
{
    public partial class FormMain : Form
    {

        Dictionary<string, Guid> symbols = new Dictionary<string, Guid>();

        Dictionary<Guid, string> inversed = new Dictionary<Guid, string>();

        Dictionary<int, DateTime> dates = new Dictionary<int, DateTime>();

        double[] coeff = { 1, 2, 3 };

        IFilter<double>[] filters;

        int barCounter = 0;

        DateTime currDate;
        IncomeCalculator incomeCalculator;

        PureSeries averageLong;
        PureSeries averageShort;
        PureSeries donchianHigh;
        PureSeries donchianLow;
        PureSeries sell;
        PureSeries buy;
        MultiSeries candles;

        double currentTime = 0;

        public void CreateSeries()
        {
            userControlChart.Performer.RemoveAll();
            averageLong = new PureSeries();
            averageShort = new PureSeries();
            donchianHigh = new PureSeries();
            donchianLow = new PureSeries();
            sell = new PureSeries();
            buy = new PureSeries();
            candles = new MultiSeries(4);
            userControlChart.AddSeries(averageShort, Color.Green);
            userControlChart.AddSeries(averageLong, Color.Red);
            userControlChart.AddSeries(donchianHigh, new StepSeriesPainter([Color.Magenta]));
            userControlChart.AddSeries(donchianLow, new StepSeriesPainter([Color.Magenta]));
            userControlChart.AddSeries(candles, 
                
                new CandleSeriesPainter(Color.LightGreen, Color.LightPink));
            var buyP = new DelegatePainter();
            var byBrush = new SolidBrush(Color.Green);
            var sellBrush = new SolidBrush(Color.Red);
            var sellP = new DelegatePainter();
            int k = 10;
            sellP.Paint +=
                (int[] n, Graphics g) =>
                {
                    Point[] points =
                    [new Point(n[0], n[1]),
                        new Point(n[0] + 2 * k, n[1] - k),
                        new Point(n[0] + 2 * k, n[1] + k)];
                    g.FillPolygon(sellBrush, points);
                };
            buyP.Paint += (int[] n, Graphics g) =>
            {
                Point[] points =
                [new Point(n[0], n[1]),
                    new Point(n[0] - 2 * k, n[1] - k),
                    new Point(n[0] - 2 * k, n[1] + k)];
                g.FillPolygon(byBrush, points);
            };

            userControlChart.AddSeries(buy, buyP);

            userControlChart.AddSeries(sell, sellP);
            //  userControlChart.AddSeries(buy, new CircleSeriesPainter(10, new SolidBrush(Color.Magenta)));
            //  userControlChart.AddSeries(sell, new CircleSeriesPainter(10, new SolidBrush(Color.Maroon)));
        }

        private void CreateFilters()
        {
            int n = (int)shortNum.Value;
            int n1 = (int)longNum.Value;
            int n3 = (int)numericUpDownDonchian.Value;
            /*     filters = [new Exponential(0.9, n), new Exponential(0.9, n1), 
                     new Donchian(10, true), new Donchian(20, false)];*/
                filters = [new AverageFilter(n), new AverageFilter(n1), 
                    new Donchian(n3, true), new Donchian(n3, false)];

        }
        public FormMain()
        {
            InitializeComponent();
            chartData.Visible = !userControlChart.Visible;
            userControlChart.Prepare(new int[,] { { 80, 30 }, { 10, 40 } }, true);
            var performer = userControlChart.Performer;

            // performer.SetMouseIndicator(labelMouseIndicator);

            performer.Add(new MouseIndicatior(dates, labelMouseIndicator));

            performer.Coordinator =
                new Chart.Drawing.Coordinators.SimpleCoordinator(4, 4, performer);
            var chartArea = chartData.ChartAreas[0];

            chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            chartData.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartData.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            symbols = StaticExtensionTradingDatabase.Symbols;
            var i = 0;
            foreach (var symbol in symbols.Keys)
            {
                var val = symbols[symbol];
                comboBoxSymbols.Items.Add(symbol);
            }
            comboBoxSymbols.SelectedIndex = 2;
            dateBegin.Value = new DateTime(2023, 7, 11);
            dateEnd.Value = new DateTime(2023, 7, 20);
            var itervals = StaticExtensionIBApi.Barsizes;
            comboBoxBarSize.Items.Clear();
            comboBoxBarSize.Items.AddRange(itervals);
            comboBoxBarSize.SelectedIndex = 11;
            chartData.MouseWheel += chart_MouseWheelOLD;
 
        }


        int deltaScrollTotal = 0;

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            dates.Clear();
            CreateFilters();
            CreateSeries();
            var t = comboBoxBarSize.SelectedItem + "";
            foreach (var s in chartData.Series)
            {
                s.Points.Clear();
            }
            var bs = t.ToBarSize();
            if (bs < TimeSpan.FromSeconds(5))
            {
                return;
            }
            
            barCounter = -1;
            chartData.Series[0].Points.Clear();
            var begin = dateBegin.Value;
            var end = dateEnd.Value;
            /*
            begin = new DateTime(2023, 11, 2, 9, 0, 0);
            end = new DateTime(2023, 11, 2, 9, 20, 0);
            //*/ 

            var symbol = comboBoxSymbols.SelectedItem + "";
            var guid = symbols[symbol];
            var enu = guid.GetHistoricalDataMessageDateTimes(begin, end);
            var convert = enu.Convert(bs);
            var nd = (int)numericUpDownDonchian.Value;
            var nl = (int)longNum.Value;
            var ns = (int)shortNum.Value;
            EWrapper s1 = new DonchianStrategy(nd, ns, nl);

            var str = new HistoryReatimeWrapper(s1);
            var historicalProcessor = new HistoricalProcessor(str);
            incomeCalculator  = new IncomeCalculator(new ClosedIncomeCalculator());
            historicalProcessor.OrderReceived += HistoricalProcessor_OrderReceived;

            historicalProcessor.HistoricalDataMessageReceived += HistoricalProcessor_HistoricalDataMessageReceived;
            historicalProcessor.Process(convert, str);
            labelIncome.Text = incomeCalculator.Income + "";
            if (userControlChart.Visible)
            {
                userControlChart.Performer.RefreshAll();
            }
        }

        private void HistoricalProcessor_OrderReceived(Contract arg1, Order arg2, HistoricalDataMessageDateTime arg3)
        {
            incomeCalculator.Process(arg3, arg2, arg1);
            //double k = (arg2.Action == "BUY") ? 130 : 100;
            if (arg2.Action == "BUY")
            {
                buy.AddXY((double)barCounter, arg3.Close);
                chartData.Series[5].Points.AddXY(currDate, 150);
            }
            else
            {
                sell.AddXY((double)barCounter, arg3.Close);
                chartData.Series[6].Points.AddXY(currDate, 150);
            }
            //chartData.Series[7].Points.AddXY(currDate, incomeCalculator.Income);
        }

        void DrawChart(double? averageHigh, double? averageLow, 
            double ? donchianHigh,
            double ? donchianLow, double[] x) 
        {
            double time = (double)barCounter;
            averageLong.AddXY(time, averageHigh);
            averageShort.AddXY(time, averageLow);
            this.donchianHigh.AddXY(time, donchianHigh);
            this.donchianLow.AddXY(time, donchianLow);
            candles.AddXY(time, x);
        }

 
        private void HistoricalProcessor_HistoricalDataMessageReceived(HistoricalDataMessageDateTime obj)
        {
            
            ++barCounter;
            currDate = (DateTime)obj.Date;
            dates[barCounter] = currDate;
            var m = 0.5 * (obj.High + obj.Low);
            double? averageHigh = filters[0][m];
            double? averageLow = filters[1][m];
            double? donchianHigh = filters[2][obj.High];
            double? donchianLow = filters[3][obj.Low];
            if (userControlChart.Visible)
            {
                var x = new double[] { obj.High, obj.Low, obj.Open, obj.Close };

                DrawChart(averageHigh, averageLow, 
                    donchianHigh, donchianLow, x);
                return;
            }

            if (averageHigh != null)
            {
                chartData.Series[1].Points.AddXY(currDate, averageHigh);
            }
            if (averageLow != null)
            {
                chartData.Series[2].Points.AddXY(currDate, averageLow);
            }

    
            chartData.Series[0].Points.AddXY(currDate, obj.High);
            chartData.Series[0].Points[barCounter].YValues[1] = obj.Low;
            chartData.Series[0].Points[barCounter].YValues[2] = obj.Open;
            chartData.Series[0].Points[barCounter].YValues[3] = obj.Close;
  
            chartData.Series[3].Points.AddXY(currDate, donchianHigh);
            chartData.Series[4].Points.AddXY(currDate, donchianLow);
            
        }


        #region Mouse events
        private void chart_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = chartData;
            int maxChangeRange = 1001;
            int minChangeRange = -1;

            int deltaScroll = e.Delta / Math.Abs(e.Delta);
            deltaScrollTotal += deltaScrollTotal + deltaScroll > minChangeRange
                             && deltaScrollTotal + deltaScroll < maxChangeRange
                              ? deltaScroll : 0;
            // Additional calculation in order to obtain pseudo
            // "positional zoom" feature
            var x = (double)e.X;
            var y = (double)e.Y;
            var dx = chart.ChartAreas[0].AxisX.Maximum - chart.ChartAreas[0].AxisX.Minimum;
            var dy = chart.ChartAreas[0].AxisY.Maximum - chart.ChartAreas[0].AxisY.Minimum;
            double minXScale = x / (double)chart.Width;
            double maxXScale = 1 - minXScale;
            double minYScale = y / (double)chart.Height;
            double maxYScale = 1 - minYScale;
            var a = dx * dx + dy * dy;
            a = Math.Sqrt(a);
            var ax = dx / a;
            var ay = dy / a;
            minXScale *= ax;
            maxXScale *= ax;
            minYScale *= ay;
            maxYScale *= ay;

            // Max and min values into which axis need to be scaled/zoomed
            double maxX = chart.ChartAreas[0].AxisX.Maximum
                        - deltaScrollTotal * maxXScale;
            double minX = chart.ChartAreas[0].AxisX.Minimum
                        + deltaScrollTotal * minXScale;
            double maxY = chart.ChartAreas[0].AxisY.Maximum
                        - deltaScrollTotal * minYScale;
            double minY = chart.ChartAreas[0].AxisY.Minimum
                        + deltaScrollTotal * maxYScale;

            chart.ChartAreas[0].AxisX.ScaleView.Zoom(minX, maxX);
            chart.ChartAreas[0].AxisY.ScaleView.Zoom(minY, maxY);
        }

        private void chart_MouseWheelOLD(object sender, MouseEventArgs e)
        {
            var chart = chartData;
            int maxChangeRange = 1001;
            int minChangeRange = -1;

            int deltaScroll = e.Delta / Math.Abs(e.Delta);
            deltaScrollTotal += deltaScrollTotal + deltaScroll > minChangeRange
                             && deltaScrollTotal + deltaScroll < maxChangeRange
                              ? deltaScroll : 0;
            // Additional calculation in order to obtain pseudo
            // "positional zoom" feature
            var x = (double)e.X;
            var y = (double)e.Y;
            var dx = chart.ChartAreas[0].AxisX.Maximum - chart.ChartAreas[0].AxisX.Minimum;
            var dy = chart.ChartAreas[0].AxisY.Maximum - chart.ChartAreas[0].AxisY.Minimum;
            double minXScale = x / (double)chart.Width;
            double maxXScale = 1 - minXScale;
            double minYScale = y / (double)chart.Height;
            double maxYScale = 1 - minYScale;

            // Max and min values into which axis need to be scaled/zoomed
            double maxX = chart.ChartAreas[0].AxisX.Maximum
                        - deltaScrollTotal * maxXScale;
            double minX = chart.ChartAreas[0].AxisX.Minimum
                        + deltaScrollTotal * minXScale;
            double maxY = chart.ChartAreas[0].AxisY.Maximum
                        - deltaScrollTotal * minYScale;
            double minY = chart.ChartAreas[0].AxisY.Minimum
                        + deltaScrollTotal * maxYScale;

            chart.ChartAreas[0].AxisX.ScaleView.Zoom(minX, maxX);
            chart.ChartAreas[0].AxisY.ScaleView.Zoom(minY, maxY);
        }

        #endregion

        #region Mouse indicator


        internal class MouseIndicatior : IMouseChartIndicator
        {
            internal MouseIndicatior(Dictionary<int, DateTime> dates, Control control)
            {
                this.dates = dates;
                this.control = control;
            }

            Dictionary<int, DateTime> dates;

            Control control;

            bool IMouseChartIndicator.IsEnabled { get => true; set { } }

            void IMouseChartIndicator.Indicate(double x, double y)
            {
                int k = (int)x;
                if (dates.ContainsKey(k))
                {
                    var dt = dates[k];
                    control.Text = "Time = " + dt.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") + "; Value = " + y;
                }
            }
        }


        #endregion

    }
}
