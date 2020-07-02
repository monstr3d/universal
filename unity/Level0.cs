using System;

using UnityEngine;


using Motion6D.Interfaces;

using Scada.Desktop;
using Scada.Interfaces;

using Unity.Standard;

namespace Assets
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

        static internal readonly string YControl = "Y-Control/Epsilon.Formula_1";

        static internal readonly string YK = "Y-Control/Mod.k";

        static internal readonly string ZControl = "Z-Control/Epsilon.Formula_1";

        static internal readonly string OzK = "Oz-Control/Mod.k";

        static internal readonly string OzControl = "Oz-Control/Epsilon.Formula_1";



        static internal readonly string ZK = "Z-Control/Mod.k";
        
        static internal readonly string Oz = "Relative to station.OMz";


        static internal readonly string RigidBodyStation = "RigidBodyStation";




        static internal readonly string[] Forces = new string[]
            { "Fx", "Fy", "Fz", "Mx", "My", "Mz"};
        
        static internal readonly string VxLimiter = "Vx limiter.Formula_1";

        static internal readonly string Station = "Station";

        static internal readonly string Velocity = "Relative to station.Velocity";

        static internal readonly string Rz = "Relative to station.z";

        static internal readonly string Vz = "Relative to station.Vz";

        static internal readonly string Ry = "Relative to station.y";

        static internal readonly string Vy = "Relative to station.Vy";

        static internal readonly string Rx = "Relative to station.x";

        static internal readonly string Vx = "Relative to station.Vx";


        static internal readonly string Distance = "Relative to station.Distance";


        static internal void Set(OutputController behavior)
        {
            var c = behavior.inputConstants;
            int k = Math.Abs(StaticExtensionUnity.Activation.level);
            for (int i = k; i < 6; i++)
            {
                c[i] = 0;
            }
        }

        static void SetStation(ReferenceFrameBehavior behavior)
        {
            var c = behavior.constants;
            int k = Math.Abs(StaticExtensionUnity.Activation.level);
            for (int i = k; i < c.Length; i++)
            {
                c[i] = c[i].ToZero();
            }
        }



        internal static void Get(out IScadaInterface scada, out IEvent ev, out ReferenceFrame xFrame)
        {
            scada = RigidBodyStation.ToExistedScada();
            ev = scada["Force"];
            xFrame = scada.GetOutput("X-Frame.Frame")() as ReferenceFrame;
        }

        internal static void Set(this MonoBehaviour monoBehaviour)
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
                Set(oc as OutputController);
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
            if (name == Station )
            {
                SetStation(rf);
                return;
            }
            SetCamera(rf);
            
        }

        static void SetCamera(ReferenceFrameBehavior behavior)
        {

        }

        static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            ForcesIndicator.indicator.StopAudio();
        }


    }
}
