using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Scada.Interfaces;
using Scada.Desktop;

using Unity.Standard;


public class SliderScript : MonoBehaviour
{

    #region Fields

    public float limit;

    public float scale;

    public bool positive  = true;

   // public float ratio = 0.5f;

    public Color normal = new Vector4(0, 0, 1, 1);

    public Color exceed = new Vector4(1, 1, 0, 0);

    public string desktop = "";

    public string pararmeter = "";

    Dictionary<string, List<Component>> components;

    Func<double> output;

    IScadaInterface scada;

    bool exists = false;

    bool isEnabled = true;

    MonoBehaviourTimerFactory factory;

    Action ev;

    Action update;

    Slider left;

    Slider right;

    #endregion

    #region Standard Members

    private void Awake()
    {
        if (desktop.Length == 0)
        {
            enabled = false;
        }
        this.Add();
        exists = desktop.ScadaExists();
        if (!isEnabled)
        {
            return;
        }
        scada = MonoBehaviourTimerFactory.Create(desktop, out factory);
        components = gameObject.GetGameObjectComponents<Component>();
        if (!exists)
        {
            ev = factory.Update;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        throw new Exception();
        if (desktop.Length == null)
        {
            enabled = false;
        }
        factory.Start();
        output = scada.GetDoubleOutput(pararmeter);
        CreateUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        update?.Invoke();
    }

    private void FixedUpdate()
    {
        ev?.Invoke();
    }

    #endregion

    float Get()
    {
        return scale * (float)output();
    }


    void CreateUpdate()
    {
        if (!isEnabled)
        {
            return;
        }
        var c = components;
        RectTransform tr = gameObject.GetComponent<RectTransform>();
        var tt = gameObject.GetComponentsInChildren<RectTransform>();
        left = c["SliderLeft"][1] as Slider;
        right = c["SliderRight"][1] as Slider;
        Vector3 vp = new Vector3();
         left.fillRect.sizeDelta = new Vector2(0, 0);
       // left.fillRect.position = left...position;
        left.GetComponentInChildren<Image>().color = normal;
       // right.fillRect.sizeDelta = new Vector2(0, 0);
 //       right.fillRect.position = vp;
        right.value = 0;
        right.GetComponentInChildren<Image>().color = exceed;

        //  left.GetComponent<Image>().color = normal;
        update = SimpleUpdate;

    }


    void SimpleUpdate()
    {
        float x = Get() / limit;
        if (x < 1)
        {
            left.value = x;
            return;
        }
        left.value = 1;
        x -= 1;
        if (x > 1)
        {
            x = 1;
        }
        right.value = x;
    }
 
}
