using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTest : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject collidedObj;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        if (GetComponent<ShipModuleTest>() == null) return;

        collidedObj = collision.gameObject;
        //if (Input.GetButton(collidedObj.GetComponent<PlayerMovement>().playerInteract))
        {
            GetComponent<ShipModuleTest>().isRepairing = true;
            if (GetComponent<ShipModuleTest>().health < 0)
            {
                GetComponent<ShipModuleTest>().health = 0;
            }
        }
        //else
        //    GetComponent<ShipModuleTest>().isRepairing = false;
        if (Input.GetButtonDown(collidedObj.GetComponent<PlayerMovement>().playerInteract))
        {
            GetComponent<ShipModuleTest>().neglect = 0.0001f;
            if (GetComponent<ShipModuleTest>().amountToRepair < 10)
            {
                GetComponent<ShipModuleTest>().amountToRepair += GetComponent<ShipModuleTest>().repairSpeed;
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject != collidedObj) return;
        GetComponent<ShipModuleTest>().isRepairing = false;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
