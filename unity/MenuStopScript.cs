using System;
using System.Collections.Generic;

using UnityEngine;

using Assets;


public class MenuStopScript : MonoBehaviour
{
    MenuKeyPerformer keyPerformer;


    private void Awake()
    {
        keyPerformer = new MenuKeyPerformer(gameObject, this, new KeySaver());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    class KeySaver : ISaverLoadSave
    {
        Dictionary<int, KeyCode> ISaverLoadSave.Dictionary { get => Saver.saver.dict; set => Saver.saver.dict = value; }
    }

}
