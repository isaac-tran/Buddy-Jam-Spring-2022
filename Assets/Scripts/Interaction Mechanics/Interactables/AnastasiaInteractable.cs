using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnastasiaInteractable : Interactable
{
    public string dialogueTree;
    Interactable interactable;
    Dialogues dialogues;
    private SpriteRenderer thisSprite;
    [SerializeField] private float fadeDuration = 1f;
    private bool fadingOut, fadingIn;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
        dialogues = GetComponent<Dialogues>();

        thisSprite = GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        StartCoroutine(PickDialogue());
    }

    private IEnumerator FadeIn()
    {
        fadingIn = true;
        float timer = 0f;
        for (timer = 0f; timer < fadeDuration; timer += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            thisSprite.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
        fadingIn = false;
        yield return null;
    }

    private IEnumerator FadeOut()
    {
        fadingOut = true;
        float timer = 0f;
        for (timer = 0f; timer < fadeDuration; timer+=Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            thisSprite.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
        fadingOut = false;
        yield return null;
    }

    private IEnumerator PickDialogue()
    {
        Debug.Log(DialogueController.Instance.IsFinished());
        if (DialogueController.Instance.IsFinished() == false) 
            yield break;

        if (Level1GameManager.Instance.acquiredDiary == true)
        {
            DialogueController.Instance.Play(Level1GameManager.Instance.anastasiasDiaryDialogues, "SeeAnaAfterEnteringChamber");
            while (DialogueController.Instance.IsFinished() == false) yield return null;

            yield return FadeOut();
            while (fadingOut) yield return null;
        }
        else
        {
            DialogueController.Instance.Play(Level1GameManager.Instance.anastasiasDiaryDialogues, "HasNotAcquiredDiary");
            while (DialogueController.Instance.IsFinished() == false) yield return null;
        }

        yield return null;
    }
}
