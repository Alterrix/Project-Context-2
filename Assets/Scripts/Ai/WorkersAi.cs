using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkersAi : MonoBehaviour
{
    NavMeshAgent agent;
    public PlayerMechanics playerMechanics;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    public GameObject text;
    bool timer = false;
    bool resetTimer;
    float currentTime;
    float startingTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        updateDestination();
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,target) < 1)
        {
            NextWaypoint();
            updateDestination();
        }

        if(playerMechanics.workerBump)
        {
            timer = true;
            
            text.SetActive(true);
            playerMechanics.workerBump = false;
        }

        if (timer)
        {
            currentTime += 1 * Time.deltaTime;
        }

        if (currentTime >= 3f)
        {
            text.SetActive(false);
            timer = false;
            resetTimer = true;

        }
        if (resetTimer)
        {
            currentTime = 0f;
            resetTimer = false;
        }
        //Debug.Log(currentTime);
        text.transform.localEulerAngles = new Vector3(0, 180, 0);
    }

    void updateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void NextWaypoint()
    {
        waypointIndex++;
        if(waypointIndex== waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    void activateText()
    {

    }
}
