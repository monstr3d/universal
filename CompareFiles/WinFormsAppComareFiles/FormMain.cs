namespace WinFormsAppComareFiles
{
    using CompareFiles;
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            textBoxSource.Text = Properties.Settings.Default.Source;
            textBoxDestination.Text = Properties.Settings.Default.Destination;
        }

        private void buttonSource_Click(object sender, EventArgs e)
        {
            if (openFileDialogSource.ShowDialog() == DialogResult.OK) 
            {
                textBoxSource.Text = openFileDialogSource.FileName;
            }
        }

        private void buttonTarget_Click(object sender, EventArgs e)
        {
            if (openFileDialogTarget.ShowDialog() == DialogResult.OK)
            {
                textBoxDestination.Text = openFileDialogTarget.FileName;
            }
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            var s = textBoxSource.Text;
            var t = textBoxDestination.Text;
            Properties.Settings.Default.Source = s;
            Properties.Settings.Default.Destination = t;
            Properties.Settings.Default.Save();
            var result = s.Compare(t);
            labelResult.Text = result[0] + " - " + result[1];

        }
    }
}