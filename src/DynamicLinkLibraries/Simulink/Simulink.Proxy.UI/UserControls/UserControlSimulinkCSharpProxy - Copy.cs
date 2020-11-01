using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BaseTypes;

using DataPerformer.Portable;

using Simulink.CSharp.Proxy;
using Diagram.UI.Utils;


namespace Simulink.Proxy.UI.UserControls
{
    /// <summary>
    /// Editor of C# proxy of Simulink
    /// </summary>
    public partial class UserControlSimulinkCSharpProxy : UserControl
    {

        #region Fields

        CSharpSimulinkProxy proxy;

        List<string> l = new List<string>();

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlSimulinkCSharpProxy()
        {
            InitializeComponent();
        }

        
        internal CSharpSimulinkProxy Proxy
        {
            set
            {
                proxy = value;
                Fill();
            }
        }


        internal void Accept()
        {
            string[] ss = userControlComboboxList.Texts;
            Dictionary<string, string> l = new Dictionary<string, string>();
            ComboBox[] bxs = userControlComboboxList.Boxes.ToArray();
            for (int i = 0; i < bxs.Length; i++)
            {
                object o = bxs[i].SelectedItem;
                if (o == null)
                {
                    continue;
                }
                l[o + ""] = ss[i];
            }
            proxy.Links = l;
        }


        internal void Fill()
        {
            l.Clear();
            Dictionary<string, Type> d = proxy.Input;
            if (d == null)
            {
                return;
            }
            foreach (string s in d.Keys)
            {
                l.Add(s);
            }
            string[] ss = l.ToArray();
            userControlComboboxList.Texts = ss;
            Dictionary<string, string> dl = proxy.Links;
            ComboBox[] b = userControlComboboxList.Boxes.ToArray();

            for (int i = 0; i < ss.Length; i++)
            {
                string sn = ss[i];
                Type t = d[sn];
                object type = t.GetObjectFromType();
                IList<string> ls = proxy.GetAllMeasurementsType(type);
                b[i].FillCombo(ls);
                foreach (string key in dl.Keys)
                {
                    if (sn.Equals(dl[key]))
                    {
                        b[i].SelectCombo(key);
                        break;
                    }
                }
            }
        }


        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Accept();
        }
    }
}
