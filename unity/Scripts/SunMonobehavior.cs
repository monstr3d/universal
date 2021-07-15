using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMonobehavior : MonoBehaviour
{

    internal static SunMonobehavior sunMonobehavior;

    internal static GameObject game;

    internal static Transform trans;

  
    private void Awake()
    {
        sunMonobehavior = this;
        game = gameObject;
        trans = game.transform;
        Unity.Standard.StaticExtensionUnity.Enabled = this;
    }

    private void Start()
    {

    }

    private void Update()
    {

    }





    internal static void SetCoordinates(float x, float y, float z)
    {
        trans.position = new  Vector3(x, y, z);
    }

    internal static void SetSemiDark()
    {
        SetCoordinates(800, -500, 0);
    }

    internal static void SetDark()
    {
        SetCoordinates(8000, -5000, 5000);
    }

    internal static void SetGood()
    {
        SetCoordinates(5000, 0, -3000);
    }

    internal static void SetSun()
    {
        SetCoordinates(0, 0, -3000);
    }


}
