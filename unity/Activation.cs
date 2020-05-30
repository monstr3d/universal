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


    public MonoBehaviour[] components;

    private void Awake()
    {
        if (activation != null)
        {
            if (activation.Length > 0)
            {
                ConstructorInfo ci = StaticExtensionUnity.activations[this.activation];
                IActivation activation = ci.Invoke(new object[0]) as IActivation;
                activation.Level = level;
                activation.Activate(components);
            }
        }
        foreach (MonoBehaviour monoBehaviour in components)
        {
            monoBehaviour.enabled = true;
        }
    }
}