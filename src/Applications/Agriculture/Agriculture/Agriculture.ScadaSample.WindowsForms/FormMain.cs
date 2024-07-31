using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Event.Interfaces;
using Scada.Desktop;
using Scada.Desktop.Serializable;
using Scada.Interfaces;
using Scada.Windows.UI;

namespace Agriculture.ScadaSample.WindowsForms
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
            scada = Properties.Resources.SCADA_Test.ScadaFromBytes("Chart",
                BaseTypes.Attributes.TimeType.Second, false, null);
            //    (scada as Scada.Motion6D.Factory.ScadaDesktopMotion6D).AnimationType =
            //        Animation.Interfaces.Enums.AnimationType.Synchronous;
        }


    }
}
