using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Dialogues))]
public class DialogueOnlyInteractable : Interactable
{
    public string dialogueTree = "BookDetails";
    Interactable interactable;
    Dialogues dialogues;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        dialogues = GetComponent<Dialogues>();
    }

    public override void Interact()
    {
        DialogueController.Instance.Play(dialogues, dialogueTree);
    }
}