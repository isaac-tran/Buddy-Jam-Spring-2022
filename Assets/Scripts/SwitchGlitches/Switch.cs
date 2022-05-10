using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool switchstate = false;
    public GameObject switchItem; //this is the item that's needed to be inside the switch to activate
    // Update is called once per frame
    void Update()
    {
    
    }
    //this a button-like switch
    void OnTriggerEnter(Collider collider)
    {
        var COLLIDER = collider.gameObject;

        if (COLLIDER == switchItem)
        {
            switchstate = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        var COLLIDER = collider.gameObject;

        if (COLLIDER == switchItem)
        {
            switchstate = false;
        }
    }
}
