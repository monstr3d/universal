using System;
using System.Collections.Generic;

using UnityEngine;

using Scripts;
using Scripts.Specific;

public class MenuSctript : MonoBehaviour
{

    MenuKeyPerformer keyPerformer;


    private void Awake()
    {
        keyPerformer = new MenuKeyPerformer(gameObject, this, new KeySaver());
    }

    private void OnGUI()
    {
        MenuKeyPerformer.OnGUI();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public KeyCode CheckSaver(List<KeyCode> l)
    {
       return  keyPerformer.CheckSaver(l);
    }


    public void ResetButtons()
    {
        keyPerformer.LoadButtons();
    }

    public void SaveSaver()
    {
        keyPerformer.SaveSaver();
    }
    class KeySaver : ISaverLoadSave
    {
        Dictionary<int, KeyCode> ISaverLoadSave.Dictionary { get => Saver.saver.KeyValuePairs; set => Saver.saver.KeyValuePairs = value; }
    }

}
