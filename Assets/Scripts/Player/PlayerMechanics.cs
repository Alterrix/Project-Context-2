using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    public bool cleaning = false;
    public bool workerBump = false;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            cleaning = true;
        }
        else
        {
            cleaning = false;
        }
        //Debug.Log(cleaning);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Worker")
        {
            workerBump = true;
        }
    }

}
