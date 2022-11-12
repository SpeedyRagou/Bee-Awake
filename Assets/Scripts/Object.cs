using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public int speed;
    public bool good;

    bool move;
    // Start is called before the first frame update
    void Start()
    {
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            Rigidbody2D ridgid = GetComponent<Rigidbody2D>();
            ridgid.velocity = new Vector2(-speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "conveyer")
        {
            move = true;
        }
        
        if (collision.gameObject.name == "killzone")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "conveyer")
        {
            move = false;
        }

        
    }
}
