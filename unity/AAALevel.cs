using Assets;
using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AAALevel : MonoBehaviour
{

    static Action update;

    static Saver saver;


    static string path;





    public static void Exit()
    {
        Application.Quit();
    }
    static public bool Unload
    {
        set
        {

        }
    }


    private void Awake()
    {
        saver = Saver.saver;
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
                string ss = s;
                if (button.name.Contains(s))
                {
                    UnityAction act = () =>
                    {
                        Click(k[0]);
                    };
                    button.onClick.AddListener(act);
                    if (i > saver.level)
                    {
                        ss = "?";
                    }
                    button.GetComponentInChildren<Text>().text = ss;
                }
            }
        }
        Component[] comp = gameObject.GetComponentsInParent<Component>();
        buttons = comp[6].gameObject.GetComponentsInChildren<Button>();
        UnityAction exit = () =>
        {
            Application.Quit();
        };
        foreach (Button b in buttons)
        {
            var n = b.name;
            if (n == "Exit")
            {
                b.onClick.AddListener(exit);
                continue;
            }
            if (n == "SelectKeys")
            {
                UnityAction sel = () =>
                {
                    SceneManager.LoadScene("KeySelection", LoadSceneMode.Single);
                };

                b.onClick.AddListener(sel);
                continue;
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
     /*       if (level > 0)
            {
                ss +=  level;
            }*/
            SceneManager.LoadScene(ss, LoadSceneMode.Single);
        }
        catch (Exception ex)
        {

        }
    }


}
