using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] public GameObject Enemy;
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

        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + EnemySpawnTime;
            Instantiate(Enemy, transform.position, Quaternion.Euler(0,0, -180));
           
        }
    }
}
