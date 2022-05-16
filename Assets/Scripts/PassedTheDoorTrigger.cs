using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassedTheDoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject lockedDoorTrigger;

    private void Awake()
    {
        lockedDoorTrigger.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        lockedDoorTrigger.SetActive(true);
    }
}
