using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

using DataSetService;
using System.ComponentModel;


namespace DataSetService.Forms
{
    internal class PanelLink : Panel, ILink
    {
        #region Fields
        private readonly int shift = 30;

        private static readonly Pen pen = new Pen(Color.Black);

        private PanelColumn source;
        private PanelColumn target;

        protected string sourceTable;
        protected string targetTable;
        protected string sourceColumn;
        protected string targetColumn;
        protected CheckBox mark = new CheckBox();



        #endregion

        #region Constructors

        internal PanelLink()
        {
            Width = 100;
            Height = 30;
            mark.Top = 5;
            mark.Left = 5;
            Controls.Add(mark);
            InitializeComponent();
        }

        #endregion

        #region ILink Members

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IColumn Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value as PanelColumn;
                sourceTable = source.Table.Name;
                sourceColumn = source.Name;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IColumn Target
        {
            get
            {
                return target;
            }
            set
            {
                AbstractLink.Check(this, value);
                target = value as PanelColumn;
                targetTable = target.Table.Name;
                targetColumn = target.Name;
                add(target.Parent);
                mark.Text = source.Name + " = " + target.Name;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDataSetDesktop Desktop
        {
            get
            {
                return Parent as PanelDataSet;
            }
            set
            {
                PanelDataSet p = value as PanelDataSet;
                add(p);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SourceTable
        {
            get
            {
                return sourceTable;
            }
            set
            {
                sourceTable = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TargetTable
        {
            get
            {
                return targetTable;
            }
            set
            {
                targetTable = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SourceColumn
        {
            get
            {
                return sourceColumn;
            }
            set
            {
                sourceColumn = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TargetColumn
        {
            get
            {
                return targetColumn;
            }
            set
            {
                targetColumn = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMarked
        {
            get
            {
                return mark.Checked;
            }
            set
            {
                mark.Checked = value;
            }
        }

        public void Remove()
        {
            source.Parent.Controls.Remove(this);
            AbstractDataSetDesktop.RemoveLink(this);
        }

        #endregion

        #region Specific Members

        protected void add(Control c)
        {
            if (c == null)
            {
                return;
            }
            if (c.Controls.Contains(this))
            {
                return;
            }
            c.Controls.Add(this);
        }

        internal void Set()
        {
            int x1 = source.Xl + shift;
            int x2 = target.Xr - shift;
            int y1 = source.PosLink;
            int y2 = target.PosLink;
            int dx = Width / 2;
            int dy = Height / 2;
            Left = (x1 + x2 - Width) / 2;
            Top = (y1 + y2 - Height) / 2;
        }

        internal void Draw(Graphics g)
        {
            Set();
            int x1 = source.Xr;
            int x2 = target.Xl;
            int y1 = source.PosLink;
            int y2 = target.PosLink;
            x1 += shift;
            x2 -= shift;
            g.DrawLine(pen, source.Xl, y1, x1, y1);
            g.DrawLine(pen, x1, y1, x2, y2);
            g.DrawLine(pen, x2, y2, target.Xr, y2);
 
        }


        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PanelLink
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelLink_Paint);
            this.ResumeLayout(false);

        }

        private void PanelLink_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }

    }
}
