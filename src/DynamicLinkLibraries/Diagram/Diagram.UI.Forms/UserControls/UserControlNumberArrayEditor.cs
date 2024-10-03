using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// Editor of number array
    /// </summary>
    public partial class UserControlNumberArrayEditor : UserControl
    {

        #region Fields

        List<UserControlNumberEditorUnit> list 
            = new List<UserControlNumberEditorUnit>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlNumberArrayEditor()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Members

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="names">Names</param>
        public void Set(int[] array, string[] names)
        {
            int y = 0;
            for (int i = 0; i < array.Length; i++)
            {
                UserControlNumberEditorUnit uc =
                    new UserControlNumberEditorUnit(array, i, names[i]);
                list.Add(uc);
                uc.Left = 0;
                uc.Top = y;
                y += uc.Height;
                panelCenter.Controls.Add(uc);
            }
        }

        /// <summary>
        /// Change event
        /// </summary>
        public event Action Change
        {
            add
            {
                foreach (UserControlNumberEditorUnit uc in list)
                {
                    uc.Change += value;
                }
            }
            remove
            {
                foreach (UserControlNumberEditorUnit uc in list)
                {
                    uc.Change += value;
                }
            }
        }

        #endregion

        #region Event Handlers

        private void panelCenter_Resize(object sender, EventArgs e)
        {
            foreach (UserControlNumberEditorUnit uc in list)
            {
                uc.Width = panelCenter.Width - 1;
            }
        }

        #endregion
    }
}
