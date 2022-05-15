using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Dialogues))]
public class Key3 : Interactable
{
    Interactable interactable;
    Dialogues dialogues;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        dialogues = GetComponent<Dialogues>();

        interactable.DisplayName = "Key 3";
    }

    public override void Interact()
    {
        Level1GameManager.Instance.AcquireKey3();
        DialogueController.Instance.Play(dialogues, "AcquiredKey3");
        Destroy(gameObject);
    }
}
