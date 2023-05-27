using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBins : MonoBehaviour
{
    public GameObject teleportPoint;
    public GameObject teleportPointBack;
    public GameObject boxCollCoffee;
    public GreyBins greyBins;

    int items;
    public bool items1clean = false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "room2PickUpBlack")
        {
            items++;
            other.gameObject.transform.position = teleportPoint.transform.position;
        }


        if (other.tag == "room2PickUpGray")
        {
            other.gameObject.transform.position = teleportPointBack.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(items1clean);

        if (items >= 3 && GreyBins.items2clean)
        {
            //Debug.Log("works");
            items1clean = true;
            boxCollCoffee.SetActive(false);
            //Debug.Log(items1clean);
        }
    }
}
