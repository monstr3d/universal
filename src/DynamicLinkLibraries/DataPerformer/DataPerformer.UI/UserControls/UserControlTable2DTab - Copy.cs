using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;

using DataPerformer;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Tab control for 2D table
    /// </summary>
    public partial class UserControlTable2DTab : UserControl
    {
        #region Members

        Table2D table;

        #endregion


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlTable2DTab()
        {
            InitializeComponent();
        }

        #endregion

        #region Members

        internal Table2D Table
        {
            set
            {
                userControlTable2DEditor.Table = value;
                table = value;
           // !!! COMMENTS     this.SetComments(table.Comments);
            }
        }

        internal Action Action
        {
            set
            {
                userControlTable2DEditor.Action = value;
            }
        }

 
        #endregion
    }
}
