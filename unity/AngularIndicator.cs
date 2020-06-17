using Motion6D.Interfaces;
using Scada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Standard;
using UnityEngine;
using UnityEngine.UI;
using Vector3D;

namespace Assets
{
    [JumpedIndicator]
    public class AngularIndicator : IIndicator
    {
        #region Fields

        bool isActive = true;

        GameObject gameObject;

        IScadaInterface scada;

        Func<object> f;

        IReferenceFrame fr;

        ReferenceFrame frame;

        string parameter;

        Action update;

        EulerAngles angles = new EulerAngles();

        float roll, pitch, heading;

        RawImage compass;

        Text headingTxt;

        RectTransform horisRollPitch;

        #region Float fields

        float startX, startY, startWidth, startHeight;

        float headingAmplitude = 1, headingOffSet = 0, headingFilterFactor = 0.1f;
        float factor = 1, maxValue = 360;

        float rollAmplitude = 1, pitchAmplitude = 1,
        pitchXOffSet = 0, pitchYOffSet = 0;

        #endregion

        #endregion

        #region Ctor

        public AngularIndicator(GameObject gameObject,
            IScadaInterface scada, Func<object> f, IReferenceFrame frame,
             string parameter, Text headingTxt)
        {
            this.gameObject = gameObject;
            this.scada = scada;
            this.parameter = parameter;
            this.headingTxt = headingTxt;
            this.Add();
            Prepare();
            if (f != null)
            {
                update = () =>
                {
                    this.frame = f() as ReferenceFrame;
                    UpdateInternal();
                    update = UpdateInternal;
                };
            }
            else
            {
                update = () =>
                {
                    this.frame = frame.GetFrame();
                    UpdateInternal();
                    update = UpdateInternal;
                };
            }
        }

        #endregion

        #region IIndicator Members

        Action IIndicator.Update => update;

        string IIndicator.Parameter => parameter;

        object IIndicator.Value { set => update(); }

        object IIndicator.Type => typeof(ReferenceFrame);

        bool IIndicator.IsActive
        {
            get => isActive;
            set
            {
                if (!this.SetActive(value))
                {
                    return;
                }
                isActive = value;
            }
        }

        #endregion

        #region Members

        void UpdateInternal()
        {
            angles.Set(frame.Quaternion);
            heading = angles.pitch.ToDegree();
            roll = angles.yaw.ToDegree();
            pitch = angles.roll.ToDegree(); ;
            UpdateHeading();
            UpdateCompass();
            UpdateRollPitchImage();
        }

        void UpdateRollPitchImage()
        {
            horisRollPitch.localRotation =
                Quaternion.Euler(0, 0, rollAmplitude * roll);
            Vector3 v = new Vector3(
                -pitchAmplitude * pitch *
                Mathf.Sin(horisRollPitch.transform.localEulerAngles.z *
                Mathf.Deg2Rad) + pitchXOffSet,
                pitchAmplitude * pitch *
                Mathf.Cos(horisRollPitch.transform.localEulerAngles.z *
                Mathf.Deg2Rad) + pitchYOffSet, 0);
            horisRollPitch.localPosition = v;
        }

        void UpdateHeading()
        {
            if (heading < 0)
            {
                headingTxt.text = (heading + 360f).ToString("000");
            }
            else
            {
                headingTxt.text = heading.ToString("000");
            }


        }

        void UpdateCompass()
        {
            Rect r = new Rect(factor * (heading + headingOffSet)
     / maxValue + startX, compass.uvRect.y,
     compass.uvRect.width, compass.uvRect.height);
            compass.uvRect = r;

        }

        void Prepare()
        {
            var comp = gameObject.GetGameObjectComponents<Component>();
            compass = comp["CompassComponent"][0].GetComponent<RawImage>();
            startX = compass.uvRect.x;
            startY = compass.uvRect.y;
            startWidth = compass.uvRect.width;
            startHeight = compass.uvRect.height;
            horisRollPitch = comp["HorizonRollPitch"][0].GetComponent<RectTransform>();
        }

        #endregion
    }
}
