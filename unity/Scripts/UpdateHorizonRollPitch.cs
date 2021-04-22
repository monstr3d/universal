using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

using Unity.Standard;

using Vector3D;
using Motion6D.Interfaces;
using Scada.Interfaces;

namespace Scripts
{
    public class UpdateHorizonRollPitch : AbstractFrameUpdate
    {
        RectTransform horizonRoll;

        RectTransform horizonPitch;

        float rollAmplitude = 1, pitchAmplitude = 1,
            pitchXOffSet = 0, pitchYOffSet = 0;

        Func<double>[] omegas = new Func<double>[2];

        int[] om = new int[2];

        float pasX;

        float pasY;

        Vector3 lpos;

        Func<double> omx;


        float rollOffSet = 0, rollFilterFactor = 0.25f, pitchFilterFactor = 0.125f,
            pitchOffSet;
        RectTransform path;


        #region Constructor
        public UpdateHorizonRollPitch()
        {
            constants = new float[] {rollAmplitude = 1, pitchAmplitude = 1,
            pitchXOffSet = 0, pitchYOffSet};
        }

        #endregion

        #region Overriden Members

        public override void Set(object[] o, Component component, IScadaInterface scada)
        {
            base.Set(o, component, scada);
            RectTransform transform = component.gameObject.GetComponent<RectTransform>();
            string[] s = new string[] { "My", "Mx"};
            for (int i = 0; i < 2; i++)
            {
                omegas[i] = scada.GetDoubleOutput("Force." + s[i]);
            }

            // base.Set(frame, angles, transform);
            horizonRoll = transform;
            horizonPitch = transform;
            MonoBehaviour mb = o[2] as MonoBehaviour;
            GameObject cam = mb.gameObject;
            Dictionary<string, List<RectTransform>> l = 
                cam.GetGameObjectComponents<RectTransform>();
            path = l["Path"][0];
            lpos = path.localPosition;
        }




        public override int SetConstants(int offset, float[] constants)
        {
            int i = base.SetConstants(offset, constants);
            rollAmplitude = constants[0];
            pitchAmplitude = constants[1];
            pitchXOffSet = constants[2];
            pitchYOffSet = constants[3];
            return i;
        }

        public override Action Update => UpdateInternal;

        #endregion


        void UpdateInternal()
        {
            float amp = 100;
            for (int i = 0; i < 2; i++)
            {
                om[i] = Math.Sign(omegas[i]());
            }
            Vector2 p = new Vector2(lpos.x + om[0] * amp, lpos.y + om[1] * amp);
            if (!p.Equals(path.localPosition))
            {
                path.localPosition = p;
            }

            float heading = angles.pitch.ToDegree();
            float roll = angles.yaw.ToDegree();
            float pitch = angles.roll.ToDegree(); ;

            //Send values to Gui and Instruments
            if (horizonRoll != null)
            {

                horizonRoll.localRotation =
                    Quaternion.Euler(0, 0, rollAmplitude * roll);
            }
            if (horizonPitch != null)
            {
                Vector3 v = new Vector3(
                    -pitchAmplitude * pitch *
                    Mathf.Sin(horizonPitch.transform.localEulerAngles.z *
                    Mathf.Deg2Rad) + pitchXOffSet,
                    pitchAmplitude * pitch *
                    Mathf.Cos(horizonPitch.transform.localEulerAngles.z *
                    Mathf.Deg2Rad) + pitchYOffSet, 0);
                horizonPitch.localPosition = v;

            }
            /*           horizonPitch.localPosition = 
                           new Vector3(-pitchAmplitude * pitch * 
                           Mathf.Sin(horizonPitch.transform.localEulerAngles.z * 
                           Mathf.Deg2Rad) + pitchXOffSet, pitchAmplitude * pitch * 
                           Mathf.Cos(horizonPitch.transform.localEulerAngles.z * 
                           Mathf.Deg2Rad) + pitchYOffSet, 0);
            */
        }
    }
}