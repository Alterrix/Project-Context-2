using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxStaff : MonoBehaviour
{
    public GameObject startGame;

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            startGame.SetActive(false);
            Debug.Log("go off");
        }
       
    }
}
