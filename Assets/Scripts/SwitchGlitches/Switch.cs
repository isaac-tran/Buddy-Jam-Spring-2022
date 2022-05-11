using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Interactable switchInteractable;
    public bool isInteractable = false;
    public bool isCollision = false;
    public bool switchstate = false;
    public GameObject switchItem; //this is the item that's needed to be inside the switch to activate

    //this a button-like switch

    void Update()
    {
        if(isInteractable == false)
        {
            return;
        }

        if(switchInteractable.Interacted == true)
        {
            switchstate = true;
        }
    }
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

    void OnTriggerExit(Collider collider)
    {   
        if (isCollision == false)
        {
            return;
        }

        var COLLIDER = collider.gameObject;

        if (COLLIDER == switchItem)
        {
            switchstate = false;
        }
    }
}
