using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


using Motion6D.Interfaces;

using Vector3D;

using Scada.Interfaces;

using Unity.Standard;

public class ResultIndicator : MonoBehaviour
{

  
    Action update;

    IScadaInterface scada;

    float[] parameters;

    double[] pos = new double[3];

    double[] ori = new double[4];

    double[] vel= new double[3];

    double[] omega = new double[3];

    float time;

    static int count = 0;

    string resString = "Success";

    string GetResult(double val, float lim, float scale, string format)
    {
        float f = (float)val * scale;
        string s = " " + f.ToString(format) + " (" + lim.ToString(format) + ")";
        if (Math.Abs(f) > lim)
        {
            s = s + " Crashed";
            resString = "Crashed";
        }
        return s;
    }

   


    // Start is called before the first frame update
    void Start()
    {
         update = ShowTable;
    }

    private void Update()
    {
        update?.Invoke();
    }


    #region Public Members

    public void Indicate(object ob)
    {
        time = (float)Activation.Time;
        object[] o = ob as object[];
        IScadaInterface scada = o[0] as IScadaInterface;
        ReferenceFrame frame = scada.GetOutput("Relative to station.Frame")() as ReferenceFrame;
        Array.Copy(frame.Position, pos, 3);
        Array.Copy(frame.Quaternion, ori, 4);
        IVelocity v = frame as IVelocity;
        Array.Copy(v.Velocity, vel, 3);
        IAngularVelocity av = frame as IAngularVelocity;
        Array.Copy(av.Omega, omega, 3);
        parameters = o[2] as float[];
        scada.IsEnabled = false;
        ShowResults();
    }

    void ShowTable()
    {
        update = Quit;
        Dictionary<string, List<Component>> tr =
              gameObject.GetGameObjectComponents<Component>();
        Component res = tr["Results"][0];
        Dictionary<string, List<RectTransform>> rts =
              gameObject.GetGameObjectComponents<RectTransform>(); 
        RectTransform rt = rts["Results"][0];
        rt.sizeDelta = new Vector2(rt.rect.width, 850f);
        Text text = res.GetComponentsInChildren<Text>(true)[0];
        EulerAngles angles = new EulerAngles();
        angles.Set(ori);
        string s = "Deviations\nY\t";
        s += GetResult(pos[1], parameters[0], 100, "0.0");
        s += "\nZ\t" + GetResult(pos[0], parameters[0], 100, "0.0");
        s += "\nRoll\t" + GetResult(Mathf.Rad2Deg * angles.yaw, parameters[5], 1, "0.0");
        s += "\nPitch\t" + GetResult(Mathf.Rad2Deg * angles.pitch, parameters[5], 1, "0.0"); (Mathf.Rad2Deg * angles.pitch).ToString("0.0");
        s += "\nYaw\t" + GetResult(Mathf.Rad2Deg * angles.roll, parameters[5], 1, "0.0");
        s += "\nVx\t" + GetResult(vel[2], parameters[3], 100, "0.0");
        s += "\nVy\t" + GetResult(vel[1], parameters[3], 100, "0.0");
        s += "\nVz\t" + GetResult(vel[0], parameters[3], 100, "0.0");
        s += "\nOmega X\t" + GetResult(Mathf.Rad2Deg * omega[2], parameters[7], 1, "0.0");
        s += "\nOmega Y\t" + GetResult(Mathf.Rad2Deg * omega[1], parameters[7], 1, "0.0");
        s += "\nOmega Z\t" + GetResult(Mathf.Rad2Deg * omega[0], parameters[7], 1, "0.0");
        s += "\nTime\t" + GetResult(time, parameters[11], 1, "0"); 
        s += "\n\n" + resString;
        text.text = s;
        update = Quit;
        res.gameObject.SetActive(true);
    }

    private void Quit()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.SetActive(false);
            StaticExtensionUnity.Clear();
            ++count;
            Assets.SimpleActivation.StaticLevel = -1;
            Activation.Disable();
            SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
        }
    }

    #endregion


    void ShowResults()
    {
        Text text = gameObject.GetGameObjectComponents<Text>()["Message_Txt"][0];
        text.text = "Game over. Press Q for quit";
        update = ShowTable;
        enabled = true;
    }
}
