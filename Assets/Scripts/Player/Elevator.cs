using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Elevator : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;
    public GameObject elevator1;
    public GameObject elevator2;

    public Transform elevator;
    public Transform el2Out;
    public GameObject oldcam;
    public GameObject newcam;
    public GameObject roomswitch;
    public bool walking = false;
    bool timer = false;
    bool resetTimer;
    

    //timer
   
    float currentTime;
    float startingTime = 0f;
   [SerializeField] Vector3 liftTarget;
    Animator animEl1;
    Animator animEl2;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        updateDestination();
        animEl1 = elevator1.GetComponent<Animator>();
        animEl2 = elevator2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, liftTarget) < 1)
        {
            agent.isStopped = true;
            walking = false;
            agent.ResetPath();
            //Add timer to fix issue
        }

        if(Vector3.Distance(player.transform.position, liftTarget) < 1)
        {
            agent.isStopped = true;
            walking = false;
            agent.ResetPath();
        }

        

        if (Input.GetKey(KeyCode.F))
        {
            agent.isStopped = false;
        }

        if (timer)
        {
            currentTime += 1 * Time.deltaTime;
        }

        if (currentTime >= 3f)
        {
            newcam.SetActive(true);
            oldcam.SetActive(false);
        }

        if (currentTime >= 6f)
        {
            roomswitch.SetActive(true);
            newcam.SetActive(false);
        }
    }

    void updateDestination()
    {
        liftTarget = elevator.position;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "elevatorLobby")
        {
            timer = true;
            walking = true;
            //animEl1.enabled = true;
            animEl1.SetBool("el1", true);
           // Invoke("AnimStartEl1", 3f);

            agent.SetDestination(liftTarget);
        }

        if (other.tag == "ElevatorRoom1")
        {
            walking = true;
            liftTarget = el2Out.position;
            agent.SetDestination(liftTarget);
            //animEl2.enabled = true;
            animEl2.SetBool("el2", true);
            //Invoke("AnimStartEl2", 3f);
        }


    }
    void AnimStartEl1()
    {
        animEl1.SetBool("el1", false);
    }

    void AnimStartEl2()
    {
        animEl1.SetBool("el2", false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "elevatorLobby")
        {
            animEl1.SetBool("el1", false);
            
        }

        if (other.tag == "ElevatorRoom1")
        {
            animEl2.SetBool("el2", false);
            walking = false;
            agent.isStopped = true; 
        }
    }

}
