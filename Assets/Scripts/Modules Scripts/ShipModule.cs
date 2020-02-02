using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipModule : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float health = 15;
    public bool isRepairing = false;
    internal float damageMagnifier = 1;
    [Range(0.0001f, 2f)] public float repairSpeed = 0.0001f;
    [Range(0.0001f, 2f)] public float secondsTillRepairStop = 0.0001f;
    public float neglect = 0.0001f;
    public float amountToRepair = 0f;
    public Image helpGui;
    void Start()
    {
        helpGui.enabled = false;
    }
    protected void UpdateRepairBonus()
    {
        neglect += Time.deltaTime;
        if (isRepairing)
        {
            //amountToRepair -= secondsTillRepairStop;
            if (amountToRepair - ((neglect / secondsTillRepairStop) * amountToRepair) < 0)
            {
                amountToRepair = 0f;
            }
        }
        else
        {
            amountToRepair = 0f;
            Debug.Log("You stopped repairing.");
        }
    }
    // Update is called once per frame
    void Update()
    {
    }


    protected void Repairing()
    {
        if (isRepairing && health < 99)
        {

            health += Time.deltaTime * (amountToRepair - ((neglect / secondsTillRepairStop) * amountToRepair));
        }

    }
}
