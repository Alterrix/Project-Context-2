using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, itemContainer, point;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        //Setup
        if (!equipped)
        {
            //Disable optional script
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if (equipped)
        {
            //Disable optional script
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
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
    }
    private void PickUpItem()
    {
        equipped = true;
        slotFull = true;

        //Make rigidbody kinematic and a boxcollider trigger
        rb.isKinematic = true;
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
        equipped = false;
        slotFull = false;

        //set parent to null
        transform.SetParent(null);

        //Make rigidbody not kinematic and boxcoll normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //item force
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //Addforce
        rb.AddForce(point.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(point.up * dropUpwardForce, ForceMode.Impulse);
        //random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);


        //disable optional script
    }
}
