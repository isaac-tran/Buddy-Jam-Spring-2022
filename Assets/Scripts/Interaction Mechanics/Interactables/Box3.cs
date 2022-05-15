using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Dialogues))]
public class Box3 : Interactable
{
    Interactable interactable;
    Dialogues dialogues;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        dialogues = GetComponent<Dialogues>();

        interactable.DisplayName = "Box 3";
    }

    public override void Interact()
    {
        if (Level1GameManager.Instance.Key3)
        {
            Destroy(gameObject);
        }
        else
        {
            DialogueController.Instance.Play(dialogues, "NeedKey3");
        }
    }
}

