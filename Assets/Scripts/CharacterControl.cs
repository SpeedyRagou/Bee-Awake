using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    public float throwStrenght;
    public float rotationStrenght;

    bool canCatch;
    GameObject catchable;
    bool throwing;
    float power;


    // Start is called before the first frame update
    void Start()
    {
        canCatch = false;
        throwing = false;
        power = 0;
        //gameObject.transform.localScale = new Vector3(gameObject.transform.parent.localScale[1], gameObject.transform.parent.localScale[1], gameObject.transform.parent.localScale[1])
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Rotate"))
        {
            Debug.Log("Rotate arm");
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition[0] * -1, gameObject.transform.localPosition[1], 0);
            if (throwing)
            {
                gameObject.transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 1, 0));
                power = 0;
            }
            else
            {
                gameObject.transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 1, 0));
            }
            
            throwing = !throwing;
        }

        if (canCatch)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (catchable != null)
                {
                    Debug.Log("Catch item");
                    catchable.GetComponent<Rigidbody2D>().isKinematic = true;
                    catchable.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    catchable.GetComponent<Rigidbody2D>().angularVelocity = 0f;
                    catchable.transform.parent = gameObject.transform;

                    
                }
            }

            if (Input.GetButtonUp("Jump"))
            {
                if (catchable != null)
                {
                    
                    Debug.Log("Let item go");
                    catchable.GetComponent<Rigidbody2D>().isKinematic = false;
                    catchable.transform.parent = GameObject.Find("Main Camera/ObjectSpawner").transform;
                    if (throwing)
                    {
                        catchable.GetComponent<Rigidbody2D>().velocity = new Vector3(-power, power, 0);
                        catchable.GetComponent<Rigidbody2D>().angularVelocity= rotationStrenght;
                    }
                }
            }

        }


        if (throwing && canCatch)
        {
            if(power >= 14)
            {
                power = 0;
            }
            else
            {
                power = Time.deltaTime * throwStrenght + power;
                if (power > 14)
                {
                    power = 14;
                }
            }
            Debug.Log(power);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Item")
        {
            canCatch = true;
            catchable = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            canCatch = false;
            catchable = null;
        }
    }
}
