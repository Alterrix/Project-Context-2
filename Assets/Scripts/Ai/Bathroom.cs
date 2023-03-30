using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Bathroom : MonoBehaviour
{
    NavMeshAgent agentAI;
    NavMeshAgent playerNav;
    public GameObject playerNavmesh;
    public GameObject playerAnimator;
    public GameObject workerHallwayRoom;
    public GameObject parentNavmeshAI;
    private Animator animatorAI;
    private Animator animatorPlayer;
    public Transform hallWayRoomEnter;
    public Transform hallWayPush;
    public Transform hallWayBathroom;
    public Transform HallwayExit;
    public GameObject collBath;
    bool push = false;
    public bool walking = false;
    Vector3 targetAI;
    Vector3 targetPlayer;
    // Start is called before the first frame update
    void Start()
    {
        animatorPlayer = playerAnimator.GetComponent<Animator>();
        animatorAI = workerHallwayRoom.GetComponent<Animator>();
        agentAI = parentNavmeshAI.GetComponent<NavMeshAgent>();
        playerNav = playerNavmesh.GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (push)
        {
            push = false;
            collBath.GetComponent<BoxCollider>().enabled = false;
            targetPlayer = hallWayPush.position;
            playerNav.SetDestination(targetPlayer);
            targetAI = hallWayRoomEnter.position;
            agentAI.SetDestination(targetAI);
            Invoke("Push", 1.5f);
            Invoke("RunAway", 1.7f);
            Invoke("GettingUp", 3f);
            Invoke("StandUp", 4f);
            Invoke("PlayerBathroom", 6f);
            Invoke("DisableAnim", 10f);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerNav.GetComponent<PlayerMovement>().speed = 0;
            push = true;
        }
    }

    void Push()
    {
        playerNav.ResetPath();
        animatorAI.SetBool("Push", true);
        animatorPlayer.SetBool("pushed", true);
    }
    void GettingUp()
    {
        animatorPlayer.SetBool("pushed", false);
    }

    void StandUp()
    {
        animatorPlayer.SetBool("standUp", true);
    }

    void RunAway()
    {
        animatorAI.SetBool("Push", false);
        targetAI = HallwayExit.position;
        agentAI.SetDestination(targetAI);
    }

    void PlayerBathroom()
    {
        animatorPlayer.SetBool("standUp", false);
        targetPlayer = hallWayBathroom.position;
        walking = true;
        playerNav.SetDestination(targetPlayer);
    }

    void DisableAnim()
    {
        walking = false;
        playerNavmesh.GetComponent<PlayerMovement>().speed = 9;
    }
}
