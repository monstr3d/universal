using Diagram.UI;
using System;
using System.Collections.Generic;
using Unity.Standard;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scripts.Specific
{
    class MenuKeyPerformer
    {

        internal Dictionary<int, KeyCode> d = new Dictionary<int, KeyCode>();

        static KeyCode currentKey;

   //     Dictionary<string, List<Component>> components;

        Dictionary<Button, int> buttons = new Dictionary<Button, int>();

        GameObject gameObject;

        ISaverLoadSave saver;

        MonoBehaviour mb;


        internal MenuKeyPerformer(GameObject go, MonoBehaviour mb, ISaverLoadSave saver)
        {
            gameObject = go;
            this.saver = saver;
            d = saver.Dictionary;
            this.mb = mb;
            LoadButtons(true);
        }

        internal  void LoadButtons()
        {
            d = saver.Dictionary;
            foreach (var b in buttons.Keys)
            {
                var i = buttons[b];
                b.GetComponentInChildren<Text>().text = d[i] + "";
            }
        }

        internal void LoadButtons(bool addClick)
        {
            var components = gameObject.GetComponentsInChildren<Button>();
            foreach (var b in components)
            {
                string key = b.name;
                if (key.Contains("(") & key.Contains("Button"))
                {
                    Text text = b.GetComponentInChildren<Text>();
                    int i = int.Parse(text.text);
                    if (addClick)
                    {
                        UnityAction act = () =>
                        {
                            Click(b);
                        };
                        b.onClick.AddListener(act);
                    }
  //                  b.onClick.AddListener(act);
                    buttons[b] = i;
                    if (d.ContainsKey(i))
                    {
                        b.GetComponentInChildren<Text>().text = d[i] + "";
                    }
                }
            }
        }

  
        internal void Save()
        {
            saver.Dictionary = d;
        }

        internal static void OnGUI()
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
            if (currentKey == default(KeyCode))
            {
                return;
            }
            var i = buttons[button];
            button.GetComponentInChildren<Text>().text = currentKey + "";
            d[i] = currentKey;
        }

        internal void SaveSaver()
        {
            saver.Dictionary = d;
        }

        internal KeyCode CheckSaver(List<KeyCode> l)
        {
            return d.CompareValue(l);
        }
    }
}