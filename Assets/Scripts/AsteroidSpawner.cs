using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] public GameObject Asteroid;
    [SerializeField] private float twelve;
    [SerializeField] private float Lifetime;
    [SerializeField] private bool infiniteSpawns = false;
    private float AsteroidSpawnTime;
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
        if (mag < twelve)
        {
            isSpawning = true;
        }

        if (isSpawning)
        {
            float rand = Random.Range(1f, 4f);
            if (Time.time > rand + previousSpawnTime && (MaxSpawn - nextSpawn) != 0)
            {
                if(!infiniteSpawns)
                {
                    nextSpawn++;
                }
                Instantiate(Asteroid, transform.position, Quaternion.Euler(0, 0, 0));
                Asteroid.GetComponent<AsteroidMovement>().target = player.transform;
                Asteroid.GetComponent<AsteroidMovement>().Lifetime = Lifetime;
                //spawnedEnemies.Add(Asteroid);
                previousSpawnTime = Time.time;
            }
            if (nextSpawn == 10)
            {
                isSpawning = false;
            }
        }
    }
}
