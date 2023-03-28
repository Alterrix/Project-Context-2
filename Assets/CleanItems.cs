using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanItems : MonoBehaviour
{
    public PlayerMechanics playerMechanics;
    float currentTime = 0;
    float startingtime = 0;
    public bool drop = false;
    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "room2PickUp")
        {
            //Debug.Log("Im alive");
        }
       
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "room2PickUp" && playerMechanics.equippedItem == false && drop)
        {
            Debug.Log("Freedom");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingtime;
    }

    // Update is called once per frame
    void Update()
    {
       

       
        //Debug.Log(currentTime);
    }

    
}
