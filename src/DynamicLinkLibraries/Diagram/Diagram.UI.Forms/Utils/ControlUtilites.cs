using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Resources;
using System.Windows.Forms;

using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

namespace Diagram.UI.Utils
{
    /// <summary>
    /// Common Utilites for all windows
    /// </summary>
    public static class ControlUtilites
    {
        #region Directory + Resources

        /// <summary>
        /// Control resources
        /// </summary>
        static private Dictionary<string, object>[] controlResources;


        /// <summary>
        /// Resources
        /// </summary>
        static public Dictionary<string, object>[] Resources
        {
            get
            {
                return controlResources;
            }
            set
            {
                if (controlResources != null)
                {
                    throw new Exception();
                }
                controlResources = value;
            }
        }

        /// <summary>
        /// Resources
        /// </summary>
        static private Dictionary<string, string> resources = new Dictionary<string, string>();

        /// <summary>
        /// Error Resources
        /// </summary>
        static private Dictionary<string, string> errorResources = new Dictionary<string, string>();


        /// <summary>
        /// Current directory
        /// </summary>
        static private string currentDirectory;

        /// <summary>
        /// Current directory
        /// </summary>
        static public string CurrentDirectory
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
        /// String resources
        /// </summary>
        public static Dictionary<string, string> ResourceStrings
        {
            set
            {
                resources = value;
            }
            get
            {
                return resources;
            }
        }

        /// <summary>
        /// Resources of errors
        /// </summary>
        public static Dictionary<string, string> ErrorResources
        {
            set
            {
                errorResources = value;
            }
            get
            {
                return errorResources;
            }
        }

        /// <summary>
        /// Loads resources of controls
        /// </summary>
        /// <param name="filename">File name</param>
        public static void LoadErrorResources(string filename)
        {
            Stream stream = File.OpenRead(filename);
            ResourceReader rr = new ResourceReader(stream);
            ResourceSet rs = new ResourceSet(rr);
            IDictionaryEnumerator de = rs.GetEnumerator();
            while (de.MoveNext())
            {
                object k = de.Key;
                object v = de.Value;
                errorResources[k + ""] = v + "";
            }
            stream.Close();
        }

        #endregion

        #region Show Error

        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="form">Parent form</param>
        /// <param name="e">Inners exception</param>
        /// <param name="r">Resources</param>
        public static void ShowError(this Form form, Exception e, Dictionary<string, object>[] r)
        {
            Exception ex = e;
            if (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            /* IErrorHandler eh = PureDesktop.ErrorHandler;
             if (eh != null)
             {
                 eh.ShowError(e);
                 return;
             }*/
            string message = ex.Message;
            string url = null;
            if (ex is INamedObject)
            {
                INamedObject n = ex as INamedObject;
                url = n.Name;
            }
            if (url == null)
            {
                if (errorResources != null)
                {
                    string s = message;
                    if (errorResources.ContainsKey(message))
                    {
                        s = errorResources[message];
                    }
                    if (s != null)
                    {
                        url = s;
                    }
                    else
                    {
                        int n = message.Length;
                        IDictionaryEnumerator en = resources.GetEnumerator();
                        en.Reset();
                        while (en.MoveNext())
                        {
                            string key = en.Key as string;
                            string val = en.Value as string;
                            if (val.Length <= n)
                            {
                                if (message.Substring(0, val.Length).Equals(val))
                                {
                                    s = errorResources[key] as string;
                                    if (s != null)
                                    {
                                        url = s;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            string path = null;
            Stream stream = null;
            FormHelp f = null;
            if (r != null)
            {
                message = ResourceService.Resources.GetControlResource(ex.Message, r);
            }
            if (url != null)
            {
                string filename = url;
                try
                {
                    path = currentDirectory + "Help\\" + filename;
                    stream = File.OpenRead(path);
                    stream.Close();
                    f = new FormHelp(message, ex, path);
                    f.Left = form.Left + form.Width / 2 - f.Width / 2;
                    f.Top = form.Top + form.Width / 2 - f.Width / 2;
                    f.ShowDialog(form);
                    return;
                }
                catch (Exception)
                {
                }
            }
            if (message.Equals(ex.Message))
            {
                path = currentDirectory + "Help\\SystemError.htm";
                try
                {
                    stream = File.OpenRead(path);
                    stream.Close();
                }
                catch (Exception)
                {
                }
                try
                {
                    message = ResourceService.Resources.GetControlResource("System error : ", r) + message +
                        ResourceService.Resources.GetControlResource(" contact developer", r);
                    f = new FormHelp(message, ex, path);
                    f.Left = form.Left + form.Width / 2 - f.Width / 2;
                    f.Top = form.Top + form.Width / 2 - f.Width / 2;
                    f.ShowDialog(form);
                    return;
                }
                catch (Exception)
                {
                }
                return;
            }
            /*        if (url != null)
                    {
                        string filename = url;
                        try
                        {
                            path = currentDirectory + "Help\\" + filename;
                            stream = File.OpenRead(path);
                            stream.Close();
                            f = new FormHelp(message, e, path);
                            f.Left = form.Left + form.Width / 2 - f.Width / 2;
                            f.Top = form.Top + form.Width / 2 - f.Width / 2;
                            f.ShowDialog(form);
                            return;
                        }
                        catch (Exception)
                        {
                            //ex = ex;
                        }
                    }*/
            f = new FormHelp(message, ex, null);
            if (form != null)
            {
                f.Left = form.Left + form.Width / 2 - f.Width / 2;
                f.Top = form.Top + form.Width / 2 - f.Width / 2;
            }
            f.ShowDialog(form);
            return;

        }

        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="form">Parent form</param>
        /// <param name="e">Exception</param>
        /// <param name="helpstring">Help string</param>
        /// <param name="r">Resources</param>
        public static void ShowError(this Form form, Exception e, string helpstring, Dictionary<string, string> r)
        {
            IErrorHandler eh = StaticExtensionDiagramUI.ErrorHandler;
            if (eh != null)
            {
                e.ShowError(0);
                return;
            }
            string message = e.Message;
            if (r != null)
            {
                string rMessage = r[message];
                if (rMessage != null)
                {
                    message = rMessage;
                }
                else
                {
                    message = r["System error : "] + message + r[" contact developer"];
                }
            }
            WindowsExtensions.ControlExtensions.ShowMessageBoxModal(form, message, PanelDesktop.GetResourceString("Error", r), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="control">Related control</param>
        /// <param name="e">Error exception</param>
        /// <param name="resources">Resources</param>
        public static void ShowError(this Control control, Exception e, Dictionary<string, object>[] resources)
        {
            ShowError(control.GetForm(), e, resources);
        }

        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="e">Error exception</param>
        public static void ShowError(Exception e)
        {
            IErrorHandler eh = Diagram.UI.StaticExtensionDiagramUI.ErrorHandler;
            if (eh != null)
            {
                eh.ShowError(e, 1);
                return;
            }
            string err = ResourceService.Resources.GetControlResource("Error", controlResources);
            if (!(e is DiagramException))
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(null, e.Message, err,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DiagramException de = e as DiagramException;
            Form f = null;
            if (Diagram.UI.StaticExtensionDiagramUI.ErrorHandler is Form)
            {
                f = Diagram.UI.StaticExtensionDiagramUI.ErrorHandler as Form;
            }
            FormHelp fh = new FormHelp(e.Message, e, null);
            fh.ShowDialog(f);
        }


        #endregion

        #region ComboBox

        #region Fill
        
        /// <summary>
        /// Fills combobox
        /// </summary>
        /// <param name="cb">The combobox</param>
        /// <param name="list">List of items</param>
        /// <param name="restoreSelectedItem">The "restore selected item" sign</param>
        public static void FillCombo(this ComboBox cb, IEnumerable<string> list, bool restoreSelectedItem = true)
        {
            if (list == null)
            {
                return;
            }
            cb.Text = "";
            cb.ClearItems();
            foreach (string s in list)
            {
                cb.Items.Add(s);
            }
            if (restoreSelectedItem)
            {
                cb.RestoreSelectedItem();
            }
        }
        /// <summary>
        /// Clears items of the combobox
        /// </summary>
        /// <param name="comboBox">The combobox</param>
        public static void ClearItems(this ComboBox comboBox)
        {
            object sel = comboBox.SelectedItem;
            if (sel != null)
            {
                comboBox.Tag = sel;
            }
            comboBox.Items.Clear();
        }


        /// <summary>
        /// restores selected item of the combobox
        /// </summary>
        /// <param name="comboBox">The combobox</param>
        public static void RestoreSelectedItem(this ComboBox comboBox)
        {
            object o = comboBox.Tag;
            if (o == null)
            {
                return;
            }
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (o.Equals(comboBox.Items[i]))
                {
                    comboBox.Tag = null;
                    comboBox.SelectedIndex = i;
                    return;
                }
            }
        }

 
        /// <summary>
        /// Fills boxes by items
        /// </summary>
        /// <param name="boxes">The boxes</param>
        /// <param name="items">The items</param>
        public static void FillCombo(this IEnumerable<ComboBox> boxes, IEnumerable<string> items)
        {
            foreach (ComboBox box in boxes)
            {
                box.FillCombo(items);
            }
        }


        /// <summary>
        /// Fills combobox
        /// </summary>
        /// <param name="cb">The combobox</param>
        /// <param name="items">Array of items</param>
        public static void FillCombo(this ToolStripComboBox cb, string[] items)
        {
            if (items == null)
            {
                return;
            }
            cb.Items.Clear();
            foreach (string s in items)
            {
                cb.Items.Add(s);
            }
        }

        /// <summary>
        /// Fills array of comboboxes
        /// </summary>
        /// <param name="combo">The array of comoboxes</param>
        /// <param name="list">List of items</param>
        public static void FillCombo(this ComboBox[] combo, IEnumerable<string> list)
        {
            foreach (ComboBox cb in combo)
            {
                FillCombo(cb, list);
            }
        }

        /// <summary>
        /// Fills comboboxes 
        /// </summary>
        /// <param name="boxes">Array of coboboxes</param>
        /// <param name="list">List of items</param>
        public static void FillCombo(this IBoxArray boxes, IEnumerable<string> list)
        {
            ComboBox[] combo = boxes.Boxes;
            FillCombo(combo, list);
        }

        /// <summary>
        /// Fills collection of comboboxes
        /// </summary>
        /// <param name="combo">The collection of comboboxes</param>
        /// <param name="list">List of items</param>
        /// <param name="restoreSelectedItem">The "restore selected item" sign</param>
        public static void FillCombo(this ICollection<ComboBox> combo, IEnumerable<string> list, bool restoreSelectedItem = true)
        {
            foreach (ComboBox cb in combo)
            {
                FillCombo(cb, list);
            }
        }

        /// <summary>
        /// Fills combobox by letters
        /// </summary>
        /// <param name="box">The combobox</param>
        /// <param name="str">String of letters</param>
        /// <param name="restoreSelectedItem">The "restore selected item" sign</param>
        public static void FillCombo(this ComboBox box, string str, bool restoreSelectedItem = true)
        {
            box.Text = "";
            box.ClearItems();
            foreach (char c in str)
            {
                box.Items.Add(c + "");
            }
            if (restoreSelectedItem)
            {
                box.RestoreSelectedItem();
            }
        }

        /// <summary>
        /// Fills combobox by numbers
        /// </summary>
        /// <param name="box">The combobox</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        public static void FillCombo(this ComboBox box, int min, int max)
        {
            box.Items.Clear();
            for (int i = min; i <= max; i++)
            {
                box.Items.Add(i + "");
            }
        }


        /// <summary>
        /// Fills toolstrip combobox by numbers
        /// </summary>
        /// <param name="box">The toolStrip combobox</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        public static void FillCombo(this ToolStripComboBox box, int min, int max)
        {
            box.Items.Clear();
            for (int i = min; i <= max; i++)
            {
                box.Items.Add(i + "");
            }
        }

        /// <summary>
        /// Fills toolstrip combobox
        /// </summary>
        /// <param name="box">The toolStrip combobox</param>
        /// <param name="list">List of items</param>
        public static void FillCombo(this ToolStripComboBox box, IList<string> list)
        {
            box.Items.Clear();
            foreach (string s in list)
            {
                box.Items.Add(s);
            }
        }




        #endregion

        #region Select

        /// <summary>
        /// Gets selected string of combobox
        /// </summary>
        /// <param name="comboBox">The combobox</param>
        /// <returns>The string</returns>
        public static string GetSelectedString(this ComboBox comboBox)
        {
            var k = comboBox.SelectedIndex;
            if (k  < 0)
            {
                return "";
            }
            if (k >= comboBox.Items.Count)
            {
                return "";
            }
            return comboBox.Items[k].ToString();
        }

        /// <summary>
        /// Selects item of combobox
        /// </summary>
        /// <param name="cb">The combobox</param>
        /// <param name="item">Selected item</param>
        public static void SelectCombo(this ComboBox cb, string item)
        {
            if (item == null)
            {
                return;
            }
            for (int i = 0; i < cb.Items.Count; i++)
            {
                if (cb.Items[i].ToString().Equals(item))
                {
                    cb.SelectedIndex = i;
                    return;
                }
            }
        }

        /// <summary>
        /// Selects items of comboboxes
        /// </summary>
        /// <param name="cb">The comboboxes</param>
        /// <param name="items">The items</param>
        public static void SelectCombo(this ComboBox[] cb, string[] items)
        {
            if (items == null)
            {
                return;
            }
            if (cb.Length != items.Length)
            {
                return;
            }
            for (int i = 0; i < cb.Length; i++)
            {
                SelectCombo(cb[i], items[i]);
            }
        }

        /// <summary>
        /// Selects comboboxes from dictionary
        /// </summary>
        /// <param name="cb">Comboboxes</param>
        /// <param name="dic">Dictionary</param>
        public static void SelectCombo(this ComboBox[] cb, Dictionary<int, string> dic)
        {
            if (dic == null)
            {
                return;
            }
            foreach (int i in dic.Keys)
            {
                SelectCombo(cb[i], dic[i]);
            }
        }


        /// <summary>
        /// Selects items of comboboxes
        /// </summary>
        /// <param name="cb">The comboboxes</param>
        /// <param name="items">The items</param>
        public static void SelectCombo(this ComboBox[] cb, IList<string> items)
        {
            if (items == null)
            {
                return;
            }
            if (cb.Length != items.Count)
            {
                return;
            }
            for (int i = 0; i < cb.Length; i++)
            {
                SelectCombo(cb[i], items[i]);
            }
        }

        /// <summary>
        /// Selects items of comboboxes
        /// </summary>
        /// <param name="boxes">The comboboxes</param>
        /// <param name="items">The items</param>
        public static void SelectCombo(this IBoxArray boxes, IList<string> items)
        {
            ComboBox[] cb = boxes.Boxes;
            SelectCombo(cb, items);
        }

        /// <summary>
        /// Selects combobox letter
        /// </summary>
        /// <param name="box">The combobox</param>
        /// <param name="c">The letter</param>
        public static void SelectCombo(this ComboBox box, char c)
        {
            for (int i = 0; i < box.Items.Count; i++)
            {
                if (box.Items[i].ToString().Equals(c + ""))
                {
                    box.SelectedIndex = i;
                    return;
                }
            }
        }

        /// <summary>
        /// Selects combobox item
        /// </summary>
        /// <param name="cb">The combobox</param>
        /// <param name="item">The item</param>
        public static void SelectCombo(this ToolStripComboBox cb, string item)
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                if (cb.Items[i].ToString().Equals(item))
                {
                    cb.SelectedIndex = i;
                    return;
                }
            }
        }


        #endregion

        #region Selected Items


        /// <summary>
        /// Gets selected items of comoboxes
        /// </summary>
        /// <param name="boxes">Boxes</param>
        /// <param name="allowNulls">The allow nulls sign</param>
        /// <returns>Arrray of selected items</returns>
        public static string[] GetSelected(this ComboBox[] boxes, bool allowNulls)
        {
            string[] s = new string[boxes.Length];
            for (int i = 0; i < boxes.Length; i++)
            {
                object it = boxes[i].SelectedItem;
                if (it == null)
                {
                    if (!allowNulls)
                    {
                        throw new Exception(i + "");
                    }
                    continue;
                }
                s[i] = it + "";
            }
            return s;
        }



        /// <summary>
        /// Gets selected items of comboboxes
        /// </summary>
        /// <param name="combo">The comboboxes</param>
        /// <returns>The items</returns>
        public static List<string> GetSelected(this ComboBox[] combo)
        {
            List<string> l = new List<string>();
            for (int i = 0; i < combo.Length; i++)
            {
                string s = combo[i].SelectedItem + "";
                if (s.Length > 0)
                {
                    l.Add(s);
                }
            }
            return l;
        }


        /// <summary>
        /// Gets array of strings from selected items of comboboxes
        /// </summary>
        /// <param name="boxes">The boxes</param>
        /// <returns>The array of strings</returns>
        public static string[] GetSelectedStringArray(this ComboBox[] boxes)
        {
            string[] str = new string[boxes.Length];
            for (int i = 0; i < boxes.Length; i++)
            {
                object it = boxes[i].SelectedItem;
                if (it == null)
                {
                    continue;
                }
                str[i] = it + "";
            }
            return str;
        }

        /// <summary>
        /// Creates dictionary from comboboxes
        /// </summary>
        /// <param name="boxes">The comboboxes</param>
        /// <returns>The dictionary</returns>
        public static Dictionary<int, string> GetSelectedDictionary(this ComboBox[] boxes)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            for (int i = 0; i < boxes.Length; i++)
            {
                object it = boxes[i].SelectedItem;
                if (it == null)
                {
                    continue;
                }
                dic[i] = it + "";
            }
            return dic;
        }


        /// <summary>
        /// Gets selected items of comboboxes
        /// </summary>
        /// <param name="combo">The comboboxes</param>
        /// <returns>The items</returns>
        public static List<string> GetSelected(this IBoxArray combo)
        {
            ComboBox[] cb = combo.Boxes;
            return GetSelected(cb);
        }

        /// <summary>
        /// Gets items of combobox
        /// </summary>
        /// <param name="box">The combobox</param>
        /// <returns>The items</returns>
        public static List<string> GetItems(this ComboBox box)
        {
            List<string> l = new List<string>();
            foreach (object o in box.Items)
            {
                l.Add(o + "");
            }
            return l;
        }


        #endregion

        #region Add Remove

        /// <summary>
        /// Adds item to combobox
        /// </summary>
        /// <param name="box">The combobox</param>
        /// <param name="item">The item</param>
        public static void AddItem(this ComboBox box, string item)
        {
            foreach (object o in box.Items)
            {
                if (item.Equals(o + ""))
                {
                    return;
                }
            }
            box.Items.Add(item);
        }

        /// <summary>
        /// Adds combobox text to combobox items
        /// </summary>
        /// <param name="box">The combobox</param>
        public static void AddItem(this ComboBox box)
        {
            AddItem(box, box.Text);
        }

        /// <summary>
        /// Removes selected item from combobox
        /// </summary>
        /// <param name="box">The combobox</param>
        public static void RemoveSelected(this ComboBox box)
        {
            if (box.SelectedItem == null)
            {
                return;
            }
            object o = box.SelectedItem;
            box.Items.Remove(o);
        }


        #endregion

        #endregion

        #region CheckListBox

        #region Fill
        /// <summary>
        /// Fills checked listbox
        /// </summary>
        /// <param name="box">The checked listbox</param>
        /// <param name="list">List of items</param>
        public static void FillCheckBox(CheckedListBox box, List<string> list)
        {
            box.Items.Clear();
            foreach (string s in list)
            {
                box.Items.Add(s);
            }
        }

        /// <summary>
        /// Fills checked listbox by letters
        /// </summary>
        /// <param name="box">The checked listbox</param>
        /// <param name="str">String of letters</param>
        public static void FillCheckBox(CheckedListBox box, string str)
        {
            box.Items.Clear();
            foreach (char c in str)
            {
                box.Items.Add(c + "");
            }
        }

        #endregion


        /// <summary>
        /// Fills checked listbox
        /// </summary>
        /// <param name="box">The checked listbox</param>
        /// <param name="list">List of items</param>
        public static void CheckList(this CheckedListBox box, IEnumerable<string> list)
        {
            box.Items.Clear();
            foreach (string s in list)
            {
                box.Items.Add(s);
            }
        }

        /// <summary>
        /// Fills and checks a checked listbox
        /// </summary>
        /// <param name="box">The checked listbox</param>
        /// <param name="list">List of items</param>
        /// <param name="check">List of checked items</param>
        public static void CheckList(this CheckedListBox box, IEnumerable<string> list, ICollection<string> check)
        {
            box.Items.Clear();
            foreach (string s in list)
            {
                if (check.Contains(s))
                {
                    box.Items.Add(s, CheckState.Checked);
                }
                else
                {
                    box.Items.Add(s, CheckState.Unchecked);
                }
            }
        }

        /// <summary>
        /// Fills checked listbox
        /// </summary>
        /// <param name="box">The checked listbox</param>
        /// <param name="str">String of items</param>
        public static void CheckList(this CheckedListBox box, string str)
        {
            box.Items.Clear();
            foreach (char c in str)
            {
                box.Items.Add(c + "");
            }
        }

        /// <summary>
        /// Fills and checks a checked listbox
        /// </summary>
        /// <param name="box">The checked listbox</param>
        /// <param name="str">String of items</param>
        /// <param name="check">String of checked items</param>
        public static void CheckList(this CheckedListBox box, string str, string check)
        {
            box.Items.Clear();
            foreach (char c in str)
            {
                if (check.IndexOf(c) >= 0)
                {
                    box.Items.Add(c + "", CheckState.Checked);
                }
                else
                {
                    box.Items.Add(c + "", CheckState.Unchecked);
                }
            }
        }

        /// <summary>
        /// Gets checked items
        /// </summary>
        /// <param name="box">The checked listbox</param>
        /// <returns>List of items</returns>
        public static List<string> GetChecked(this CheckedListBox box)
        {
            List<string> l = new List<string>();
            foreach (string s in box.CheckedItems)
            {
                l.Add(s);
            }
            return l;
        }

        /// <summary>
        /// Gets unchecked items
        /// </summary>
        /// <param name="box">The checked listbox</param>
        /// <returns>List of items</returns>
        public static List<string> GetUnchecked(this CheckedListBox box)
        {
            List<string> l = new List<string>();
            List<string> check = GetChecked(box);
            foreach (string s in box.Items)
            {
                if (!check.Contains(s))
                {
                    l.Add(s);
                }
            }
            return l;
        }

        /// <summary>
        /// Gets string of checked items
        /// </summary>
        /// <param name="box">The checked listbox</param>
        /// <returns>The string of checked items</returns>
        public static string GetCheckedString(this CheckedListBox box)
        {
            string str = "";
            foreach (string s in box.CheckedItems)
            {
                str += s[0];
            }
            return str;
        }

        /// <summary>
        /// Gets string of unchecked items
        /// </summary>
        /// <param name="box">The checked listbox</param>
        /// <returns>The string of unchecked items</returns>
        public static string GetUncheckedString(this CheckedListBox box)
        {
            string str = "";
            string check = GetCheckedString(box);
            foreach (string s in box.Items)
            {
                char c = s[0];
                if (check.IndexOf(c) < 0)
                {
                    str += c;
                }
            }
            return str;
        }


        #endregion

        #region ListBox
        /// <summary>
        /// Fills listbox
        /// </summary>
        /// <param name="box">The listbox</param>
        /// <param name="items">Items</param>
        public static void FillListBox(this ListBox box, IEnumerable<string> items)
        {
            foreach (string item in items)
            {
                box.Items.Add(item);
            }
        }


        #endregion

        #region TextBox

        /// <summary>
        /// Gets double array from textBoxes
        /// </summary>
        /// <param name="boxes">The boxes</param>
        /// <returns>The array</returns>
        public static double[] GetDoubleTextArray(this TextBox[] boxes)
        {
            double[] arr = new double[boxes.Length];
            for (int i = 0; i < boxes.Length; i++)
            {
                double a = Double.Parse(boxes[i].Text);
                arr[i] = a;
            }
            return arr;
        }

        /// <summary>
        /// Fills text boxes
        /// </summary>
        /// <param name="boxes">The boxes</param>
        /// <param name="array">The array</param>
        /// <param name="offset">The offset</param>
        public static void FillTextBoxes(this TextBox[] boxes, Array array, int offset)
        {
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Text = array.GetValue(i + offset) + "";
            }
        }

 
        #endregion

        #region Access

        /// <summary>
        /// Gets associated control
        /// </summary>
        /// <param name="obj">Prototype</param>
        /// <returns>The control</returns>
        public static Control GetControl(this IAssociatedObject obj)
        {
            INamedComponent nc = obj.GetNamedComponent();
            if (nc is Control)
            {
                return nc as Control;
            }
            return null;
        }

        #endregion

        #region Resources

        /// <summary>
        /// Loads resources strings to control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="resources">The resources</param>
        public static void LoadControlResources(this Control control, Dictionary<string, object>[] resources)
        {
            ResourceService.StaticExtensionResourceService.LoadControlResources(control, resources);
        }

        #endregion

        #region Ations

        /// <summary>
        /// Performs ation with Messagebox error show
        /// </summary>
        /// <param name="control">Base control</param>
        /// <param name="action">The action</param>
        static public void PerformWithMessageBox(this Control control, Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        #endregion

    }


}
