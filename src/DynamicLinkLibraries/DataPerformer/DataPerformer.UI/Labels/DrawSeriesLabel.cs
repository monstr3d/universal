using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using CategoryTheory;
using Chart;
using Chart.Drawing;
using Chart.Drawing.Interfaces;
using Chart.Objects;
using DataPerformer;
using DataPerformer.UI;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using ErrorHandler;
using NamedTree;
using ToolBox;

namespace DataPerformer.UI.Labels
{
    /// <summary>
    /// Label for series drawing
    /// </summary>
    [Serializable()]
    public partial class DrawSeriesLabel : UserControl,
        IObjectLabel, ISerializable, INonstandardLabel
    {

        #region Fields

        private DrawSeries series;

        IDesktop desktop;

        private IPointCollecionChooser chooser;


        private Chart.ChartPerformer performer;

        private FormPointCollection form;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public DrawSeriesLabel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DrawSeriesLabel(SerializationInfo info, StreamingContext context)
            : this()
        {
        }

        #endregion


        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region IObjectLabel Members

        ICategoryObject IObjectLabel.Object
        {
            get
            {
                return series;
            }
            set
            {
                series = value.GetObject<DrawSeries>();
                value.Object = this;
            }
        }

        #endregion

        #region INamedComponent Members

        string INamed.Name
        {
            get => this.GetRootLabel().Name;
            set => throw new IllegalSetPropetryException("LABEL");
        }


        string INamedComponent.Kind
        {
            get { return ""; }
        }

        string INamedComponent.Type
        {
            get { return typeof(Chart.Objects.DrawSeries).FullName; }
        }

        void INamedComponent.Remove()
        {
        }

        int INamedComponent.X
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        int INamedComponent.Y
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        IDesktop INamedComponent.Desktop
        {
            get
            {
                if (desktop == null)
                {
                    desktop = this.GetRootLabel().Desktop;
                }
                return desktop;
            }
            set
            {
            }
        }

        int INamedComponent.Ord
        {
            get
            {
                INamedComponent nc = this;
                Control c = nc.Desktop as Control;
                return c.Controls.GetChildIndex(this);
            }
        }


        INamedComponent INamedComponent.Parent
        {
            get
            {
                return null;
            }
            set
            {
                throw new ErrorHandler.OwnException("You should not set parent to UI component");
            }
        }

        /// <summary>
        /// Root
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <returns>Root</returns>
        public INamedComponent GetRoot(IDesktop desktop)
        {
            return PureObjectLabel.GetRoot(this, desktop);
        }

        string INamedComponent.GetName(IDesktop desktop)
        {
            return PureObjectLabel.GetName(this, desktop);
        }

        string INamedComponent.RootName
        {
            get
            {
                INamedComponent nc = this;
                return nc.GetName(nc.Desktop.Root);
            }
        }

        INamedComponent INamedComponent.Root
        {
            get { return PureObjectLabel.GetRoot(this); }
        }


        INamedComponent INamedComponent.GetRoot(IDesktop desktop)
        {
            return PureObjectLabel.GetRoot(this, desktop);
        }


        #endregion

        #region Create form members

        /// <summary>
        /// Initialization
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        /// Resize
        /// </summary>
        new public void Resize()
        {
        }

        /// <summary>
        /// Creates Form
        /// </summary>
        public void CreateForm()
        {
            form = new FormPointCollection(this);
        }

        /// <summary>
        /// Form
        /// </summary>
        public object Form
        {
            get
            {
                return form;
            }
        }

        /// <summary>
        /// Image
        /// </summary>
        public object Image
        {
            get
            {
                return ResourceImage.Indicator2D;
            }
        }

       

        /// <summary>
        /// Post operation
        /// </summary>
        public void Post()
        {
            userControlChart.Prepare(new int[,] { { 80, 30 }, { 10, 40 } }, true);
            performer = userControlChart.Performer;
            string[] names = PointCollectionChooserFactory.Factory.Names;
            comboBoxType.FillCombo(names);
            SimpleCoordinator coordinator = new SimpleCoordinator(5, 5);
            performer.Coordinator = coordinator;
            setChooser();
            string fn = series.FactoryName;
            if (fn != null)
            {
                comboBoxType.SelectCombo(fn);
            }
        }



        #endregion

        #region Members

        void setChooser()
        {
            if (chooser != null)
            {
                Control c = chooser as Control;
                Control p = c.Parent;
                p.Controls.Remove(c);
            }
            IPointFactory f = series.Factory;
            if (f == null)
            {
                return;
            }
            chooser = PointCollectionChooserFactory.Factory[f];
            chooser.Consumer = series;
            chooser.Measurements = series.Measurements;
            Control control = chooser as Control;
            this.LoadResources();
            panelParameters.Controls.Add(control);
            if (performer.Count > 0)
            {
                performer.Remove(series);
            }
            ISeriesPainter painter = f.GetPainter(performer);
            performer.AddSeries(series, painter);
            performer.Resize();
            performer.RefreshAll();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem == null)
            {
                return;
            }
            string s = comboBoxType.SelectedItem + "";
            if (s.Length == 0)
            {
                return;
            }
            series.FactoryName = s;
            setChooser();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (chooser == null)
                {
                    return;
                }
                series.Measurements = chooser.Measurements;
                performer.RefreshAll();
                Refresh();
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }
        #endregion

    }
}
