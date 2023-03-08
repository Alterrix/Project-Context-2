using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanBoxes : MonoBehaviour
{
    public GameObject redbox;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(redbox);
    }
}
