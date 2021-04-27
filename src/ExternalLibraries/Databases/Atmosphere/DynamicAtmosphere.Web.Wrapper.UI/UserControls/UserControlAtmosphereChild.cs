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

using Diagram.UI;
using Diagram.UI.Interfaces;

namespace DynamicAtmosphere.Web.Wrapper.UI.UserControls
{
    /// <summary>
    /// Atmosphere with child
    /// </summary>
    public partial class UserControlAtmosphereChild : UserControl
    {
        internal UserControlAtmosphereChild()
        {
            InitializeComponent();
        }


        internal Atmosphere Atmosphere
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                IChildrenObject co = value;
                IAssociatedObject[] ao = co.Children;
                if (ao == null)
                {
                    return;
                }
                foreach (object o in ao)
                {
                    if (o is IPropertiesEditor)
                    {
                        IPropertiesEditor pe = o
                            as IPropertiesEditor;
                        object edit = pe.Editor;
                        if (edit is object[])
                        {
                            object[] oe = edit as object[];
                            foreach (object eo in oe)
                            {
                                if (eo is UserControl)
                                {
                                    UserControl uc = eo as UserControl;
                                    uc.Dock = DockStyle.Fill;
                                    panelChild.Controls.Add(uc);
                                    goto fin;
                                }
                            }
                        }
                    }
                }
            fin:
                return;
            }
        }
    }
}
