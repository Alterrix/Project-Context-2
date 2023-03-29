using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Room1AiWorker : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject workerRoom1;
    private Animator animator;
    public Transform room2Enter;
    public Puddle puddle;
    public GameObject boxCollToRoom2;
    Vector3 roomEnter;

    // Start is called before the first frame update
    void Start()
    {
        animator = workerRoom1.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        roomEnter = room2Enter.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(puddle.room1 == true)
        {
            boxCollToRoom2.SetActive(false);
            animator.SetBool("clean", true);
            agent.SetDestination(roomEnter);
        }
    }
}
