using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTest : ShipModuleTest
{
    // Start is called before the first frame update
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private float shieldPenalty;
    void Start()
    {

    }
    public float GetEffectiveShieldPenalty() // returns the damage pentalty for current shield health
    {
        if (health < 10)
        {
            return shieldPenalty;
        }
        else //no damage penalty
        {
            return 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateRepairBonus();
        if (isRepairing)
            Repairing();
        //if (!isRepairing)
        {
            health -= Time.deltaTime * (damageMagnifier);
        }
        progressBar.setFillAmount(health);
    }
}
