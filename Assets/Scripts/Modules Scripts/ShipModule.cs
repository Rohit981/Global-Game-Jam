using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModule : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float health = 15;
    public bool isRepairing = false;
    internal float damageMagnifier  = 1;
    [Range (1f, 10f)]public float repairSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       
    }


    protected void Repairing()
    {
        if (isRepairing) {

            health += Time.deltaTime * repairSpeed;
        }

    }

}
