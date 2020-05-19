using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Compass : MonoBehaviour
{
    public RawImage rawImg;

    public Text headingTxt;

    public float heading, headingOffSet = 0, factor = 1, maxValue = 360;
    public bool isActive = true, moveX = true;

    public float startX = 0, startY = 0, startWidth, startHeight;
    //
    void Start()
    {
        startX = rawImg.uvRect.x; startY = rawImg.uvRect.y;
        startWidth = rawImg.uvRect.width; startHeight = rawImg.uvRect.height;
    }
    //

    ///////////////////////////
    void Update()
    {
        if (isActive)
        {
            if(moveX) 
                rawImg.uvRect = new Rect(factor * (heading + headingOffSet) / maxValue + startX, rawImg.uvRect.y, rawImg.uvRect.width, rawImg.uvRect.height);

            if (headingTxt != null) 
            { if (heading < 0) 
                    headingTxt.text = (heading + 360f).ToString("000"); 
                else 
                    headingTxt.text = heading.ToString("000"); }
        }
    }
    ///////////////////////////

}
