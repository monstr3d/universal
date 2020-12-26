using System;
using System.Collections.Generic;


using Motion6D.Interfaces;

using Vector3D;

using Scada.Interfaces;
using Scada.Desktop;


using Unity.Standard;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultIndicator : MonoBehaviour
{

    #region Fields

    Action update;

    IScadaInterface scada;

    static IScadaInterface staticScada;

    static ReferenceFrame frame;

   
    static IVelocity v;

    static IAngularVelocity av;

    static double[] spos = new double[3];

    static double[] sori = new double[4];

    static double[] svel = new double[3];

    static double[] somega = new double[3];



    float[] parameters;

    double[] pos = new double[3];

    double[] ori = new double[4];

    double[] vel = new double[3];

    double[] omega = new double[3];

    float time;


    string resString = "Success";

    static EulerAngles angles = new EulerAngles();

    static internal KeyCode Pause = KeyCode.Escape;


    static internal KeyCode StopKey = KeyCode.Return;

    static internal KeyCode QuitKey = KeyCode.Q;




    #endregion

    #region Standard Members

    // Start is called before the first frame update
    void Start()
    {
        // update = ShowTable;
    }

    private void Update()
    {
        if (Input.GetKey(ResultIndicator.Pause))
        {
            Activation.PauseRestart();
        }
        return;
        var s = "RigidBodyStation".ToExistedScada();
        var c = s.Constants;
        var cc = s.GetConstantValue("Aim 1.Z");

     //   update?.Invoke();
    }

    #endregion

    #region Public Members

    static public float[] Constants
    {
        get;
        set;
    }


    public void Indicate(object ob)
    {
        time = (float)StaticExtensionUnity.Time;
        object[] o = ob as object[];
        scada = o[0] as IScadaInterface;
        ReferenceFrame frame = 
            scada.GetOutput("Relative to station.Frame")() as ReferenceFrame;
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

    static public void Stop()
    {
        StaticExtensionUnity.Stop();
        Assets.SimpleActivation.StaticLevel = -1;
        SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
    }


    static public IScadaInterface Scada
    {
        get => staticScada;
        set { staticScada = value; SetScada(); }
    }



    static public string GetResult(out float[] yz, out float[] delta)
    {
        yz = null;
        delta = null;
        Array.Copy(frame.Position, spos, 3);
        double d = RealMatrixProcessor.RealMatrix.Norm(spos);
        if (d > 0.1)
        {
            return null;
        }
        Array.Copy(frame.Quaternion, sori, 4);
        Array.Copy(v.Velocity, svel, 3);
        Array.Copy(av.Omega, somega, 3);
        angles.Set(sori);
        string s = CheckResult("Y", spos[1], Constants[0], 100);
        {
            if (s != null)
            {
                yz = new float[] { (float)spos[1], (float)spos[0], (float)(Mathf.Rad2Deg * angles.yaw) };
                return "";
            }
        }
        s = CheckResult("Z", spos[0], Constants[0], 100);
        {
            if (s != null)
            {
                yz = new float[] { (float)spos[1], (float)spos[0], (float)(Mathf.Rad2Deg * angles.yaw) };
                return "";
            }
        }
        s = CheckResult("Roll", Mathf.Rad2Deg * angles.yaw, Constants[5], 1);
        {
            if (s != null)
            {
                yz = new float[] { (float)spos[1], (float)spos[0], (float)(Mathf.Rad2Deg * angles.yaw) };
                return "";
            }
        }
        s = CheckResult("Pitch", Mathf.Rad2Deg * angles.pitch, Constants[5], 1);
        {
            if (s != null)
            {
                delta = outp;
                return s;
            }
        }
        s = CheckResult("Yaw", Mathf.Rad2Deg * angles.roll, Constants[5], 1);
        {
            if (s != null)
            {
                delta = outp;
                return s;
            }
        }
        s = CheckResult("Vx", svel[2], Constants[3], 100);
        {
            if (s != null)
            {
                delta = outp;
                return s;
            }
        }
        s = CheckResult("Vy", svel[1], Constants[3], 100);
        {
            if (s != null)
            {
                delta = outp;
                return s;
            }
        }
        s = CheckResult("Vz", svel[0], Constants[3], 100);
        {
            if (s != null)
            {
                delta = outp;
                return s;
            }
        }
        s = CheckResult("Omega X", Mathf.Rad2Deg * somega[2], Constants[7], 1);
        {
            if (s != null)
            {
                delta = outp;
                return s;
            }
        }
        s = CheckResult("Omega Y", Mathf.Rad2Deg * somega[1], Constants[7], 1);
        {
            if (s != null)
            {
                delta = outp;
                return s;
            }
        }
        s = CheckResult("Omega Z", Mathf.Rad2Deg * somega[0], Constants[7], 1);
        {
            if (s != null)
            {
                delta = outp;
                return s;
            }
        }
        return null;
    }

    #endregion

    #region Private Members
    private void Quit()
    {
        if (Input.GetKey(QuitKey))
        {
            gameObject.SetActive(false);
            Stop();
        }
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



    static void SetScada()
    {
        frame = staticScada.GetOutput("Relative to station.Frame")() as ReferenceFrame;
        v = frame as IVelocity;
        av = frame as IAngularVelocity;
    }

    static float[] outp;

    

    static string CheckResult(string s, double val, float lim, float scale)
    {
        float f = (float)val * scale;
        float fa = Math.Abs(f);
        if (Math.Abs(f) > lim)
        {
            outp = new float[] { fa, lim };
            return s;// + "=" + f.ToString("0.00") + " Exceeds " + lim.ToString("0.00");
        }
        outp = null;
        return null;
    }

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



    void ShowResults()
    {
       // Text text = gameObject.GetGameObjectComponents<Text>()["Message_Txt"][0];
       // text.text = "Game over. Press Q for quit";
        update = ShowTable;
        enabled = true;
    }

    #endregion
}
