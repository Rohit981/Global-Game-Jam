using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    private GameObject collidedObj;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        if (GetComponent<ShipModule>() == null) return;

        collidedObj = collision.gameObject;

        GetComponent<ShipModule>().isRepairing = true;
       
        if (GetComponent<ShipModule>().health < 0)
        {
            GetComponent<ShipModule>().health = 0;
        }
        if (GetComponent<ShipModule>().neglect > 0.1f)
        GetComponent<ShipModule>().helpGui.enabled = true;

        if (Input.GetButtonDown(collidedObj.GetComponent<PlayerMovement>().playerInteract))
        {
            GetComponent<ShipModule>().helpGui.enabled = false;
            GetComponent<ShipModule>().neglect = 0.0001f;
            if (GetComponent<ShipModule>().amountToRepair < 50 )
            {
                GetComponent<ShipModule>().amountToRepair += GetComponent<ShipModule>().repairSpeed;
            }
        }
       

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject != collidedObj) return;
        GetComponent<ShipModule>().isRepairing = false;
        GetComponent<ShipModule>().helpGui.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
