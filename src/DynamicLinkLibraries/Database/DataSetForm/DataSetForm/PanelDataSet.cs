using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

using DataSetService;

namespace DataSetService.Forms
{
    /// <summary>
    /// Desktop pabel
    /// </summary>
    public class PanelDataSet : Panel, IDataSetDesktop
    {
        private static readonly Brush brush = new SolidBrush(Color.White);
        Dictionary<string, ITable> tables = new Dictionary<string, ITable>();
        List<ILink> links = new List<ILink>();

        #region IDataSetDesktop Members

        /// <summary>
        /// Dictionary of tables
        /// </summary>
        public Dictionary<string, ITable> Tables
        {
            get
            {
                return tables;
            }
        }

        /// <summary>
        /// Links
        /// </summary>
        public List<ILink> Links
        {
            get 
            {
                return links;
            }
        }

        /// <summary>
        /// Removes table
        /// </summary>
        /// <param name="table">Table for removing</param>
        public void Remove(ITable table)
        {
            tables.Remove(table.Name);
            Control c = table as Control;
            Controls.Remove(c);
        }

        /// <summary>
        /// Removes linlk
        /// </summary>
        /// <param name="link">Link for removing</param>
        public void Remove(ILink link)
        {
            links.Remove(link);
            Control c = link as Control;
            Controls.Remove(c);
        }

        #endregion

        /// <summary>
        /// Initialization
        /// </summary>
        public void Init()
        {
            foreach (PanelTable pan in tables.Values)
            {
                pan.init();
                if (!Controls.Contains(pan))
                {
                    Controls.Add(pan);
                }
            }
            foreach (PanelLink pan in links)
            {
                if (!Controls.Contains(pan))
                {
                    Controls.Add(pan);
                }
            }
            InitializeComponent();
        }

        /// <summary>
        /// Copies itfelf
        /// </summary>
        /// <param name="factory">Fasctory</param>
        /// <returns>The copy</returns>
        public IDataSetDesktop Save(IDataSetDesktopFactory factory)
        {
            return factory.Copy(this);
        }

        internal static PanelDataSet Load(IDataSetDesktop desktop)
        {
            PanelDataFactory f = PanelDataFactory.Object;
            PanelDataSet p = f.Copy(desktop) as PanelDataSet;
            p.Init();
            p.Set();
            return p;
        }

        internal void Clear()
        {
            List<ITable> tables = new List<ITable>(Tables.Values);
            foreach (ITable t in tables)
            {
                t.Remove();
            }
        }


        internal PanelColumn Get(int x, int y)
        {
            foreach (PanelTable t in Tables.Values)
            {
                PanelColumn p = t.Get(x, y);
                if (p != null)
                {
                    return p;
                }
            }
            return null;
        }

        internal void Set()
        {
            foreach (PanelLink l in Links)
            {
                l.Set();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PanelDataSet
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDataSet_Paint);
            this.ResumeLayout(false);

        }

        private void PanelDataSet_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(brush, 0, 0, Width, Height);
            foreach (PanelLink link in Links)
            {
                link.Draw(g);
            }
        }
    }
}
