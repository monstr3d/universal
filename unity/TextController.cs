using System;
using System.Collections.Generic;
using System.Reflection;


using UnityEngine;
using UnityEngine.UI;

using Scada.Desktop;
using Scada.Interfaces;


using Motion6D.Interfaces;
using Diagram.UI.Interfaces;
using Diagram.UI;
using Vector3D;

using Unity.Standard;


public class TextController : MonoBehaviour
{

    public string desktop;

    public string[] parameters;


    public Text[] texts;

    public string[] formats;




    public float[] scales;

    public string referenceFrame;

    public string[] frameUpdates;


    public RectTransform[] transforms;



    public bool isEnabled = true;

    bool exists;


    Action update = () => { };

   

    Action ev = () => { };

    IScadaInterface scada;

    IDesktop scadaDesktop;

    MonoBehaviorTimerFactory factory;


    private void Awake()
    {
        exists = desktop.ScadaExists();
        if (!isEnabled)
        {
            update = () => { };
            return;
        }
        scada = MonoBehaviorTimerFactory.Create(desktop, out factory);
        scadaDesktop = scada.GetDesktop();
        if (!exists)
        {
            ev = factory.Update;
        }
        for (int i = 0; i < parameters.Length; i++)
        {
            if (i >= texts.Length)
            {
                break;
            }
            Text text = texts[i];
            if (text == null)
            {
                continue;
            }
            float scale = 1f;
            string format = null;
            if (i < scales.Length)
            {
                scale = scales[i];
            }
            if (i < formats.Length)
            {
                format = formats[i];
            }
            Action act = scada.CreateTextAction(
                parameters[i], format, text, scale);
            AddUpdate(act);
        }
        if (update == null)
        {
            update = () => { };
        }
    (factory as IScadaUpdate).Update = null;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        factory.Start();
        UpdateTransforms();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ev();
    }

    void  Update()
    {
        update();
    }

    private void UpdateTransforms()
    {
        if (referenceFrame == null)
        {
            return;
        }
        if (referenceFrame.Length == 0)
        {
            return;
        }
        ReferenceFrame frame = null;
        var ou = scada.Outputs;
        if (ou.ContainsKey(referenceFrame))
        {
            if (ou[referenceFrame] == typeof(ReferenceFrame))
            {
                frame = scada.GetOutput(referenceFrame)() as ReferenceFrame;
            }
        }
        if (frame == null)
        {
            scadaDesktop.ForEach((IReferenceFrame f) =>
            {
                string fn = f.GetName(scadaDesktop);
                if (fn == referenceFrame)
                {
                    frame = f.Own;
                }
            });
        }
        if (frame == null)
        {
            return;

        }
        EulerAngles angles = new EulerAngles();
        Action updateFrames = () =>
        {
            angles.Set(frame.Quaternion);
        };
        Dictionary<string, ConstructorInfo> constructors =
            StaticExtensionUnity.updatesRectTransform;
        for (int i = 0; i < frameUpdates.Length; i++)
        {
            IUpdateRectTransform r =
                constructors[frameUpdates[i]].Invoke(new Type[0])
                as IUpdateRectTransform;
            r.Set(frame, angles, transforms[i]);
            Action act = r.Update;
            updateFrames += act;
        }
        update = updateFrames + update;
    }


    void AddUpdate(Action act)
    {
        if (act == null)
        {
            return;
        }
        if (update == null)
        {
            update = act;
            return;
        }
        update += act;
    }

}
