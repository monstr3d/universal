using Scada.Interfaces;
using Scada.Wpf.Common;
using Scada.WPF.UI;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scada.WPF.Immelman.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        IScadaInterface scada;

        #endregion

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                CreateScada();
                // this.CreateMessageBoxEventHandler(scada);
                StaticExtensionWpfUI.Strict = false;
                this.Set(scada);
            }
            catch (Exception ex)
            {

            }
        }


        private void Start_Click(object sender, RoutedEventArgs e)
        {
            bool b = !scada.IsEnabled;
            scada.IsEnabled = b;
            ButtonStart.Content = b ? "Stop" : "Start";
        }

    }
}