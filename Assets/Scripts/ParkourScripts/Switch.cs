using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool switchstate = false;
    // Update is called once per frame
    void Update()
    {
    
    }
    //this an oneshot switch
    void OnTriggerEnter(Collider collider)
    {
        var COLLIDER = collider.gameObject.tag;

        if (COLLIDER == "Player")
        {
            switchstate = true;
        }
    }
}
