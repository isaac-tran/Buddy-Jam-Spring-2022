using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnastasiaInteractable : Interactable
{
    public string dialogueTree;
    Interactable interactable;
    Dialogues dialogues;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        dialogues = GetComponent<Dialogues>();
    }

    public override void Interact()
    {
        PickDialogue();
    }

    private void PickDialogue()
    {
        if (Level1GameManager.Instance.acquiredDiary == true)
        {
            DialogueController.Instance.Play(Level1GameManager.Instance.anastasiasDiaryDialogues, "SeeAnaAfterEnteringChamber");
        }
    }
}
