using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] public GameObject Enemy;
    [SerializeField] private float twelve;
    private float EnemySpawnTime;
    private float nextSpawn = 0f;
    private float MaxSpawn = 0f;
    private float rand;
    float previousSpawnTime;
    public bool isSpawning;
    public float mag;
    [SerializeField] GameObject player;
    public List<GameObject> spawnedEnemies;
    // Start is called before the first frame update
    void Start()
    {
        MaxSpawn = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVector = player.transform.position - gameObject.transform.position;
        mag = targetVector.magnitude;
        if (mag < twelve) {
            isSpawning = true;
        }

        if (isSpawning)
        {
            float rand = Random.Range(1f, 4f);
            if (Time.time > rand + previousSpawnTime && (MaxSpawn - nextSpawn) != 0)
            {
                nextSpawn++;
                Instantiate(Enemy, transform.position, Quaternion.Euler(0, 0, 0));
                //spawnedEnemies.Add(Enemy);
                previousSpawnTime = Time.time;
            }
            if (nextSpawn == 10) {
                isSpawning = false;
            }
        }
    }
}
