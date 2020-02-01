using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketForce : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float forceValue;
     private Transform target;
    [SerializeField] private float RoatateValue;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * forceValue * Time.deltaTime;

        Vector3 targetVector = target.position - transform.position;

        float rotatingIndex = Vector3.Cross(targetVector, transform.up).z;

        rb.angularVelocity = -1 * rotatingIndex * RoatateValue * Time.deltaTime;

        //float rotateAmount = Vector3.Cross(direction, transform.up).z;

        //rb.angularVelocity =  -rotateAmount * RoatateValue;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }


}
