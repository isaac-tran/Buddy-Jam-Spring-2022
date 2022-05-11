using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject Player; //connect the player in the editor when using

    private void OnTriggerEnter(Collider collider)
    {   
        var COLLIDER = collider.gameObject.tag;

        if(COLLIDER == "Player")
        {
        //position which player respawns at, position of the "RespawnPosition" GameObject
        Vector3 exactRespawnPosition = transform.GetChild(0).gameObject.transform.position;
        
        Player.transform.GetChild(2).GetComponent<RespawnManager>().PlayerHasEnterdRespawnPoint(exactRespawnPosition);
        }
    }
}
