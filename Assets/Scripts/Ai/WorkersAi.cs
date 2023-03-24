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

    //timer
    bool timer = false;
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
        if (Vector3.Distance(transform.position, target) < 1)
        {
            NextWaypoint();
            updateDestination();
        }

        if (timer)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= 3f)
            {
                timer = false;
                text.SetActive(false);
                currentTime = startingTime;
            }
        }
    }

    void updateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void NextWaypoint()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    public void ActivateText()
    {
        timer = true;
        text.SetActive(true);
    }
}
