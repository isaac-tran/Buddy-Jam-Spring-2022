using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Please don't look at this code, it's the most hacky thing ever

public class RespawnManager : MonoBehaviour
{
    public Component Controller;
    public Behaviour bhvr;

    Vector3 last_respawnpoint_position;

    private void Awake()
    {   //set the initial respawnpoint
        last_respawnpoint_position = transform.position;
        bhvr = (Behaviour)Controller;
    }

    public void PlayerHasEnterdDeathZone()
    {   //return to last checkpoint this can be smoothed or animated
        
        bhvr.enabled = false;
        transform.position = last_respawnpoint_position;
        StartCoroutine(yield1second());
    }

    public void PlayerHasEnterdRespawnPoint(Vector3 respawn_point)
    {   //set the respawnpoint
        last_respawnpoint_position = respawn_point;
    }

    IEnumerator yield1second(){
        yield return new WaitForSeconds(1);
        bhvr.enabled = true;
    }
}
