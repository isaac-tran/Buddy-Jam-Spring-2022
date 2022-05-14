using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Dialogues))]
[RequireComponent(typeof(DialogueTrigger))]
public class Key1 : Interactable
{
    Interactable interactable;
    Dialogues dialogues;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        dialogues = GetComponent<Dialogues>();

        interactable.DisplayName = "Key 1";
    }

    public override void Interact()
    {
        Level1GameManager.Instance.AcquireKey1();
        DialogueController.Instance.Play(dialogues, "AcquiredKey1");
        Destroy(gameObject);
    }
}
