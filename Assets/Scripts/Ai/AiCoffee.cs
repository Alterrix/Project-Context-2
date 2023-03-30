using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiCoffee : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject workerCoffeeRoom;
    private Animator animator;
    private Animator animatorPuddle;

    public Transform CoffeeRoomEnter;
    public Transform coffeeMachine;
    public Transform CoffeeRoomExit;
    Vector3 roomEnter;
    Vector3 roomexit;
    public GameObject puddle;
    public triggerCoffee triggerCoffee;
    public GameObject collToHallWay;

    public bool worker;
    // Start is called before the first frame update
    void Start()
    {
        animator = workerCoffeeRoom.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        roomEnter = CoffeeRoomEnter.position;
        //roomEnter = CoffeeRoomEnter.position;
        animatorPuddle = puddle.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerCoffee.coffee && worker)
        {
            Invoke("Walk", 14f);
            Invoke("Wave", 15f);
            Invoke("WalkCoffee", 18f);
            Invoke("Clean", 20f);
            Invoke("WalkAway", 22f);
        }
    }

    void Walk()
    {
        roomEnter = CoffeeRoomEnter.position;
        agent.SetDestination(roomEnter);
    }

    void Wave()
    {
        animator.SetBool("wave", true);
    }

    void WalkCoffee()
    {
        animator.SetBool("wave", false);
        roomEnter = coffeeMachine.position;
        agent.SetDestination(roomEnter);
        
    }

    void Clean()
    {
        animator.SetBool("clean", true);
        animatorPuddle.enabled = true;
    }

    void WalkAway()
    {
        roomEnter = CoffeeRoomExit.position;
        agent.SetDestination(roomEnter);
        animator.SetBool("clean", false);
        worker = false;
        collToHallWay.SetActive(false);
    }
}
