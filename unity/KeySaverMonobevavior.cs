using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class KeySaverMonobevavior : MonoBehaviour
{


    Action act = () => { };

    List<MonoBehaviour> l = new List<MonoBehaviour>();

    // Start is called before the first frame update
    void Start()
    {
        var mbs = gameObject.GetComponentsInChildren<MonoBehaviour>();
        object[] o = new object[] { l };
        foreach (MonoBehaviour mb in mbs)
        {
            MethodInfo mi = mb.GetType().GetMethod("CheckSaver");
            if (mi != null)
            {
                l.Add(mb);
            }
        }
        var btn = gameObject.GetComponentsInChildren<Button>();
        foreach (var bt in btn)
        {
            string n = bt.name;
            if (name == "ButtonOK")
            {
                UnityAction act = OK;
                bt.onClick.AddListener(act);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OK()
    {
        object[] o = new object[] { new List<KeyCode>() };
        foreach (var mb in l)
        {
            MethodInfo mi = mb.GetType().GetMethod("CheckSaver");
            KeyCode kc = (KeyCode)mi.Invoke(mb, o);
        }
    }

    public void Cancel()
    {

    }
}
