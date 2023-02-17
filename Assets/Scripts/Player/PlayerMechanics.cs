using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    public bool cleaning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        Debug.Log(cleaning);
    }
}
