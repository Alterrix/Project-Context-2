using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    public GameObject broom;
    public bool bossPoint = false;
    [SerializeField] PlayerMechanics pm;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && pm.pressingE)
        {
            bossPoint = true;
            broom.SetActive(false);
            Debug.Log("pickup broom");
        }
    }
}
