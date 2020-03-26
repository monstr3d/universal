using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using DataPerformer;


namespace DataPerformer.UI.Labels
{
    /// <summary>
    /// Label of 2D Table
    /// </summary>
    [Serializable()]
    public partial class Table2DLabel : UserControl,
        IObjectLabel, ISerializable, INonstandardLabel
    {
        #region Fields

        private Table2D table;

        private IDesktop desktop;

        private Forms.FormTable2D form;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Table2DLabel()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Table2DLabel(SerializationInfo info, StreamingContext context) : 
            this()
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
                return table;
            }
            set
            {
                table = value.GetSource<Table2D>();
                value.Object = this;
                checkBoxOut.Checked = table.ThrowsOutOfRangeException;
                checkBoxOut.CheckedChanged += checkBoxOut_CheckedChanged;
            }
        }

        #endregion

        #region INamedComponent Members

        string INamedComponent.Name
        {
            get { return this.GetRootLabel().Name; }
        }

        string INamedComponent.Kind
        {
            get { return ""; }
        }

        string INamedComponent.Type
        {
            get { return "DataPerformer.Table2D"; }
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
        /// Creates Form
        /// </summary>
        public void CreateForm()
        {
            form = new Forms.FormTable2D(this.GetRootLabel(), Accept, table);
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
                return ResourceImage.Table2D.ToBitmap();
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public void Post()
        {
            Accept();
            if (table != null)
            {
                userControlTable2D.Table = table;
            }
        }



        #endregion

        #region Members

        private void open()
        {
            userControlTable2D.Open();
        }

        private void save()
        {
            userControlTable2D.Save();
        }

        #endregion

        #region Event Handlers

        private void panelBootomHigh_Resize(object sender, EventArgs e)
        {
            labelX.Width = panelTopHigh.Width - labelX.Width - 1;
            labelY.Width = panelTopHigh.Width - labelY.Width - 1;
        }

        private void userControlTable2D_Load(object sender, EventArgs e)
        {
            if (table != null)
            {
                userControlTable2D.Table = table;
            }
        }

 
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            open();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            save();
        }

        internal void Accept()
        {
            string[] s = table.Arguments;
            Label[] l = new Label[] { labelX, labelY };
            for (int i = 0; i < 2; i++)
            {
                if (s[i] != null)
                {
                    if (s[i].Length == 0)
                    {
                        s[i] = null;
                    }
                }
            }
            if (s[0] == null | s[1] == null)
            {
                labelX.Visible = false;
                labelY.Visible = false;
                int delta = checkBoxOut.Top - 2;
                panelBottom.Height = panelBottom.Height - delta;
                checkBoxOut.Top = checkBoxOut.Top - delta + 2;
                return;
            }
            string[] ss = new string[] { "X=", "Y=" };
            for (int i = 0; i < 2; i++)
            {
                string ts = s[i];
                if (ts != null)
                {
                    l[i].Text = ss[i] + ts;
                }
            }
        }


        private void checkBoxOut_CheckedChanged(object sender, EventArgs e)
        {
            table.ThrowsOutOfRangeException = checkBoxOut.Checked;
        }

        #endregion

    }
}