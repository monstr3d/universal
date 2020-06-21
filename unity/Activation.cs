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

    #region Fields


    public string activation = "";

    public float delay = 1f;

    public int level;

    public string[] strings = new string[0];

    public float[] constants;
    
    static bool exists = false;

    Action update = null;

    public MonoBehaviour[] components;

    public string[] enabledComponents;

    public string[] disabledComponents;

    static bool isEscaped = false;

    IActivation act;


    #endregion

    #region Standard Members

    private void Awake()
    {
        isEscaped = false;
        StaticExtensionUnity.StartTime = Time.realtimeSinceStartup;
        if (exists)
        {
            throw new Exception();
        }
        StaticExtensionUnity.Activation = this;
        exists = true;
        Type type = StaticExtensionUnity.Level;
        MethodInfo mi = type.GetMethod("Set", new Type[] { typeof(MonoBehaviour) });
        if (activation != null)
        {
            if (activation.Length > 0)
            {
                ConstructorInfo ci = StaticExtensionUnity.activations[this.activation];
                IActivation activation = ci.Invoke(new object[0]) as IActivation;
                act = activation;
                activation.Level = level;
                activation.SetConstants(constants);
                activation.SetConstants(strings);
                activation.Activate(components);
                update = UpdateFist;
            }
        }
        foreach (MonoBehaviour monoBehaviour in components)
        {
            mi.Invoke(null, new object[] { monoBehaviour });
        }

        foreach (MonoBehaviour monoBehaviour in components)
        {
            monoBehaviour.enabled = true;
        }
    }

    private void Start()
    {
        StaticExtensionUnity.SetLevel();
    }

    private void Update()
    {
        update?.Invoke();
    }

    #endregion

    #region Public members

    void UpdateFist()
    {
        act.Update();
        foreach (string s in disabledComponents)
        {
            s.EnableDisable(false);
        }
        foreach (string s in enabledComponents)
        {
            s.EnableDisable(true);
        }
        update = act.Update;
    }

    /// <summary>
    /// Esapes game
    /// </summary>
    static public void Escape()
    {
        if (isEscaped)
        {
            StaticExtensionUnity.Restart();
        }
        else
        {
            StaticExtensionUnity.Pause();
        }
        isEscaped = !isEscaped;
    }

    /// <summary>
    /// Disables itsels
    /// </summary>
    static public void Disable()
    {
        exists = false;
    }

    #endregion

}