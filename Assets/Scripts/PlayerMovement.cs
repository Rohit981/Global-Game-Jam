using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private bool onLadder;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        onLadder = false;
    }

   

    // Update is called once per frame
    void FixedUpdate()
    {
        if (onLadder)
        {
            rigidBody.gravityScale = 0;
            if (Input.GetKey("w"))
            {
                //rigidBody.AddForce(new Vector2(-5f, 0f), new ForceMode2D());
                rigidBody.transform.Translate(new Vector2(0f, 0.5f * Time.deltaTime));
            }
            if (Input.GetKey("s"))
            {
                //rigidBody.AddForce(new Vector2(5f, 0f), new ForceMode2D());
                rigidBody.transform.Translate(new Vector2(0f, -0.5f * Time.deltaTime));
            }
        }
        else
        {
            rigidBody.gravityScale = 0.5f;

        }
        if (Input.GetKey("a"))
        {
            //rigidBody.AddForce(new Vector2(-5f, 0f), new ForceMode2D());
            rigidBody.transform.Translate(new Vector2(-0.5f * Time.deltaTime, 0f));
        }
        if (Input.GetKey("d"))
        {
            //rigidBody.AddForce(new Vector2(5f, 0f), new ForceMode2D());
            rigidBody.transform.Translate(new Vector2(0.5f * Time.deltaTime, 0f));
        }
    }

    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            onLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            onLadder = false;
        }
    }
}
