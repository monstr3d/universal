using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CategoryTheory;

namespace Celestrak.NORAD.Satellites.UI.UserControls
{
    /// <summary>
    /// Editor of object with child
    /// </summary>
    public partial class UserControlChild : UserControl
    {

        #region Ctor
        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlChild()
        {
            InitializeComponent();
        }

        #endregion

        #region Members

        internal void Delete()
        {
            userControlCelestrak.Delete();
        }

        internal Celestrak.NORAD.Satellites.SatelliteData Satellite
        {
            get
            {
                return userControlCelestrak.Data;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                userControlCelestrak.Data = value;
                IChildrenObject ch = value;
                if (ch.Children != null)
                {
                    foreach (object o in ch.Children)
                    {
                        if (o is Diagram.UI.IPropertiesEditor)
                        {
                            object ob = (o as Diagram.UI.IPropertiesEditor).Editor;
                            if (ob is object[])
                            {
                                object[] oo = ob as object[];
                                foreach (object ooo in oo)
                                {
                                    if (ooo is UserControl)
                                    {
                                        UserControl uc = ooo as UserControl;
                                        uc.Dock = DockStyle.Fill;
                                        panelChild.Controls.Add(uc);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
