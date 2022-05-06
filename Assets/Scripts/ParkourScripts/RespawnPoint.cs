using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider collider)
    {
        Vector3 exactRespawnPosition = transform.GetChild(0).gameObject.transform.position;
        Debug.Log(exactRespawnPosition);
        Player.GetComponent<RespawnManager>().PlayerHasEnterdRespawnPoint(exactRespawnPosition);
    }
}
