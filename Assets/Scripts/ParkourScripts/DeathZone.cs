using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject Player; //connect the player in the editor when using

    private void OnTriggerEnter(Collider collider)
    {
        var COLLIDER = collider.gameObject.tag;

        if(COLLIDER == "Player")
        {
            //signal the RespwanManager to return to last checkpoint
            Player.transform.GetChild(2).GetComponent<RespawnManager>().PlayerHasEnterdDeathZone();
        }
        
    }
}
