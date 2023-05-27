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
    public GameObject cameraDeathroom;
    public GameObject cameraBalcony;

    public Transform inspectWorker;
    public Transform turnAround;
    public Transform run;
    public Transform bossEnter;
    public Transform bossChase;

    private Animator animatorAI;
    private Animator animatorPlayer;

    public bool finalShowdown = false;
    public bool chase = false;
    public bool walking = false;
    public static bool balcony = false;

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
            Invoke("DisableWalk", 14.5f);
            Invoke("PlayerRun", 16f);
            Invoke("BossWalkIn", 16f);
            Invoke("CameraBalcony", 18f);
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

    void BossWalkIn()
    {
        agentAIBoss.speed = 7f;
        targetAI = bossEnter.position;
        agentAIBoss.SetDestination(targetAI);
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

   void CameraBalcony()
    {
        cameraBalcony.SetActive(true);
        cameraDeathroom.SetActive(false);
        balcony = true;
    }
}
