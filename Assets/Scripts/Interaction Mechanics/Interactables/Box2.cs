using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Dialogues))]
[RequireComponent(typeof(DialogueTrigger))]
public class Box2 : Interactable
{
    Interactable interactable;
    Dialogues dialogues;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        dialogues = GetComponent<Dialogues>();

        interactable.DisplayName = "Box 2";
    }

    public override void Interact()
    {
        if (Level1GameManager.Instance.Key2)
        {
            Destroy(gameObject);
        }
    }
}

