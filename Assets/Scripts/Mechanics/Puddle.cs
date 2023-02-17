using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    public Animator animator;
    public PlayerMechanics pl;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && pl.cleaning )
        {
            Debug.Log("ghello");
            animator.enabled = true;
            //Add animation puddle cleaning
        }
        else
        {
            animator.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.enabled = false;
        }
    }
}
