using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Drawing;
using System.Xml;

namespace ResourceService
{
	/// <summary>
	/// Directory.
	/// </summary>
	public static class Resources
	{
		/// <summary>
		/// CurrentDirectory
		/// </summary>
		static private string currentDirectory;

		/// <summary>
		/// Control resources
		/// </summary>
		static private Dictionary<string, object> controlResources = new Dictionary<string, object>();

		/// <summary>
		/// Control resources
		/// </summary>
		static private Dictionary<string, object> resources = new Dictionary<string, object>();

        /// <summary>
        /// Resources of attributes
        /// </summary>
        static internal Dictionary<string, string> attributeResources = new Dictionary<string, string>();


        /// <summary>
        /// Writes of missing strings
        /// </summary>
        static private StreamWriter missWriter;


        /// <summary>
        /// Writes missing strings
        /// </summary>
        static public StreamWriter MissWriter
        {
            set
            {
                missWriter = value;
            }
            get
            {
                return missWriter;
            }
        }

        /// <summary>
        /// Resources of attributes
        /// </summary>
        static public Dictionary<string, string> AttributeResources
        {
            get
            {
                return attributeResources;
            }
        }


		/// <summary>
		/// Current directory
		/// </summary>
		public static string CurrentDirectory
		{
			get
			{
				return currentDirectory;
			}
			set
			{
				currentDirectory = value;
			}
		}

        /// <summary>
        /// Conversion to attribute resource
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Conversion result</returns>
        public static string ToLocalizedAttribute(this string str)
        {
            if (attributeResources.ContainsKey(str))
            {
                return attributeResources[str];
            }
            return str;
        }

        /// <summary>
        /// Recursively updates UI of control and all its subcontrols
        /// </summary>
        /// <param name="control">The control of UI updating</param>
        public static void UpdateUI(Control control)
        {
            if (control is IUpdatableUI)
            {
                IUpdatableUI up = control as IUpdatableUI;
                up.UpdateUI();
            }
            foreach (Control c in control.Controls)
            {
                UpdateUI(c);
            }
        }



		/// <summary>
		/// Gets parent form
		/// </summary>
		/// <param name="control">Control</param>
		/// <returns>Parent form</returns>
		public static Form GetParentForm(Control control)
		{
			Control c = control;
			while (true)
			{
				if (c is Form)
				{
					return c as Form;
				}
				c = c.Parent;
			}
		}

		/// <summary>
		/// Loads resources from file
		/// </summary>
		/// <param name="filename">Filename</param>
		public static void LoadControlResourcesFromFile(string filename)
		{
			Stream stream = File.OpenRead(filename);
			ResourceReader r = new ResourceReader(stream);
			ResourceSet s = new ResourceSet(r);
			IDictionaryEnumerator d = s.GetEnumerator();
			while (d.MoveNext())
			{
				object k = d.Key;
				object v = d.Value;
				controlResources[k + ""] = v;
			}
			stream.Close();
		}

		/// <summary>
		/// Loads resources from file
		/// </summary>
		/// <param name="filename">Filename</param>
		public static void LoadResources(string filename)
		{
			Stream stream = File.OpenRead(filename);
			ResourceReader r = new ResourceReader(stream);
			ResourceSet s = new ResourceSet(r);
			IDictionaryEnumerator d = s.GetEnumerator();
			while (d.MoveNext())
			{
				object k = d.Key;
				object v = d.Value;
				resources[k + ""] = v;
			}
			stream.Close();
		}

		/// <summary>
		/// Control resources
		/// </summary>
		public static Dictionary<string, object> ControlResources
		{
			get
			{
				return controlResources;
			}
		}

        /// <summary>
        /// String resources
        /// </summary>
        public static Dictionary<string, object> CommonResources
        {
            get
            {
                return resources;
            }
        }

	/*	/// <summary>
		/// Gets control resource
		/// </summary>
		/// <param name="key">Key string</param>
		/// <returns>The resource</returns>
		/*public static string GetControlResource(string key)
		{
			if (controlResources.ContainsKey(key))
			{
				return controlResources[key] as string;
			}
            if (missWriter != null & key.Length != 0)
            {
                missWriter.WriteLine(key);
            }
            if (key.Length == 0)
            {
                return "";
            }
			return key;
		}*

		/// <summary>
		/// Gets resource string
		/// </summary>
		/// <param name="key">Key string</param>
		/// <returns>The resource</returns>
		public static string GetResourceString(string key)
		{
			if (resources.ContainsKey(key))
			{
				return resources[key] as string;
			}
            if (missWriter != null & key.Length != 0)
            {
                missWriter.WriteLine(key);
            }
			return key;
		}

		/// <summary>
		/// Loads resources strings to control
		/// </summary>
		/// <param name="control">The control</param>
		private static void LoadControlResources(Control control)
		{
			LoadControlResources(control, controlResources);
		}*/


        /// <summary>
        /// Shows dialog
        /// </summary>
        /// <param name="form">Parent form</param>
        /// <param name="resources">Resources</param>
        /// <param name="dialog">Dialog</param>
        /// <returns>Dialog result</returns>
        public static DialogResult ShowDialog(IWin32Window form, Dictionary<string, object>[] resources, FileDialog dialog)
        {
            Type t = form.GetType();
            dialog.Filter = GetControlResource(dialog.Filter, resources);
            return dialog.ShowDialog(form);
        }


		/// <summary>
		/// Loads resources strings to control
		/// </summary>
        /// <param name="control">The control</param>
		/// <param name="resources">The resources</param>
        public static void LoadControlResources(Control control, Dictionary<string, object>[] resources)
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
            if (!(control is TextBox) & !(control is WebBrowser))
            {
                control.Text = GetControlResource(control.Text, resources);
            }
            foreach (Control c in control.Controls)
            {
                LoadControlResources(c, resources);
            }
 /*           if (control is DataGrid)
            {
                DataGrid grid = control as DataGrid;
                if (grid.DataSource is DataTable)
                {
                    DataTable table = grid.DataSource as DataTable;
                    foreach (DataColumn col in table.Columns)
                    {
                        col.ColumnName = GetControlResource(col.ColumnName, resources);
                    }
                }
            }*/
            if (control is DataGridView)
            {
                DataGridView dgv = control as DataGridView;
                LoadDataControlResourses(dgv, resources);
            }
            if (control is ListView)
            {
                ListView lv = control as ListView;
                foreach (ColumnHeader ch in lv.Columns)
                {
                    ch.Text = GetControlResource(ch.Text, resources);
                }
            }
            if (control is Form)
            {
                Form form = control as Form;
                MenuStrip menu = form.MainMenuStrip;
                if (menu != null)
                {
                    foreach (MenuStrip item in menu.Items)
                    {
                        LoadControlResources(item, resources);
                    }
                }
            }
            if (control is TabControl)
            {
                TabControl tc = control as TabControl;
                foreach (TabPage page in tc.TabPages)
                {
                    page.Text = GetControlResource(page.Text, resources);
                }
            }
            if (control is MenuStrip)
            {
                MenuStrip ms = control as MenuStrip;
                foreach (ToolStripItem it in ms.Items)
                {
                    LoadToolMenuItem(it, resources);
                }
            }
            if (control is ToolStrip)
            {
                ToolStrip ts = control as ToolStrip;
                ToolStripItemCollection coll = ts.Items;
                LoadResources(coll, resources);
            }
        }

        /// <summary>
        /// Gets resource string
        /// </summary>
        /// <param name="key">Key string</param>
        /// <param name="resources">Resources</param>
        /// <returns>The resource</returns>
        public static string GetControlResource(this string key, Dictionary<string, object>[] resources)
        {
            if (resources == null)
            {
                return key;
            }
            foreach (Dictionary<string, object> r in resources)
            {
                if (r.ContainsKey(key))
                {
                    return r[key] as string;
                }
            }
            return key;
        }

        /*
        /// <summary>
        /// Loads resources to menu items
        /// </summary>
        /// <param name="item">Parent item</param>
        /// <param name="resources">Resources</param>
        public static void LoadMenuResources(MenuItem item, Dictionary<string, object>[] resources)
        {
            item.Text = GetControlResource(item.Text, resources);
            foreach (MenuItem it in item.MenuItems)
            {
                LoadMenuResources(it, resources);
            }
        }
/*
        /// <summary>
        /// Loads Menu resources
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="resources">The resouces</param>
        public static void LoadMenuResources(MenuItem item, Dictionary<string, object>[] resources)
        {
            LoadMenuResources(item, resources);
        }
*/
        static void SaveImage(object c, string dir, ref int k)
        {
           // System.Drawing.Imaging.Encoder enc = new System.Drawing.Imaging.Encoder(Guid.NewGuid());
           // System.Drawing.Imaging.EncoderParameters par = new System.Drawing.Imaging.EncoderParameters(1);
           // par.Param[0] = 
            Type t = c.GetType();
            PropertyInfo pi = t.GetProperty("Image");
            if (pi != null)
            {
                Image im = pi.GetValue(c, null) as Image;
                if (im != null)
                {
                    if ((im.Flags & 2) != 0)
                    {
                        im.Save(dir + k + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else
                    {
                        im.Save(dir + k + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    ++k;
                }
            }
            pi = t.GetProperty("Icon");
            if (pi != null)
            {
                Icon ic = pi.GetValue(c, null) as Icon;
                Stream str = File.OpenWrite(dir + k + ".ico");
                ic.Save(str);
                str.Close();
                ++k;
            }

        }


        /// <summary>
        /// Saves images
        /// </summary>
        /// <param name="control">Conrtol</param>
        /// <param name="dir">Directory</param>
        /// <param name="k">Index</param>
        public static void SaveImages(Control control, string dir, ref int k)
        {
            SaveImage(control, dir, ref k);
            foreach (Control c in control.Controls)
            {
                SaveImages(c, dir, ref k);
            }
            if (control is MenuStrip)
            {
                MenuStrip ms = control as MenuStrip;
                foreach (ToolStripItem it in ms.Items)
                {
                    saveImages(it, dir, ref k);
                }
            }
            if (control is ToolStrip)
            {
                ToolStrip ts = control as ToolStrip;
                ToolStripItemCollection coll = ts.Items;
                foreach (ToolStripItem c in coll)
                {
                    saveImages(c, dir, ref k);
                }
            }
        }

        /// <summary>
        /// Loads control resourses of data grid
        /// </summary>
        /// <param name="data">Data grid</param>
        /// <param name="resources">Resources</param>
        public static void LoadDataControlResourses(DataGridView data, Dictionary<string, object>[] resources)
        {
            DataGridViewColumnCollection coll = data.Columns;
            foreach (DataGridViewColumn c in coll)
            {
                c.HeaderText = GetControlResource(c.HeaderText, resources);
            }
        }
/*
        /// <summary>
        /// Loads resources to form
        /// </summary>
        /// <param name="form">The form</param>
       / public static void LoadFormResources(Form form)
        {
            LoadControlResources(form);
        }

 */ 

        /// <summary>
        /// Loads control resourses
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="resources">Resources</param>
        public static void LoadDataControlResourses(Control control, Dictionary<string, object> resources)
        {
            if (control is DataGridView)
            {
                DataGridView d = control as DataGridView;
                LoadDataControlResourses(d, resources);
            }
            foreach (Control c in control.Controls)
            {
                LoadDataControlResourses(c, resources);
            }
        }

        /// <summary>
        /// Localization by resourse manager
        /// </summary>
        /// <param name="man">The manager</param>
        public static void Localize(ResourceManager man)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            ResourceSet rs = man.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, true, false);
            IDictionaryEnumerator rEnu = rs.GetEnumerator();
            while (rEnu.MoveNext())
            {
                string k = rEnu.Key + "";
                k = ReverseTransform(k);
                object v = rEnu.Value;
                ControlResources[k] = v;
                CommonResources[k] = v;
            }
        }


        /// <summary>
        /// Creates resource manager
        /// </summary>
        /// <param name="manager">The resource manager</param>
        /// <returns>The dictionary</returns>
        public static Dictionary<string, object> CreateResourceDictionary(ResourceManager manager)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            ResourceSet rs = manager.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, true, false);
            IDictionaryEnumerator rEnu = rs.GetEnumerator();
            while (rEnu.MoveNext())
            {
                string k = rEnu.Key + "";
                k = ReverseTransform(k);
                object v = rEnu.Value;
                d[k] = v;
            }
            return d;
        }

        /// <summary>
        /// Creates localization dictionary by resourse manager
        /// </summary>
        /// <param name="man">The manager</param>
        /// <returns>Localization dictionary</returns>
        public static Dictionary<string, object> CreateLocalizationDictionary(ResourceManager man)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            ResourceSet rs = man.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, true, false);
            IDictionaryEnumerator rEnu = rs.GetEnumerator();
            while (rEnu.MoveNext())
            {
                string k = rEnu.Key + "";
                k = ReverseTransform(k);
                object v = rEnu.Value;
                d[k] = v;
            }
            return d;
        }


        /// <summary>
        /// Sets the "enabled" property for object
        /// </summary>
        /// <param name="o">Object</param>
        /// <param name="enabled">The enabled value</param>
        public static void SetEnabled(object o, bool enabled)
        {
            Type t = o.GetType();
            PropertyInfo pi = t.GetProperty("Enabled");
            if (pi == null)
            {
                return;
            }
            pi.SetValue(o, enabled, null);
        }

        /// <summary>
        /// Sets the "enabled" property for array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="enabled">The enabled value</param>
        public static void SetEnabled(object[] array, bool enabled)
        {
            foreach (object o in array)
            {
                SetEnabled(o, enabled);
            }
        }
        
        /// <summary>
        /// Reverse transformation of string
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>Result</returns>
        static public string ReverseTransform(string str)
        {
            string s = str + "";
            s = s.Replace("DEFIS", "-");
            s = s.Replace("PLUS", "+");
            s = s.Replace("_", " ");
            s = s.Replace("AND", "&");
            s = s.Replace("POINT", ".");
            s = s.Replace("MORE", ">");
            s = s.Replace("LESS", "<");
            s = s.Replace("SQUAREBRACKETO", "[");
            s = s.Replace("SQUAREBRACKETC", "]");
            s = s.Replace("BRA", "(");
            s = s.Replace("KET", ")");
            s = s.Replace("OR", "|");
            s = s.Replace("COMMA", ",");
            s = s.Replace("EQUALS", "=");
            s = s.Replace("APOSTROFF", "'");
            s = s.Replace("STAR", "*");
            s = s.Replace("SEMICOLON", ";");
            s = s.Replace("COLON", ":");
            s = s.Replace("FRACTION", "/");
            s = s.Replace("QUERY", "?");
            s = s.Replace("THREE", "3");
            s = s.Replace("SIX", "6");
            /*if (s.Contains("]"))
            {
                s = s;
            }*/
            return s;
        }

        /// <summary>
        /// Cheks whether resouces contain control resource
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="resources">Resources</param>
        /// <returns>True if contains and false othewise</returns>
        public static bool ContainsControlResource(string key, Dictionary<string, object>[] resources)
        {
            foreach (Dictionary<string, object> d in resources)
            {
                if (d.ContainsKey(key))
                {
                    return true;
                }
            }
            return false;
        }


        static private void CreateRes(Dictionary<string, string> res, string filename)
        {
            Stream stream = File.OpenWrite(filename);
            ResourceWriter rw = new ResourceWriter(stream);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Root/>");
            foreach (string key in res.Keys)
            {
                XmlElement e = doc.CreateElement("data");
                doc.DocumentElement.AppendChild(e);
                string s = key;
                s = s.Replace("-", "DEFIS");
                s = s.Replace("+", "PLUS");
                s = s.Replace(" ", "_");
                s = s.Replace("&", "AND");
                s = s.Replace(".", "POINT");
                s = s.Replace(">", "MORE");
                s = s.Replace("<", "LESS");
                s = s.Replace("[", "SQUAREBRACKETO");
                s = s.Replace("]", "SQUAREBRACKETC");
                s = s.Replace("(", "BRA");
                s = s.Replace(")", "KET");
                s = s.Replace("|", "OR");
                s = s.Replace(",", "COMMA");
                s = s.Replace("=", "EQUALS");
                s = s.Replace("'", "APOSTROFF");
                s = s.Replace("*", "STAR");
                s = s.Replace(";", "SEMICOLON");
                s = s.Replace(":", "COLON");
                s = s.Replace("/", "FRACTION");
                s = s.Replace("?", "QUERY");
                s = s.Replace("3", "THREE");
                s = s.Replace("6", "SIX");
                rw.AddResource(s, res[key]);
                XmlAttribute a = doc.CreateAttribute("name");
                a.Value = s;
                e.Attributes.Append(a);
                a = doc.CreateAttribute("xml:space");
                a.Value = "preserve";
                e.Attributes.Append(a);
                XmlElement el = doc.CreateElement("value");
                e.AppendChild(el);
                // el.InnerText = TransformEncoding(res[key]);
            }
            doc.Save("1.xml");
        }


        static private void CreateRes(string[,] res, string filename)
        {
            Dictionary<string, string> r = new Dictionary<string, string>();
            for (int i = 0; i < res.GetLength(0); i++)
            {
                r[res[i, 0]] = res[i, 1];
            }
            CreateRes(r, filename);
        }





        /// <summary>
        /// Loads resources to menu items
        /// </summary>
        /// <param name="item">Parent item</param>
        /// <param name="resources">Resources</param>
        static internal void LoadMenuResourcesInternal(ToolStripItem item, Dictionary<string, object>[] resources)
        {
            item.Text = GetControlResource(item.Text, resources);
            if (item is ToolStripDropDownItem)
            {
                ToolStripDropDownItem tdd = item as ToolStripDropDownItem;
                foreach (ToolStripItem it in tdd.DropDownItems)
                {
                    LoadMenuResourcesInternal(it, resources);
                }
            }
        }
 

        static internal void LoadToolMenuItem(ToolStripItem item, Dictionary<string, object>[] resources)
        {
            item.Text = GetControlResource(item.Text, resources);
            if (item is ToolStripMenuItem)
            {
                ToolStripMenuItem mi = item as ToolStripMenuItem;
                foreach (ToolStripItem it in mi.DropDown.Items)
                {
                    LoadToolMenuItem(it, resources);
                }
            }
        }

        static internal void LoadResources(ToolStripItemCollection coll, Dictionary<string, object>[] resources)
        {
            foreach (ToolStripItem c in coll)
            {
                c.Text = GetControlResource(c.Text, resources);
                if (c is ToolStripDropDownButton)
                {
                    ToolStripDropDownButton tsddb = c as ToolStripDropDownButton;
                    LoadResources(tsddb.DropDownItems, resources);
                    return;
                }

                if (c is ToolStripComboBox)
                {
                    ToolStripComboBox tscb = c as ToolStripComboBox;
                    ComboBox.ObjectCollection tscbi = tscb.Items;
                    List<object> l = new List<object>();
                    foreach (object o in tscbi)
                    {
                        Type t = o.GetType();
                        if (t == typeof(string))
                        {
                            string s = o + "";
                            l.Add(GetControlResource(s, resources));
                        }
                        else
                        {
                            l.Add(o);
                        }
                    }
                    tscb.Items.Clear();
                    foreach (object o in l)
                    {
                        tscb.Items.Add(o);
                    }
                }
            }
        }


        static void saveImages(ToolStripItem item, string dir, ref int k)
        {
            SaveImage(item, dir, ref k);
            if (item is ToolStripMenuItem)
            {
                ToolStripMenuItem mi = item as ToolStripMenuItem;
                foreach (ToolStripItem it in mi.DropDown.Items)
                {
                    saveImages(it, dir, ref k);
                }
            }
 
        }

 /*       static void saveImages(MenuItem item, string dir, ref int k)
        {
            if (item. != null)
            {
                it.Image.Save(dir + k + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                ++k;
            }
            if (it is ToolStripMenuItem)
            {
                ToolStripMenuItem mi = it as ToolStripMenuItem;
                foreach (ToolStripItem ite in mi.DropDown.Items)
                {
                    saveImages(ite, dir, ref k);
                }
            }

        }*/

        internal static void LoadControlResources(TreeNode node, Dictionary<string, object>[] resources)
        {
            node.Text = GetControlResource(node.Text, resources);
            ContextMenuStrip cms = node.ContextMenuStrip;
            if (cms != null)
            {
                LoadControlResources(cms, resources);
            }
            foreach (TreeNode n in node.Nodes)
            {
                LoadControlResources(n, resources);
            }
        }
/*
        internal static void LoadControlResources(ContextMenu cm, Dictionary<string, object>[] resources)
        {
            foreach (MenuItem it in cm.MenuItems)
            {
                it.Text = GetControlResource(it.Text, resources);
            }
        }
*/
	}

}
