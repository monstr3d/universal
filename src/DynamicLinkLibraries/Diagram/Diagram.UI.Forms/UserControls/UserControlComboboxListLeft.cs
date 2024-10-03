using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// List of comboboxes with left position of labels
    /// </summary>
    public partial class UserControlComboboxListLeft : UserControl
    {
        #region Fields

        static private int height = 0;

        /// <summary>
        /// List of controls
        /// </summary>
        protected List<UserControlComboboxListLeft> list = new List<UserControlComboboxListLeft>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlComboboxListLeft()
        {
            InitializeComponent();
            if (height == 0)
            {
                height = Height;
            }
            list.Add(this);
        }

        private UserControlComboboxListLeft(List<UserControlComboboxListLeft> list)
            : this()
        {
            this.list = list;
            list.Add(this);
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Count of comboboxes
        /// </summary>
        public int Count
        {
            get
            {
                return list.Count;
            }
            set
            {
                int n = list.Count;
                if (n == value)
                {
                    return;
                }
                if (value > n)
                {
                    for (int i = n; i < value; i++)
                    {
                        Add();
                    }
                }
                else
                {
                    for (int i = value; i < n; i++)
                    {
                        Remove();
                    }
                }
            }
        }

        /// <summary>
        /// Texts of labels
        /// </summary>
        public string[] Texts
        {
            get
            {
                List<string> t = new List<string>();
                foreach (UserControlComboboxListLeft uc in list)
                {
                    t.Add(uc.labelText.Text);
                }
                return t.ToArray();
            }
            set
            {
                for (int i = 0; i < list.Count; i++)
                {
                    UserControlComboboxListLeft uc = list[i];
                    uc.labelText.Text = value[i];
                }
            }
        }



        /// <summary>
        /// Font of labels
        /// </summary>
        public Font LabelFont
        {
            get
            {
                return labelText.Font;
            }
            set
            {
                foreach (UserControlComboboxListLeft uc in list)
                {
                    uc.labelText.Font = value;
                }
            }
        }

        /// <summary>
        /// Boxes
        /// </summary>
        public List<ComboBox> Boxes
        {
            get
            {
                List<ComboBox> boxes = new List<ComboBox>();
                foreach (UserControlComboboxListLeft uc in list)
                {
                    boxes.Add(uc.comboBox);
                }
                return boxes;
            }
        }

        /// <summary>
        /// Selected strings
        /// </summary>
        public string[] Selected
        {
            get
            {
                List<ComboBox> boxes = Boxes;
                string[] sel = new string[boxes.Count];
                for (int i = 0; i < sel.Length; i++)
                {
                    object it = boxes[i].SelectedItem;
                    if (it != null)
                    {
                        sel[i] = it + "";
                    }
                }
                return sel;
            }
        }

        /// <summary>
        /// Creates Combo control
        /// </summary>
        /// <param name="texts">Texts</param>
        /// <returns>Created control</returns>
        public static Control CreateComboboxControl(string[] texts)
        {
            if (texts != null)
            {
                if (texts.Length > 0)
                {
                    UserControlComboboxList uc = new UserControlComboboxList();
                    uc.Count = texts.Length;
                    uc.Texts = texts;
                    uc.Dock = DockStyle.Fill;
                    return uc;
                }
            }
            return Panel;
        }

        /// <summary>
        /// Gets selected combobox items of control
        /// </summary>
        /// <param name="control">The control</param>
        /// <returns>The items</returns>
        public static string[] GetSelected(Control control)
        {
            if (!(control is UserControlComboboxList))
            {
                return new string[0];
            }
            UserControlComboboxList uc = control as UserControlComboboxList;
            return uc.Selected;
        }

        /// <summary>
        /// Replaces control by new texts
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="texts">Texts</param>
        /// <returns>Replacing result</returns>
        public static Control Replace(Control control, string[] texts)
        {
            if (texts == null)
            {
                return Replace(control, 0);
            }
            Control c = Replace(control, texts.Length);
            if (c is UserControlComboboxList)
            {
                UserControlComboboxList uc = c as UserControlComboboxList;
                uc.Texts = texts;
            }
            return c;
        }

        /// <summary>
        /// Replaces combobox control
        /// </summary>
        /// <param name="control">The replaced control</param>
        /// <param name="num">Number of comboboxes</param>
        /// <returns>Replacing result</returns>
        public static Control Replace(Control control, int num)
        {
            if (num == 0)
            {
                if (control is Panel)
                {
                    return control;
                }
                Control p = Remove(control);
                Panel pan = Panel;
                p.Controls.Add(pan);
                return pan;
            }
            UserControlComboboxList ucl = null;
            if (control is UserControlComboboxList)
            {
                ucl = control as UserControlComboboxList;
                if (ucl.Count == num)
                {
                    return ucl;
                }
                ucl.Count = num;
                return ucl;
            }
            Control par = Remove(control);
            ucl = new UserControlComboboxList();
            ucl.Count = num;
            ucl.Dock = DockStyle.Fill;
            par.Controls.Add(ucl);
            return ucl;
        }

        /// <summary>
        /// Width of text
        /// </summary>
        public int TextWidth
        {
            get
            {
                return panelLeftCombo.Width;
            }
            set
            {
                foreach (UserControlComboboxListLeft uc in list)
                {
                    uc.panelLeftCombo.Width = value;
                    Label l = uc.labelText;
                    l.Width = value - l.Left - 1;
                }
            }
        }

        /*   /// <summary>
           /// Localization
           /// </summary>
           /// <param name="dic">Dictionaries</param>
           public void Localize(Dictionary<string, string>[] dic)
           {
               foreach (UserControlComboboxList uc in list)
               {
                   Label l = uc.labelText;
                   string text = l.Text;
                   foreach (Dictionary<string, string> d in dic)
                   {
                       if (d.ContainsKey(text))
                       {
                           l.Text = d[text];
                           break;
                       }
                   }
               }
           }*/



        #endregion

        #region Internal Members

        internal Label Label
        {
            get
            {
                return labelText;
            }
        }

        #endregion

        #region Private Members

        private static Control Remove(Control c)
        {
            Control p = c.Parent;
            p.Controls.Remove(c);
            return p;
        }

        private static Panel Panel
        {
            get
            {
                Panel p = new Panel();
                p.Width = 0;
                p.Height = 0;
                return p;
            }
        }

        private void Add()
        {
            int n = list.Count;
            UserControlComboboxListLeft fin = list[n - 1];
            UserControlComboboxListLeft uc = new UserControlComboboxListLeft(list);
            for (int i = 0; i < n; i++)
            {
                list[i].Height += height;
            }
            uc.Dock = DockStyle.Fill;
            uc.labelText.Font = labelText.Font;
            fin.panelCenter.Controls.Add(uc);
        }

        void Remove()
        {
            if (list.Count == 1)
            {
                return;
            }
            int n = list.Count;
            UserControlComboboxListLeft fin = list[n - 1];
            UserControlComboboxListLeft pre = list[n - 2];
            pre.panelCenter.Controls.Remove(fin);
            list.Remove(fin);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Height -= height;
            }
        }

        #endregion

    }
}
