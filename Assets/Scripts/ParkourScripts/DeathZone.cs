using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        var COLLIDER = collider.gameObject.tag;

        if(COLLIDER == "Player")
        {
            Debug.Log("Player has entered");
            //signal the player to return to last checkpoint
        }
        
    }
}
