using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isInteractable = false;
    public bool isCollision = false;
    public bool switchstate = false;
    public GameObject switchItem; //this is the item that's needed to be inside the switch to activate

    //this a button-like switch
    void OnTriggerEnter(Collider collider)
    {
        if (isCollision == false)
        {
            return;
        }

        var COLLIDER = collider.gameObject;

        if (COLLIDER == switchItem)
        {
            switchstate = true;
        }
    }

    //void interacted() //function for when switch is interacted with(?)
    // {
    //     if (isInteractable == false)
    //     {
    //         return;
    //     }

    //     switchstate = true;
    // }


    // void OnTriggerExit(Collider collider)
    // {
    //     var COLLIDER = collider.gameObject;

    //     if (COLLIDER == switchItem)
    //     {
    //         switchstate = false;
    //     }
    // }
}
