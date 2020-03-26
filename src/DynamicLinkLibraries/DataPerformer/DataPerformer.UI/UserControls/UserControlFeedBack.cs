using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Utils;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control for feedback
    /// </summary>
    public partial class UserControlFeedBack : UserControl
    {
        #region Fields

        private IDataConsumer consumer;

        private IMeasurements measurements;

        private Dictionary<int, string> dictionary = new Dictionary<int, string>();

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlFeedBack()
        {
            InitializeComponent();
        }

        #endregion

        #region Members

        internal void Set(IDataConsumer consumer, IMeasurements measurements)
        {
            this.consumer = consumer;
            this.measurements = measurements;
        }


        internal void Set(Dictionary<int, string> dictionary)
        {
            ComboBox[] cb = Boxes;
            this.dictionary = dictionary;
            foreach (int i in dictionary.Keys)
            {
                if (i < cb.Length)
                {
                    cb[i].SelectCombo(dictionary[i]);
                }
            }
        }


        internal ComboBox[] Boxes
        {
            get
            {
                return userControlComboboxList.Boxes.ToArray();
            }
        }

        internal void Reset()
        {
            if ((consumer == null) | (measurements == null))
            {
                return;
            }
            userControlComboboxList.Count = measurements.Count;
            string[] t = new string[measurements.Count];
            ComboBox[] cb = Boxes;
            for (int i = 0; i < t.Length; i++)
            {
                IMeasurement m = measurements[i];
                t[i] = m.Name;
                object type = m.Type;
                List<string> l = new List<string>();
                consumer.GetAllAliases(l, type);
                cb[i].FillCombo(l);
            }
            userControlComboboxList.Texts = t;
            Set(dictionary);
        }


        internal Dictionary<int, string> Dictionary
        {
            get
            {
                ComboBox[] cb = Boxes;
                dictionary.Clear();
                for (int i = 0; i < cb.Length; i++)
                {
                    ComboBox c = cb[i];
                    object o = c.SelectedItem;
                    if (o != null)
                    {
                        dictionary[i] = o + "";
                    }
                }
                return dictionary;
            }
        }

        #endregion
    }
}
