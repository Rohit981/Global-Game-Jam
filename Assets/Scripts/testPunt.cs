using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPunt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("z"))
        {
            //rigidBody.AddForce(new Vector2(-5f, 0f), new ForceMode2D());
            gameObject.GetComponent<Rigidbody2D>().transform.Translate(new Vector2(-5f * Time.deltaTime, 0f));
            gameObject.GetComponent<Rigidbody2D>().transform.Translate(new Vector2(0f, -5f * Time.deltaTime));
        }
        if (Input.GetKey("q"))
        {
            //rigidBody.AddForce(new Vector2(5f, 0f), new ForceMode2D());
            gameObject.GetComponent<Rigidbody2D>().transform.Translate(new Vector2(5f * Time.deltaTime, 0f));
            gameObject.GetComponent<Rigidbody2D>().transform.Translate(new Vector2(0f, 5f * Time.deltaTime));
        }
    }
}
