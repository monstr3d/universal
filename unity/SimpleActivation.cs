using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Unity.Standard;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
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
               new string[] {  "Station motion.z=3.5",
  "Station motion.a=0.00",
  "Station motion.q=0.00",
  "Station motion.r=0",
   "Station motion.s=-1",
  "Station motion.b=0.0",
  "Station motion.d=0.0",
  "Station motion.x=0.0",
  "Station motion.y=0.0" }
            };



        static private float[][] defaultfloatConstants = new float[][]
            {
                new float[7]
            };

        static string controlString;

        static int controlHeight;

        static private float[][] floatConstants;
        static public int StaticLevel
        {
            get
            {
                return level;
            }
            set
            {
                if (value == -1)
                {
                    level = value;
                    return;
                }
                if (level > 0)
                {
                    return;
                }
                level = value;
                Init();
                SetValues();
            }
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
                ReferenceFrameBehavior rf = null;
                OutputController oc = null;
                if (mono is ReferenceFrameBehavior)
                {
                    rf = mono as ReferenceFrameBehavior;
                }
                if (mono is OutputController)
                {
                    oc = mono as OutputController;
                }
                string name = mono.gameObject.name;
                if (oc != null)
                {
                    oc.inputConstants = floatConstants[0];
                    var txts = oc.gameObject.GetGameObjectComponents<Text>();
                    var tt = txts["Text"];
                    foreach (var t in tt)
                    {
                        if (t.text.Contains("WASD"))
                        {
                            t.text = controlString;
                            break;
                        }
                    }
                    var cc = oc.gameObject.GetGameObjectComponents<RectTransform>();
                    RectTransform rt = cc["Results"][0];
                    Vector3 anc = rt.anchoredPosition;
                    rt.sizeDelta = new Vector2(rt.rect.width, (float)controlHeight);
                    rt.anchoredPosition = anc;
                }
                if (name == "Station")
                {
                    rf.constants = stringConstants[0];
                }
            }
        }

        int IActivation.Level { get => StaticLevel; set => StaticLevel = value; }

        int IActivation.SetConstants(float[] constants)
        {
            floatConstants[0][6] = constants[0];
            return -1;
        }


        #endregion

        private static void SetValues()
        {
            floatConstants[0][0] = kF;
            float[] f = floatConstants[0];
            f[0] = kF;
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
                    return;
                }
                sc[1] = "Station motion.a=0.01";
                f[3] = kM;
                return;
            }
            f[2] = kF;
            sc[8] = "Station motion.y=0.5";
            if (level == 2)
            {
                return;
            }
            stringConstants[0][7] = "Station motion.x=0.5";
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

     }
}
