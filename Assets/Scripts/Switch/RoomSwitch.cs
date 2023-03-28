using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomSwitch : MonoBehaviour
{
    //add animation
    //add post process switch
    [SerializeField] GameObject oldCamera;
    [SerializeField] GameObject newCamera;
    [SerializeField] GameObject newSwitch;
    [SerializeField] GameObject newPoint;
    [SerializeField] GameObject player;
    public Elevator elevator;
    private bool swap = false;
    //old camera is the camera from the room you came from
    //new camera is the camera from the room you are going too
    //new switch is the box collider that needs to be disabled to prevent camera switch back to the room you came from
    //every entry for a room has 2 colliders


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
            swap = true;
            newCamera.gameObject.SetActive(true);
            oldCamera.gameObject.SetActive(false);
            newSwitch.gameObject.SetActive(false);
            //Debug.Log("triggerd");
            player.GetComponent<NavMeshAgent>().enabled = false;
            player.transform.position = newPoint.transform.position;
            player.GetComponent<NavMeshAgent>().enabled = true;
            player.GetComponent<NavMeshAgent>().ResetPath();

            Debug.Log(player.transform.position);
        }
    }

    private void Update()
    {
        if (swap && elevator.isElevator == false)
        {
            Invoke("RoomTimer", 8f);
        }
    }

    void RoomTimer()
    {
        newSwitch.gameObject.SetActive(true);
        swap = false;
        //Debug.Log("swap");
    }
}
