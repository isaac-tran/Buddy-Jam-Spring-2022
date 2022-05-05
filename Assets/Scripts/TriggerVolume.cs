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
            if (onlyOnce)
                Destroy(gameObject);

            onTriggerExit.Invoke();
            if (onlyOnce)
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnter.Invoke();
        if (onlyOnce)
            Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerExit.Invoke();
        if (onlyOnce)
            Destroy(gameObject);
    }
}
