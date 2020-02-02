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
    private Shield shieldRef;
    private Engine engineRef;
    private Gun gunRef;
    private ShipController ship;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        targetVector = target.position - transform.position;
        shieldRef = FindObjectOfType<Shield>();
        ship = FindObjectOfType<ShipController>();
        engineRef = FindObjectOfType<Engine>();
        gunRef = FindObjectOfType<Gun>();
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

            if (shieldRef.health <= 0)
            {
                ship.hullIntegrity -= 1;
                engineRef.health -= 5f;
                gunRef.health -= 5f;
            }
            else if (shieldRef.health > 0)
            {
                shieldRef.health -= 2f;
                engineRef.health -= 2f;
                gunRef.health -= 2f;
            }
            Destroy(this.gameObject);
        }
    }

   
}
