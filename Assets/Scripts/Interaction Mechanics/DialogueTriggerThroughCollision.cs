using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Put this script in a sphere or cube, which is the area that when the player gets into, a dialogue will be triggered.
//  e.g Standing in front of a door, put a 20x20x10 box collider right in front of the door.
public class DialogueTriggerThroughCollision : MonoBehaviour
{
    public string dialogueTreeToPlay;
    Interactable interactable;
    Dialogues dialogues;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        dialogues = GetComponent<Dialogues>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            DialogueController.Instance.Play(dialogues, dialogueTreeToPlay);
    }
}
