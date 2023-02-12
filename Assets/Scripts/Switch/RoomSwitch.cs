using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitch : MonoBehaviour
{
    //add animation
    //add post process switch
    [SerializeField] GameObject oldCamera;
    [SerializeField] GameObject newCamera;
    [SerializeField] GameObject newSwitch;
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
            Debug.Log("triggerd");
        }
    }

    private void Update()
    {
        if (swap)
        {
            Invoke("RoomTimer", 3f);
        }
    }

    void RoomTimer()
    {
        newSwitch.gameObject.SetActive(true);
        swap = false;
        Debug.Log("swap");
    }
}
