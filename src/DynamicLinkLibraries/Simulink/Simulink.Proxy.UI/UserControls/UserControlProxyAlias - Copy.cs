using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Simulink.CSharp.Proxy;
using Diagram.UI;

namespace Simulink.Proxy.UI.UserControls
{
    /// <summary>
    /// Editor of Simulink component as alias
    /// </summary>
    public partial class UserControlProxyAlias : UserControl
    {
 
        #region Fields

        CSharpSimulinkProxy proxy;


        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlProxyAlias()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Proxy
        /// </summary>
        public CSharpSimulinkProxy Proxy
        {
            set
            {
                proxy = value;
                userControlSimulinkCSharpProxy.Proxy = value;
                propertyGrid.SetAlias(value);
            }
        }

        internal void Fill()
        {
            userControlSimulinkCSharpProxy.Fill();
        }


    }
}
