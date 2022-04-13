using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSControl : MonoBehaviour
{

    public Transform moveObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            moveObject.Rotate(Vector3.up * 90);
        }

        if (Input.GetKeyDown("q"))
        {
            moveObject.Rotate(Vector3.up * -90);
        }
        
    }
}
