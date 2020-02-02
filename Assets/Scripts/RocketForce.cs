using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketForce : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float forceValue;

    private EnemyRotation Enemy;
     private Transform target;
    public EnemyRotation[] targetObject;

    [SerializeField] private float RoatateValue;
    
    private float detonateTime = 0f;

    [SerializeField] private float TimeOfDetonation = 6f;


    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //target = targetObject.FindIndex(0, 1, );
        //targetObject.

        int place = Random.Range(0, targetObject.Length);
        target = targetObject[place].transform;

    }

    // Update is called once per frame
    void Update()
    {
        targetObject = FindObjectsOfType<EnemyRotation>();
        rb.velocity = transform.up * forceValue * Time.deltaTime;

        //transform.rotation = Quaternion.Euler(0, 0, -90);
        Detonate();


        if (target)
        {
            Vector3 targetVector = target.position - transform.position;

            float rotatingIndex = Vector3.Cross(targetVector, transform.up).z;

            rb.angularVelocity = -1 * rotatingIndex * RoatateValue * Time.deltaTime;


        }
        else
        {
            if(targetObject.Length <= 0)
            {
                DetonateValue();

            }
            int place = Random.Range(0, targetObject.Length);
            target = targetObject[place].transform;


        }
        //float rotateAmount = Vector3.Cross(direction, transform.up).z;


        //rb.angularVelocity =  -rotateAmount * RoatateValue;

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
  

        }
    }

    void DetonateValue()
    {
        
        if(!target   )
        {
            Debug.Log("Detonated");
            Destroy(gameObject);
        }
    }

    void Detonate()
    {
        detonateTime += Time.deltaTime;
        if (detonateTime >= TimeOfDetonation)
        {
            Destroy(gameObject);
        }
    }

}
