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
    /// Hetero container
    /// </summary>
    public partial class UserControlHeteroContainer : UserControl
    {
        #region Fields

        static private int height = 0;

        /// <summary>
        /// List of controls
        /// </summary>
        protected List<UserControlHeteroContainer> list =
            new List<UserControlHeteroContainer>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserControlHeteroContainer()
        {
            InitializeComponent();
            if (height == 0)
            {
                height = Height;
            }
            list.Add(this);
        }


        /// <summary>
        /// Constructor
        /// </summary>

        private UserControlHeteroContainer(List<UserControlHeteroContainer> list)
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
                foreach (UserControlHeteroContainer uc in list)
                {
                    t.Add(uc.labelText.Text);
                }
                return t.ToArray();
            }
            set
            {
                for (int i = 0; i < list.Count; i++)
                {
                    UserControlHeteroContainer uc = list[i];
                    if (i >= value.Length)
                    {
                        uc.labelText.Text = "";
                    }
                    else
                    {
                        uc.labelText.Text = value[i];
                    }
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
                foreach (UserControlHeteroContainer uc in list)
                {
                    uc.labelText.Font = value;
                }
            }
        }

        /// <summary>
        /// Children
        /// </summary>
        public Control[] Children
        {
            get
            {
                Control[] controls = new Control[Count];
                for (int i = 0; i < controls.Length; i++)
                {
                    controls[i] = list[i].panelTop.Controls[0];
                }
                return controls;
            }
            set
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].panelComponent.Controls.Clear();
                    list[i].panelComponent.Controls.Add(value[i]);
                }
            }
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
            if (c is UserControlHeteroContainer)
            {
                UserControlHeteroContainer uc = c as UserControlHeteroContainer;
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
            UserControlHeteroContainer ucc = null;
            if (control is UserControlComboboxList)
            {
                ucc = control as UserControlHeteroContainer;
                if (ucc.Count == num)
                {
                    return ucc;
                }
                ucc.Count = num;
                return ucc;
            }
            Control par = Remove(control);
            ucc = new UserControlHeteroContainer();
            ucc.Count = num;
            ucc.Dock = DockStyle.Fill;
            par.Controls.Add(ucc);
            return ucc;
        }




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
            UserControlHeteroContainer fin = list[n - 1];
            UserControlHeteroContainer uc = new UserControlHeteroContainer(list);
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
            UserControlHeteroContainer fin = list[n - 1];
            UserControlHeteroContainer pre = list[n - 2];
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
