using Scada.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Standard;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class ForcesMomentums : MonoBehaviour
{

    public string desktop;

    public string fx;

    public string fy; 

    public string fz;
    
    public string mx;

    public string my;

    public string mz;

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

    MonoBehaviorTimerFactory factory;

   

    Action<double>[] actions = new Action<double>[6];

    
    bool isEnabled = true;

    Action ev;

    Action update;

    IScadaInterface scada;

    Action<double>[] dInp = new Action<double>[6];

    float lastTime;

    Action factotyUpdate;

    private void Awake()
    {
        if (!isEnabled)
        {
            update = () => { };
            ev = update;
            return;
        }
        scada = MonoBehaviorTimerFactory.Create(desktop,  out factory);
        string[] s = new string[] { fz, fy, fz, mx, my, mz };
        var inp = scada.Inputs;
        for (int i = 0; i < 6; i++)
        {
            string str = s[i];
            if (inp.ContainsKey(str))
            {
                if (inp[str].GetType() == typeof(double))
                {
                    dInp[i] = scada.GetDoubleInput(str);
                    continue;
                }
            }
            string err = "ForcesMomentums " + gameObject.name + 
                " Parameter " + str + " does not exit";
            Debug.LogError(err);
            throw new Exception(err);
        }
        update = UpdateForces;
        lastTime = Time.realtimeSinceStartup;
        factotyUpdate = factory.Update;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!scada.IsEnabled)
        {
            scada.IsEnabled = true;
        }
    }

    void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //       factory.Update();
        factotyUpdate();
        update();
    }

    ////// Controls: W-S (Pitch), A-D (Roll), Q-E (Yaw), R-F (Ligt), T-Space (Reset Attitude), Y (Toogle Sound), Shift-Ctrl (Faster/Slower speed)
    //////
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="old"></param>
    /// <returns></returns>
    
        
    void UpdateForces()
    {
        ////// Controls: W-S (Pitch), A-D (Roll), Q-E (Yaw), R-F (Ligt),
        try
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                ResetValue(ref vMx, -kMx, 3);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                ResetValue(ref vMx, kMx, 3);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                ResetValue(ref vMy, kMy, 5);
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                ResetValue(ref vMy, -kMy, 5);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                ResetValue(ref vMz, -kMz, 4);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                ResetValue(ref vMz, kMz, 4);
            }
            
        }
        catch (Exception ex)
        {
            ex.ShowError();
        }

    }


    void ResetValue(ref float value, float newValue, int i)
    {
        float t = Time.realtimeSinceStartup;
        if ((t - lastTime) < 0.5f)
        {
            return;
        }
        lastTime = t;
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

}
