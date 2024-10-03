using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;

using CategoryTheory;
using Diagram.UI.Labels;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Utils;

using SerializationInterface;

using Motion6D;
using Motion6D.UI;
using Motion6D.Drawing.Interfaces;

namespace Motion6D.UI.Labels
{
    /// <summary>
    /// Label for indication of points
    /// </summary>
    [Serializable()]
    public partial class PositionsIndicatorLabel : UserControl,
        IObjectLabel, IRedraw, ISerializable, IBlocking, INonstandardLabel
    {
        #region Fields

        private PositionCollectionIndicator indicator;
        private IPointsIndicator pIndicator;
        private bool blocked = true;
        private string name = "";

        private IDesktop desktop;


        private FormPositionsIndicator form;

        private string indicatorType = "";

        private ComboBox comboBoxType;
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PositionsIndicatorLabel()
        {
            InitializeComponent();
            comboBoxType = userControlComboboxListLeft.Boxes[0];
        }



        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected PositionsIndicatorLabel(SerializationInfo info, StreamingContext context)
            : this()
        {
            indicatorType = info.Deserialize<string>("Type");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<string>("Type", indicatorType);
        }

        #endregion

        #region IRedraw Members

        void IRedraw.Redraw()
        {
            if (blocked)
            {
                return;
            }
            if (pIndicator != null)
            {
                if (pIndicator is IRedraw)
                {
                    IRedraw r = pIndicator as IRedraw;
                    r.Redraw();
                }
            }
        }

        #endregion
 
        #region IBlocking Members

        bool IBlocking.IsBlocked
        {
            get
            {
                return blocked;
            }
            set
            {
                if (blocked == value)
                {
                    return;
                }
                blocked = value;
                /*if (blocked)
                {
                    pan.Paint -= paintC;
                    return;
                }
                pan.Paint += paintC;*/
            }
        }

        #endregion

        #region IObjectLabel Members

        ICategoryObject IObjectLabel.Object
        {
            get
            {
                return indicator;
            }
            set
            {
                indicator = value.GetObject<PositionCollectionIndicator>();
            }
        }

        #endregion

        #region INamedComponent Members

        string INamedComponent.Name
        {
            get { return name; }
        }

        string INamedComponent.Kind
        {
            get { return ""; }
        }

        string INamedComponent.Type
        {
            get { return "Motion6D.PositionCollectionIndicator"; }
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
                throw new Exception("You should not set parent to UI component");
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
        /// Creates editor form
        /// </summary>
        public void CreateForm()
        {
            form = new FormPositionsIndicator(this);
        }

        /// <summary>
        /// Editor form
        /// </summary>
        public object Form
        {
            get
            {
                return form;
            }
        }

        /// <summary>
        /// Icon image
        /// </summary>
        public object Image
        {
            get
            {
                return ResourceImage.Indicator3D;
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public void Post()
        {
            string[] s = SimplePointsIdicator.Indicator[indicator];
            comboBoxType.FillCombo(s);
            comboBoxType.SelectCombo( indicatorType);
            comboBoxType.SelectedIndexChanged +=
                comboBoxType_SelectedIndexChanged;
            if (indicatorType.Length > 0)
            {
                pIndicator = SimplePointsIdicator.Indicator[indicatorType];
                if (indicator != null)
                {
                    pIndicator.Positions = indicator;
                    Control c = pIndicator as Control;
                    panelChart.Controls.Add(c);
                    pIndicator.Blocked = false;
                }
            }
        }



        #endregion


        #region Members

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string s = comboBoxType.SelectedItem + "";
                if (s.Length == 0)
                {
                    return;
                }
                if (pIndicator != null)
                {
                    Control cont = pIndicator as Control;
                    panelChart.Controls.Remove(cont);
                }
                pIndicator = SimplePointsIdicator.Indicator[s];
                pIndicator.Positions = indicator;
                Control c = pIndicator as Control;
                panelChart.Controls.Add(c);
                indicatorType = s;
                pIndicator.Blocked = false;
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }


        #endregion


    }
}
