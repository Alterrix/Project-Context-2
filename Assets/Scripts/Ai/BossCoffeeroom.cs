using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BossCoffeeroom : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject bossCoffeeRoom;
    private Animator animator;
    public Transform CoffeeRoomEnter;
    public Transform CoffeeRoomExit;
    Vector3 roomEnter;
    Vector3 roomexit;
    public triggerCoffee triggerCoffee;


    // Start is called before the first frame update
    void Start()
    {
        animator = bossCoffeeRoom.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        roomEnter = CoffeeRoomEnter.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerCoffee.coffee)
        {
            agent.SetDestination(roomEnter);
            Invoke("BossWalkAway",10f);
        }
    }

    void BossWalkAway()
    {
        triggerCoffee.coffee = false;
        roomexit = CoffeeRoomExit.position;
        agent.SetDestination(roomexit);
    }

}
