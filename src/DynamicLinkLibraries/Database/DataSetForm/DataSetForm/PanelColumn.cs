using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using DataSetService;
using System.ComponentModel;


namespace DataSetService.Forms
{
    internal class PanelColumn : Panel, IColumn
    {

        #region Fields
        
        protected ITable table;
        protected DataColumn column;
        protected CheckBox mark = new CheckBox();
        private CheckBox cbNull = null;
        protected string type;

        protected bool isNullable = false;

        protected bool isNull = false;


        protected ComboBox cbMod = new ComboBox();
        protected TextBox val = new TextBox();
        protected string mod = "";

        protected int length;



        #endregion

        #region IColumn Members

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ITable Table
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataColumn Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNullable
        {
            get { return cbNull != null; }
            set 
            {
                if (value)
                {
                    cbNull = new CheckBox();
                    cbNull.Text = "Is not null";
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNull
        {
            get 
            {
                if (cbNull != null)
                {
                    return !cbNull.Checked;
                }
                return false;
            }
            set 
            {
                if (cbNull != null)
                {
                    cbNull.Checked = !value;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Modifier
        {
            get 
            { 
                return cbMod.SelectedItem + ""; 
            }
            set 
            {
                mod = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Value
        {
            get 
            { 
                return val.Text; 
            }
            set 
            { 
                val.Text = value; 
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
   
        #endregion

        #region Specific Members

        internal void init()
        {
            InitializeComponent();
            Label l = new Label();
            IColumn col = this;
            l.Text = col.Name;
            l.Top = 2;
            l.Left = 2;
            Controls.Add(l);
            l.Height = 20;
            l.MouseUp += PanelColumn_MouseUp;
            int y = l.Bottom + 3;
            if (type != null)
            {
                Label lab = new Label();
                lab.Text = type + "";
                lab.Top = y;
                Controls.Add(lab);
                lab.MouseUp += PanelColumn_MouseUp;
                lab.Height = 20;
                y = lab.Bottom + 12;
            }
            mark.Left = 2;
            mark.Top = y;
            mark.Width = 10;
            mark.Height = 10;
            Controls.Add(mark);
            Height = mark.Bottom + 5;
            if (cbNull != null)
            {
                cbNull.Top = Height;
                cbNull.Left = mark.Left;
                Controls.Add(cbNull);
                Height = cbNull.Bottom + 5;
            }
            initMod();
            cbMod.Top = Height;
            cbMod.Left = mark.Left;
            cbMod.Width = 50;
            Controls.Add(cbMod);
            val.Left = cbMod.Right + 5;
            val.Top = cbMod.Top;
            val.Width = Width - val.Left - 40;
            Controls.Add(val);
            Height = cbMod.Bottom + 5;
        }

        private void initMod()
        {
            string[] mods = DataSetFactoryPerformer.GetModifiers(type);
            foreach (string s in mods)
            {
                cbMod.Items.Add(s);
            }
            for (int i = 0; i < cbMod.Items.Count; i++)
            {
                if (mod.Equals(cbMod.Items[i] + ""))
                {
                    cbMod.SelectedIndex = i;
                    return;
                }
            }
        }


        internal int Xl
        {
            get
            {
                Control c = this;
                while (true)
                {
                    if (c.Parent is PanelDataSet)
                    {
                        break;
                    }
                    c = c.Parent;
                }
                return c.Left;
            }
        }

        internal int Xr
        {
            get
            {
                Control c = this;
                while (true)
                {
                    if (c.Parent is PanelDataSet)
                    {
                        break;
                    }
                    c = c.Parent;
                }
                return c.Right;
            }
        }

        internal int Yp
        {
            get
            {
                //Panel par = Parent as Panel;
                //int y = par.Top ;//- par.;
                return PosY + Width / 2;
            }
        }

        internal int PosX
        {
            get
            {
                return Xl;
            }
        }

        internal int PosY
        {
            get
            {
                int t = Top;
                Control c = this;
                while (true)
                {
                    Control pp = c.Parent;
                    if (pp is PanelDataSet)
                    {
                        return t;
                    }
                    t += pp.Top;
                    c = pp;
                }
            }
        }

        internal int PosLink
        {
            get
            {
                int y = PosY;
                PanelTable pt = Table as PanelTable;
                if (y < 0 | y > pt.Bottom)
                {
                    if (y < 0)
                    {
                        return pt.Top + 30;
                    }
                    return pt.Bottom - 30;
                }
                return y + 30;
            }
        }

        internal bool Get(int x, int y)
        {
            Control p = Parent;
            int xx = PosX;
            int l = xx + Left;
            int r = xx + Right;
            /*int t = p.Top;
            Control par = p.Parent;
            t += par.Top;
            t += Top;*/
            int t = PosY;
            int b = t + Height;
            if (x > l & x < r & y > t & y < b)
            {
                return true;
            }
            return false;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PanelColumn
            // 
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelColumn_MouseUp);
            this.ResumeLayout(false);

        }

        private void PanelColumn_MouseUp(object sender, MouseEventArgs e)
        {
            int x = Xl + e.X;
            int y = PosY + e.Y;
            if (sender is Label)
            {
                Label l = sender as Label;
                x += l.Left;
                y += l.Top;
            }
            PanelDataSet p = Parent.Parent.Parent as PanelDataSet;
            PanelColumn c = p.Get(x, y);
            if (c == null)
            {
                return;
            }
            PanelLink link = new PanelLink();
            try
            {
                link.Source = this;
                link.Target = c;
                p.Links.Add(link);
                link.Desktop = p;
                link.Set();
                p.Invalidate();
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}
