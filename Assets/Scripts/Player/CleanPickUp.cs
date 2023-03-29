using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanPickUp : MonoBehaviour
{
    public GameObject teleportPoint;
    public GameObject boxCollHallway;
    int items = 0;
    int items2 = 0;
    public bool items1clean = false;
    public bool items2clean = false;



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "room2PickUpBlack")
        {
            items++;
            other.gameObject.transform.position = teleportPoint.transform.position;
            //Debug.Log("trigggggerd");
        }
        if (other.tag == "room2PickUpGray")
        {
            items2++;
            other.gameObject.transform.position = teleportPoint.transform.position;
            //Debug.Log("trigggggerd");
        }


    }

    private void Update()
    {
        Debug.Log(items);

        if(items >= 3)
        {
            items1clean = true;
        }

        if(items2 >= 3)
        {
            items2clean = true;
        }

        if(items1clean && items2clean)
        {

        }
    }

    
}
