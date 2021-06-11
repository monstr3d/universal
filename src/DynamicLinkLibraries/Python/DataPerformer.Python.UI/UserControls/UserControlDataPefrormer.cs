using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataPeformer.Python.Objects;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using Diagram.UI.Interfaces;
using Diagram.UI.Utils;

namespace DataPefrormer.Python.UI.UserControls
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
                d = value;
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

   
        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControlInput_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {

        }


        void IPostSet.Post()
        {

        }

    }
}
