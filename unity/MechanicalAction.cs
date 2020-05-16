using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicalAction : MonoBehaviour
{
    // Start is called before the first frame update

    public float fx;

    public float fy;

    public float fz;

    public float mx;

    public float my;

    public float mz;

    static internal float[] coeff = null;



    private void Awake()
    {
        if (coeff != null)
        {
            throw new Exception();
        }
        coeff = new float[]{ fx, fy, fz, mx, my, mz};
    }

    static internal void Force(int i,  float v, Action<double>[] act)
    {
        double val = coeff[i] * v;
        act[i](val);
    }
    
}
