using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeySaverMonobehavior : MonoBehaviour
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
            if (n == "ButtonOK")
            {
                UnityAction act = OK;
                bt.onClick.AddListener(act);
                continue;
            }
            if (n == "ButtonCancel")
            {
                bt.onClick.AddListener(Cancel);
                continue;
            }
            if (n == "ButtonReset")
            {
                bt.onClick.AddListener(() => 
                { 
                    Scripts.Saver.saver.Reset(); 
                    Execute("ResetButtons"); 
                });
                continue;
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
            if (kc != default(KeyCode))
            {
                ShowMessage(kc);
                return;
            }
        }
        Execute("SaveSaver");
        Scripts.Saver.saver.SetUnused();
        Cancel();
    }

    void Execute(string func)
    {
        foreach (var mb in l)
        {
            MethodInfo mi = mb.GetType().GetMethod(func);
            mi.Invoke(mb, null);
        }

    }

    void ShowMessage(KeyCode keyCode)
    {
        EditorUtility.DisplayDialog("Error", "The key " + keyCode + " is already defined", "OK");
    }

    public void Cancel()
    {
        SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
    }
}
