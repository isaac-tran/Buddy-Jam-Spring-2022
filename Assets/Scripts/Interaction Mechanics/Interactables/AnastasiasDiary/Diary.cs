using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : Interactable
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
        Level1GameManager.Instance.acquiredDiary = true;
        DialogueController.Instance.Play(dialogues, dialogueTree);
        Destroy(gameObject);
    }
}
