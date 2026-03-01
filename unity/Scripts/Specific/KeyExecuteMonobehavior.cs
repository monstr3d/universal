using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Standard;
using UnityEngine;

public class KeyExecuteMonobehavior : MonoBehaviour
{
    static public KeyExecuteMonobehavior keyExecuteMonobehavior;

    static KeyExecuteMonobehavior()
    {
        Action<string> a = (string str) =>
        {
            if (str == "Escape:true")
            {
               // keyExecuteMonobehavior.enabled = true;
            }
            if (str == "Escape:false")
            {
               // keyExecuteMonobehavior.enabled = false;
            }
        };
        a.AddGlobal();
    }

    void Awake()
    {
        keyExecuteMonobehavior = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StaticExtensionUnity.ProcessKeyCodes();
    }
}