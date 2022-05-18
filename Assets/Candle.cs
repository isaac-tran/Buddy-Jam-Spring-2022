using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Candle : Interactable
{
    private bool _isLit = true;
    public bool isLit
    {
        set
        {
            light.enabled = value;
            _isLit = value;
            onStateChanged.Invoke();
        }
    }

    public Light light;
    public UnityEvent onStateChanged;
    public bool isInteractable = true;

    public override void Interact()
    {
        if(isInteractable)
            isLit = !_isLit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
