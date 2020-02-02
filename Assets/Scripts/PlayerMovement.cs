using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private bool onLadder;
    public string playerHor, playrVert, playerInteract;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        onLadder = false;
        anim = GetComponent<Animator>();
    }

   

    // Update is called once per frame
    void FixedUpdate()
    {
        if (onLadder)
        {

            /*
            if ((Input.GetAxis(playerHor)) > 0.01f {
                  rigidBody.transform.Translate(new Vector2(3.5f * Time.deltaTime, 0f));
            }
            else if ((Input.GetAxis(playerHor)) < -0.01f {
                  rigidBody.transform.Translate(new Vector2(-3.5f * Time.deltaTime, 0f));
            }

             if ((Input.GetAxis(playrVert)) > 0.01f {
                   rigidBody.transform.Translate(new Vector2(0f, 3.5f * Time.deltaTime));
            }
            else if ((Input.GetAxis(playrVert)) < -0.01f {
                   rigidBody.transform.Translate(new Vector2(0f, -3.5f * Time.deltaTime));
            }


              */

            rigidBody.gravityScale = 0;
            //if (Input.GetKey("w"))
            //{
            //    //rigidBody.AddForce(new Vector2(-5f, 0f), new ForceMode2D());
            //    rigidBody.transform.Translate(new Vector2(0f, 3.5f * Time.deltaTime));
            //}
            //if (Input.GetKey("s"))
            //{
            //    //rigidBody.AddForce(new Vector2(5f, 0f), new ForceMode2D());
            //    rigidBody.transform.Translate(new Vector2(0f, -3.5f * Time.deltaTime));
            //}
            if ((Input.GetAxis(playrVert)) > 0.01f) {
                rigidBody.transform.Translate(new Vector2(0f, 3.5f * Time.deltaTime));
               

            }

            else if ((Input.GetAxis(playrVert)) < -0.01f) {
                rigidBody.transform.Translate(new Vector2(0f, -3.5f * Time.deltaTime));
            }

           

        }
        else
        {
            rigidBody.gravityScale = 3.8f;

        }
        //if (Input.GetKey("a"))
        //{
        //    //rigidBody.AddForce(new Vector2(-5f, 0f), new ForceMode2D());
        //    rigidBody.transform.Translate(new Vector2(-3.5f * Time.deltaTime, 0f));
        //}
        //if (Input.GetKey("d"))
        //{
        //    //rigidBody.AddForce(new Vector2(5f, 0f), new ForceMode2D());
        //    rigidBody.transform.Translate(new Vector2(3.5f * Time.deltaTime, 0f));
        //}

        if ((Input.GetAxis(playerHor)) > 0.01f) {
            rigidBody.transform.Translate(new Vector2(3.5f * Time.deltaTime, 0f));
            anim.SetBool("Running", true);
        }
        else if ((Input.GetAxis(playerHor)) < -0.01f) {
            rigidBody.transform.Translate(new Vector2(-3.5f * Time.deltaTime, 0f));

        }
        else
        {
            anim.SetBool("Running", false);
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
