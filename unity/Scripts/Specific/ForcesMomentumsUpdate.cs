﻿using System;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.UI;

using Diagram.UI;
using Diagram.UI.Interfaces;

using Scada.Interfaces;
using Scada.Desktop;


using Unity.Standard;
using Unity.Standard.Interfaces;
using Motion6D.Interfaces;

namespace Scripts.Specific
{
    public class ForcesMomentumsUpdate : UpdateIndicators, IKeyListener
    {

        #region Fields


        Motion6D.Portable.Aggregates.RigidBody rigidBody;

        Dictionary<string, List<Component>> components;

        static internal ForcesMomentumsUpdate forcesMomentumsUpdate;


        Text timeTxt;


        Motion6D.Interfaces.ReferenceFrame frame;

        static bool fuelEmpty = false;

        AudioSource alarm;


        Dictionary<int, int> active = new Dictionary<int, int>();

        IDesktop desktop;

        private float interval = 0;

        public float kx = 1f;

        public float ky = 1f;

        public float kz = 1f;

        public float kMx = 1f;

        public float kMy = 1f;

        public float kMz = 1f;

        public float classBound = 20;

        Dictionary<KeyCode, bool> pressed = new Dictionary<KeyCode, bool>();

        ReferenceFrameBehavior referenceBehavior;

        GameObject gameObject;

        MonoBehaviour mb;

        Action<double>[] dInp = new Action<double>[6];

        Func<double?>[] dOut = new Func<double?>[6];

        public static GameObject camera;

        KeyCode[] codes = { KeyCode.None };



        Dictionary<KeyCode, KeyCode[]> kkdic = new Dictionary<KeyCode, KeyCode[]>();

        Dictionary<KeyCode, Tuple<Action<double>, Func<double?>, Text, double, double[]>>
            actions = new ();

        Dictionary<int, Tuple<int, KeyCode[]>> dictionary;/* = new
            Dictionary<int, Tuple<int, KeyCode[]>>
        {
            {3, new Tuple<int, KeyCode[]>(3, new KeyCode[]{KeyCode.W, KeyCode.S } )},
            {5, new Tuple<int, KeyCode[]>(4, new KeyCode[]{KeyCode.Q, KeyCode.E } )},
            {4, new Tuple<int, KeyCode[]>(5, new KeyCode[]{KeyCode.D, KeyCode.A } )},
            {2, new Tuple<int, KeyCode[]>(0, new KeyCode[]{KeyCode.RightShift, 
                KeyCode.RightControl} )},
            {0, new Tuple<int, KeyCode[]>(1, new KeyCode[]{KeyCode.RightArrow, 
                KeyCode.LeftArrow} )},
           {1, new Tuple<int, KeyCode[]>(2, new KeyCode[]{KeyCode.UpArrow, 
               KeyCode.DownArrow} )}
        };*/

        Text telemerty;




        string[,] txt = new string[,] { { "Ax_Txt", "0.00" }, { "Ay_Txt", "0.00" }, { "Az_Txt", "0.00" },
            { "Omx1_Txt", "+--" }, { "Omy1_Txt", "+--" } , { "Omz1_Txt", "+--" }  };

        Dictionary<KeyCode, Tuple<Text, string[]>> texts =
            new Dictionary<KeyCode, Tuple<Text, string[]>>();

        Dictionary<KeyCode, int> inverse = new Dictionary<KeyCode, int>();

        float bp = 0.2f;


        #endregion

        #region Ctor
        public ForcesMomentumsUpdate()
        {
            StaticExtensionUnity.UnusedKey = Saver.saver.unused;
            this.AddKeyListener();
            forcesMomentumsUpdate = this;
            StaticExtensionUnity.Collision += (Tuple<GameObject, Component, IScadaInterface, ICollisionAction> obj) =>
        {

            ///DELETE AFTER TELEMETRY !!!
           // telemerty.gameObject.SetActive(true);

            scada.IsEnabled = false;

        };
            constants = new float[] { kx, ky, kz, kMx, kMy, kMz, 0 };
        }

        internal static IScadaInterface Scada { get => forcesMomentumsUpdate.scada; }

        static internal void Finish()
        {
            var a = forcesMomentumsUpdate.constants[0];
            var scada = forcesMomentumsUpdate.scada;
            scada.GetDoubleInput("Force.Fz")(a);
        }


        #endregion

        #region Overriden Members  

        public override void Set(object[] obj, Component indicator, IScadaInterface scada)
        {
            base.Set(obj, indicator, scada);
            scada.OnStart += () =>
            {
                // KeyExecuteMonobehavior.keyExecuteMonobehavior.enabled = false;
            };
            scada.OnStop += () =>
            {
                // KeyExecuteMonobehavior.keyExecuteMonobehavior.enabled = true;
            };
            var c = scada.Constants;
            frame = scada.GetOutput("Relative to station.Frame")() as Motion6D.Interfaces.ReferenceFrame;
            for (int i = 0; i < 6; i++)
            {
                active[i] = 0;
            }
            camera = indicator.gameObject;
            referenceBehavior =
                camera.GetComponentInChildren<ReferenceFrameBehavior>();
            mb = obj[0] as MonoBehaviour;
            gameObject = mb.gameObject;
            components = gameObject.GetGameObjectComponents<Component>();
            timeTxt = components["Time_Txt"][0].gameObject.GetComponent<Text>();
            telemerty = components["Telemetry"][0].gameObject.GetComponent<Text>();
            Dictionary<string, List<AudioSource>> las =
                camera.GetGameObjectComponents<AudioSource>();
            alarm = las["Alarm"][0];
            var s = "Force.";
            string[] ss = { "Fx", "Fy", "Fz", "Mx", "My", "Mz" };
            for (int i = 0; i < ss.Length; i++)
            {
                string key = s + ss[i];
                dInp[i] = scada.GetDoubleInput(key);
                dOut[i] = scada.GetDoubleOutput(key);
            }
            /*
            Func<double> f = scada.GetDoubleOutput("Relative to station.Velocity");
            var c = components;
            SliderWrapper sw = new SliderWrapper(c["MarkedLimitedSlider"][0], -100, 2, f);
            sliders.Add(sw);
            sw = new SliderWrapper(c["MarkedLimitedNegativeSlider"][0], -100, 2, f);
            sliders.Add(sw);*/
        }

   
        public override int SetConstants(int offset, float[] constants)
        {
            int i = base.SetConstants(offset, constants);
            interval = constants[6];
           // StaticExtensionUnity.KeyInterval = interval;
          //  bound = (float)constants[7];
            desktop = scada.GetDesktop();
            rigidBody = desktop.GetAssociatedObject<Motion6D.Portable.Aggregates.RigidBody>(
                "Rigid Body");
            Prepare();
            return i;
            /*
            kx = cons[0];
            ky = cons[1];
            kz = cons[2];
            kMx = cons[3];
            kMy = cons[4];
            kMz = cons[5];
            return i;*/
        }

        public override Action Update => UpdateForces + base.Update;
 
        #endregion

        #region IKeyListener Members

        List<KeyCode> IKeyListener.Keys => new List<KeyCode>(Saver.saver.KeyValuePairs.Values);

        Action<KeyCode> IKeyListener.Action => KeyAction;

        #endregion

        #region Update

        void KeyAction(KeyCode keyCode)
        {
            if (Activation.IsPaused)
            {
                return;
            }
            var code = keyCode;
            var current = keyCode;
            if (!actions.ContainsKey(current))
            {
                return;
            }
            int pp = inverse[current];
            if (fuelEmpty)
            {
                return;
            }
            var t = actions[code];
            double[] v = t.Item5;
            double newValue = t.Item4;
            double value = v[0];
            double delta = Math.Abs(value - newValue);
            if (delta < double.Epsilon)
            {
                return;
            }
            if (delta > (1 + double.Epsilon) * Math.Abs(newValue))
            {
                value = 0f;
            }
            else
            {
                value = newValue;
            }
            t.Item1(value);
            int m = Math.Sign(value);
            var y = t.Item2();
            if (y == null)
            {
                return;
            }
            var x = y.Value;
            if (Math.Abs(x - value) > double.Epsilon)
            {
                throw new Exception();
            }
            v[0] = value;
            var tst = texts[code];
            string ss = "0";
            string f = tst.Item2[1];
            string a = tst.Item2[0];
            if (f == "+--")
            {
                if (x > double.Epsilon)
                {
                    ss = "+";
                }
                if (x < -double.Epsilon)
                {
                    ss = "-";
                }
            }
            else
            {
                ss = x.ToString(f);
            }
            if (tst.Item1 != null)
            {
                tst.Item1.text = a + " " + ss;
            }
        }

        void UpdateForces()
        {
            timeTxt.text = "Time " + StaticExtensionUnity.Time.ToString("0.00");
            if (!scada.IsEnabled)
            {
                return;
            }
/*            int k = Math.Sign(dOut[5]());
            float r = ap * k;
            Vector3 euler = new Vector3(0, 0, r);
            pivot.rotation = Quaternion.Euler(euler);
*/
            if (!scada.IsEnabled)
            {
             //   alarm.enabled = false;
                for (int i = 0; i < 6; i++)
                {
                    dInp[i](0);
                }
                return;
            }
            UpdateAlarm();
            StaticExtensionUnity.ProcessKeyCodes();
        }

        internal void AlarmAudio(bool b)
        {
            alarm.enabled = b;
        }


        #endregion

        #region Internal Members

        internal static string Telemetry
        {
            set => forcesMomentumsUpdate.telemerty.text = value;
        }

        internal void Contact()
        {
            IDesktop desk = scada.GetDesktop();
            desk.ForEach((IReferenceFrame fr) =>
            {
              /*  if (fr.GetName(desk) == par)  !!! DELETE
                {
                    frame = fr;
                }*/
            });

        }

        #endregion

        #region Private

        static internal void FuelEmpty()
        {
            fuelEmpty = true;
        }


        void Prepare()
        {
            dictionary = Saver.saver.dictionary;
            List<KeyCode> l = new List<KeyCode>();
            Dictionary<string, List<Text>> lt = 
                gameObject.GetGameObjectComponents<Text>();
            List<Tuple<Text, string[]>> ttt = new List<Tuple<Text, string[]>>();
            for (int i = 0; i < txt.GetLength(0); i++)
            {
                Text tx = null;
                if (lt.ContainsKey(txt[i, 0]))
                {
                    tx = lt[txt[i, 0]][0];
                }
                string text = "";
                if (tx != null)
                {
                    text = tx.text;
                }
                Tuple<Text, string[]> tst = new Tuple<Text, string[]>(tx, new string[] { text, txt[i, 1] });
                ttt.Add(tst);
            }
            var co = scada.Constants;
            var level = StaticExtensionUnity.Activation.level;
            var ml = Math.Abs(level);
            if (level < 0)
            {
                scada.SetConstant(Level0.LongXK, (double)constants[0]);
                scada.SetConstant(Level0.ShortXK, (double)constants[0]);
            }
            if (level < -1)
            {
                scada.SetConstant(Level0.YK, (double)constants[1]);
            }
            if (level < -2)
            {
                scada.SetConstant(Level0.ZK, (double)constants[2]);
            }
            if (level <= -6)
            {
                scada.SetConstant(Level0.YK, (double)constants[1]);
                scada.SetConstant(Level0.ZK, (double)constants[2]);
            }
            if (constants[4] > float.Epsilon)
            {
                scada.SetConstant(Level0.OzK, (double)constants[4]);
            }
            if (level < -6)
            {
                scada.SetConstant(Level0.OxK, (double)constants[3]);
                scada.SetConstant(Level0.OyK, (double)constants[5]);
            }
            foreach (var i in dictionary.Keys)
            {
                var tst = ttt[i];
                Action<double> a = dInp[i];
                Func<double?> f = dOut[i];
                var tt = dictionary[i];
                var j = tt.Item1;
                double k = constants[j];
                var kk = tt.Item2;
                if (k < double.Epsilon)
                {
                    continue;
                }
                double[] val = new double[]{ 0 };
                for (int m = 0; m < 2; m++)
                {
                    var kc = kk[m];
                    inverse[kc] = i;
                    texts[kc] = tst;
                    kkdic[kc] = kk;
                    if (l.Contains(kc))
                    {
                        throw new Exception();
                    }
                    l.Add(kc);
                    double coeff = (m == 0) ? k : -k;
                    var v = new Tuple<Action<double>, Func<double?>, Text, double, double[]>
                        (a, f, null, coeff, val);
                    var ts = StaticExtensionUnity.Level + "";
                    if (StaticExtensionUnity.Activation.level > 0 | ts.Contains("Fuel"))
                    {
                        actions[kc] = v;
                    }
                }
            }
            codes = l.ToArray();
            Dictionary<string, List<Image>> canv =
                gameObject.GetGameObjectComponents<Image>();
 
            foreach (var kk in codes)
            {
                pressed[kk] = true;
            }
        }

        float[] delta;

        void UpdateAlarm()
        {

        }

        #endregion

        #region Coroutines

        System.Collections.IEnumerator showDelta
        {
            get
            {
                while (true)
                {
                    /*                   float[] d = delta;
                                       if (d == null)
                                       {
                                           foreach (var v in results)
                                           {
                                               v.gameObject.SetActive(false);
                                           }
                                           break;
                                       }
                                       yield return new WaitForSeconds(0.2f);
                                       float x = (d[0] - d[1]) / d[1];
                                       slider.value = x;
                                       foreach (var v in results)
                                       {
                                           v.gameObject.SetActive(true);
                                       }*/
                    yield return new WaitForSeconds(0.2f);

                    break;
                }
            }
        }

   
        #endregion

    }
}