using Event.Interfaces;
using Scada.Desktop.Serializable;
using Scada.Desktop;
using Scada.Interfaces;
using Scada.Windows.UI;

namespace Scada.Temperature.WinFormsApp
{
    public partial class FormMain : Form
    {

        IScadaInterface scada;

        public FormMain()
        {
            InitializeComponent();
            CreateScada();
            this.Set(scada);
            scada.IsEnabled = true;

        }


        void CreateScada()
        {

            StaticExtensionEventInterfaces.TimerEventFactory = Event.Windows.Forms.WindowsTimerFactory.Singleton;
            StaticExtensionScadaDesktop.ScadaFactory = StaticExtensionScadaDesktopSerializable.BaseFactory;
            scada = Properties.Resources.temprerature_control.ScadaFromBytes("Chart",
                BaseTypes.Attributes.TimeType.Second, false, null);
        }
    }
}
