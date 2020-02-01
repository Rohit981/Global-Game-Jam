using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Rocket;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if( Input.GetKeyDown(KeyCode.Mouse0))
       {
            Instantiate(Rocket, transform.position, transform.rotation);
       }
    }
}
