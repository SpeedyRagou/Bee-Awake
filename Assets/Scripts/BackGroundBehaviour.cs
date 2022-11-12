using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public float imageChange;
    public bool backgroundChanged;
    private float countUp;
    private Sprite background;
    private bool finished;

    void Start()
    {
        countUp = 0;
        background = Resources.Load<Sprite>("Background2");
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if (backgroundChanged)
        {
            gameObject.SetActive(false);
        }


        if (!finished)
        {
            countUp += Time.deltaTime;
            if (countUp > imageChange)
            {
                //countUp = 0;
                gameObject.GetComponent<Animator>().Play("change");
                finished = true;
            }
            
        }
        
    }
}
