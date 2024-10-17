using Scada.Interfaces;
using Scada.Wpf.Common;
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
            InitializeComponent();
            CreateScada();
            this.CreateMessageBoxEventHandler(scada);
            this.Set(scada);
        }
    }
}