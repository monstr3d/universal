using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;

using Unity.Standard;

/// <summary>
/// Activation of level
/// </summary>
public class Activation : MonoBehaviour
{


    public string activation = "";

    public int level;

    public string[] strings = new string[0];

    public float[] constants;
    

    static bool exists = false;


    public MonoBehaviour[] components;

    static float startTime;

    private void Awake()
    {
        startTime = UnityEngine.Time.realtimeSinceStartup;
        if (exists)
        {
            throw new Exception();
        }
        exists = true;
        if (activation != null)
        {
            if (activation.Length > 0)
            {
                ConstructorInfo ci = StaticExtensionUnity.activations[this.activation];
                IActivation activation = ci.Invoke(new object[0]) as IActivation;
                activation.Level = level;
                activation.SetConstants(constants);
                activation.SetConstants(strings);
                activation.Activate(components);
            }
        }
        foreach (MonoBehaviour monoBehaviour in components)
        {
            monoBehaviour.enabled = true;
        }
    }

    /// <summary>
    /// Disables itsels
    /// </summary>
    static public void Disable()
    {
        exists = false;
    }

    static public double Time 
    { 
        get => UnityEngine.Time.realtimeSinceStartup - startTime; 
    }
 }