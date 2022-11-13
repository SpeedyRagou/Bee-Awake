using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwapImages : MonoBehaviour
{
    public Image StartImage;
   // public Image EndImage;
    float startTime;
    public float elapsedTime;
    float transparency = 1.0f;
    public float fadeRate = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
       startTime =  Time.unscaledTime;


    }

    // Update is called once per frame
    void Update()
    {
        //transparency -= fadeRate;
        if (Time.time > startTime + elapsedTime)
        {
            transparency -= fadeRate;
            if (transparency > 0.0f)
            {
                Color color = StartImage.color;
                color.a *= transparency;
                StartImage.color = color;
            }
            else if (transparency < 0.0f)
            {
                StartImage.enabled = false;
                GameObject.Find("Main Camera/Canvas/Background").SetActive(false);
            }
        }
        
    }
}
