using System.ComponentModel;

namespace Database.UI.Windows
{
    /// <summary>
    /// Form for connection string
    /// </summary>
    public partial class FormConnectionString : Form
    {
        #region Fields

        string cs;

        #endregion

        /// <summary>
        /// Constructos
        /// </summary>
        /// <param name="conns">All connection strings</param>
        /// <param name="conn">Connection string</param>
        public FormConnectionString(List<string> conns, string conn)
        {
            InitializeComponent();
            foreach (string s in conns)
            {
                comboBoxCS.Items.Add(s);
            }
            comboBoxCS.Text = conn;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxCS.SelectedItem != null)
            {
                cs = comboBoxCS.SelectedItem + "";
            }
            else
            {
                cs = comboBoxCS.Text;
            }
            DialogResult = DialogResult.OK;
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            cs = "";
            Close();
        }

        /// <summary>
        /// Connection string
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return cs;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CancellationTokenSource Token
        {
            get;
            set;
        }

    }
}