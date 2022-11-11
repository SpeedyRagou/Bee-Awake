using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    bool canCatch;
    GameObject catchable;

    // Start is called before the first frame update
    void Start()
    {
        canCatch = false;
        gameObject.transform.localScale = new Vector3(gameObject.transform.parent.localScale[1], gameObject.transform.parent.localScale[1], gameObject.transform.parent.localScale[1])
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Rotate"))
        {
            Debug.Log("Rotate arm");
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition[0] * -1, gameObject.transform.localPosition[1], 0);
            gameObject.transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));
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
                    catchable.transform.localScale= new Vector3(1, 1/gameObject.transform.localScale[1], 1);
                    catchable.transform.sca

                    
                }
            }

            if (Input.GetButtonUp("Jump"))
            {
                if (catchable != null)
                {
                    Debug.Log("Let item go");
                    catchable.transform.parent = GameObject.Find("Main Camera/ObjectSpawner").transform;
                    catchable.transform.localScale = Vector3.one;
                    catchable.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }

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
