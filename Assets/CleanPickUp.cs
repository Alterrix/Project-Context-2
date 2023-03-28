using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanPickUp : MonoBehaviour
{
    public GameObject teleportPoint;

  

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "room2PickUp")
        {
            other.gameObject.transform.position = teleportPoint.transform.position;
            Debug.Log("trigggggerd");
        }
    }
}
