using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BathroomAi : MonoBehaviour
{
    NavMeshAgent agentAIBoss;
    NavMeshAgent playerNav;
    public GameObject cam;
    public GameObject collBath;
    public GameObject playerAnimator;
    public GameObject playerNavmesh;
    public GameObject Boss;
    public GameObject HallWayWorkers;
    public GameObject HallWayBlood;
    public GameObject collToDeathRoom;
    private Animator animatorAI;
    private Animator animatorPlayer;
    public Transform PlayerMirror;
    public Transform BossYell;
    public Transform WalkOut;
    public bool walking = false;
    private bool start = false;
    bool hallwaycLean = false;
    public bool CoffeeBlood = false;
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
        if(hallwaycLean)
        {
            HallWayWorkers.SetActive(false);
        }
        if (CoffeeBlood)
        {
            collToDeathRoom.SetActive(false);
            HallWayBlood.SetActive(true);
        }

        if (start)
        {
            Invoke("StartRoom", 1f);
            Invoke("DisableAnim", 4.2f);
            Invoke("BossWalk", 14f);
            Invoke("BossYelling", 19.5f);
            Invoke("BossWalkOut", 25f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CoffeeBlood = true;
            hallwaycLean = true;
            playerNav.ResetPath();
            start = true;
            Debug.Log("AppelSap");
        }
    }

    void StartRoom()
    {
        Debug.Log("Bathroom");
        walking = true;
        targetAI = PlayerMirror.position;
        playerNav.GetComponent<PlayerMovement>().speed = 0;
        playerNav.GetComponent<PlayerMovement>().rotationSpeed = 0;

        playerNav.SetDestination(targetAI);
        start = false;
        collBath.GetComponent<BoxCollider>().enabled = false;
        
    }

    void BossYelling()
    {
        animatorAI.SetBool("Yell", true);
    }

    void BossWalk()
    {
        targetAI = BossYell.position;
        agentAIBoss.SetDestination(targetAI);
        playerNav.GetComponent<PlayerMovement>().speed = 4;
        playerNav.GetComponent<PlayerMovement>().rotationSpeed = 400;
    }

    void DisableAnim()
    {
        playerNav.ResetPath();
        walking = false;
    }

    void BossWalkOut()
    {
        animatorAI.SetBool("Yell", false);

        cam.GetComponent<Animator>().enabled = false;
        targetAI = WalkOut.position;
        agentAIBoss.SetDestination(targetAI);
    }
}
