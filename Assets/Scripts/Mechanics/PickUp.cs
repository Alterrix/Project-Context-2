using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Rigidbody rbPickup;
    public BoxCollider coll;
    public Transform player, itemContainer, point;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;
    float currentTime = 0;
    float startingtime = 0;

    public bool equipped;
    public static bool slotFull;
    bool cleancar;
    public PlayerMechanics playerMechanics;

    private void Start()
    {
        //Setup
        if (!equipped)
        {
            //Disable optional script
            rbPickup.isKinematic = false;
            coll.isTrigger = false;
        }

        if (equipped)
        {
            //Disable optional script
            rbPickup.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        if(playerMechanics.equippedItem == false)
        {
            currentTime += Time.deltaTime;
        }
        //Debug.Log(currentTime);
        

        if (currentTime >= 5 && !equipped)
        {
        }

        //Debug.Log(currentTime);

        if (currentTime >= 6)
        {
            currentTime = 0f;
        }
        //check if player is in range and presses E
        Vector3 distanceToPlayer = player.position - transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUpItem();
        }
        //Drop if equipped and Q is pressed
        if(equipped && Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }

        if (equipped)
        {
            rbPickup.velocity = new Vector3(0, 0, 0);
            //playeprb.velocity = new Vector3(0, 0, 0);
        }
        //PickUp worker car
        if (playerMechanics.pickupCar && !equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUpItem();
        }
    }

    private void PickUpItem()
    {
        currentTime = 0;
        playerMechanics.equippedItem = true;
        equipped = true;
        slotFull = true;
        playerMechanics.enablePickUpColl = true;

        //Make rigidbody kinematic and a boxcollider trigger
        rbPickup.isKinematic = true;
        coll.isTrigger = true;

        //Make item child and move to correct place
        transform.SetParent(itemContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        
        //Enable optional script
    }

    private void DropItem()
    {
        currentTime = 0;
        playerMechanics.equippedItem = false;
        equipped = false;
        slotFull = false;
        playerMechanics.enablePickUpColl = false;
        playerMechanics.enableCarColl = false;

        //set parent to null
        transform.SetParent(null);

        //Make rigidbody not kinematic and boxcoll normal
        rbPickup.isKinematic = false;
        coll.isTrigger = false;

        //item force
        rbPickup.velocity = player.GetComponent<Rigidbody>().velocity;

        //Addforce
        rbPickup.AddForce(point.forward * dropForwardForce, ForceMode.Impulse);
        rbPickup.AddForce(point.up * dropUpwardForce, ForceMode.Impulse);
        //random rotation
        float random = Random.Range(-1f, 1f);
        rbPickup.AddTorque(new Vector3(random, random, random) * 10);


        //disable optional script
        playerMechanics.enableCarColl = false;
        playerMechanics.enablePickUpColl = false;
    }


    /* private void OnTriggerStay(Collider other)
     {
         if(other.tag == "Player")
         {
             cleancar = true;
             if (!equipped && cleancar &&Input.GetKey(KeyCode.E))
             {
                 PickUpItem();
                 //enabble player collider cleancar
                 playerMechanics.enablePickUpColl = true;
             }
         }
     }
    */

    /* private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            cleancar = false;
            //disable player cleancar
        }
    }
    */
}
