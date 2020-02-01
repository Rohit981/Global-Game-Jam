using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField] private Transform target;
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float ChangeState;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        speed = 0.01f;
        ChangeState = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, speed, 0);

        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed);

        ChangeState += Time.deltaTime;

        if(ChangeState >= 5f)
        {
            speed = 0f;
            transform.RotateAround(target.position, -Vector3.forward, Random.Range(20,30) * Time.deltaTime);


        }
      
    }
}
