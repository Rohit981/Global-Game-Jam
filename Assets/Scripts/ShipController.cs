using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    public GameObject targetPoint;
    public NavMeshAgent agent;
    public float hullIntegrity = 100;
    public Shield shieldref;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private string LevelName;
    // Update is called once per frame

    private void Start()
    {
        LevelName = "LoseScene";
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

        if(hullIntegrity <= 0)
        {
            SceneManager.LoadScene(LevelName, LoadSceneMode.Single);            
        }
      
    }
}
