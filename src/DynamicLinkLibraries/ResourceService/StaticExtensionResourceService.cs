using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ResourceService
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    public static class StaticExtensionResourceService
    {
        /// <summary>
        /// Loads resources strings to control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="resources">The resources</param>
        public static void LoadControlResources(this Control control, Dictionary<string, object>[] resources)
        {
            if (control == null)
            {
                return;
            }
            if (resources == null)
            {
                return;
            }
            ContextMenuStrip cms = control.ContextMenuStrip;
            if (cms != null)
            {
                LoadControlResources(cms, resources);
            }
            if (control is TreeView)
            {
                TreeView tv = control as TreeView;
                foreach (TreeNode tn in tv.Nodes)
                {
                    Resources.LoadControlResources(tn, resources);
                }
            }
            if (!(control is TextBox) & !(control is WebBrowser))
            {
                control.Text = ResourceService.Resources.GetControlResource(control.Text, resources);
            }
            foreach (Control c in control.Controls)
            {
                LoadControlResources(c, resources);
            }
      /*      if (control is DataGrid)
            {
                DataGrid grid = control as DataGrid;
                if (grid.DataSource is DataTable)
                {
                    DataTable table = grid.DataSource as DataTable;
                    foreach (DataColumn col in table.Columns)
                    {
                        col.ColumnName = ResourceService.Resources.GetControlResource(col.ColumnName, resources);
                    }
                }
            }*/
            if (control is DataGridView)
            {
                DataGridView dgv = control as DataGridView;
                Resources.LoadDataControlResourses(dgv, resources);
            }
            if (control is ListView)
            {
                ListView lv = control as ListView;
                foreach (ColumnHeader ch in lv.Columns)
                {
                    ch.Text = ResourceService.Resources.GetControlResource(ch.Text, resources);
                }
            }
            if (control is Form)
            {
                Form form = control as Form;
                MenuStrip menu = form.MainMenuStrip;
                if (menu != null)
                {
                    foreach (ToolStripItem item in menu.Items)
                    {
                        Resources.LoadMenuResourcesInternal(item, resources);
                    }
                }
            }
            if (control is TabControl)
            {
                TabControl tc = control as TabControl;
                foreach (TabPage page in tc.TabPages)
                {
                    page.Text = ResourceService.Resources.GetControlResource(page.Text, resources);
                }
            }
            if (control is MenuStrip)
            {
                MenuStrip ms = control as MenuStrip;
                foreach (ToolStripItem it in ms.Items)
                {
                    Resources.LoadToolMenuItem(it, resources);
                }
            }
            if (control is ToolStrip)
            {
                ToolStrip ts = control as ToolStrip;
                ToolStripItemCollection coll = ts.Items;
                Resources.LoadResources(coll, resources);
            }
        }

        /// <summary>
        /// Loads resources strings to controls
        /// </summary>
        /// <param name="controls">Controls</param>
        /// <param name="resources">The resources</param>
        public static void LoadControlResources(this IEnumerable<Control> controls, Dictionary<string, object>[] resources)
        {
            foreach (Control control in controls)
            {
                control.LoadControlResources(resources);
            }
        }
   }
}