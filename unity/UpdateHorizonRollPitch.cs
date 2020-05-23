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

namespace Assets
{
    public class UpdateHorizonRollPitch : AbstractFrameUpdate
    {
        RectTransform horizonRoll;

        RectTransform horizonPitch;

        float rollAmplitude = 1, pitchAmplitude = 1,
            pitchXOffSet = 0, pitchYOffSet = 0;
           

        float rollOffSet = 0, rollFilterFactor = 0.25f, pitchFilterFactor = 0.125f,
            pitchOffSet;


        public UpdateHorizonRollPitch()
        {
            constants = new float[] {rollAmplitude = 1, pitchAmplitude = 1,
            pitchXOffSet = 0, pitchYOffSet};
        }

        public override void Set(object[] o, GameObject gameObject)
        {
            base.Set(o, gameObject);
            RectTransform transform = gameObject.GetComponent<RectTransform>();

            // base.Set(frame, angles, transform);
            horizonRoll = transform;
            horizonPitch = transform;
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



        void UpdateInternal()
        {

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