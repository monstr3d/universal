using Diagram.UI;

using Event.Interfaces;

using Scada.Desktop;
using Scada.Desktop.Serializable;

namespace Scada.Windows.UI.Sample
{
    partial class FormMain
    {
        void CreateScada()
        {
            StaticExtensionScadaDesktop.ScadaFactory = StaticExtensionScadaDesktopSerializable.BaseFactory;
            StaticExtensionEventInterfaces.TimerEventFactory = Event.Windows.Forms.WindowsTimerFactory.Singleton;
            StaticExtensionDiagramUISerializable.Init();

            scada = Properties.Resources.simple_control_system.ScadaFromBytes("Chart",
                BaseTypes.Attributes.TimeType.Second, false, null);
        }
    }
}