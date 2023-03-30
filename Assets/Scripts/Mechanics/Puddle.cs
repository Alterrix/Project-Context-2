using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Puddle : MonoBehaviour
{
    public Broom broom;
    public Animator animator;
    public PlayerMechanics pl;
    public GameObject puddle;
    public GameObject puddle2;
    public GameObject puddle3;
    public GameObject RudeClean;

    public bool room1 = false;
    public bool puddleClean1 = false;
    public bool puddleClean2 = false;
    public bool puddleClean3 = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    private void Update()
    {
        if (puddle.transform.localScale.x <0.1 && puddle.transform.localScale.y < 0.1f)
        {
            puddleClean1 = true;
            puddle.GetComponent<MeshRenderer>().enabled = false;
        }

        if (puddle2.transform.localScale.x < 0.1 && puddle2.transform.localScale.y < 0.1f)
        {
            puddleClean2 = true;
            puddle2.GetComponent<MeshRenderer>().enabled = false;

        }

        if (puddle3.transform.localScale.x < 0.1 && puddle3.transform.localScale.y < 0.1f)
        {
            puddleClean3 = true;
            puddle3.GetComponent<MeshRenderer>().enabled = false;
        }

        if (puddleClean1 && puddleClean2 && puddleClean3)
        {
            room1 = true;
            RudeClean.SetActive(false);
            //Debug.Log("Victory");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && pl.pressingE && broom.PickepUpBroom)
        {
            //Debug.Log("Cleaning");
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
