using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Simulink.Parser.Library;
using CommonControls;
using Simulink.Proxy.UI.Tree;
using Simulink.Proxy.UI.Interfaces;

namespace Simulink.Proxy.UI.UserControls
{
    /// <summary>
    /// Editor of Simulink tree
    /// </summary>
    public partial class UserControlSimulinkTree : UserControl, IChangeSystem
    {
        Action<object> act = delegate(object ss)
        {
        };

        /// <summary>
        /// Default constructot
        /// </summary>
        public UserControlSimulinkTree()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Simulink system
        /// </summary>
        public object SimulinkSystem
        {
            set
            {
                treeView.Nodes.Clear();
                TreePerformer.Add(value, new SimulinkTree(), treeView);
            }
        }

        #region IChangeSystem Members

        event Action<object> IChangeSystem.ChangeSystem
        {
            add { act += value; }
            remove { act -= value; }
        }

        #endregion

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView.SelectedNode;
            if (node == null)
            {
                return;
            }
            object o = node.Tag;
            if (o is SimulinkSubsystem)
            {
                SimulinkSubsystem ss = o as SimulinkSubsystem;
                act(ss);
            }
        }
    }
}
