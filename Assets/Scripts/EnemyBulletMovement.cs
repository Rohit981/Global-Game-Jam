using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBulletMovement : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector3 targetVector;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        targetVector = target.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = targetVector * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            print("Collided with player");
            Destroy(this.gameObject);
        }
    }

   
}
