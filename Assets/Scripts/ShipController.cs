using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipController : MonoBehaviour
{
    public GameObject targetPoint;
    public NavMeshAgent agent;
    // Update is called once per frame

    void Update() {
           
        agent.SetDestination(targetPoint.transform.position);
        transform.rotation = Quaternion.Euler(0,90,0);
    }
}
