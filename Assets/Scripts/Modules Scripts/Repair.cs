using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject collidedObj;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        if (GetComponent<ShipModule>() == null) return;

        collidedObj = collision.gameObject;
        if (Input.GetButtonDown(collidedObj.GetComponent<PlayerMovement>().playerInteract))
        {
            GetComponent<ShipModule>().isRepairing = true;
        }
        else
            GetComponent<ShipModule>().isRepairing = false;

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject != collidedObj) return;
        GetComponent<ShipModule>().isRepairing = false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
