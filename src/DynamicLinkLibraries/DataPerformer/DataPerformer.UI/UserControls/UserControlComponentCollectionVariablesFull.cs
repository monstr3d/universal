using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataPerformer.Helpers;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Full editor of collection of variables
    /// </summary>
    public partial class UserControlComponentCollectionVariablesFull : UserControl
    {

        #region Fields

        DataPerformerCollectionStateTransformer transformer;

 
        /// <summary>
        /// Types
        /// </summary>
        public static readonly Type[] Types = new Type[]
        {
            typeof(StateTransformer), typeof(StateVariableTransformer)
        };

        #endregion

        #region Ctor

        /// <summary>
        /// Construtor
        /// </summary>
        public UserControlComponentCollectionVariablesFull()
        {
            InitializeComponent();
        }

        #endregion


        /// <summary>
        /// Transformer
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataPerformerCollectionStateTransformer Transformer
        {
            get
            {
                return transformer;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                transformer = value;
                Type t = transformer.Transformer.GetType();
                for (int i = 0; i < Types.Length; i++)
                {
                    if (t.Equals(Types[i]))
                    {
                        comboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }


        private void SetChild()
        {
            panelCenter.Controls.Clear();
            UserControl uc = null;
            AbstractDoubleTransformer tr = transformer.Transformer;
            if (tr is StateTransformer)
            {
                StateTransformer str = tr as StateTransformer;
               UserControlComponentCollectionVariablesStep ucs = new UserControlComponentCollectionVariablesStep();
                uc = ucs;
                ucs.Step = transformer.Step;
                ucs.Collection = transformer;
                ucs.SetStep += (double a) => { transformer.Step = a; };
            }
            else
            {
                UserControlComponentCollectionVariablesMeasure ucm = new UserControlComponentCollectionVariablesMeasure();
                uc = ucm;
                ucm.Transformer = transformer;
            }
            uc.Dock = DockStyle.Fill;
            panelCenter.Controls.Add(uc);
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox.SelectedIndex;
            if (i >= 0)
            {
                transformer.TransformerType = Types[i];
                SetChild();
            }
        }
    }
}
