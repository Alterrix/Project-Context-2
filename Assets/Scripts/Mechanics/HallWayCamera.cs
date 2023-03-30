using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallWayCamera : MonoBehaviour
{
    public GameObject CamRightWall;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = CamRightWall.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.SetBool("Left", true);
            animator.SetBool("right", false);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.SetBool("Left", false);
            animator.SetBool("right", true);
        }
    }
}
