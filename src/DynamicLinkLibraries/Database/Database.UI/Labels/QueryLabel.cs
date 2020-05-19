using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using DataSetService;


using Database.UI.Forms;
using Web.Interfaces;


namespace Database.UI.Labels
{
    /// <summary>
    /// Label for query object
    /// </summary>
    [Serializable()]
    public partial class QueryLabel : UserControl, ISerializable,
        IObjectLabel, INonstandardLabel
    {
        #region Fields

        protected IDataSetProvider provider;

        bool showTable = false;

        protected Form form;

        private IDesktop desktop;

        static protected Diagram.UI.Interfaces.IUIFactory factory;

        #endregion

        #region Ctor

        public QueryLabel()
        {
            InitializeComponent();
        }


        protected QueryLabel(SerializationInfo info, StreamingContext context)
            : this()
        {
            ResourceService.Resources.LoadControlResources(this, Database.UI.Utils.ControlUtilites.Resources);
            showTable = (bool)info.GetValue("ShowTable", typeof(bool));
            checkBoxShowData.Checked = showTable;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ShowTable", showTable, typeof(bool));
        }

        #endregion

        #region IObjectLabel Members

        /// <summary>
        /// Object
        /// </summary>
        public virtual ICategoryObject Object
        {
            get
            {
                return provider as ICategoryObject;
            }
            set
            {
                if (!(value is StatementWrapper))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                provider = value as StatementWrapper;
                value.Object = this;
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

        public virtual string Type
        {
            get { return typeof(StatementWrapper).FullName; }
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

        #region INonstandardLabel Members

        void INonstandardLabel.Initialize()
        {
        }

        void INonstandardLabel.Post()
        {
            ShowNumber();
            ShowTable();
            checkBoxShowData.CheckedChanged += checkBoxShowData_CheckedChanged;
        }

        void INonstandardLabel.Resize()
        {
        }

        /// <summary>
        /// Creates Form
        /// </summary>
        public virtual void CreateForm()
        {
            object o = factory.GetAdditionalFeature<IUrlConsumer>(provider as IAssociatedObject);
            if (o is Control)
            {
                form = new FormExternalData(this.GetRootLabel(), o as Control);
                return;
            }
            form = new FormStatementWrapper(this.GetRootLabel(), checkBoxShowData.Checked,
                ShowNumber, ShowTable);
        }

        object INonstandardLabel.Form
        {
            get { return form; }
        }

        /// <summary>
        /// Associated image
        /// </summary>
        public virtual object Image
        {
            get { return ResourceImage.Query; }
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Shows number of rows
        /// </summary>
        protected void ShowNumber()
        {
            DataTable t = Table;
            if (t == null)
            {
                return;
            }
            labelNumber.Text =
                ResourceService.Resources.GetControlResource("Number of rows: ",
                Database.UI.Utils.ControlUtilites.Resources) + t.Rows.Count;

        }

        /// <summary>
        /// Shows table
        /// </summary>
        /// <param name="show">The "show" sign</param>
        protected void ShowTable(bool show)
        {
            checkBoxShowData.Checked = show;
        }


        #endregion

        #region Event Handlers

        private void checkBoxShowData_CheckedChanged(object sender, EventArgs e)
        {
            showTable = checkBoxShowData.Checked;
            ShowTable();
        }

        #endregion

        #region Private & Internal Members

        static internal Diagram.UI.Interfaces.IUIFactory Factory
        {
            set
            {
                factory = value;
            }
        }

        private void Check(bool b)
        {
            checkBoxShowData.Checked = b;
        }

        private DataTable Table
        {
            get
            {
                DataSet ds = provider.DataSet;
                if (ds == null)
                {
                    return null;
                }
                if (ds.Tables.Count == 0)
                {
                    return null;
                }
                return ds.Tables[0];
            }
        }

        private void ShowTable()
        {
            if (showTable)
            {
                DataTable t = Table;
                if (t == null)
                {
                    dataGridViewTable.DataMember = null;
                    return;
                }
                dataGridViewTable.DataSource = provider.DataSet;
                dataGridViewTable.DataMember = t.TableName;
                return;
            }
            dataGridViewTable.DataMember = null;
        }

        #endregion

    }
}
