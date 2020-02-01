using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] public GameObject Enemy;
    private float EnemySpawnTime;
    private float nextSpawn = 0f;
    private float MaxSpawn = 0f;
    private float rand;
    float previousSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        MaxSpawn = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
        float rand = Random.Range(1f, 4f);
        if(Time.time > rand + previousSpawnTime && (MaxSpawn - nextSpawn) != 0)
        {
            nextSpawn++;
            Instantiate(Enemy, transform.position, Quaternion.Euler(0,0, 0));
            previousSpawnTime = Time.time;
        }
    }
}
