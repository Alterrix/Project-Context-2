using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    public bool pressingE = false;
    public bool enableCarColl = false;
    public bool enablePickUpColl = false;
    public bool pickupCar = false;
    public BoxCollider playerCarColl;
    public BoxCollider trashPickupColl;
    public bool equippedItem = false;

    private void Start()
    {
        playerCarColl.enabled = false;
        trashPickupColl.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            pressingE = true;
        }
        else
        {
            pressingE = false;
        }
        //Debug.Log(equippedItem);

        if (enablePickUpColl)
        {
            trashPickupColl.enabled = true;
        }
        else
        {
            trashPickupColl.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Worker")
        {
            other.GetComponent<WorkersAi>().ActivateText();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "car" && Input.GetKey(KeyCode.E))
        {
            pickupCar = true;
            playerCarColl.enabled = true;
            trashPickupColl.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "car")
        {
            pickupCar = false;
            playerCarColl.enabled = false;
        }

        if (other.CompareTag("car"))
        {

        }
    }
}
