using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Standard;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AAALevel : MonoBehaviour
{

    static Action update;

    static int level = 0;
    static public bool Unload
    {
        set
        {

        }
    }


    // Start is called before the first frame update
    void Start()
    {
       Button[] buttons = gameObject.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            for (int i = 1; i < 7; i++)
            {
                int[] k = new int[] { i };
                string s = i + "";
                if (button.name.Contains(s))
                {
                    UnityAction act = () => 
                    { 
                        Click(k[0]); 
                    };
                    button.onClick.AddListener(act);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        update?.Invoke();
    }

    void Click(int i)
    {
        Assets.SimpleActivation.StaticLevel = i;
        try
        {
            string ss = "SampleScene";
            if (level > 0)
            {
                ss +=  level;
            }
            SceneManager.LoadScene(ss, LoadSceneMode.Single);
            ++level;
        }
        catch (Exception ex)
        {

        }
    }


}
