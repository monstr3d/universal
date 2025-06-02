using Diagram.UI;
using Diagram.UI.Interfaces;
using Motion6D.Interfaces;
using Scada.Desktop;
using Scada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard.Interfaces;
using Vector3D;

namespace Unity.Standard
{
    class FrameReplaceActionFactory : IReplaceActionFactory
    {
        object[] IReplaceActionFactory.Create(IScadaInterface scada, string name, out Action action)
        {
            var ou = scada.Outputs;
            object[] o = null;
            EulerAngles euler = null;
            ReferenceFrame frame = null;
            action = null;
          if (ou.ContainsKey(name))
            {
                if (ou[name] == typeof(ReferenceFrame))
                {
                    Func<object> f = scada.GetOutput(name);
                    euler = new EulerAngles();
                    frame = f() as ReferenceFrame;
                    o = new object[] { frame, euler };
                    action = () => { euler.Set(frame.Quaternion); };
                    return o;
                }
            }
            IDesktop d = scada.GetDesktop();
            d.ForEach((IReferenceFrame f) =>
            {
                string fn = f.GetName(d);
                if (fn == name)
                {
                    frame = f.Own;
                }
            });
            euler = new EulerAngles();
            o = new object[] { frame, euler };
            action = () => { euler.Set(frame.Quaternion); };
            return o;
        }
    }
}