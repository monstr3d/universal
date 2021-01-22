using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;

using Unity.Standard;

using Scada.Interfaces;
using System.Threading;
using BaseTypes;

/// <summary>
/// Activation of level
/// </summary>
public class Activation : MonoBehaviour
{

    #region Fields


    public string activation = "";

    public float delay = 0.1f;

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

    private IActivation activationObject;


    public Texture[] textures;

    volatile Queue<Tuple<Action<object>, object>> queue = new Queue<Tuple<Action<object>, object>>();

    #endregion

    #region Standard Members

    private void Awake()
    {
        if (activation != null)
        {
            if (activation.Length > 0)
            {
                ConstructorInfo ci = StaticExtensionUnity.activations[this.activation];
                activationObject = ci.Invoke(new object[0]) as IActivation;
             }
        }

        isEscaped = false;
        if (StaticExtensionUnity.StaticLevel != 0)
        {
            level = StaticExtensionUnity.StaticLevel;
        }
        else
        {
            StaticExtensionUnity.StaticLevel = level;
        }
        StaticExtensionUnity.StartTime = Time.realtimeSinceStartup;
        if (exists)
        {
            throw new Exception();
        }
        StaticExtensionUnity.Activation = this;
        exists = true;
        Type type = StaticExtensionUnity.Level;
        MethodInfo stop = type.GetMethod("Collision", 
            new Type[] { typeof(Tuple<GameObject, Component, IScadaInterface, ICollisionAction>) });
        if (stop != null)
        {
            StaticExtensionUnity.Collision += (Tuple<GameObject, Component, IScadaInterface, ICollisionAction> x) =>
            {
                stop.Invoke(null, new object[] { x });
            };
        }

        MethodInfo mi = type.GetMethod("Set", new Type[] { typeof(MonoBehaviour) });
        if (activation != null)
        {
            if (activationObject != null)
            {
                act = activationObject;
                activationObject.Level = level;
                activationObject.SetConstants(constants);
                activationObject.SetConstants(strings);
                activationObject.Activate(components);
            }
            update = UpdateFist;
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
        StartCoroutine(enumerator);
    }

    private void Update()
    {
         update?.Invoke();
    }

    #endregion

    #region Public members

  
    void UpdateFist()
    {
        act?.Update();
        foreach (string s in disabledComponents)
        {
            s.EnableDisable(false);
        }
        foreach (string s in enabledComponents)
        {
            s.EnableDisable(true);
        }
        if (act != null)
        {
            update = act.Update;
        }
        else
        {
            update = () =>
            {

            };
        }
    }

    /// <summary>
    /// Esapes game
    /// </summary>
    static public void PauseRestart()
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

    object l = new object();

    bool evebool = true;

    /// <summary>
    /// Puts action into queue
    /// </summary>
    /// <param name="action">Action</param>
    /// <param name="value">Value</param>
    internal void Put(Action<object> action, object value)
    {
        lock (l)
        {
            var t = new Tuple<Action<object>, object>(action, value);
            queue.Enqueue(t);
            evebool = queue.Count == 1;
        }
    }

    #endregion

    #region Private Members

    bool Predicate()
    {
        return evebool;
    }

    IEnumerator enumerator
    {
        get
        {
            while (true)
            {
                yield return new WaitUntil(Predicate);
                evebool = false;
                if (queue.Count ==  0)
                {
                    continue;
                }
                var t = queue.Dequeue();
                t.Item1(t.Item2);
                yield return new WaitForSeconds(delay);
                evebool = true;
           }
        }
    }

    #endregion

}