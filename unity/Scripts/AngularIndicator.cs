using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Scada.Interfaces;

using Motion6D.Interfaces;

using Vector3D;

using Unity.Standard;

using Unity.Standard.Interfaces;

namespace Scripts
{
    public class AngularIndicator : IIndicator, ILimits
    {
        #region Fields

        public const float MaxRoll = 10;

        bool isActive = true;

        GameObject gameObject;

        IScadaInterface scada;

        Func<object> f;

        IReferenceFrame fr;
//*/
        ReferenceFrame frame;

        string parameter;

        Action update;

        EulerAngles angles = new EulerAngles();

        float roll, pitch, heading;

        RawImage[] compasses = new RawImage[2];

        RectTransform[] horisRollPitch = new RectTransform[2];



        Text[] headingTxt = new Text[2];

     

        Image _mask;

        Image _maskR;

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
             string parameter, Text[] headingTxt, Image _mask, Image _maskR)
        {
            this.gameObject = gameObject;
            this.scada = scada;
            this.parameter = parameter;
            this.headingTxt = headingTxt;
            this._mask = _mask;
            this._maskR = _maskR;
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

        object IIndicator.Value { get => null;  set => update(); }

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

        Action<string> IIndicator.Global => (string s) => { };


        #endregion

        #region ILimits Members

        private Dictionary<string, Tuple<float[], string[]>> d = new Dictionary<string, Tuple<float[], string[]>>();

        Dictionary<string, Tuple<float[], string[]>> ILimits.Limits => d; // !!!

        bool ILimits.Exceeds => ExceedsRoll;

        bool ILimits.Active 
        { 
            get => isLActive; 
            set => SetLActive(value); 
        }

        #endregion

        #region Members


        bool isLActive = true; 

        void SetLActive(bool act)
        {
            if (act == isLActive)
            {
                return;
            }
            isLActive = act;
            var exr = ExceedsRoll;
            if (exr)
            {
                SetRoll(act);
            }
            if (!act)
            {
                SetRoll(true);
            }
        }

        void SetRoll(bool act)
        {
             _maskR.gameObject.SetActive(act);
            //_mask.enabled = true;
        }

        bool ExceedsRoll
        {
            get => Math.Abs(roll) > MaxRoll;
        }


        void UpdateInternal()
        {
            angles.Set(frame.Quaternion);
            heading = angles.pitch.ToDegree();
            roll = angles.yaw.ToDegree();
            pitch = angles.roll.ToDegree(); ;
            UpdateHeading();
            UpdateCompass();
            UpdateRollPitchImage();
            var exr = ExceedsRoll;
            if (_mask.enabled)
            {
                if (exr)
                {
                    {
                        _mask.enabled = false;
                        _maskR.enabled = true;
                    }
                }
            }
            else if (!exr)
            {
                _mask.enabled = true;
                _maskR.enabled = false;
            }
        }

        void UpdateRollPitchImage()
        {
            foreach (var h in horisRollPitch)
            {
                h.localRotation =
                    Quaternion.Euler(0, 0, rollAmplitude * roll);
                Vector3 v = new Vector3(
                    -pitchAmplitude * pitch *
                    Mathf.Sin(h.transform.localEulerAngles.z *
                    Mathf.Deg2Rad) + pitchXOffSet,
                    pitchAmplitude * pitch *
                    Mathf.Cos(h.transform.localEulerAngles.z *
                    Mathf.Deg2Rad) + pitchYOffSet, 0);
                h.localPosition = v;
            }
            bool b = Math.Abs(pitch) > MaxRoll;
            if (b)
            {
                if (horisRollPitch[0].gameObject.activeSelf)
                {
                    horisRollPitch[0].gameObject.SetActive(false);
                    horisRollPitch[1].gameObject.SetActive(true);
                }
                return;
            }
            if (horisRollPitch[1].gameObject.activeSelf)
            {
                horisRollPitch[1].gameObject.SetActive(false);
                horisRollPitch[0].gameObject.SetActive(true);
            }

        }

  
        void UpdateHeading()
        {
            if (heading < 0)
            {
                headingTxt[0].text = (heading + 360f).ToString("000");
            }
            else
            {
                headingTxt[0].text = heading.ToString("000");
            }
            Color c = (Math.Abs(heading) > MaxRoll) ? Color.red : Color.green;
            if (headingTxt[0].color != c)
            {
                foreach (var h in headingTxt)
                {
                    h.color = c;
                }
            }
        }

        void UpdateCompass()
        {
            var compass = compasses[0];
            Rect r = new Rect(factor * (heading + headingOffSet)
     / maxValue + startX, compass.uvRect.y,
     compass.uvRect.width, compass.uvRect.height);
            foreach (var c in compasses)
            {
                c.uvRect = r;
            }
            bool b = Math.Abs(heading) > MaxRoll;
            if (b)
            {
                if (compass.gameObject.activeSelf)
                {
                    compass.gameObject.SetActive(false);
                    compasses[1].gameObject.SetActive(true);
                    foreach (var t in headingTxt)
                    {
                        t.color = Color.red;
                    }
                }
                return;
            }
            if (!compass.gameObject.activeSelf)
            {
                compass.gameObject.SetActive(true);
                compasses[1].gameObject.SetActive(false);
                foreach (var t in headingTxt)
                {
                    t.color = Color.green;
                }
            }


        }

        void Prepare()
        {
            var comp = gameObject.GetGameObjectComponents<Component>();

            var ss = new string[] { "CompassComponent", "CompassComponent_Red" };
            for (int i = 0; i < 2; i++)
            {
                compasses[i] = comp[ss[i]][0].GetComponent<RawImage>();
            }
            var compass = compasses[0];
            startX = compass.uvRect.x;
            startY = compass.uvRect.y;
            startWidth = compass.uvRect.width;
            startHeight = compass.uvRect.height;

            ss = new string[] { "HorizonRollPitch", "HorizonRollPitch_Red" };
            for (int i = 0; i < 2; i++)
            {
                horisRollPitch[i] = comp[ss[i]][0].GetComponent<RectTransform>();
            }
         }

        #endregion
    }
}
