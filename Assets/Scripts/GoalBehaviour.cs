using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{

    private int score;
    private float sleepiness;
    public int max_sleepiness;
    public int sleepiness_change_rate;
    public int item_strenght;
    public int score_per_item;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        sleepiness = max_sleepiness;
    }

    // Update is called once per frame
    void Update()
    {
        sleepiness = sleepiness - sleepiness_change_rate * Time.deltaTime;
        //Debug.Log(sleepiness);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            if (collision.gameObject.GetComponent<Object>().good)
            {
                sleepiness = sleepiness + 10;
                if (sleepiness > max_sleepiness)
                {
                    sleepiness = max_sleepiness;
                }
                score = score + score_per_item;
            }
            else
            {
                sleepiness = sleepiness - item_strenght;
                if (sleepiness < 0)
                {
                    sleepiness = 0;
                }
            }
            collision.gameObject.SetActive(false);
        }
        Debug.Log(score);
    }

    
}
