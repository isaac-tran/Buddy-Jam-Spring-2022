using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Dialogues))]
public class Box1 : Interactable
{
    Interactable interactable;
    Dialogues dialogues;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        dialogues = GetComponent<Dialogues>();

        interactable.DisplayName = "Box 1";
    }

    public override void Interact()
    {
        if (Level1GameManager.Instance.Key1)
        {
            Destroy(gameObject);
        }
        else
        {
            DialogueController.Instance.Play(dialogues, "NeedKey1");
        }
    }
}

