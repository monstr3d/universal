using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Simulink.Parser.Library;

namespace Simulink.Proxy.UI.UserControls
{
    /// <summary>
    /// User control for simulink scheme and simulink tree
    /// </summary>
    public partial class UserControlSimulinkSchemeAndTree : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlSimulinkSchemeAndTree()
        {
            InitializeComponent();
            userControlSimulinkSystemPicture.ChangeSystem = userControlSimulinkTree;
        }

        /// <summary>
        /// System
        /// </summary>
        public object SimulinkSystem
        {
            set
            {
                userControlSimulinkTree.SimulinkSystem = value;
                userControlSimulinkSystemPicture.SimulinkSystem = value;
            }
        }
    }
}
