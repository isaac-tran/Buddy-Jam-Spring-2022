using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject Player; //connect the player in the editor when using

    private void OnTriggerEnter(Collider collider)
    {   //position which player respawns at, position of the "RespawnPosition" GameObject
        Vector3 exactRespawnPosition = transform.GetChild(0).gameObject.transform.position;
        
        Player.GetComponent<RespawnManager>().PlayerHasEnterdRespawnPoint(exactRespawnPosition);
    }
}