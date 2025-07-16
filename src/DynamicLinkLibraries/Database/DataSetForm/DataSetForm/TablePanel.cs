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
    internal class PanelTable : Panel, ITable
    {

        #region Fields
        static internal readonly int panelWidth = 150;
        static internal readonly int panelTop = 30;
        static readonly Brush brush = new SolidBrush(Color.Blue);
        static readonly Brush pbrush = new SolidBrush(Color.White);
        static internal readonly Font font = new Font("Times", 15);
        Dictionary<string, IColumn> columns = new Dictionary<string, IColumn>();
        DataTable table;
        bool isMoved;
        int mouseX;
        int mouseY;
        const int MaxHeight = 400;
        Panel pTop = new Panel();
        Panel pLeft = new Panel();
        Panel pRight = new Panel();
        Panel pBottom = new Panel();
        Panel pCenter = new Panel();

        
        #endregion

        #region ITable Members


        public Dictionary<string, IColumn> Columns
        {
            get
            {
                return columns;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int X
        {
            get
            {
                return Left;
            }
            set
            {
                Left = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Y
        {
            get
            {
                return Top;
            }
            set
            {
                Top = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable Table
        {
            get
            {
                return table;
            }
            set
            {
                table = value;
            }
        }

        public void Remove()
        {
            AbstractDataSetDesktop.RemoveTable(this);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDataSetDesktop Desktop
        {
            get
            {
                return Parent as IDataSetDesktop;
            }
            set
            {
                if (Parent == null)
                {
                    Control c = value as Control;
                    if (!c.Controls.Contains(this))
                    {
                        c.Controls.Add(this);
                    }
                }
            }
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TablePanel
            // 
           /* this.Paint += new System.Windows.Forms.PaintEventHandler(this.TablePanel_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TablePanel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TablePanel_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TablePanel_MouseDown);
            this.ResumeLayout(false);*/

        }

        private void TablePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(brush, 0, 0, Width, Height);
            g.DrawString(Name, font, pbrush, 3, 3); 

        }

        internal void init()
        {
            InitializeComponent();
            pTop.Height = panelTop;
            Width = panelWidth;
            pTop.Dock = DockStyle.Top;
            pTop.Paint += TablePanel_Paint;
            pTop.MouseMove += TablePanel_MouseMove;
            pTop.MouseUp += TablePanel_MouseUp;
            pTop.MouseDown += TablePanel_MouseDown;
            pLeft.Width = 1;
            pLeft.Dock = DockStyle.Left;
            pRight.Width = 1;
            pRight.Dock = DockStyle.Right;
            pBottom.Height = 1;
            pBottom.Dock = DockStyle.Bottom;
            //pCenter.Dock = DockStyle.Fill;
            pRight.BackColor = Color.Black;
            pLeft.BackColor = Color.Black;
            pTop.BackColor = Color.Black;
            pBottom.BackColor = Color.Black;
            pCenter.BackColor = Color.Black;
            Controls.Add(pTop);
            Controls.Add(pBottom);
            Controls.Add(pLeft);
            Controls.Add(pRight);
            Controls.Add(pCenter);
            int y = 1;
            foreach (IColumn c in columns.Values)
            {
                PanelColumn col = c as PanelColumn;
                col.Left = 1;
                col.Width = Width - 2;
                col.Top = y;
                col.init();
                col.BackColor = Color.White;
                pCenter.Controls.Add(col);
                y = col.Top + col.Height;
                /*Panel p = new Panel();
                p.Width = Width;
                p.Height = 2;
                p.BackColor = Color.White;
                p.Top = y;
                pCenter.Controls.Add(p);*/
                y = col.Bottom + 2;
            }
            Height = y + pTop.Bottom + 2;
            if (y > MaxHeight)
            {
                Height = MaxHeight;
                pCenter.AutoScroll = true;
                pCenter.Scroll += pCenter_Scroll;

            }
            pCenter.Top = pTop.Height + 1;
            pCenter.Left = pLeft.Width + 1;
            pCenter.Width = Width - pLeft.Width - pRight.Width - 2;
            pCenter.Height = Height - pTop.Height - pBottom.Height - 2;
        }

        void pCenter_Scroll(object sender, ScrollEventArgs e)
        {
            Parent.Refresh();
        }


        private void TablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            isMoved = true;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void TablePanel_MouseUp(object sender, MouseEventArgs e)
        {
            isMoved = false;
            if (e.Button == MouseButtons.Right)
            {
                PanelDataSet p = Parent as PanelDataSet;
                Remove();
                p.Invalidate();
            }
        }

        private void TablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMoved)
            {
                return;
            }
            Left += e.X - mouseX;
            Top += e.Y - mouseY;
            PanelDataSet p = Parent as PanelDataSet;
            p.Set();
            p.Invalidate();
        }

        internal PanelColumn Get(int x, int y)
        {
            foreach (PanelColumn c in Columns.Values)
            {
                if (c.Get(x, y))
                {
                    return c;
                }
            }
            return null;
        }
    }
}
