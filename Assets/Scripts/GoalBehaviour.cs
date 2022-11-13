using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Apple;
using UnityEngine.SceneManagement;

public class GoalBehaviour : MonoBehaviour
{

    private int score;
    private float sleepiness;
    public int max_sleepiness;
    public float sleepiness_change_rate;
    public int item_strenght;
    public int score_per_item;
    public float movement_speed;

    public float maxY = 5.5f;
    public float minY = 2.5f;
    public float maxX = -1.0f;
    public float minX = -7.0f;

    private Sprite[] sleepState;
    private int sleep_sprite;
    private int movement_state;
    private Vector2 direction;
    public AudioClip[] audios;
    private Vector3 Mydestination = Vector3.zero;

    private List<Vector3> RandomTargetPositions = new List<Vector3>();

    private bool turned = true;
    private bool other_position = true;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        sleepiness = max_sleepiness;
        sleepState = Resources.LoadAll<Sprite>("woke");
        sleep_sprite = sleepState.Length - 1;
        gameObject.GetComponent<SpriteRenderer>().sprite = sleepState[(sleepState.Length - 1) - sleep_sprite];
        movement_state = 0;
        direction = new Vector2(0, movement_speed);
        Mydestination = transform.localPosition;

        for (float i = minY; i < maxY; i++)
        {
            for (float j = minX; j < maxX; j++)
            {
                Vector3 newVector = new Vector3(j, i, 0f);
                RandomTargetPositions.Add(new Vector3(j, i, 0f));
                // Debug.Log(newVector);
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sleepiness = sleepiness - sleepiness_change_rate * Time.deltaTime;

        float tmp_sprite = sleepiness / (max_sleepiness / (sleepState.Length - 1));




        // ending check
        if (sleepiness <= 0)
        {
            //Ende
            // Debug.Log("End");
            int[] highscores = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            try {
                highscores = JsonUtility.FromJson<int[]>(File.ReadAllText("./data.txt"));
            }
            catch
            {
                FileStream stream = File.Create("./data.txt");
                stream.Close();
            }

            int index = -1;
            for(int i = 0; i < highscores.Length; i++)
            {
                
                if (score > highscores[i])
                {
                    index = i;
                    break;
                }
                
            }
            Debug.Log(index);
            if (index >= 0)
            {
                Debug.Log("I am here " + score.ToString());
                int tmp = highscores[index];
                highscores[index] = score;
                
                for (int i = index + 1; i < highscores.Length; i++)
                {
                    int tmp2 = highscores[i];
                    highscores[i] = tmp;
                    tmp = tmp2;
                }
                
            }
            File.WriteAllText("./data.txt", JsonUtility.ToJson(highscores));

            SceneManager.LoadScene("Leaderbord");
        }

        // select sprite for state
        if (Mathf.RoundToInt(tmp_sprite) != sleep_sprite)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sleepState[Mathf.RoundToInt((sleepState.Length - 1) - tmp_sprite)];
            sleep_sprite = Mathf.RoundToInt(tmp_sprite);
        }


        // select appropriate movement
        if (score == 10)
        {
            movement_state = 1;
        }
        else if (score == 30)
        {
            movement_state = 2;
        }else if(score == 100)
        {
            movement_state = 3;
        }


        // up down movement
        if (movement_state == 1)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = direction;

            if (gameObject.transform.localPosition[1] >= 2.5)
            {
                direction[1] = movement_speed * -1;
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition[0], 2.5f, 10);
            }

            if (gameObject.transform.localPosition[1] <= -5.5)
            {
                direction[1] = movement_speed;
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition[0], -5.5f, 10);

            }
            Mydestination = transform.localPosition;
        }

        // down right left up movement
        if (movement_state == 2)
        {

            gameObject.GetComponent<Rigidbody2D>().velocity = direction;

            if (gameObject.transform.localPosition[1] >= 2.5)
            {
                direction[1] = movement_speed * -1;
                gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition[0], 2.5f, 10);
                turned = true;
            }


            if (gameObject.transform.localPosition[1] <= -5.5 && gameObject.transform.localPosition[0] <= -7)
            {
                if (turned)
                {
                   // // Debug.Log("hier");
                    Vector3 tmp = new Vector3(0, 0, 10);
                    tmp[0] = direction[1] * -1;
                    tmp[1] = direction[0] * -1;
                    direction = tmp;
                    gameObject.transform.localPosition = new Vector3(-7f, -5.5f, 10f);
                    turned = false;
                }
            }

            if (gameObject.transform.localPosition[0] >= -1)
            {
                direction[0] = movement_speed * -1;
                gameObject.transform.localPosition = new Vector3(-1.0f, -5.5f, 10f);
                turned = true;
            }
            Mydestination = transform.localPosition;
        }

        //    bool targetReached = true;
        //    Vector3 destination = transform.position;
        //    //Random Movement
        if (movement_state == 3)
        {
            if (!other_position && Mydestination != transform.localPosition)
            {
                other_position = true;
            }
            if ((Mydestination == transform.localPosition && other_position) || (transform.localPosition.x < minX || transform.localPosition.x > maxX || transform.localPosition.y < minY || transform.position.y > maxY))
            {
                other_position = false;
                Vector3 new_destination = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 10);
                Debug.Log("Old Position: " + Mydestination.ToString());
                Debug.Log("New destination: " + new_destination.ToString());
                direction = new_destination - transform.localPosition;
                Mydestination = new_destination;
                Debug.Log("" + direction.ToString());

            }
            gameObject.GetComponent<Rigidbody2D>().velocity = direction;
        }

        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
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

            AudioSource audio = GameObject.Find("Main Camera").GetComponents<AudioSource>()[1];

            audio.clip = audios[Random.Range(0, audios.Length)];
            audio.Play();
        }
        // Debug.Log(score);
    }


}
