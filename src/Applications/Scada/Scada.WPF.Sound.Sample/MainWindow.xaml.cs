using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Scada.Interfaces;

using Scada.Wpf.Common;

namespace Scada.WPF.Sound.Sample
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

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            bool b = !scada.IsEnabled;
            scada.IsEnabled = b;
            ButtonStart.Content = b ? "Stop" : "Start";
        }
    }
}