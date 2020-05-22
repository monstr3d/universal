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
    public class UpdateHorizonRollPitch : AbstractRectTransformUpdate
    {
        RectTransform horizonRoll;

        RectTransform horizonPitch;

        float rollAmplitude = 1, rollOffSet = 0, rollFilterFactor = 0.25f;
        float pitchAmplitude = 1, pitchOffSet = 0, 
            pitchXOffSet = 0, pitchYOffSet = 0,
            pitchFilterFactor = 0.125f;

        public UpdateHorizonRollPitch()
        {

        }

        public override void Set(ReferenceFrame frame, EulerAngles angles,
            RectTransform transform)
        {
            base.Set(frame, angles, transform);
            horizonRoll = transform;
            horizonPitch = transform;
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
                horizonPitch.localPosition = 
                    new Vector3(-pitchAmplitude * pitch * 
                    Mathf.Sin(horizonPitch.transform.localEulerAngles.z * 
                    Mathf.Deg2Rad) + pitchXOffSet, pitchAmplitude * pitch * 
                    Mathf.Cos(horizonPitch.transform.localEulerAngles.z * 
                    Mathf.Deg2Rad) + pitchYOffSet, 0);
            }
        }
    }
}
