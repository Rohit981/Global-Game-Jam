using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField] private Transform target;
    Rigidbody2D rb;
    [SerializeField] private GameObject combatState;  
    [SerializeField] private GameObject explosion;
    public Vector3 targetVector;
    public float mag;
    bool closeEnough = false;
    internal float MaxEnemies = 10;
    private Shield shieldRef;
    private Engine engineRef;
    private Gun gunRef;
    private ShipController ship;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();       
        combatState = GameObject.FindGameObjectWithTag("Combat");
        combatState.GetComponent<Combat>().enemies++;
        shieldRef = FindObjectOfType<Shield>();
        ship = FindObjectOfType<ShipController>();
        engineRef = FindObjectOfType<Engine>();
        gunRef = FindObjectOfType<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        targetVector = target.position - transform.position;

        if (targetVector.magnitude >= 12){
            closeEnough = false;
        }
        if (targetVector.magnitude >= 12 && !closeEnough)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, 5 * Time.deltaTime);
        }
        
        else
        {
            closeEnough = true;
            transform.RotateAround(target.position, Vector3.forward, 40 * Time.deltaTime);
        }

       
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Collided with player");

            if(shieldRef.health <= 0)
            {
                ship.hullIntegrity -= 5;
                engineRef.health -= 5f;
                gunRef.health -= 5f;
            }
            else if(shieldRef.health > 0)
            {
                shieldRef.health -= 5;
                engineRef.health -= 2f;
                gunRef.health -= 2f;
            }
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    private void OnDestroy()
    {
        //MaxEnemies -= 1f;
        combatState.GetComponent<Combat>().enemies--;

    }


}
