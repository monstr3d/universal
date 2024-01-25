using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI;

using DataPerformer.Portable.DifferentialEquationProcessors;

using BasicEngineering.UI.Factory;
using BasicEngineering.UI.Factory.Advanced.Forms;

using CommonService;

using DataWarehouse.Interfaces;

using Chart.Drawing.Interfaces;
using Chart.Drawing.Interfaces.Points;
using DataPerformer.Portable;
using DataPerformer.UI.UserControls;

using Chart.Drawing;
using Chart.Drawing.Painters;


using Chart.DataPerformer.Interfaces;
using Chart.DataPerformer;
using Chart.Drawing.TextPainters;

using Trading.Charts;
using Trading.Library.Objects;



namespace Trading.Analytics
{
    internal static class StaticExtension
    {
        class SeriesFactory : ISeriesPainterFactory, ICoordinateFunctionsCreator,
            IAttachedToPointFactory, IChartPerformerPreparation
        {
            Brush sellBrush = new SolidBrush(Color.Red);
            Brush buyBrush = new SolidBrush(Color.Green);


            object Attach(object value)
            {

                var s = value.GetType().ToString();
                if (s.Contains("Trading.Library"))
                {
                    if (value is IAssociatedObject)
                    {
                        var o = (value as IAssociatedObject).Object;
                        if (o is Order)
                        {
                            var p = o as Order;
                            var pos = p.PositionDirection;
                            return pos;
                        }
                    }
                }
                return null;
            }

            internal SeriesFactory()
            {
                StaticExtensionDataPerformerChart.AttachedToPointFactory = this;
                StaticExtensionChartDrawing.SeriesPainterFactory = this;
                StaticExtensionChartInterfaces.CoordinateFunctionsCreator = this;
                StaticExtensionChartDrawing.ChartPerformerPreparation = this;
            }

            void DrawTriangle(Brush brush, int[] n, bool right, Graphics graphics, int k)
            {
                Point[] points = right ?

                                    [new Point(n[0], n[1]),
                                        new Point(n[0] - 2 * k, n[1] - k),
                                        new Point(n[0] - 2 * k, n[1] + k)] :
                  [new Point(n[0], n[1]),
                      new Point(n[0] + 2 * k, n[1] - k),
                      new Point(n[0] + 2 * k, n[1] + k)];
                graphics.FillPolygon(brush, points);

            }

            void DrawTriangleO(Brush brush, int[] n, Graphics graphics, int k, Order order)
            {
                var p = order.PositionDirection == Library.Enums.PositionDirection.Opened;
                DrawTriangle(brush, n, p, graphics, k);

            }

            bool OpenPosition(object o)
            {
                if (o is IPoint)
                {
                    var p = (o as IPoint).Properties;
                    if (p != null)
                    {
                        return p.Equals(Library.Enums.PositionDirection.Opened);
                    }
                }
                return false;
            }

            #region Implementation of interfaces

            object IAttachedToPointFactory.this[object value] => Attach(value);


            void IChartPerformerPreparation.Prepare(ChartPerformer performer, object obj)
            {
                var control = performer.Control;
                if (!(control is Chart.ChartPerformer.ControlWrapper))
                {
                    return;
                }
                var c = (control as Chart.ChartPerformer.ControlWrapper).Control;
                var cc = c.FindParent<UserControlGraph>();
                if (cc == null)
                {
                    return;
                }
                if (obj.GetType().FullName == "Trading.Library.Objects.DataQuery+FullTimeMeasurement")
                {
                    performer.Coordinator.X = new DataTimeFromOATextPainter();
                }
                else
                {
                    performer.Coordinator.X = new SimpleCoordTextPainter();
                }



            }

            Func<object, object>[] ICoordinateFunctionsCreator.this[object obj]
                    => Create(obj);



            ISeriesPainter ISeriesPainterFactory.this[object key]
            {
                get
                {
                    if (key is Tuple<ISeries, Color[], ChartPerformer, object>)
                    {
                        var t = key as Tuple<ISeries, Color[], ChartPerformer, object>;
                        var type = t.Item4.GetType();
                        var fn = type.FullName;
                        FilterWrapper filterWrapper = null;
                        Order order = null;
                        if (t.Item4 is IAssociatedObject)
                        {
                            var of = (t.Item4 as IAssociatedObject).Object;
                            if (of is FilterWrapper)
                            {
                                filterWrapper = (FilterWrapper)of;
                                if (filterWrapper.Kind > 0)
                                {
                                    return new StepSeriesPainter(t.Item2);
                                }
                            }
                            if (of is Order)
                            {
                                order = (Order)of;
                                if (fn.Equals("Trading.Library.Objects.Order+IncomeMeasurement"))
                                {
                                    return new StepSeriesPainter(t.Item2);
                                }
                            }
                        }

                        if (fn == "DataPerformer.Portable.FilterWrapper+DonchianMeasurement")
                        {
                            return new StepSeriesPainter(t.Item2);
                        }
                        if (type.Assembly != typeof(DataQuery).Assembly)
                        {
                            return null;
                        }

                        if (fn == "Trading.Library.Objects.DataQuery+CandleMeasurement")
                        {
                            return new CandleSeriesPainter(Color.LightGreen, Color.LightPink);
                        }
                        int k = 10;
                        object o = null;
                        if (t.Item4 is IAssociatedObject)
                        {
                            o = (t.Item4 as IAssociatedObject).Object;
                        }
                        if (fn == "Trading.Library.Objects.Order+BuyTaxMeasurement")
                        {
                            var buyP = new DelegatePainter();

                            /*    buyP.Paint += (int[] n, Graphics g) =>
                                    {
                                       DrawTriangle(buyBrush, n,  g,  k, order);

                                     };*/
                            buyP.PaintPoint += (n, g, o) =>
                            {
                                var op = OpenPosition(o);
                                DrawTriangle(buyBrush, n, op, g, k);

                            };
                            return buyP;
                        }
                        if (fn == "Trading.Library.Objects.Order+SellTaxMeasurement")
                        {
                            var sellP = new DelegatePainter();
                            sellP.PaintPoint +=
                                (n, g, o) =>
                                {
                                    var op = OpenPosition(o);

                                    DrawTriangle(sellBrush, n, op, g, k);

                                };
                            return sellP;

                        }

                    }
                    return null;
                }
            }

            #endregion


            Func<object, object>[] Create(object obj)
            {
                return [fdt, f];
             }

            object fdt(object obj)
            {
                double t = (double)obj;
                var dt = DateTime.FromOADate(t);
                return dt.ToString();
            }

            object f(object obj) => obj;
      



        }

        static StaticExtension()
        {
            new SeriesFactory();
        }


        public static FormMain CreateForm(string filename)
        {
            return CreateForm(null, "", null, [], [], [], false, "Trading analytics",
                Properties.Resources.ib_logo_2015, null, null);
        }

        public static FormMain CreateForm(IDatabaseCoordinator database,
            string filename, ByteHolder holder,
            ButtonWrapper[] addButtons, IUIFactory[] factories,
            Dictionary<string, object>[] addReasurces, bool throwsDoubleInit,
            string caption, Icon icon, TextWriter logWriter,
            TestCategory.Interfaces.ITestInterface testInterface)
        {
            var tabs = new string[] { "Trading", "Filters", "General", "Statistics", "Database", "Events", "Arrows" };
            ButtonWrapper[][] but = new ButtonWrapper[tabs.Length][];
            int i = 0;
            var trading = new List<ButtonWrapper>();
            trading.AddRange(Library.Forms.StaticExtensionTradingLibraryForms.ObjectsButtons);
            but[i] = trading.ToArray();
            ++i;
            var filters = new List<ButtonWrapper>();
            filters.AddRange(DataPerformer.UI.Factory.StaticFactory.FilterButtons);
            but[i] = filters.ToArray();
            ++i;
            List<ButtonWrapper> gen = new List<ButtonWrapper>();
            gen.AddRange(DataPerformer.UI.Factory.StaticFactory.GeneralObjectsButtons);
            gen.AddRange(addButtons);
            but[i] = gen.ToArray();
            ++i;
            List<ButtonWrapper> stat = new List<ButtonWrapper>();
            stat.AddRange(EngineeringUIFactory.StatisticalObjectsButtons);
            but[i] = stat.ToArray();
            ++i;
            but[i] = Database.UI.Factory.DatabaseFactory.ObjectButtons;
            ++i;
            List<ButtonWrapper> events = new List<ButtonWrapper>();
            events.AddRange(Event.UI.Factory.UIFactory.ObjectButtons);
            but[i] = events.ToArray();
            ++i;
            List<ButtonWrapper> arr = new List<ButtonWrapper>();
            arr.AddRange(EngineeringUIFactory.ArrowButtons);
            arr.Add(EngineeringUIFactory.DataExchangeArrowButtons[0]);
            arr.AddRange(Event.UI.Factory.UIFactory.ArrowButtons);
            arr.AddRange(Database.UI.Factory.DatabaseFactory.ArrowButtons);
            but[i] = arr.ToArray();
            LightDictionary<string, ButtonWrapper[]> buttons = new LightDictionary<string, ButtonWrapper[]>();
            buttons.Add(tabs, but);
             Dictionary<string, object> dm = new Dictionary<string, object>();

      IUIFactory[] facts =
                      [
                    // !!!REMOVED        SoundService.UI.Factory.SoundUIFactrory.Singleton,
                    Event.UI.Factory.UIFactory.Factory,
                    Database.UI.Factory.DatabaseFactory.Object
                      ];

            IApplicationInitializer[] init =
                                  [
                          DataSetService.Initialization.DatabaseInitializer.GetInitializer(
                           DataSetService.DllDataSetFactoryChooser.BaseDirectoryFactory)
                                  ];   

            FormMain form = BasicEngineering.UI.Factory.Advanced.DefaultApplicationCreator.CreateForm(
                database, holder, OrdinaryDifferentialEquations.Runge4Solver.Singleton,
                RungeProcessor.Processor, init,
                facts, false, buttons, icon,
                filename, [], caption,
                ".cft",
                "Trading configuration files |*.cft", null, null);
            return form;
        }
  
    }
}

