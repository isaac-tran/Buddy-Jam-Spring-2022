using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string displayName;
    public bool Interacted = false;
    [SerializeField] private float interactionRadius = 5f;

    public string DisplayName
    {
        get { return displayName; }
        set { displayName = value; }
    }

    public float InteractionRadius
    {
        get { return interactionRadius; }
    }

    //  To be overridden
    public virtual void Interact()
    {
        Debug.Log("Interacted. Within " + interactionRadius + " unit radius");
        Interacted = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
