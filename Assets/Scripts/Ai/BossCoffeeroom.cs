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
    public bool boss = true;


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
        if (triggerCoffee.coffee && boss)
        {
            //Debug.Log("Boss");
            agent.SetDestination(roomEnter);
            Invoke("Point", 7.6f);
            Invoke("BossWalkAway",12f);
        }
    }

    void BossWalkAway()
    {
        roomexit = CoffeeRoomExit.position;
        animator.SetBool("Coffee", false);
        agent.SetDestination(roomexit);
        boss = false;
    }

    void Point()
    {
        animator.SetBool("Coffee", true);
    }

}
