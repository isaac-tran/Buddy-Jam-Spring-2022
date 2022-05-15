using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Dialogues))]
public class Key2 : Interactable
{
    Interactable interactable;
    Dialogues dialogues;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        dialogues = GetComponent<Dialogues>();

        interactable.DisplayName = "Key 2";
    }

    public override void Interact()
    {
        Level1GameManager.Instance.AcquireKey2();
        DialogueController.Instance.Play(dialogues, "AcquiredKey2");
        Destroy(gameObject);
    }
}
