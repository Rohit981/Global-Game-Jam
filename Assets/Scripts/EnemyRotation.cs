using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    private GameObject combatState;
    [SerializeField] private Transform target;
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float ChangeState;
    public Vector3 targetVector;
    public float mag;
    bool closeEnough = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        speed = 0.01f;
        ChangeState = 0f;
        combatState = GameObject.FindGameObjectWithTag("Combat");
        combatState.GetComponent<Combat>().enemies++;
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
            combatState.GetComponent<Combat>().enemies--;
            Destroy(this.gameObject);
        }
    }
}
