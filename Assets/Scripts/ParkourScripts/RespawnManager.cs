using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    Vector3 last_respawnpoint_position;

    private void Awake()
    {   //set the initial respawnpoint
        last_respawnpoint_position = transform.position;
    }

    public void PlayerHasEnterdDeathZone()
    {   //return to last checkpoint this can be smoothed or animated
        Debug.Log(last_respawnpoint_position);
        transform.position = last_respawnpoint_position;
    }

    public void PlayerHasEnterdRespawnPoint(Vector3 respawn_point)
    {   //set the respawnpoint
        last_respawnpoint_position = respawn_point;
    }
}
