using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BaseTypes.Attributes;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// Time type editor
    /// </summary>
    public partial class UserControlTimeUnit : UserControl
    {

        #region Fields

        event Action<TimeType> changeTimeUnit = (TimeType type) => { };

        Dictionary<string, object> dic = UserControlPhysicalUnit.StringUnitDictionary[2];

        #endregion


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlTimeUnit()
        {
            InitializeComponent();
            foreach (string key in dic.Keys)
            {
                comboBox.Items.Add(key);
            }
        }

        /// <summary>
        /// Type of time
        /// </summary>
        public TimeType TimeUnit
        {
            get
            {
                object o = comboBox.SelectedItem;
                if (o == null)
                {
                    return TimeType.Second;
                }
                return (TimeType)dic[o + ""];
            }
            set
            {
                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    string key = comboBox.Items[i] + "";
                    if (value.Equals(dic[key]))
                    {
                        comboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Change time unit event
        /// </summary>
        public event Action<TimeType> ChangeTimeUnit
        {
            add { changeTimeUnit += value; }
            remove { changeTimeUnit -= value; }
        }

        #endregion

        #region Event handlers

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            object o = comboBox.SelectedItem;
            if (o == null)
            {
                return;
            }
            TimeType type = (TimeType)dic[o + ""];
            changeTimeUnit(type);
        }

        #endregion

    }
}
