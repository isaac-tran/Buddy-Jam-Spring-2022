using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider collider)
    {
        var COLLIDER = collider.gameObject.tag;

        if(COLLIDER == "Player")
        {
            //signal the RespwanManager to return to last checkpoint
            Player.GetComponent<RespawnManager>().PlayerHasEnterdDeathZone();
        }
        
    }
}
