using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyBins : MonoBehaviour
{
    public GameObject teleportPoint;
    public GameObject teleportPointBack;

    int items2;
    public static bool items2clean = false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "room2PickUpGray")
        {
            items2++;
            other.gameObject.transform.position = teleportPoint.transform.position;
        }


        if (other.tag == "room2PickUpBlack")
        {
            other.gameObject.transform.position = teleportPointBack.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(items2clean);

        if (items2 >= 3)
        {
            //Debug.Log("works");
            items2clean = true;
        }
    }
}
