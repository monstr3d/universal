using System;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.UI;

using Unity.Standard;

using Scada.Interfaces;

namespace Assets
{
    public class ForcesMomentumsUpdate : AbstractUpdateGameObject
    {

        #region Fields

        Dictionary<string, List<Component>> components;

      
 
     
        static public event Action<string, float[], float[]> Alarm;

   
        KeyCode current;

        KeyCode lastCurrent;



        AudioSource torch;

        AudioSource alarm;


        Dictionary<int, int> active = new Dictionary<int, int>();

 
        private float interval = 0;
 
        public float kx = 1f;

        public float ky = 1f;

        public float kz = 1f;

        public float kMx = 1f;

        public float kMy = 1f;

        public float kMz = 1f;

        Dictionary<KeyCode, bool> pressed = new Dictionary<KeyCode, bool>();

        ReferenceFrameBehavior referenceBehavior;

        GameObject gameObject;

        MonoBehaviour mb;

        Action<double>[] dInp = new Action<double>[6];

        Func<double>[] dOut = new Func<double>[6];

        public static GameObject camera;

        KeyCode[] codes = { KeyCode.None };

        

        Dictionary<KeyCode, KeyCode[]>  kkdic = new Dictionary<KeyCode, KeyCode[]>();

        Dictionary<KeyCode,  Tuple<Action<double>, Func<double>, Text, double, double[]>>
            actions = new Dictionary<KeyCode, Tuple<Action<double>, Func<double>, Text, double, double[]>>();

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

  
        Component[] results;

        Slider slider;

        Text sliderText;

   
        string[,] txt = new string[,] { { "Ax_Txt", "0.00" }, { "Ay_Txt", "0.00" }, { "Az_Txt", "0.00" },
            { "Omx1_Txt", "+--" }, { "Omy1_Txt", "+--" } , { "Omz1_Txt", "+--" }  };

        Dictionary<KeyCode, Tuple<Text, string[]>> texts = new Dictionary<KeyCode, Tuple<Text, string[]>>();

        Dictionary<KeyCode, int> inverse = new Dictionary<KeyCode, int>();

        float bp = 0.2f;

 
        #endregion

        #region Ctor
        public ForcesMomentumsUpdate()
        {
            constants = new float[] { kx, ky, kz, kMx, kMy, kMz, 0 };
        }

        #endregion

        #region Overriden Members   

        public override void Set(object[] obj, Component indicator, IScadaInterface scada)
        {
            base.Set(obj, indicator, scada);
            for (int i = 0; i < 6; i++)
            {
                active[i] = 0;
            }
            camera = indicator.gameObject;
            referenceBehavior =
                camera.GetComponentInChildren<ReferenceFrameBehavior>();
            mb = obj[0] as MonoBehaviour;
            gameObject = mb.gameObject;
            components = 
                gameObject.GetGameObjectComponents<Component>();
          
            /*
            slider = sl["SliderRight"][0];
            Dictionary<string, List<Text>> texts = 
                gameObject.GetGameObjectComponents<Text>();
            sliderText = texts["SliderText"][0];
            results = new Component[]
            {
                sliderText, 
                slider,
                 sl["SliderLeft"][0]
            };
            foreach (string key in texts.Keys)
            {
                if (key == "Text" || key == "SliderText")
                {
                    continue;
                }
                var ttx = texts[key];
                foreach (var tttx in ttx)
                {
                    tttx.color = new Color(0, 1, 0, 1);
                }
            }
            //resText = texts["Text"][0];
            */
            Dictionary<string, List<AudioSource>> las = 
                camera.GetGameObjectComponents<AudioSource>();
            torch = las["Torch"][0];
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

        public override Action Update => UpdateInternal;



        #endregion

        #region Update

        void UpdateInternal()
        {
/*            int k = Math.Sign(dOut[5]());
            float r = ap * k;
            Vector3 euler = new Vector3(0, 0, r);
            pivot.rotation = Quaternion.Euler(euler);
*/
            if (Input.GetKey(KeyCode.Return))
            {
                ResultIndicator.Escape();
            }
            if (!scada.IsEnabled)
            {
                alarm.enabled = false;
                torch.enabled = false;
                for (int i = 0; i < 6; i++)
                {
                    dInp[i](0);
                }
                return;
            }
            UpdateAlarm();
            foreach (var code in actions.Keys)
            {
                Process(code);
            }
            foreach (var code in actions.Keys)
            {
                if (Input.GetKeyUp(code))
                {
                    current = KeyCode.F10;
                }
            }
        }


        #endregion

        #region Private

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
            foreach (var i in dictionary.Keys)
            {
                var tst = ttt[i];
                Action<double> a = dInp[i];
                Func<double> f = dOut[i];
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
                    var v = new Tuple<Action<double>, Func<double>, Text, double, double[]>
                        (a, f, null, coeff, val);
                    actions[kc] = v;
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



         void UpdateCurrent()
        {
            if (current != lastCurrent)
            {
                return;
            }
            KeyCode code = current;
            if (!actions.ContainsKey(current))
            {
                return;
            }
            int pp = inverse[current];

            /*     if (!keyPressed)
                 {
                     return;
                 }*/
            var t = actions[code];
            double[] v = t.Item5;
            double newValue = t.Item4;
            double value = v[0];
            if (value == newValue)
            {
                current = KeyCode.F10;
                return;
            }
            referenceBehavior.Jump();
            torch.enabled = true;
            mb.StartCoroutine(enumeratorT);
            if (Math.Abs(value - newValue) > (1 + double.Epsilon) * Math.Abs(newValue))
            {
                value = 0f;
            }
            else
            {
                value = newValue;
            }
            t.Item1(value);
            int m = Math.Sign(value);
            double x = t.Item2();
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
            mb.StartCoroutine(coroutine);
         }
        bool Process(KeyCode code)
        {
            if (Input.GetKey(code))
            {
                if (current == KeyCode.F11)
                {
                    return false;
                }
                current = code;
                lastCurrent = code;
                UpdateCurrent();
            }
            return false;
        }

        float[] delta;

        void UpdateAlarm()
        {
            float[] yz = null;
            float[] ddelta = null;
            string res = ResultIndicator.GetResult(out yz, out ddelta);
            Alarm(res, yz, ddelta);
            if (res == null)
            {
                alarm.enabled = false;
               // resText.text = "";
                //        result.gameObject.SetActive(false);
                return;
            }
            alarm.enabled = true;
           // resText.text = res;
         //   resText.color = Color.red;
            //result.gameObject.SetActive(true);
            if (delta == null & ddelta != null)
            {
                delta = ddelta;
                mb.StartCoroutine(showDelta);
                sliderText.text = res;
            }
        }


        #endregion

        #region Coroutines

        System.Collections.IEnumerator showDelta
        {
            get
            {
                while (true)
                {
                    float[] d = delta;
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
                    }
                    yield return new WaitForSeconds(0.2f);

                }
            }
        }

 
        System.Collections.IEnumerator enumeratorT
        {
            get
            {
                yield return new WaitForSeconds(0.5f);
                torch.enabled = false;
                yield return 0;
            }
        }



        System.Collections.IEnumerator coroutine
        {
            get
            {
                current = KeyCode.F11;
                yield return new WaitForSeconds(interval);
                current = KeyCode.F10;
                yield return current;
            }
        }



        #endregion

    }
}