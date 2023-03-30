using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject player;
    public GameObject oldcam;
    public GameObject Newcam;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        Invoke("StartGame1", 26.6f);
    }

    // Update is called once per frame
   

    void StartGame1()
    {
        oldcam.SetActive(false);
        Newcam.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
