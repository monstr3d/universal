
using System;
using UnityEngine;
using UnityEngine.UI;

using Motion6D;
using Scada.Interfaces;



using Unity.Standard;
using Motion6D.Interfaces;

public class OrientationCockpit : MonoBehaviour
{


    //Config Variables
    public bool isActive = false;


    public string desktop;



    public string measureName;

    private ReferenceFrame frame;

    Vector3D.EulerAngles angles = new Vector3D.EulerAngles();

    //




    public RectTransform hudPanel;

    public bool useRoll = true;
    public float rollAmplitude = 1, rollOffSet = 0, rollFilterFactor = 0.25f;
    public RectTransform horizonRoll;
    public Text horizonRollTxt;

    public bool usePitch = true;
    public float pitchAmplitude = 1, pitchOffSet = 0, pitchXOffSet = 0, pitchYOffSet = 0, pitchFilterFactor = 0.125f;
    public RectTransform horizonPitch;
    public Text horizonPitchTxt;
    
    public bool useHeading = true;
    public float headingAmplitude = 1, headingOffSet = 0, headingFilterFactor = 0.1f;
    public RectTransform compassHSI;
    public Text headingTxt;
    public CompassBar compassBar;


    public bool useAltitude = true;
    public float altitudeAmplitude = 1, altitudeOffSet = 0, altitudeFilterFactor = 0.5f;
    public Text altitudeTxt;

    public bool useSpeed = true;
    public float speedAmplitude = 1, speedOffSet = 0, speedFilterFactor = 0.25f;
    public Text speedTxt;

   
    //


    //All Flight Variables
    public float speed, altitude, pitch, roll, heading;


    //Internal Calculation Variables
    Vector3 currentPosition, lastPosition, relativeSpeed, lastSpeed;

    MonoBehaviorTimerFactory factory;

    Action fixedUpdate;

    Action update;


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////// Inicialization
 

   //////////////////////////////////////////////////////////////////////////////////////////////////////////////// Inicialization

    void UpdateFrame()
    {
        
        Quaternion quaternion = frame.ToQuaternion(angles);
        Vector3 v = quaternion.eulerAngles;
        heading = v.x;
        roll = v.z;
        pitch = v.y;
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



    /////////////////////////////////////////////////////// Updates and Calculations


    void Awake()
    {

        if (desktop != null)
        {
            try
            {

                IScadaInterface scada = MonoBehaviorTimerFactory.Create(desktop,  out factory);
                update = () => { };
                fixedUpdate = factory.Update;
                var ou = scada.Outputs;
                Func<object> f = scada.GetOutput(measureName);
                frame = f() as ReferenceFrame;
                update = UpdateFrame;
                return;
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }
    }

    private void Start()
    {
        factory.Start();
    }

    

    private void FixedUpdate()
    {
        fixedUpdate();
    }


    void Update()
    {
        update();
    }






}