using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : ShipModule
{
    // Start is called before the first frame update
    [SerializeField] private ProgressBar progressBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Repairing();
        if (!isRepairing && health > 0)
        {
            health -= Time.deltaTime * damageMagnifier;
        }
        if (health < 10) {
            damageMagnifier = 5;
        }
        progressBar.setFillAmount(health);
    }
}
