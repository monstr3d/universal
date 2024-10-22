using System;
using System.Collections.Generic;
using Unity.Standard;
using Unity.Standard.Interfaces;
using UnityEngine;

namespace Scripts.Specific
{
    

    public class SimpleActivation : IActivation
    {
        static private int level = -1;

        static string[][] stringConstants;

        static float kF = 0.001f;

        static float kM = 0.0001f;

   
        static private string[][] defalutStrings =
            new string[][]
            {//"Station motion.z=3.5" "Station motion.z=1.2", "Station motion.z=1.5"
               new string[] {  "Station frame.X=0",
  "Station frame.Y=0.00",
  "Station frame.Z=1.2",
  "Station frame.Vx=0",
   "Station frame.Vy=0",
  "Station frame.Vz=0.0",
  "Station frame.Roll=0.0",
  "Station frame.Pitch=0.0",
  "Station frame.Yaw=0.0",
  "Station frame.OMGx=0.0",
  "Station frame.OMGy=0.0",
  "Station frame.OMGz=0.0",
  "Aim 1.Z=-1"
               }
            };



        static private float[][] defaultfloatConstants = new float[][]
            {
                new float[7]
            };

        static string controlString;

        static int controlHeight;

        static private float[][] floatConstants;

        static int fullLevel;
        static public int StaticLevel
        {
            get
            {
                return fullLevel;
            }
            set
            {
                if (value == 0)
                {
                    fullLevel = value;
                    return;
                }
                if (fullLevel != 0)
                {
                    return;
                }
                level = Math.Abs(value);
                fullLevel = value;
                Init();
                SetValues();
                SetActivation();
            }
        }

  
        static void SetActivation()
        {
            var kc = Saver.saver.dict;

            KeyActivation.Pause = kc[12];

            KeyActivation.StopKey = kc[13];

            KeyActivation.QuitKey = kc[14];


            var ss = new string[] { };// "Relative to station.Velocity", "Relative to station.Distance" };
            var l = new List<string>();
            int lev = Math.Abs(fullLevel);
            

            string s = "RigidBodyStation.";
            foreach (var p in ss)
            {
                l.Add(s + p);
            }
            if (fullLevel > 0)
            {
            //    StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
                return;
            }
            ss = new string[] {  };
            if (lev == 1)
            {
                foreach (var p in ss)
                {
                    l.Add(s + p);
                }
            }
            if (lev > 1)
            {
                ss = new string[] { "Y - Control/Limiter.Formula_1" };
                foreach (var p in ss)
                {
                    l.Add(s + p);
                }
            }
            StaticExtensionUnity.Activation.enabledComponents = l.ToArray();
        }

   
        static SimpleActivation()
        {

        }

        public SimpleActivation()
        {

        }

        #region  IActivation Members

        void IActivation.Activate(MonoBehaviour[] monoBehaviours)
        {
            foreach (var mono in monoBehaviours)
            {
            }
        }

        int IActivation.Level { get => StaticLevel; set => StaticLevel = value; }

        Action IActivation.Update => UpdateInternal;


        int IActivation.SetConstants(float[] constants)
        {
            int ml = Math.Abs(StaticLevel);
            if (ml > 1)
            {
                floatConstants[0][1] = constants[1];
            }
            floatConstants[0][6] = constants[0];
            return -1;
        }

        int IActivation.SetConstants(string[] constants)
        {
            if (constants.Length > 0)
            {
                stringConstants[0][2] = constants[0];
                stringConstants[0][12] = constants[1];
           }
            return -1;
        }



        #endregion

        void UpdateInternal()
        {
           
        }

        private static void SetValues()
        {
            int lev = Math.Abs(fullLevel);
            floatConstants[0][0] = kF;
            float[] f = floatConstants[0];
            string[] ds = stringConstants[0];
            f[0] = kF;
            if (lev == 2)
            {
                f[1] = kF;
                ds[1] = "Station frame.Y=0.9";
                return;
            }
            controlString = "Controls:\n\nRight Shift/Ctrl - Forward/Bakward";
            if (level == 1)
            {
                controlHeight = 200;
                return;
            }
            string sud = "\nUp/Down     -       Up/Down";
            if (level == 2)
            {
                controlString += sud;
                controlHeight = 300;
            }

            string slr = "\nLeft/Right     -    Left/Right";
            if (level == 3)
            {
                controlString += sud + slr;
                controlHeight = 350;
            }
            string   sroll = "\nQE      -    Roll\n\nDocking of Soyuz 3";
            if (level == 4)
            {
                controlString += sroll;
                controlHeight = 350;
            }
             string swasd = "\n\nQEAD        - Roll and Pitch";
            if (level == 5)
            {
                f[1] = f[2] = f[0];
                controlString += sud + slr + swasd;
                controlHeight = 500;
            }
            if (level == 6)
            {
                f[1] = f[2] = f[0];
                controlString += sud + slr + "\n\nQEWSAD  - Roll, Pitch, Yaw";
                controlString += "\n\nDocking of Soyuz T-13";
                controlHeight = 600;
            }
            string[] sc = stringConstants[0];
            if (level >= 4)
            {
                sc[5] = "Station motion.b=1.57";
                f[4] = kM;
                if (level == 4)
                {
                    return;
                }
                sc[6] = "Station motion.d=0.1";
                f[5] = kM;
                if (level == 5)
                {
                    f[3] = kM;
                    sc[9] = "Station motion.y=0.00";
                    return;
                }
                sc[1] = "Station motion.a=0.01";
                f[3] = kM;
                return;
            }
            f[2] = kF;
            sc[8] = "Station motion.y=0.00"; // !!!DEBUG "Station motion.y=0.5"
            if (level == 2)
            {
                return;
            }
            stringConstants[0][7] = "Station motion.x=0.00"; // !!!DEBUG "Station motion.x=0.5"
            f[1] = kF;
            if (level == 100)
            {
                stringConstants[0][5] = "Station motion.b=1.57";
            }
        }

        static void Init()
        {
            stringConstants = new string[defalutStrings.Length][];
            for (int i = 0; i < defalutStrings.Length; i++)
            {
                string[] ds = defalutStrings[i];
                string[] ss = new string[ds.Length];
                Array.Copy(ds, ss, ss.Length);
                stringConstants[i] = ss;
            }
            floatConstants = new float[defaultfloatConstants.Length][];
            for (int i = 0; i < defaultfloatConstants.Length; i++)
            {
                float[] ds = defaultfloatConstants[i];
                float[] ss = new float[ds.Length];
                Array.Copy(ds, ss, ss.Length);
                floatConstants[i] = ss;
            }

        }

        Type IActivation.GetActivationType(int level)
        {
            return null;
        }

        void IActivation.PostActivate(MonoBehaviour[] monoBehaviours)
        {
        }
    }
}
