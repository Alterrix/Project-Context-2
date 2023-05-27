using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLook : MonoBehaviour
{
    public Transform target;
    public float turnSpeed;
    Quaternion rotGoal;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsBoss();
    }

    void RotateTowardsBoss()
    {
        direction = (target.position - transform.position).normalized;
        rotGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
    }
}
