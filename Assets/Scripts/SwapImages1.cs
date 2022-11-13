using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwapImages1 : MonoBehaviour
{
    public Sprite[] Sprites = new Sprite[0];

    public float duration = 0.5f;

    public bool loop = true;

    public bool destroyObject = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playAnimation());
    }

    protected IEnumerator playAnimation()
    {
        Image img = GetComponent<Image>();

        do
        {
            for (int i = 0; i < Sprites.Length; i++)
            {
                if (!enabled)
                {
                    break;
                }
                img.sprite = Sprites[i];
                yield return new WaitForSeconds(duration / Sprites.Length);
            }
        } while (enabled && loop);

        if (destroyObject)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ////transparency -= fadeRate;
        //if (Time.time > startTime + elapsedTime)
        //{
        //    transparency -= fadeRate;
        //    if (transparency > 0.0f)
        //    {
        //        Color color = StartImage.color;
        //        StartImage.color = color.WithAlphaMultiplied(transparency);
        //    }
        //    else if (transparency < 0.0f)
        //    {
        //        StartImage.enabled = false;
        //        GameObject.Find("Main Camera/Canvas/Background").SetActive(false);
        //    }
        //}
        
    }
}
