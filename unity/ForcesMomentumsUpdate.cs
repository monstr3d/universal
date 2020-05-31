using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

using Unity.Standard;

using Scada.Interfaces;

namespace Assets
{
    public class ForcesMomentumsUpdate : AbstractUpdateGameObject
    {

        #region Fields

        private float interval = 0;
 
        public float kx = 1f;

        public float ky = 1f;

        public float kz = 1f;

        public float kMx = 1f;

        public float kMy = 1f;

        public float kMz = 1f;

        float vx = 0f;

        float vy = 0f;

        float vz = 0f;

        float vMx = 0f;


        float vMy = 0f;

        float vMz = 0f;

        Dictionary<KeyCode, bool> pressed = new Dictionary<KeyCode, bool>();

   

        GameObject gameObject;

        MonoBehaviour mb;

        Action<double>[] dInp = new Action<double>[6];

        Func<double>[] dOut = new Func<double>[6];



        KeyCode[] codes = { KeyCode.None };

        Dictionary<KeyCode, KeyCode[]>  kkdic = new Dictionary<KeyCode, KeyCode[]>();

        Dictionary<KeyCode,  Tuple<Action<double>, Func<double>, Text, double, double[]>>
            actions = new Dictionary<KeyCode, Tuple<Action<double>, Func<double>, Text, double, double[]>>();

        Dictionary<int, Tuple<int, KeyCode[]>> dicionary = new
            Dictionary<int, Tuple<int, KeyCode[]>>
        {
            {3, new Tuple<int, KeyCode[]>(3, new KeyCode[]{KeyCode.W, KeyCode.S } )},
            {5, new Tuple<int, KeyCode[]>(4, new KeyCode[]{KeyCode.Q, KeyCode.E } )},
            {4, new Tuple<int, KeyCode[]>(5, new KeyCode[]{KeyCode.D, KeyCode.A } )},
            {2, new Tuple<int, KeyCode[]>(0, new KeyCode[]{KeyCode.RightShift, KeyCode.RightControl} )},
            {0, new Tuple<int, KeyCode[]>(1, new KeyCode[]{KeyCode.RightArrow, KeyCode.LeftArrow} )},
           {1, new Tuple<int, KeyCode[]>(2, new KeyCode[]{KeyCode.UpArrow, KeyCode.DownArrow} )}
        };

        string[,] txt = new string[,] { { "Ax_Txt", "0.00" }, { "Ay_Txt", "0.00" }, { "Az_Txt", "0.00" },
            { "Omx1_Txt", "+--" }, { "Omy1_Txt", "+--" } , { "Omz1_Txt", "+--" }  };

        Dictionary<KeyCode, Tuple<Text, string[]>> texts = new Dictionary<KeyCode, Tuple<Text, string[]>>();

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
            mb = obj[0] as MonoBehaviour;
            gameObject = mb.gameObject;
            var s = "Force.";
            string[] ss = { "Fx", "Fy", "Fz", "Mx", "My", "Mz" };
            for (int i = 0; i < ss.Length; i++)
            {
                string key = s + ss[i];
                dInp[i] = scada.GetDoubleInput(key);
                dOut[i] = scada.GetDoubleOutput(key);
            }
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

        void Prepare()
        {
            List<KeyCode> l = new List<KeyCode>();
            Dictionary<string, List<Text>> lt = gameObject.GetGameObjectComponents<Text>();
            List<Tuple<Text, string[]>> ttt = new List<Tuple<Text, string[]>>();
            for (int i = 0; i < txt.GetLength(0); i++)
            {
                Text tx = lt[txt[i, 0]][0];
                Tuple<Text, string[]> tst = new Tuple<Text, string[]>(tx, new string[] { tx.text, txt[i, 1] });
                ttt.Add(tst);
            }
            foreach (var i in dicionary.Keys)
            {
                var tst = ttt[i];
                Action<double> a = dInp[i];
                Func<double> f = dOut[i];
                var tt = dicionary[i];
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
            foreach (var kk in codes)
            {
                pressed[kk] = true;
            }
        }

      KeyCode current;

        KeyCode lastCurrent;

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
            if (Math.Abs(value - newValue) > (1 + double.Epsilon) * Math.Abs(newValue))
            {
                value = 0f;
            }
            else
            {
                value = newValue;
            }
            t.Item1(value);
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
            tst.Item1.text = a + " " + ss;
            mb.StartCoroutine(coroutine);
         }

        bool Process(KeyCode code)
        {
            if (Input.GetKey(code))
            {
                current = code;
                lastCurrent = code;
                UpdateCurrent();
            }
            return false;
        }

        System.Collections.IEnumerator coroutine
        {
            get
            {
                yield return new WaitForSeconds(interval);
                UpdateCurrent();
                current = KeyCode.F10;
                yield return current;
            }
        }





        void UpdateInternal()
        {
            if (!scada.IsEnabled)
            {
                for (int i = 0; i < 6; i++)
                {
                    dInp[i](0);
                }
            }
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
    }
}