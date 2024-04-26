using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.UI.Interfaces;
using DataPerformer.UI.Labels;
using Diagram.UI;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Pkcs;
using System.Text.Json;
using System.Windows.Forms;
using WindowsExtensions;

namespace DataPerformer.WebGenerator.UserControls
{
    public partial class UserControGenerator : UserControl
    {
        GraphLabel label;

        Saver saver;

        IDataConsumer consumer;

        DataGridView input;

        DataGridView output;

        string filename;

        public UserControGenerator()
        {
            InitializeComponent();
            input = userControlInput.FindControlChild<DataGridView>();
            output = userControlOutput.FindControlChild<DataGridView>();
            filename = Path.Combine(ControlExtensions.ConfigurationPath, "WebGenerator.ini");
        }

        internal void Set(GraphLabel label, Saver saver)
        {
            this.label = label;
            this.saver = saver;
            consumer = label.Object as IDataConsumer;
            userControGeneratorSummary.Saver = saver;
            var an = consumer.GetAllAliases();
            DataTable dt = an.Create(saver.Input);
            dt.Fill(input);
            IGraphLabel l = label;
            var s = l.Data.Item3;
            var list = new List<string>(s.Keys);
            var ss = label.MultiSeries;
            foreach (var item in ss)
            {
                foreach (var key in item.Keys)
                {
                    var pp = key + ".";
                    var it = item[key];
                    foreach (var val in it.Keys)
                    {
                        var st = pp + val;
                        if (!list.Contains(st))
                        {
                            list.Add(st);
                        }
                    }
                }
            }
            dt = list.Create(saver.Output);
            dt.Fill(output);
        }
        internal void Genterate()
        {
            //saver.Input =
    
            string jsonString = JsonSerializer.Serialize(saver);

        }


    }
}
