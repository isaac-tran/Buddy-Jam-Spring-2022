using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.Events;

public class DialogueController : MonoBehaviour
{
    public StarterAssets.FirstPersonController playerController;

    public TextAnimator text;
    public TextMeshProUGUI header;
    private DialogueCharacter[] characters;
    private DialogueCharacter characterCurrent;
    private bool isTriggerWaitingForAnims;
    private bool isTriggerWaitingForInput;
    private int animCount = 0;
    public Dialogues dialogues;
    private bool textFinished;
    private bool isFinished = true;
    private bool canSkip = true;

    public UnityEvent onFinished;
    public UnityEvent onStarted;

    static DialogueController _instance;
    public static DialogueController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DialogueController>();
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        characters = GetComponentsInChildren<DialogueCharacter>();
        foreach (DialogueCharacter c in characters)
        {
            c.onAnimationsEnded.AddListener(OnAnimationFinished);
        }
        text.onTrigger.AddListener(OnTextTrigger);
        text.onFinished.AddListener(OnTextFinished);

        //PlayTree("init");
    }

    public bool IsFinished() { return textFinished; }

    public void Play(Dialogues dialogue, string tree)
    {
        playerController.DisableController();

        this.dialogues = dialogue;
        dialogues.SetTree(tree);
        isFinished = false;
        onStarted.Invoke();
        PlayNext();
    }

    private void PlayNext()
    {
        
        string name = "";
        string str = dialogues.GetCurrentDialogue();

        if (dialogues.HasTrigger())
        {
            name = dialogues.GetTrigger();
        }

        // TODO: Handle Choices

        characterCurrent = Array.Find(characters, c => c.characterKey == name);

        if(characterCurrent != null)
        {
            header.color = characterCurrent.headerColor;
            text.textMesh.color = characterCurrent.textColor;
            header.text = characterCurrent.characterDisplayName;
        }
        else if (name != "")
        {
            header.color = Color.grey;
            text.textMesh.color = Color.black;
            header.text = name;
        }

        textFinished = false;
        text.PlayText(str);
    }

    public void OnTextFinished()
    {
        // TODO: Handle Choices

        textFinished = true;

        //if(dialogues.End)
    }

    public void OnTextTrigger(string trigger, bool isSkipping)
    {
        //TriggerInfo t = ParseTrigger(trigger);

        //Debug.Log("char:" + t.character + " method:" + t.method + " param:" + t.param);

        string[] parameters;
        DialogueCharacter character;

        parameters = trigger.Split(new char[] { ' ' });

        switch (parameters[0])
        {
            case "Wait":
                if (!isSkipping)
                {
                    text.enabled = false;
                    if (parameters.Length > 1)
                    {
                        // Error handling?
                        StartCoroutine(EnableText(float.Parse(parameters[1])));
                    }
                    else
                    {
                        isTriggerWaitingForAnims = true;
                    }
                }
                break;

            case "WaitInput":
                text.enabled = false;
                isTriggerWaitingForInput = true;
                break;

            case "SetName":
                if(parameters.Length > 2)
                {
                    character = Array.Find(characters, c => c.characterKey == parameters[1]);
                    character.characterDisplayName = trigger.Substring(parameters[0].Length + parameters[1].Length + 2);
                }
                break;

            case "DisableSkip":
                canSkip = false;
                break;

            case "EnableSkip":
                canSkip = true;
                break;

            case "PlayNext":
                isTriggerWaitingForInput = false;
                text.SkipAll();
                dialogues.Next();
                PlayNext();
                break;

            default:
                character = Array.Find(characters, c => c.characterKey == parameters[0]);
                if(character != null && parameters.Length > 1)
                {
                    character.Play(parameters[1], isSkipping);
                }
                break;
        }
    }

    IEnumerator EnableText(float delay)
    {
        yield return new WaitForSeconds(delay);
        text.enabled = true;
    }

    public void OnAnimationFinished()
    {
        animCount--;
        if(isTriggerWaitingForAnims && animCount <= 0)
        {
            text.enabled = true;
            animCount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinished)
            return;

        if (isTriggerWaitingForInput)
        {
            if(Input.anyKeyDown)
            {
                isTriggerWaitingForInput = false;
                text.enabled = true;
            }
        } else if(textFinished)
        {
            if (Input.anyKeyDown)
            {
                // TODO: Handle Choices
                if(dialogues.End())
                {
                    Debug.Log("dialogues ended");

                    StartCoroutine(playerController.DelayedEnableController());

                    // TODO: Enable Player Input
                    // TODO: Refactor:
                    // "DialogCharacter should be somewhing like DialogEntity ot something
                    // Refactor {Wait} etc. commands to functions
                    text.Clear();
                    header.text = "";
                    /*DialogueCharacter bg = Array.Find(characters, c => c.characterKey == "dialog");
                    bg.Play("fadeOut");*/
                    onFinished.Invoke();
                    isFinished = true;
                }
                else
                {
                    dialogues.Next();
                    PlayNext();
                }
            }
        } else if(Input.anyKeyDown && canSkip)
        {
            text.SkipAll();
        }
        // {Aeri:Play(Intro)}
        // {Aeri:Surprise}
        // {Wait}
        // {Wait(0.5)}
        // {WaitInput}
    }
}
