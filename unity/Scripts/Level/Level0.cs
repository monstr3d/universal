using System;

using UnityEngine;


using Motion6D.Interfaces;

using Scada.Desktop;
using Scada.Interfaces;

using Unity.Standard;

namespace Scripts
{
    static class Level0
    {
        /*  static internal readonly string ShortX = "X - Control.Formula_1";
          static internal readonly string ShortXK = "X - Control.k";
          static internal readonly string LongX = "X - Control 1.Formula_1";
          static internal readonly string LongXK = "X - Control 1.k";
          static internal readonly string XFrameZ = "X-Frame.z";*/
        static internal readonly string LongXK = "X-Control 1/Mod.k";
        static internal readonly string ShortXK = "X-Control 2/Mod.k";
        static internal readonly string LongXC = "X-Control 1/Epsilon.Formula_1";
        static internal readonly string ShortXC = "X-Control 2/Epsilon.Formula_1";
        static internal readonly string LimitedXC = "X-limitation.Formula_1";

        static internal readonly string YControl = "Y-Control/Epsilon.Formula_1";

        static internal readonly string YK = "Y-Control/Mod.k";

        static internal readonly string ZControl = "Z-Control/Epsilon.Formula_1";

        static internal readonly string OzK = "Oz-Control/Mod.k";
        static internal readonly string OyK = "Oy-Control/Mod.k";
        static internal readonly string OxK = "Ox-Control/Mod.k";

        static internal readonly string ZControl1 = "Z-Control 1/Epsilon.Formula_1";

        static internal readonly string OzK1 = "Oz-Control 1/Mod.k";

        static internal readonly string OzControl = "Oz-Control/Epsilon.Formula_1";

        static internal readonly string OxControl = "Ox-Control/Epsilon.Formula_1";

        static internal readonly string OyControl = "Oy-Control/Epsilon.Formula_1";

        static internal readonly string OzControl1 = "Oz-Control 1.Formula_1";

        static internal readonly string ZK = "Z-Control/Mod.k";

        static internal readonly string Oz = "Relative to station.OMz";

        static internal readonly string Ox = "Relative to station.OMx";

        static internal readonly string Oy = "Relative to station.OMy";
        static internal readonly string Fuel = "Fuel rate.x";


        static internal readonly string RigidBodyStation = "RigidBodyStation";




        static internal readonly string[] Forces = new string[]
            { "Fx", "Fy", "Fz", "Mx", "My", "Mz"};
        
        static internal readonly string VxLimiter = "Vx limiter.Formula_1";

        static internal readonly string Station = "Station";

        static internal readonly string Main_Camera = "Main Camera";

        static internal readonly string Earth = "Earth";

        static internal readonly string Velocity = "Relative to station.Velocity";

        static internal readonly string Rz = "Relative to station.z";

        static internal readonly string Vz = "Relative to station.Vz";

        static internal readonly string Ry = "Relative to station.y";

        static internal readonly string Vy = "Relative to station.Vy";

        static internal readonly string Rx = "Relative to station.x";

        static internal readonly string Vx = "Relative to station.Vx";


        static internal readonly string Distance = "Relative to station.Distance";


        static internal void Set(OutputController behavior, int level)
        {
            var c = behavior.inputConstants;
            for (int i = level; i < 6; i++)
            {
                c[i] = 0;
            }
        }

        

        static internal void SetStation(ReferenceFrameBehavior behavior, int level)
        {
            var c = behavior.constants;
            for (int i = level; i < c.Length; i++)
            {
                c[i] = c[i].ToZero();
            }
        }

        internal static void Set(this MonoBehaviour monoBehaviour, int level)
        {
            ReferenceFrameBehavior rf = null;
            OutputController oc = null;
            if (monoBehaviour is ReferenceFrameBehavior)
            {
                rf = monoBehaviour as ReferenceFrameBehavior;
            }
            if (monoBehaviour is OutputController)
            {
                oc = monoBehaviour as OutputController;
                Set(oc as OutputController, level);
                return;

            }
            if (rf == null)
            {
                return;
            }
            if (rf.desktop != RigidBodyStation)
            {
                return;
            }
            string name = monoBehaviour.gameObject.name;
            if (name == Station)
            {
                SetStation(rf, level);
                return;
            }
            SetCamera(rf);
       }

        internal static void Get(out IScadaInterface scada, out IEvent ev, out ReferenceFrame xFrame)
        {
            scada = RigidBodyStation.ToExistedScada();
            ev = scada["Force"];
            xFrame = scada.GetOutput("X-Frame.Frame")() as ReferenceFrame;
        }

        internal static void Set(this MonoBehaviour monoBehaviour)
        {
            monoBehaviour.Set(Math.Abs(StaticExtensionUnity.Activation.level));
        }

        static internal void SetCamera(ReferenceFrameBehavior behavior)
        {

        }

        static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            ForcesIndicator.indicator.StopAudio();
        }

    }
}
