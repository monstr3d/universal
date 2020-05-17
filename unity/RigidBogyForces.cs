using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class RigidBogyForces : AbstractUpdate
    {
        public RigidBogyForces()
        {

        }

        public override void Set(MonoBehaviorWrapper wrapper, ScriptWithWrapper mono)
        {
            base.Set(wrapper, mono);
        }



        #region Fields

        float fx = 0;

        float fy = 0;

        float fz = 0;

        float mx = 0;

        float my = 0;

        float mz = 0;



        #endregion


        ////// Controls: W-S (Pitch), A-D (Roll), Q-E (Yaw), R-F (Ligt), T-Space (Reset Attitude), Y (Toogle Sound), Shift-Ctrl (Faster/Slower speed)
        //////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="old"></param>
        /// <returns></returns>
        /// 
       void ResetValue(ref float value, float newValue, int i)
        {
            if (value == newValue)
            {
                return;
            }
            if (Math.Abs(value - newValue) > 1.1f)
            {
                value = 0f;
            }
            else
            {
                value = newValue;
            }
            dInp.Force(i, value);
        }

        public override void Start()
        {
           
        }

        public override void Update()
        {
            ////// Controls: W-S (Pitch), A-D (Roll), Q-E (Yaw), R-F (Ligt),
            try
            {
                if (Input.GetKey(KeyCode.S))
                {
                    ResetValue(ref mx, 1f, 3);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    ResetValue(ref mx, -1f, 3);
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    ResetValue(ref my, -1f, 5);
                }
                if (Input.GetKey(KeyCode.E))
                {
                    ResetValue(ref my, 1f, 5);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    ResetValue(ref mz, 1f, 4);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    ResetValue(ref mz, -1f, 4);
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }
    }
}
