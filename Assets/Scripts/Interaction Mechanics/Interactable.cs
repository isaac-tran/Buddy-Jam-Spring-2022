using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("UI and Interaction mechanics")]
    [SerializeField] private string displayName;
    [SerializeField] private float interactionRadius = 5f;

    [Space(10)]
    [Header("Debug Mode")]
    public bool Interacted = false;

    public string DisplayName
    {
        get { return displayName; }
        set { displayName = value; }
    }

    public float InteractionRadius
    {
        get { return interactionRadius; }
    }

    private void Start()
    {
        if (displayName == "")
            displayName = gameObject.name;
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
