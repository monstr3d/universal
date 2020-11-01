using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using Unity.Standard;

public class MenuSctript : MonoBehaviour
{

    int current = -1;

    Dictionary<int, KeyCode> d = new Dictionary<int, KeyCode>();

    KeyCode currentKey;

    Dictionary<string, List<Component>> components;

    Dictionary<Button, int> buttons = new Dictionary<Button, int>();


    private void Awake()
    {
        Dictionary<int, KeyCode> d = Saver.saver.KeyValuePairs;
        components = gameObject.GetGameObjectComponents<Component>();
        foreach (var key in components.Keys)
        {
            if (key.Contains("(") & key.Contains("Button"))
            {
                var l = components[key];
                foreach (var cc in l)
                {
                    if (cc is Button)
                    {
                        Button b = cc as Button;
                        Text text = b.GetComponentInChildren<Text>();
                        int i = int.Parse(text.text);
                        buttons[b] = i;
                        UnityAction act = () =>
                        {
                            Click(b);
                        };
                        b.onClick.AddListener(act);
                        b.GetComponentInChildren<Text>().text = d[i] + "";

                    }
                }
            }
        }
    }
 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                string k = kcode + "";
                if (k.Contains("Mouse"))
                {
                    break;
                }
                currentKey = kcode;
                break;
            }
        }
    }

    void Click(Button button)
    {
        var i = buttons[button];
        button.GetComponentInChildren<Text>().text = currentKey + "";
        d[i] = currentKey;
    }


}
