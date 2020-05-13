using System;

using Scada.Desktop;
using System.Runtime.Serialization;

using Diagram.UI;
using Scada.Desktop.Serializable;
using Event.Interfaces;
using Event.WPF;
using System.Collections.Generic;
using System.Windows.Media;

namespace Scada.WPF.Sound.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class MainWindow
    {
        private void CreateScada()
        {
            StaticExtensionEventInterfaces.TimerEventFactory = WpfTimerEventFactory.Singleton;
            StaticExtensionScadaDesktop.ScadaFactory = StaticExtensionScadaDesktopSerializable.BaseFactory;
            scada = Properties.Resources.atis_sound_event_tu154.ScadaFromBytes("Chart",
                BaseTypes.Attributes.TimeType.Second, false, null);
            //(scada as Scada.Motion6D.Factory.ScadaDesktopMotion6D).AnimationType =
           //     Animation.Interfaces.Enums.AnimationType.Synchronous;
            chart.Output = new List<Tuple<string, Color, double[]>>()
            {
                new Tuple<string, Color, double[]>("Motion.Formula_1",
                Color.FromRgb(0xFF, 0x00, 0xFF), new double[] {0, 250000}),
                new Tuple<string, Color, double[]>("Motion.Formula_2",
                Color.FromRgb(0x90, 0xEE, 0x90), new double[] {0, 4000}),
            };

        }
    }


}