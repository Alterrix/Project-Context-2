using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCoffee : MonoBehaviour
{
    public bool coffee = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            coffee = true;
        }
    }
}
