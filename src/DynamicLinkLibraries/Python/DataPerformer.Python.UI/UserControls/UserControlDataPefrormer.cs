using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CategoryTheory;
using DataPerformer.Python.Objects;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using Diagram.UI.Interfaces;
using Diagram.UI.Utils;

namespace DataPerformer.Python.UI.UserControls
{
    public partial class UserControlDataPefrormer : UserControl, IPostSet
    {
        private PythonTransformer transformer;

        private IDataConsumer dc;

        public UserControlDataPefrormer()
        {
            InitializeComponent();
        }


        internal PythonTransformer Transformer
        {
            set
            {
                transformer = value;
                dc = value;
                textBoxCode.Text = transformer.Code;
            }
        }

        void FillTypes()
        {
            var to = new List<Tuple<string, object>>();
            List<string> l = new List<string>(transformer.Outputs.Keys);
            l.Sort();
            foreach (var t in l)
            {
                to.Add(new Tuple<string, object>(t, transformer.Outputs[t][0]));
            }
            userControlTypeListOutput.Types = to;
            var ti = new List<Tuple<string, object>>();
            foreach (var t in l)
            {
                var s = transformer.Inputs[t];
                IMeasurement m = dc.FindMeasurement(s);
                ti.Add(new Tuple<string, object>(t, m.Type));
            }
            userControlTypeListInput.Types = ti;
        }

        void FillInput()
        {
            var t = userControlTypeListInput.Types;
            var d = new Dictionary<string, object>();
            foreach (var tt in t)
            {
                d[tt.Item1] = tt.Item2;
            }
            var l = new List<string>(d.Keys);
            l.Sort();
            userControlComboboxListInput.Texts = l.ToArray();
           var b =  userControlComboboxListInput.Boxes;
            for (int i = 0; i < l.Count; i++)
            {
                var s = l[i];
                var ty = d[s];
                var ttt = dc.GetAllMeasurementsType(ty);
                b[i].FillCombo(ttt);
                if (transformer.Inputs.ContainsKey(s))
                {
                    b[i].SelectCombo(transformer.Inputs[s]);
                }
            }
        }

        void SelectInput()
        {
            var d = new Dictionary<string, string>();
            var t = userControlComboboxListInput.Texts;
            for (int i = 0; i < t.Length; i++)
            {
                var o = userControlComboboxListInput.Boxes[i];
                if (o != null)
                {
                    d[t[i]] = o + "";
                }
            }
            transformer.Inputs = d;
        }


        void SelectOutput()
        {
            var t = userControlTypeListOutput.Types;
            var l = new Dictionary<string, object[]>();
            foreach (var ttt in t)
            {
                l[ttt.Item1] = new object[] { ttt.Item2, ttt.Item2 };
            }
            var ll = new List<string>(l.Keys);
            ll.Sort();
            var tt = transformer.Outputs;
            tt.Clear();
            foreach (var k in ll)
            {
                tt[k] = l[k];
            }
        }
  
        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageInput)
            {
                FillInput();
                return;
            }
            SelectInput();

        }

        private void tabControlInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlInput.SelectedTab == tabPageMap)
            {
                FillInput();
                return;
            }
            SelectInput();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            transformer.Code = textBoxCode.Text;
            SelectInput();
            SelectOutput();
            transformer.CreateAll();
            
        }


        void IPostSet.Post()
        {
            FillTypes();
            FillInput();
        }

    }
}
