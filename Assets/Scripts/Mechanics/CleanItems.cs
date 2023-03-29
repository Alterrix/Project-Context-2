using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanItems : MonoBehaviour
{
    public PlayerMechanics playerMechanics;
    float currentTime = 0;
    float startingtime = 0;
    public bool drop = false;
    

    void start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "room2PickUpBlack")
        {
            drop = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "room2PickUpBlack")
        {
            //Debug.Log("Im alive");
            drop = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //&& drop
        if (other.tag == "room2PickUpBlack" && playerMechanics.equippedItem == false &&drop)
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
