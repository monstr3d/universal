using DataPerformer.UI.Labels;
using System.Text.Json;
using System.Windows.Forms;
using WindowsExtensions;

namespace DataPerformer.WebGenerator.UserControls
{
    public partial class UserControGenerator : UserControl
    {
        GraphLabel label;

        Saver saver;

        public UserControGenerator()
        {
            InitializeComponent();
        }

        internal void Set(GraphLabel label, Saver saver)
        {
            this.label = label;
            this.saver = saver;
            userControGeneratorSummary.Saver = saver;
        }

        internal void Genterate()
        {
            saver.Input = userControlInput.ToDataTable();
            saver.Output = userControlOutput.ToDataTable();
            userControGeneratorSummary.Get();

            string jsonString = JsonSerializer.Serialize(saver);

        }


    }
}
