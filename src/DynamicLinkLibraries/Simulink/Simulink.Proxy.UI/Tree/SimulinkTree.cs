using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using CommonControls.Interfaces;

using Simulink.Parser.Library;
using Simulink.Parser.Library.StateFlow;

namespace Simulink.Proxy.UI.Tree
{
    class SimulinkTree : IChildrenCreator
    {
        #region IChildrenCreator Members

        object[] IChildrenCreator.GetChildern(object o)
        {
            if (o is SimulinkSystem)
            {
                SimulinkSystem sys = o as SimulinkSystem;
                SimulinkStateflow sf = sys.Stateflow;
                if (sf == null)
                {
                    return new object[] { sys.Subsystem };
                }
                return new object[] { sys.Subsystem, sys.Stateflow };
            }
            if (o is SimulinkSubsystem)
            {
                SimulinkSubsystem ss = o as SimulinkSubsystem;
                SimulinkSubsystem[] sss = ss.Systems;
                return sss.ToArray<object>();
            }
            return null;
        }

        int IChildrenCreator.GetImageIndex(object o)
        {
            return GetImage(o);
        }

        int IChildrenCreator.GetSelectedImageIndex(object o)
        {
            return GetImage(o);
        }

        string IChildrenCreator.GetObjectName(object o)
        {
            if (o is SimulinkSystem)
            {
                return "Simulink";
            }
            if (o is SimulinkSubsystem)
            {
                SimulinkSubsystem ss = o as SimulinkSubsystem;
                return ss.Name;
            }
            if (o is SimulinkStateflow)
            {
                return "Stateflow";
            }
            return null;
        }

        #endregion

        int GetImage(object o)
        {
            if (o is SimulinkSystem)
            {
                return 0;
            }
            if (o is SimulinkSubsystem)
            {
                return 1;
            }
            if (o is SimulinkStateflow)
            {
                return 2;
            }
            return 0;
        }
    }
}
