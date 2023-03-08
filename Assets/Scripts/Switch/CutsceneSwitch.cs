using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneSwitch : MonoBehaviour
{
    public GameObject player;
    public Collider playerCollider;
    public Camera cam;
    public Animator cameraAnimator;

    private void Start()
    {
        playerCollider = player.GetComponent<CapsuleCollider>();
        cameraAnimator = cam.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other = playerCollider)
        {
            Debug.Log("gelukt");
            // cameraAnimator.SetBool(playCutscene,true);
            
        }
        
    }
}
