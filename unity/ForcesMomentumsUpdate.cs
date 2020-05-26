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

        Action<double>[] dInp = new Action<double>[6];

        public ForcesMomentumsUpdate()
        {
            constants = new float[] { kx, ky, kz, kMx, kMy, kMz };
        }

        public override void Set(object[] obj, GameObject gameObject, IScadaInterface scada)
        {
            base.Set(obj, gameObject, scada);
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
            kMx = cons[5];
            return i;
        }

        public override Action Update => UpdateInternal;



        void ResetValue(ref float value, float newValue, int i)
        {

            if (value == newValue)
            {
                return;
            }
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



        void UpdateInternal()
        {
            if (!scada.IsEnabled)
            {
                for (int i = 0; i < 6; i++)
                {
                    dInp[i](0);
                }
            }
 
            if (Input.GetKey(KeyCode.S))
            {
                ResetValue(ref vMx, -kMx, 3);
            }
            if (Input.GetKey(KeyCode.W))
            {
                ResetValue(ref vMx, kMx, 3);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                ResetValue(ref vMy, kMy, 5);
            }
            if (Input.GetKey(KeyCode.E))
            {
                ResetValue(ref vMy, -kMy, 5);
            }

            if (Input.GetKey(KeyCode.A))
            {
                ResetValue(ref vMz, -kMz, 4);
            }
            if (Input.GetKey(KeyCode.D))
            {
                ResetValue(ref vMz, kMz, 4);
            }

            if (Input.GetKey(KeyCode.RightShift))
            {
                ResetValue(ref vx, kx, 2);
            }
            if (Input.GetKey(KeyCode.RightControl))
            {
                ResetValue(ref vx, -kx, 2);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                ResetValue(ref vy, ky, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                ResetValue(ref vy, -ky, 0);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                ResetValue(ref vz, kz, 1);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                ResetValue(ref vz, -kz, 1);
            }
        }
    }
}