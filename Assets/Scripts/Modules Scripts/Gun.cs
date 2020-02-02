using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : ShipModule
{
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
        if (health > 0)
        {
            health -= Time.deltaTime * (damageMagnifier);
        }
        progressBar.setFillAmount(health);
    }
}
