using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// List of aligned editors
    /// </summary>
    public partial class UserControlEditList : UserControl
    {
        #region Fields
        Type type;

         static private int height = 0;


        Control control;

        Type[] types = new Type[]{typeof(Label)};

        /// <summary>
        /// List of controls
        /// </summary>
        protected List<UserControlEditList> list = new List<UserControlEditList>();
            

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlEditList()
        {
            InitializeComponent();
           if (height == 0)
            {
                height = Height;
            }
            list.Add(this);
        }

        private UserControlEditList(List<UserControlEditList> list) : this()
        {
            this.list = list;
            list.Add(this);
        }

 
        #endregion

        #region Public Members

        /// <summary>
        /// Gets control
        /// </summary>
        public Control Control
        {
            get
            {
                return control;
            }
        }

        /// <summary>
        /// Gets i - th control
        /// </summary>
        /// <param name="i">Control number</param>
        /// <returns>The i - th control</returns>
        public Control this[int i]
        {
            get
            {
                return list[i].Control;
            }
        }

        /// <summary>
        /// Gets child control as T type
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="number">Child numbers</param>
        /// <returns>The child as T</returns>
        public T GetControl<T>(int number) where T : class
        {
            return this[number] as T;
        }



        /// <summary>
        /// Type of control
        /// </summary>
        public Type Type
        {
            get
            {
                return type;
            }
            set
            {
                userControl.Controls.Clear();
                type = value;
                if (type == null)
                {
                    return;
                }
                ConstructorInfo c = type.GetConstructor(new Type[0]);
                control = c.Invoke(new object[0]) as Control;
                control.Dock = DockStyle.Fill;
                userControl.Controls.Add(control);
            }
        }

        /// <summary>
        /// Types
        /// </summary>
        public Type[] Types
        {
            get
            {
                return types;
            }
            set
            {
                types = value;
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Type = value[i];
                }
            }
        }

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
                types = new Type[value];
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
                foreach (UserControlEditList uc in list)
                {
                    t.Add(uc.labelText.Text);
                }
                return t.ToArray();
            }
            set
            {
                for (int i = 0; i < list.Count; i++)
                {
                    UserControlEditList uc = list[i];
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

        



        #endregion

        #region Private Members

        private void Add()
        {
            int n = list.Count;
            UserControlEditList fin = list[n - 1];
            for (int i = 0; i < n; i++)
            {
                list[i].Height += height;
            }
            UserControlEditList uc = new UserControlEditList(list);
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
            UserControlEditList fin = list[n - 1];
            UserControlEditList pre = list[n - 2];
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
