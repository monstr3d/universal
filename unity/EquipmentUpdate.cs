using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class EquipmentUpdate : AbstractUpdate
    {
        public static HudLiteScript current;


        //Config Variables
        public bool isActive = false;

        public Transform aircraft;
        public Rigidbody aircraftRB;
        //

        //Hud Display Variables
        public string activeMsg = "HUD Activated";

        public RectTransform hudPanel;

        public bool useRoll = true;
        public float rollAmplitude = 1, rollOffSet = 0, rollFilterFactor = 0.25f;
        public RectTransform horizonRoll;

        public bool usePitch = true;
        public float pitchAmplitude = 1, pitchOffSet = 0, pitchXOffSet = 0, pitchYOffSet = 0, pitchFilterFactor = 0.125f;
        public RectTransform horizonPitch;
         public bool useHeading = true;
        public float headingAmplitude = 1, headingOffSet = 0, headingFilterFactor = 0.1f;
        public RectTransform compassHSI;
        public CompassBar compassBar;
        Text text;
        Text altitudeTxt;
        Text speedTxt;
        Text headingTxt;
        Text horizonRollTxt;
        Text horizonPitchTxt;
        float speed, altitude, pitch, roll, heading;

        Quaternion quaternion = new Quaternion();

        public EquipmentUpdate()
        {

        }

        double[] q = new double[4];

       
 
        public override void Set(MonoBehaviorWrapper wrapper, ScriptWithWrapper mono)
        {
            base.Set(wrapper, mono);
            GameObject gob = mono.gameObject;
            Dictionary<string, List<Component>> c;
            Dictionary<string, List<GameObject>> d = gob.GetComponents(out c);
            Dictionary<string, List<Text>> lt = c.GetComponents<Text>();
            Dictionary<string, List<CompassBar>> lcb = c.GetComponents<CompassBar>();
            Dictionary<string, List<RectTransform>> lrt = c.GetComponents<RectTransform>();
            headingTxt = lt["heading_Txt"][0];
            text = lt["Text"][0];
            altitudeTxt = lt["Altitude_Txt"][0];
            speedTxt = lt["Speed_Txt"][0];
            compassBar = lcb["CompassBar"][0];
            horizonPitch = lrt["HorizonRollPitch"][0];
            horizonRoll = horizonPitch;
            var outp = scada.Outputs;
        }

        public override void Start()
        {
           
        }

        public override void Update()
        {
            Quaternion quaternion = dOut.Calculate(8, q);
            Vector3 v = quaternion.eulerAngles;
            heading = v.y;
            roll = v.z;
            pitch = v.x;
            if (compassHSI != null) compassHSI.localRotation = Quaternion.Euler(0, 0, headingAmplitude * heading);
            if (compassBar != null) compassBar.heading = heading;
            if (headingTxt != null)
            {
                if (heading < 0)
                    headingTxt.text = (heading + 360f).ToString("000");
                else
                    headingTxt.text = heading.ToString("000");
            }

            //Send values to Gui and Instruments
            if (horizonRoll != null) 
                horizonRoll.localRotation = 
                    Quaternion.Euler(0, 0, rollAmplitude * roll);
            if (horizonRollTxt != null)
            {
                //horizonRollTxt.text = roll.ToString("##");
                if (roll > 180) horizonRollTxt.text = (roll - 360).ToString("00");
                else if (roll < -180) horizonRollTxt.text = (roll + 360).ToString("00");
                else horizonRollTxt.text = roll.ToString("00");
            }
            if (horizonPitch != null) horizonPitch.localPosition = new Vector3(-pitchAmplitude * pitch * Mathf.Sin(horizonPitch.transform.localEulerAngles.z * Mathf.Deg2Rad) + pitchXOffSet, pitchAmplitude * pitch * Mathf.Cos(horizonPitch.transform.localEulerAngles.z * Mathf.Deg2Rad) + pitchYOffSet, 0);
            if (horizonPitchTxt != null) horizonPitchTxt.text = pitch.ToString("0");


        }

        void UpdateInternal()
        {
            // Return if not active
            /*       if (!isActive || !hudPanel.gameObject.activeSelf) return;
                   if (aircraft == null) { isActive = false; return; }*/

            //////////////////////////////////////////// Frame Calculations
            /*    lastPosition = currentPosition;
                lastSpeed = relativeSpeed;*/

            /* if (aircraft != null && aircraftRB == null) //Mode Transform
             {
                 currentPosition = aircraft.transform.position;
                 relativeSpeed = aircraft.transform.InverseTransformDirection((currentPosition - lastPosition) / Time.deltaTime);
             }
             else if (aircraft != null && aircraftRB != null)  //Mode RB
             {
                 currentPosition = aircraftRB.transform.position;
                 relativeSpeed = aircraftRB.transform.InverseTransformDirection(aircraftRB.velocity);
             }
             else
             {
                 currentPosition = Vector3.zero;
                 relativeSpeed = Vector3.zero;
             }*/
            //////////////////////////////////////////// Frame Calculations


            //////////////////////////////////////////// Compass, Heading and/or HSI
            if (useHeading)
            {
                heading = Mathf.LerpAngle(heading, aircraft.eulerAngles.y + headingOffSet, headingFilterFactor) % 360f;

                //Send values to Gui and Instruments
                if (compassHSI != null) compassHSI.localRotation = Quaternion.Euler(0, 0, headingAmplitude * heading);
                if (compassBar != null) compassBar.heading = heading;
                if (headingTxt != null)
                {
                    if (heading < 0)
                        headingTxt.text = (heading + 360f).ToString("000");
                    else
                        headingTxt.text = heading.ToString("000");
                }
            }
            //////////////////////////////////////////// Compass, Heading and/or HSI


            //////////////////////////////////////////// Roll
            if (useRoll)
            {
                roll = Mathf.LerpAngle(roll, aircraft.rotation.eulerAngles.z + rollOffSet, rollFilterFactor) % 360;

                //Send values to Gui and Instruments
                if (horizonRoll != null) horizonRoll.localRotation = Quaternion.Euler(0, 0, rollAmplitude * roll);
                if (horizonRollTxt != null)
                {
                    //horizonRollTxt.text = roll.ToString("##");
                    if (roll > 180) horizonRollTxt.text = (roll - 360).ToString("00");
                    else if (roll < -180) horizonRollTxt.text = (roll + 360).ToString("00");
                    else horizonRollTxt.text = roll.ToString("00");
                }
                //
            }
            //////////////////////////////////////////// Roll


            //////////////////////////////////////////// Pitch
            if (usePitch)
            {
                pitch = Mathf.LerpAngle(pitch, -aircraft.eulerAngles.x + pitchOffSet, pitchFilterFactor);

                //Send values to Gui and Instruments
                if (horizonPitch != null) horizonPitch.localPosition = new Vector3(-pitchAmplitude * pitch * Mathf.Sin(horizonPitch.transform.localEulerAngles.z * Mathf.Deg2Rad) + pitchXOffSet, pitchAmplitude * pitch * Mathf.Cos(horizonPitch.transform.localEulerAngles.z * Mathf.Deg2Rad) + pitchYOffSet, 0);
                if (horizonPitchTxt != null) horizonPitchTxt.text = pitch.ToString("0");
            }
            //////////////////////////////////////////// Pitch


            //////////////////////////////////////////// Altitude
           /* if (useAltitude)
            {
                altitude = Mathf.Lerp(altitude, altitudeOffSet + altitudeAmplitude * currentPosition.y, speedFilterFactor);

                //Send values to Gui and Instruments
                if (altitudeTxt != null) altitudeTxt.text = altitude.ToString("0").PadLeft(5);
            }*/
            //////////////////////////////////////////// Altitude


            //////////////////////////////////////////// Speed
            /*if (useSpeed)
            {
                speed = Mathf.Lerp(speed, speedOffSet + speedAmplitude * relativeSpeed.z, speedFilterFactor);

                //Send values to Gui and Instruments
                if (speedTxt != null) speedTxt.text = speed.ToString("0").PadLeft(5);//.ToString("##0");
            }*/
            //////////////////////////////////////////// Speed

        }

    }
}
