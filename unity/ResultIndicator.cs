using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using Scada.Interfaces;

using Unity.Standard;

public class ResultIndicator : MonoBehaviour
{

    Action update;

    

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
        object[] o = ob as object[];
        IScadaInterface scada = o[0] as IScadaInterface;
        scada.IsEnabled = false;
        ShowResults();
    }

    void ShowTable()
    {
        update = null;
    }

    #endregion


    void ShowResults()
    {
        Text text = gameObject.GetGameObjectComponents<Text>()["Message_Txt"][0];
        text.text = "Game over. Press ENTER for result";
        enabled = true;
    }
}
