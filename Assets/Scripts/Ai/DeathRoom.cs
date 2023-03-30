using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathRoom : MonoBehaviour
{
    NavMeshAgent agentAIBoss;
    NavMeshAgent playerNav;
    public GameObject playerAnimator;
    public GameObject playerNavmesh;
    public GameObject Boss;
    public Transform inspectWorker;
    public Transform turnAround;
    public Transform run;
    public Transform bossEnter;
    public Transform bossChase;

    private Animator animatorAI;
    private Animator animatorPlayer;
    public bool finalShowdown = false;
    public bool walking = false;
    Vector3 targetAI;
    Vector3 targetPlayer;
    // Start is called before the first frame update
    void Start()
    {
        playerNav = playerNavmesh.GetComponent<NavMeshAgent>();
        animatorPlayer = playerAnimator.GetComponent<Animator>();
        agentAIBoss = Boss.GetComponent<NavMeshAgent>();
        animatorAI = Boss.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (finalShowdown)
        {
            Invoke("DisableWalk", 3f);
            Invoke("PlayerTurn", 12f);
            Invoke("DisableWalk", 13f);
            Invoke("PlayerRun", 14f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNav.GetComponent<PlayerMovement>().speed = 0;
            playerNav.GetComponent<PlayerMovement>().rotationSpeed = 0;
            finalShowdown = true;
            PlayerCheckBin();
        }

        
    }
    void PlayerCheckBin()
    {
        walking = true;
        targetPlayer = inspectWorker.position;
        playerNav.SetDestination(targetPlayer);
        
    }
    void DisableWalk()
    {
        walking = false;
    }

    void PlayerTurn()
    {
        walking = true;
        targetPlayer = turnAround.position;
        playerNav.SetDestination(targetPlayer);
    }

    void PlayerRun()
    {
        playerNav.speed = 9f;
        animatorPlayer.SetBool("Running", true);
        targetPlayer = run.position;
        playerNav.SetDestination(targetPlayer);
    }


}
