using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control which sets integer valur for every chart
    /// </summary>
    public partial class UserControlCharIntDictionary : UserControl
    {
        Dictionary<string, UserControlCharNumber> cont =
            new Dictionary<string, UserControlCharNumber>();
        int min = 0;

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCharIntDictionary()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ICollection<string> Keys
        {
            set
            {
                Controls.Clear();
                cont.Clear();
                List<string> l = new List<string>(value);
                l.Sort();
                int y = 0;
                for (int i = 0; i < l.Count; i++)
                {
                    string n = l[i];
                    UserControlCharNumber uc = new UserControlCharNumber();
                    uc.Minimum = min;
                    uc.Char = n;
                    cont[n] = uc;
                    uc.Top = y;
                    y += uc.Height;
                    Controls.Add(uc);
                }
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Dictionary<string, int> Dictionary
        {
            get
            {
                Dictionary<string, int> d = new Dictionary<string, int>();
                foreach (string key in cont.Keys)
                {
                    d[key] = cont[key].Value;
                }
                return d;
            }
            set
            {
                foreach (string key in value.Keys)
                {
                    UserControlCharNumber uc = cont[key];
                    uc.Value = value[key];
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int Minimum
        {
            get
            {
                return min;
            }
            set
            {
                min = value;
            }
        }
        
    }
}
