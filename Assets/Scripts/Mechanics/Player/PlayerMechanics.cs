using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
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
    private Animator anim;
    public GameObject playerMesh;
    public GameObject player;

    private void Start()
    {
        playerCarColl.enabled = false;
        trashPickupColl.enabled = false;
        anim = playerMesh.GetComponent<Animator>();
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
            anim.SetBool("push", true);
            player.GetComponent<PlayerMovement>().speed = 1.5f;
            player.GetComponent<PlayerMovement>().rotationSpeed = 40f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "car")
        {
            pickupCar = false;
            playerCarColl.enabled = false;
            anim.SetBool("push", false);
            player.GetComponent<PlayerMovement>().speed = 4f;
            player.GetComponent<PlayerMovement>().rotationSpeed = 600f;
        }

        if (other.CompareTag("car"))
        {

        }
    }
}
