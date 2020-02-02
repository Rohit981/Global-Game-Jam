using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Rocket;
    [SerializeField] private GameObject combatState;
    float rocketSpawnTime;
    float nextSpawn = 0f;
    public Gun gun;
    private bool lauchRockets;
    private EnemyRotation EnemyNum;
    // Start is called before the first frame update
    void Start()
    {
        lauchRockets = false;
        rocketSpawnTime = 2f * (gun.health / 50f);
        EnemyNum = FindObjectOfType<EnemyRotation>();
        combatState = GameObject.FindGameObjectWithTag("Combat");
    }

    // Update is called once per frame
    void Update()
    {
        //foreach(var spawner in enemySpawners) {
            if (combatState.GetComponent<Combat>().enemies > 0 )
            {
                lauchRockets = true;
            }
            else
                lauchRockets = false;
        //}
        if (lauchRockets)
        {
            rocketSpawnTime = 1 + (100 - (gun.health)) / 20f;

            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + rocketSpawnTime;
                Instantiate(Rocket, transform.position, transform.rotation);
            }
        }
    }
}
