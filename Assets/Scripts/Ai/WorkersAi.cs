using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkersAi : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        updateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,target) < 1)
        {
            NextWaypoint();
            updateDestination();
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
        if(waypointIndex== waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
