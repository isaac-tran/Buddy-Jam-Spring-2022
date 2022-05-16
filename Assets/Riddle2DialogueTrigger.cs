using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle2DialogueTrigger : MonoBehaviour
{
    public bool oneTimeDialogue;
    private bool dialoguePlayed = false;
    public string dialogueTreeToPlay;
    Interactable interactable;
    Dialogues dialogues;
    [SerializeField] Dialogues riddle2Dialogues;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        dialogues = riddle2Dialogues;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (dialoguePlayed == false)
        {
            if (collision.collider.tag == "Player")
                DialogueController.Instance.Play(dialogues, dialogueTreeToPlay);
        }

        if (oneTimeDialogue)
            dialoguePlayed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dialoguePlayed == false)
        {
            if (other.tag == "Player")
                DialogueController.Instance.Play(dialogues, dialogueTreeToPlay);
        }

        if (oneTimeDialogue)
            dialoguePlayed = true;
    }
}
