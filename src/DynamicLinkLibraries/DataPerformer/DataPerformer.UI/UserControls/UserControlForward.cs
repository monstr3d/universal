using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Forward send alias user control
    /// </summary>
    public partial class UserControlForward : UserControl
    {
        #region Fields

        IMeasurements measurements;

        Dictionary<int, string> items = new Dictionary<int,string>();

        event Action<Dictionary<int, string>> onChange =
            (Dictionary<int, string> d) => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlForward()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Measurements
        /// </summary>
        public IMeasurements Measurements
        {
            get
            {
                return measurements;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                measurements = value;
                int n = measurements.Count;
                userControlComboboxList.Count = n;
                List<ComboBox> b = userControlComboboxList.Boxes;
                List<string> tt = new List<string>();
                Dictionary<object, List<IAliasName>> d = measurements.GetAliasesByTypes();
                for (int i = 0; i < n; i++)
                {
                    IMeasurement m = measurements[i];
                    tt.Add(m.Name);
                    object type = m.Type;
                    if (d.ContainsKey(type))
                    {
                        List<IAliasName> la = d[type];
                        ComboBox cb = b[i];
                        foreach (IAliasName an in la)
                        {
                            cb.Items.Add(measurements.GetRelativeMeasureAliasName(an));
                        }
                    }
                }
                userControlComboboxList.Texts = tt.ToArray();
            }
        }

        /// <summary>
        /// Items
        /// </summary>
        public Dictionary<int, string> Items
        {
            get
            {
                bool change = false;
                Dictionary<int, string> d = new Dictionary<int, string>();
                for (int i = 0; i < userControlComboboxList.Boxes.Count; i++)
                {
                    object o = userControlComboboxList.Boxes[i].SelectedItem;
                    if (o == null)
                    {
                        if (items.ContainsKey(i))
                        {
                            change = true;
                        }
                    }
                    else
                    {
                        string str = o + "";
                        if (!items.ContainsKey(i))
                        {
                            change = true;
                        }
                        else if (!items[i].Equals(str))
                        {
                            change = true;
                        }
                        d[i] = str;
                    }
                }
                items = d;
                if (change)
                {
                    onChange(d);
                }
                return d;
            }
            set
            {
                items = value;
                for (int i = 0; i < userControlComboboxList.Count; i++)
                {
                    ComboBox b = userControlComboboxList.Boxes[i];
                    if (items.ContainsKey(i))
                    {
                        string s = items[i];
                        for (int j = 0; j < b.Items.Count; j++)
                        {
                            if (s.Equals(b.Items[j] + ""))
                            {
                                b.SelectedIndex = j;
                                break;
                            }
                        }
                    }
                    b.SelectedIndexChanged += SelectedIndexChanged;
                }
            }
        }

        /// <summary>
        /// On Change Event
        /// </summary>
        public event Action<Dictionary<int, string>> OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region Event Handrers
        
        void SelectedIndexChanged(object sender, EventArgs e)
        {
            items = Items;
        }


        #endregion
    }
}
