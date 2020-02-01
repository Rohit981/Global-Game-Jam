using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : ShipModule
{
    [SerializeField] private ShipController shipCont;
    [SerializeField] private Shield shield;
    [SerializeField] private ProgressBar progressBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateRepairBonus();
        if (isRepairing)
            Repairing();
        //if (!isRepairing)
        {
            health -= Time.deltaTime * (shield.damageMagnifier * shield.GetEffectiveShieldPenalty());
        }
        if (health <= 10)
        {
            shipCont.agent.isStopped = true;
        }
        else
            shipCont.agent.isStopped = false;

        progressBar.setFillAmount(health);
    }
}
