using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBehaviour : MonoBehaviour
{

    private int score;
    private float sleepiness;
    public int max_sleepiness;
    public int sleepiness_change_rate;
    public int item_strenght;
    public int score_per_item;
    public float movement_speed;


    private Sprite[] sleepState;
    private int sleep_sprite;
    private int movement_state;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        sleepiness = max_sleepiness;
        sleepState = Resources.LoadAll<Sprite>("woke");
        sleep_sprite = sleepState.Length - 1;
        gameObject.GetComponent<SpriteRenderer>().sprite = sleepState[(sleepState.Length - 1) - sleep_sprite ];
        movement_state = 0;
        direction = new Vector2(0, movement_speed);
    }

    // Update is called once per frame
    void Update()
    {
        sleepiness = sleepiness - sleepiness_change_rate * Time.deltaTime;

        float tmp_sprite = sleepiness / (max_sleepiness / (sleepState.Length - 1));


        

        // ending check
        if (sleepiness <= 0)
        {
            //Ende
            Debug.Log("End");
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

        // select sprite for state
        if (Mathf.RoundToInt(tmp_sprite) != sleep_sprite)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sleepState[Mathf.RoundToInt((sleepState.Length - 1) - tmp_sprite)];
            sleep_sprite = Mathf.RoundToInt(tmp_sprite);
        }

        
        // select appropriate movement
        if(score == 10)
        {
            movement_state = 1;
        }else if(score == 20) {
            movement_state = 2;
        }


        // up down movement
        if(movement_state == 1)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = direction;

            if (gameObject.transform.localPosition[1] >= 2.5)
            {
                direction[1] = direction[1] * -1;
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition[0], 2.49f, 10);
            }

            if (gameObject.transform.localPosition[1] <= -5.5)
            {
                direction[1] = direction[1] * -1;
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition[0], -5.49f, 10);
            }
        }

        // down right left up movement
        if (movement_state == 2)
        {
            
            gameObject.GetComponent<Rigidbody2D>().velocity = direction;

            if (gameObject.transform.localPosition[1] >= 2.5)
            {
                direction[1] = direction[1] * -1;
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition[0], 2.49f, 10);
            }

            
            if (gameObject.transform.localPosition[1] <= -5.5 && gameObject.transform.localPosition[0] <= -7)
            {
                Vector3 tmp = new Vector3(0, 0, 10);
                tmp[0] = direction[1] * -1;
                tmp[1] = direction[0] * -1;
                direction = tmp;
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition[0], -5.49f, 10);
            }

            if (gameObject.transform.localPosition[0] >= -1)
            {
                direction[0] = direction[0] * -1;
                gameObject.transform.localPosition = new Vector3(-1.01f, -5.5f, 10);
            }
        }

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
                score = score - score_per_item;
            }
            collision.gameObject.SetActive(false);
            GameObject.Find("Main Camera/Canvas/Score").GetComponent<TextMeshProUGUI>().SetText(score.ToString());
        }
        Debug.Log(score);
    }

    
}
