using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.UI.Interfaces;
using DataPerformer.UI.Labels;
using System.Collections.Generic;
using System.Data;
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

        public UserControGenerator()
        {
            InitializeComponent();
            input = userControlInput.FindControlChild<DataGridView>();
            output = userControlOutput.FindControlChild<DataGridView>();
        }

        internal void Set(GraphLabel label, Saver saver)
        {
            this.label = label;
            this.saver = saver;
            consumer = label.Object as IDataConsumer;
            userControGeneratorSummary.Saver = saver;
            var an = consumer.GetAllAliases();
            input.Fill(an, saver.Input);
            IGraphLabel l = label;
            var s = l.Data.Item3;
            var list = new List<string>(s.Keys);
            


        }

        internal void Genterate()
        {
            userControlInput.Fill(saver.Input);
            userControlOutput.Fill(saver.Output);
            userControGeneratorSummary.Get();

            string jsonString = JsonSerializer.Serialize(saver);

        }


    }
}
