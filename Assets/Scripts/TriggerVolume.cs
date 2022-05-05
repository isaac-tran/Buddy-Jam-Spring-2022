using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerVolume : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;
    public bool onlyOnce = true;
    public bool AutoStart = false;

    private void Start()
    {
        if(AutoStart)
        {
            onTriggerEnter.Invoke();
            onTriggerExit.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerExit.Invoke();
    }
}
