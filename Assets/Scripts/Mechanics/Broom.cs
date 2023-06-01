using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    public GameObject broom;
    public bool bossPoint = false;
    public bool PickepUpBroom = false;
    public GameObject coll;
    [SerializeField] PlayerMechanics pm;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && pm.pressingE)
        {
            PickepUpBroom = true;
            bossPoint = true;
            broom.SetActive(false);
            Debug.Log("pickup broom");
            coll.SetActive(false);
        }
    }
}
