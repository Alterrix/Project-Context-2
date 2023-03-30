using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanPickUp : MonoBehaviour
{
    public GameObject teleportPoint;
    public GameObject boxCollCoffee;
    int items;
    int items2;
    private bool items1clean = false;
    private bool items2clean = false;



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
        //Debug.Log(items);
        //Debug.Log(items2);
        Debug.Log(items1clean);
        Debug.Log(items2clean);

        if (items >= 3)
        {
            //Debug.Log("works");
            items1clean = true;
            //Debug.Log(items1clean);
        }

        if(items2 >= 3)
        {
            items2clean = true;
            //Debug.Log("works too");
        }

        if (items1clean && items2clean)
        {
            boxCollCoffee.SetActive(false);
            Debug.Log("Lemme IN");
        }
    }

    
}
