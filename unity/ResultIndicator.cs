using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using Scada.Interfaces;

using Unity.Standard;
using Motion6D.Interfaces;
using DataPerformer.Portable;
using Vector3D;
using CategoryTheory;
using UnityEngine.SceneManagement;

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
        time = Time.realtimeSinceStartup;
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
        SceneManager.UnloadSceneAsync("LevelScene");
    }

    void ShowTable()
    {
        update = Quit;
        Dictionary<string, List<Component>> tr =
              gameObject.GetGameObjectComponents<Component>();
        Component res = tr["Results"][0];
        Text text = res.GetComponentsInChildren<Text>(true)[0];
        EulerAngles angles = new EulerAngles();
        angles.Set(ori);
        string s = "Deviations\nY\t";
        s += (pos[1] * 100).ToString("0.0");
        s += "\nZ\t" + (pos[0] * 100).ToString("0.0");
        s += "\nRoll\t" + (Mathf.Rad2Deg * angles.roll).ToString("0.0");
        s += "\nPitch\t" + (Mathf.Rad2Deg * angles.pitch).ToString("0.0");
        s += "\nYaw\t" + (Mathf.Rad2Deg * angles.yaw).ToString("0.0");
        s += "\nVx\t" + (vel[2] * 100).ToString("0.0");
        s += "\nVy\t" + (vel[1] * 100).ToString("0.0");
        s += "\nVz\t" + (vel[0] * 100).ToString("0.0");
        s += "\nOmega X\t" + (omega[0] * 100).ToString("0.0");
        s += "\nOmega Y\t" + (omega[1] * 100).ToString("0.0");
        s += "\nOmega Z\t" + (omega[2] * 100).ToString("0.0");
        s += "\nTime\t" + time.ToString("0");
        text.text = s;
        update = Quit;
        res.gameObject.SetActive(true);
    }

    private void Quit()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
            AAALevel.Unload = true;
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
