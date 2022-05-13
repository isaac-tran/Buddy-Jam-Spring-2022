using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Dialogues))]
[RequireComponent(typeof(DialogueTrigger))]
public class Book : Interactable
{
    Interactable interactable;
    Dialogues dialogues;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        dialogues = GetComponent<Dialogues>();
    }

    public override void Interact()
    {
        Debug.Log("Book interact called");
        DialogueController.Instance.Play(dialogues, "BookDetails");
    }
}
