using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public GameObject targetPoint;
    public NavMeshAgent agent;
    public float hullIntegrity = 100;
    public Shield shieldref;
    [SerializeField] private ProgressBar progressBar;
    // Update is called once per frame

    private void Start()
    {
            
    }

    void Update() {
           
        agent.SetDestination(targetPoint.transform.position);
        transform.rotation = Quaternion.Euler(0,90,0);
        LowerHealth();
        progressBar.setFillAmount(hullIntegrity);
    }

    void LowerHealth()
    {
        if(shieldref.health < 50 && shieldref.health > 25)
        {
            hullIntegrity -= Time.deltaTime / 4;
        }

      
    }
}
