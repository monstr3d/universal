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
    /// Items of list
    /// </summary>
    public partial class UserControlListItems : UserControl
    {
        #region Fields

        List<UserControlListItem> l = new List<UserControlListItem>();

        List<ComboBox> boxes = new List<ComboBox>();

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlListItems()
        {
            InitializeComponent();
            Resize += UserControlListItems_Resize;
        }

   
        #endregion

        #region Members

        /// <summary>
        /// Count of comboboxes
        /// </summary>
        public int Count
        {
            get
            {
                return l.Count;
            }
            set
            {
                if (l.Count == value)
                {
                    return;
                }
                l.Clear();
                boxes.Clear();
                Controls.Clear();
                int y = 0;
                for (int i = 0; i < value; i++)
                {
                    UserControlListItem it = new UserControlListItem();
                    it.Top = y;
                    Controls.Add(it);
                    y = it.Bottom;
                    l.Add(it);
                    boxes.Add(it.Box);
                }
                Height = y + 1;
                ResizeC();
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
                foreach (UserControlListItem it in l)
                {
                    t.Add(it.Label);
                }
                return t.ToArray();
            }
            set
            {
                if (value.Length != l.Count)
                {
                    throw new Exception();
                }
                for (int i = 0; i < value.Length; i++)
                {
                    l[i].Label = value[i];
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
                return boxes;
            }
        }

        #region Private

        void ResizeC()
        {
            foreach (UserControlListItem it in l)
            {
                it.Left = 0;
                it.Width = Width - 1;
            }
        }

        #endregion

        #endregion

        #region Event Handlers

        void UserControlListItems_Resize(object sender, EventArgs e)
        {
           ResizeC();
        }

        #endregion

    }
}
