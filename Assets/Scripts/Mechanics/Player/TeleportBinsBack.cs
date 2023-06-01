using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBinsBack : MonoBehaviour
{
    public GameObject teleportPointBack;
    public PlayerMechanics playerMechanics;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("room2PickUpBlack") && playerMechanics.equippedItem == false || other.gameObject.CompareTag("room2PickUpGray") && playerMechanics.equippedItem == false)
        {
            other.gameObject.transform.position = teleportPointBack.transform.position;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("room2PickUpBlack") && playerMechanics.equippedItem == false || (other.gameObject.CompareTag("room2PickUpGray") && playerMechanics.equippedItem == false))
        {
            other.gameObject.transform.position = teleportPointBack.transform.position;
        }
    }
}

