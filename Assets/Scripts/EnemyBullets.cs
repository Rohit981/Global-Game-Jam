using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
   
    [SerializeField] private GameObject EnemyLaser;
    private float EnemySpawnTime;
    private float nextSpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawnTime = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + EnemySpawnTime;
            Instantiate(EnemyLaser, transform.position, transform.rotation);
        }
    }
}
