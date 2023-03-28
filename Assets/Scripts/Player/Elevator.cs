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

    public Transform elevator1In;
    public Transform el1Out;
    public Transform elevator2In;
    public Transform el2Out;
    public GameObject camLobby;
    public GameObject camEl1;
    public GameObject camEl2;
    public GameObject camRoom1;
    public GameObject roomswitchEl1;
    public GameObject roomswitchEl2;
    public bool walking = false;
    bool timer = false;
    bool resetTimer;
    public bool elevatorLobby = false;
    public bool elevatorRoom1WalkOut = false;
    public bool isElevator = false;



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

        if (Vector3.Distance(player.transform.position, liftTarget) < 1)
        {
            agent.isStopped = true;
            walking = false;
            agent.ResetPath();
        }

        //Debug.Log(currentTime);

        if (Input.GetKey(KeyCode.F))
        {
            agent.isStopped = false;
        }

        if (timer)
        {
            currentTime += 1 * Time.deltaTime;
        }
        if (resetTimer)
        {
            currentTime = 0f;
            resetTimer = false;
        }
        if (currentTime >= 3f)
        {
            
        }

        if (currentTime >= 6f)
        {
            roomswitchEl1.SetActive(true);
            roomswitchEl2.SetActive(true);
            //camEl1.SetActive(false);
            resetTimer = true;
            isElevator = false;
        }

        if (elevatorRoom1WalkOut)
        {
            Invoke("El2WalkOut", 1f);
            Invoke("Elevator2WalkOut", 3f);
            Debug.Log("ghjello");
        }
    }

    void updateDestination()
    {
        liftTarget = elevator1In.position;
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "elevatorLobby")
        {

            Elevator1();

        }

        if (other.tag == "ElevatorRoom1")
        {
            El2WalkIn();
            roomswitchEl2.SetActive(false);
            
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
            elevatorRoom1WalkOut = true;
        }

        if (other.tag == "ElevatorRoom1")
        {
            
            //animEl1.SetBool("el2", false);
        }
    }

    void Elevator1()
    {
        roomswitchEl2.SetActive(false);
        camEl1.SetActive(true);
        camLobby.SetActive(false);
        timer = true;
        walking = true;
        //animEl1.enabled = true;
        animEl1.SetBool("el1", true);
        // Invoke("AnimStartEl1", 3f);
        agent.SetDestination(liftTarget);
        isElevator = true;
    }

    void elevatorRoom1Enter()
    {
        timer = true;
        walking = true;
        //animEl1.enabled = true;
        animEl1.SetBool("el2", true);
        // Invoke("AnimStartEl1", 3f);
        agent.SetDestination(liftTarget);
        isElevator = true;
    }

    void Elevator2WalkOut()
    {
        animEl2.SetBool("el2", false);
        walking = false;
        agent.isStopped = true;
    }

    void El2WalkOut()
    {
        walking = true;
        liftTarget = el2Out.position;
        agent.SetDestination(liftTarget);
        //animEl2.enabled = true;
        animEl2.SetBool("el2", true);
        //Invoke("AnimStartEl2", 3f);
        //Debug.Log("triggerd");
        elevatorRoom1WalkOut = false;
    }

    void El2WalkIn()
    {
        agent.isStopped = false;
        resetTimer = true;
        timer = true;
        //agent.isStopped = false;
        walking = true;
        liftTarget = elevator2In.position;
        agent.SetDestination(liftTarget);
        animEl2.SetBool("el2", true);
        isElevator = true;

    }

}
