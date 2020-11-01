using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



using CategoryTheory;
using ResourceService;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;


namespace Diagram.UI.UserControls
{
    /// <summary>
    /// Control for container designer
    /// </summary>
    public partial class UserControlContainerDesigner : UserControl
    {

        #region Fields

        private IDesktop desktop;

        private List<object> comp;


        private Hashtable table = new Hashtable();

        private ArrayList selected = new ArrayList();

        const int shift = 2;

        const int wP = 10;
        const int hP = 10;

        ObjectContainerBase container;

        

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlContainerDesigner()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates container
        /// </summary>
        /// <param name="cont">The container to update</param>
        public void Update(ObjectContainerBase cont)
        {
            IDesktop desk = cont.Desktop;
            foreach (INamedComponent nc in selected)
            {
                if (!table.ContainsKey(nc))
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, Resources.GetControlResource("Element ", ControlUtilites.Resources)
                    + nc.Name +
                    Resources.GetControlResource(" is abscent", ControlUtilites.Resources));
                    return;
                }
                object[] o = table[nc] as object[];
                Panel p = o[0] as Panel;
                string comm = o[1] + "";
                desktop.SetParents();
                string nam = nc.GetName(desktop);
                desk.SetParents();
                INamedComponent comp = desk[nam];
                cont.Add(comp, p.Left - panelLabelPeer.Left, p.Top - panelLabelPeer.Top, comm);
            }
        }

        /// <summary>
        /// Fills container
        /// </summary>
        /// <param name="cont">The container to fill</param>
        public void Fill(ObjectContainerBase cont)
        {
            checkedListBoxInter.Items.Clear();
            //Desktop = cont.Desktop;
            container = cont;
            Dictionary<string,object> t = container.Interface;
            List<string> keys = new List<string>();
            foreach (string key in t.Keys)
            {
                keys.Add(key);
            }
            this.desktop = cont.Desktop;
            comp = new List<object>(desktop.GetAllObjects());
            foreach (INamedComponent nc in comp)
            {
                string name = nc.GetName(desktop);
                bool ch = keys.Contains(name);
                checkedListBoxInter.Items.Add(nc.GetName(desktop), ch);
            }
            fillCombo();
            foreach (string s in keys)
            {
                object[] o = t[s] as object[];
                Panel pan = new Panel();
                pan.Width = wP;
                pan.Height = hP;
                pan.BackColor = Color.Red;
                pan.Left = panelLabelPeer.Left + (int)o[0];
                pan.Top = panelLabelPeer.Top + (int)o[1];
                IDesktop d = cont.Desktop;
                ToolTip tt = new ToolTip();
                tt.ShowAlways = true;
                tt.SetToolTip(pan, s + " :: " + textBoxComment.Text);
                panelDrawing.Controls.Add(pan);
                table[o] = new object[] { pan, textBoxComment.Text };
            }
        }

        /// <summary>
        /// Distance of splitter
        /// </summary>
        public int SplitterDistance
        {
            get
            {
                return splitContainerMain.SplitterDistance;
            }
            set
            {
                splitContainerMain.SplitterDistance = value;
            }
        }

        /// <summary>
        /// Container
        /// </summary>
        new public ObjectContainer Container
        {
            get
            {
                PureDesktopPeer desk = new PureDesktopPeer();
                desk.Copy(desktop.Objects, desktop.Arrows, false);
                ObjectContainer c = new ObjectContainer(desk);
                Update(c);
                return c;
            }
        }


        internal IDesktop Desktop
        {
            set
            {
                this.desktop = value;
                comp = new List<object>(desktop.GetAllObjects());
                foreach (INamedComponent nc in comp)
                {
                    checkedListBoxInter.Items.Add(nc.GetName(desktop));
                }

            }
        }


        private void buttonAcceptInterfaces_Click(object sender, System.EventArgs e)
        {
            selected.Clear();
            if (container != null)
            {
                container.Interface.Clear();
            }
            ICollection check = checkedListBoxInter.CheckedIndices;
            foreach (int i in check)
            {
                selected.Add(comp[i]);
            }
            fillCombo();
            List<Control> l = new List<Control>();
            foreach (Control c in panelDrawing.Controls)
            {
                if (c != panelLabelPeer)
                {
                    l.Add(c);
                }
            }
            foreach (Control c in l)
            {
                panelDrawing.Controls.Remove(c);
            }
        }

        void ClearInterPanel()
        {
            List<Control> l = new List<Control>();
            foreach (Control c in panelDrawing.Controls)
            {
                if (c != panelLabelPeer)
                {
                    l.Add(c);
                }
            }
            foreach (Control c in l)
            {
                panelDrawing.Controls.Remove(c);
            }
        }

        private void fillCombo()
        {
            comboBoxInter.Items.Clear();
            table.Clear();
            foreach (INamedComponent nc in selected)
            {
                comboBoxInter.Items.Add(nc.GetName(desktop));
            }
        }

        private void comboBoxInter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int n = comboBoxInter.SelectedIndex;
            object o = selected[n];
            if (!table.ContainsKey(o))
            {
                return;
            }
            object[] ob = table[o] as object[];
            blackPanels();
            Panel p = ob[0] as Panel;
            p.BackColor = Color.Red;
            textBoxComment.Text = ob[1] as string;
        }

        private ICollection Panels
        {
            get
            {
                ArrayList c = new ArrayList(panelDrawing.Controls);
                c.Remove(panelLabelPeer);
                return c;
            }
        }

        private void blackPanels()
        {
            ICollection c = Panels;
            foreach (Panel comp in c)
            {
                comp.BackColor = Color.Black;
            }
        }

        private void panelDrawing_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int n = comboBoxInter.SelectedIndex;
            if (n < 0)
            {
                return;
            }
            INamedComponent o = selected[n] as INamedComponent;
            blackPanels();
            if (table.ContainsKey(o))
            {
                object[] ob = table[o] as object[];
                Panel p = ob[0] as Panel;
                p.Left = e.X;
                p.Top = e.Y;
                ob[1] = this.textBoxComment.Text;
                return;
            }
            Panel pan = new Panel();
            pan.Width = wP;
            pan.Height = hP;
            pan.BackColor = Color.Red;
            pan.Left = e.X;
            pan.Top = e.Y;
            ToolTip t = new ToolTip();
            t.ShowAlways = true;
            t.SetToolTip(pan, o.GetName(desktop) + " :: " + textBoxComment.Text);
            panelDrawing.Controls.Add(pan);
            table[o] = new object[] { pan, textBoxComment.Text };
        }

        private void save(Stream stream, string type)
        {
            try
            {
                ObjectContainer c = Container;
                BinaryFormatter f = new BinaryFormatter();
                c.Type = type;
                f.Serialize(stream, c);
                stream.Close();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
            desktop.SetParents();

        }

        private void save(string filename)
        {
            Stream stream = File.OpenWrite(filename);
            save(stream, filename);
        }

        void saveAs()
        {
            try
            {
                if (saveFileDialogContainer.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
              //  int n = saveFileDialogContainer.FileName.LastIndexOf("\\") + 1;
              //  string fn = saveFileDialogContainer.FileName.Substring(n);
                save(saveFileDialogContainer.FileName);
            }
            catch (Exception e)
            {
                e.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        private void menuItemSaveAs_Click(object sender, System.EventArgs e)
        {
            saveAs();
        }

        private void align()
        {
            List<Panel> left = new List<Panel>();
            List<Panel> right = new List<Panel>();
            List<Panel> top = new List<Panel>();
            List<Panel> bottom = new List<Panel>();
            Panel pl = panelLabelPeer;
            foreach (object[] o in table.Values)
            {
                Panel p = o[0] as Panel;
                if (p.Right < pl.Left)
                {
                    left.Add(p);
                    continue;
                }
                if (p.Left > pl.Right)
                {
                    right.Add(p);
                    continue;
                }
                if (p.Bottom < pl.Top)
                {
                    top.Add(p);
                }
                if (p.Top > pl.Top)
                {
                    bottom.Add(p);
                }
            }
            bool[] ba = { true, true, false, false };
            List<Panel>[] ll = new List<Panel>[] { left, right, top, bottom };
            int[] coord = new int[] { pl.Left - wP - shift, pl.Right + shift, pl.Top - hP - shift, pl.Bottom + shift };
            for (int i = 0; i < ll.Length; i++)
            {
                bool b = ba[i];
                List<Panel> li = ll[i];
                List<Panel> lo = Get(li, b);
                int coo = coord[i];
                if (b)
                {
                    alignVert(lo, coo);
                }
                else
                {
                    alignHor(lo, coo);
                }
            }

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        private void buttonAlignment_Click(object sender, EventArgs e)
        {
            align();
        }

        private List<Panel> Get(List<Panel> l, bool vert)
        {
            Dictionary<int, Panel> dp = new Dictionary<int, Panel>();
            foreach (Panel p in l)
            {
                int k = (vert) ? p.Top : p.Left;
                dp[k] = p;
            }
            List<int> ln = new List<int>(dp.Keys);
            ln.Sort(compare);
            List<Panel> lp = new List<Panel>();
            foreach (int i in ln)
            {
                lp.Add(dp[i]);
            }
            return lp;
        }

        int compare(int x, int y)
        {
            return x - y;
        }

        void alignVert(List<Panel> l, int left)
        {
            if (l.Count == 0)
            {
                return;
            }
            if (l.Count == 1)
            {
                l[0].Left = left;
                l[0].Top = (panelLabelPeer.Top + panelLabelPeer.Bottom - l[0].Height) / 2;
                return;
            }
            int top = panelLabelPeer.Top;
            int bottom = panelLabelPeer.Bottom - hP;
            double k = ((double)(bottom - top)) / ((double)(l.Count - 1));
            for (int i = 0; i < l.Count; i++)
            {
                Panel p = l[i];
                p.Left = left;
                int t = top + (int)(i * k);
                p.Top = t;
            }
        }

        void alignHor(List<Panel> l, int top)
        {
            if (l.Count == 0)
            {
                return;
            }
            if (l.Count == 1)
            {
                l[0].Top = top;
                l[0].Left = (panelLabelPeer.Left + panelLabelPeer.Right - l[0].Width) / 2;
                return;
            }
            int left = panelLabelPeer.Left;
            int right = panelLabelPeer.Right - hP;
            double k = ((double)(right - left)) / ((double)(l.Count - 1));
            for (int i = 0; i < l.Count; i++)
            {
                Panel p = l[i];
                p.Top = top;
                int le = left + (int)(i * k);
                p.Left = le;
            }
        }

        private void buttonAcceptAll_Click(object sender, EventArgs e)
        {
            if (container != null)
            {
                Update(container);
            }
        }
    }
}
