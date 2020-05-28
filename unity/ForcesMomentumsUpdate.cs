using Scada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;
using UnityEngine.Experimental.VFX;

namespace Assets
{
    public class ForcesMomentumsUpdate : AbstractUpdateGameObject
    {
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

        

        int Counter
        {
            get;
            set;
        }

        Action<double>[] dInp = new Action<double>[6];

        public ForcesMomentumsUpdate()
        {
            constants = new float[] { kx, ky, kz, kMx, kMy, kMz };
            KeyCode[] codes = new KeyCode[]
            {
                KeyCode.Q, KeyCode.W, KeyCode.E,
                KeyCode.A, KeyCode.S, KeyCode.D,
                KeyCode.RightShift, KeyCode.RightControl,
                KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow
            };
            foreach (KeyCode keyCode in codes)
            {
                pressed[keyCode] = false;
            }
        }

        public override void Set(object[] obj, Component indicator, IScadaInterface scada)
        {
            base.Set(obj, indicator, scada);
            var s = "Force.";
            string[] ss = { "Fx", "Fy", "Fz", "Mx", "My", "Mz" };
            for (int i = 0; i < ss.Length; i++)
            {
                dInp[i] = scada.GetDoubleInput(s + ss[i]);
            }
        }

        public override int SetConstants(int offset, float[] constants)
        {
            int i = base.SetConstants(offset, constants);
            float[] cons = this.constants;
            kx = cons[0];
            ky = cons[1];
            kz = cons[2];
            kMx = cons[3];
            kMy = cons[4];
            kMz = cons[5];
            return i;
        }

        public override Action Update => UpdateInternal;




        void ResetValue(ref float value, float newValue, int i, KeyCode code)
        {
            if (!pressed[code])
            {
                return;
            }
            if (value != newValue)
            {
                if (Math.Abs(value - newValue) > 1.1 * Math.Abs(newValue))
                {
                    value = 0f;
                }
                else
                {
                    value = newValue;
                }
                dInp[i](value);
            }
            pressed[code] = false;
        }

        void KeyDown(KeyCode code)
        {
            if (pressed[code])
            {
                return;
            }
            pressed[code] = true;
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

            if (Input.GetKeyUp(KeyCode.S))
            {
                ResetValue(ref vMx, -kMx, 3, KeyCode.S);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                KeyDown(KeyCode.S);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                KeyDown(KeyCode.W);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                ResetValue(ref vMx, kMx, 3, KeyCode.W);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                KeyDown(KeyCode.Q);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                ResetValue(ref vMy, kMy, 5, KeyCode.Q);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                KeyDown(KeyCode.E);
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                ResetValue(ref vMy, -kMy, 5, KeyCode.E);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                KeyDown(KeyCode.A);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                ResetValue(ref vMz, -kMz, 4, KeyCode.A);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                KeyDown(KeyCode.D);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                ResetValue(ref vMz, kMz, 4, KeyCode.D);
            }

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                KeyDown(KeyCode.RightShift);
            }
            if (Input.GetKeyUp(KeyCode.RightShift))
            {
                 ResetValue(ref vx, kx, 2, KeyCode.RightShift);
            }

            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                KeyDown(KeyCode.RightControl);
            }
            if (Input.GetKeyUp(KeyCode.RightControl))
            {
                 ResetValue(ref vx, -kx, 2, KeyCode.RightControl);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                KeyDown(KeyCode.LeftArrow);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                ResetValue(ref vy, -ky, 0, KeyCode.LeftArrow);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                KeyDown(KeyCode.RightArrow);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                ResetValue(ref vy, ky, 0, KeyCode.RightArrow);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                KeyDown(KeyCode.UpArrow);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                ResetValue(ref vz, kz, 1, KeyCode.UpArrow);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                KeyDown(KeyCode.DownArrow);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                ResetValue(ref vz, -kz, 1, KeyCode.DownArrow);
            }
        }
    }
}