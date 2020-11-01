using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using DataPerformer.Interfaces;
using DataPerformer;

using Simulink.Parser.Library;
using Simulink.Parser.Library.DiagramElements;

namespace Simulink.Proxy.Systems
{
    class SystemBase
    {
        #region Fields

        SimulinkSubsystem system;

        private IDesktop desktop;

        #endregion

        #region Ctor

        internal SystemBase(SimulinkSubsystem system, IDesktop desktop)
        {
            this.system = system;
            this.desktop = desktop;
        }


        #endregion

        #region Public

        public static void Process(XElement element, IDesktop desktop, out List<Arrow> absc)
        {
            List<Arrow> l = new List<Arrow>();
            SystemBase sb = Create(element, desktop);
            sb.ProcessArrows(l);
            absc = l;
        }

        #endregion

        #region Private

       

        static SystemBase Create(XElement element, IDesktop desktop)
        {
            return new SystemBase(new SimulinkSubsystem(element, null), desktop);
        }

        void ProcessArrows(List<Arrow> l)
        {
            Dictionary<string, List<Arrow>> d = system.Inputs;
                foreach (string name in d.Keys)
                {
                    ProcessObject(name, d[name], l);
                }
        }

        void ProcessObject(string name, List<Arrow> list, List<Arrow> absc)
        {
            IObjectLabel l = desktop[name] as IObjectLabel;
            if (l == null)
            {
                return;
            }
            IDataConsumer dc = l.Object as IDataConsumer;
            if (dc == null)
            {
                return;
            }
            foreach (Arrow arrow in list)
            {
                ProcessArrow(dc, l, arrow, absc);
            }
        }


        void ProcessArrow(IDataConsumer dc, IObjectLabel label, Arrow arrow, List<Arrow> absc)
        {
            BlockPort bp = arrow.Source;
            string to = bp.Block;
            IObjectLabel l = desktop[to] as IObjectLabel;
            if (l == null)
            {
                return;
            }
            DataLink dl = new DataLink();
            try
            {
                if (desktop is PureDesktopPeer)
                {
                    PureDesktopPeer pdp = desktop as PureDesktopPeer;
                    if (label.Ord < l.Ord)
                    {
                        absc.Add(arrow);
                        return;
                    }
                    pdp.AddArrowWithExistingLabels(dl, label, l, "", "");
                }
            }
            catch (Exception)
            {
                absc.Add(arrow);
            }

        }

        #endregion
    }
}
