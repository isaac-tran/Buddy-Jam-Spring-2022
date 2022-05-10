using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private float interactionRadius = 5f;

    public float InteractionRadius
    {
        get { return interactionRadius; }
    }

    //  To be overridden
    public virtual void Interact()
    {
        Debug.Log("Interacted. Within " + interactionRadius + " unit radius");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
