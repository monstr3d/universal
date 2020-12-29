using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using Unity.Standard;
using Diagram.UI;

public class MenuSctript : MonoBehaviour
{

    int current = -1;

    MenuKeyPerformer keyPerformer;

    private void Awake()
    {
        keyPerformer = new MenuKeyPerformer(gameObject, new KaySaver());
    }

    class KaySaver : ISaverLoadSave
    {
        Dictionary<int, KeyCode> ISaverLoadSave.Dictionary { get => Saver.saver.KeyValuePairs; set => Saver.saver.KeyValuePairs = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        keyPerformer.OnGUI();
    }

    public KeyCode CheckSaver(List<KeyCode> l)
    {
       return  keyPerformer.CheckSaver(l);
    }
 }
