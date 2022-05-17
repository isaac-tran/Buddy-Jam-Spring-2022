using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public StarterAssets.FirstPersonController playerController;

    public DialogueCharacter dialogueBox;
    public TextAnimator text;
    public TextMeshProUGUI header;
    public GameObject choiceContainer;
    private DialogueCharacter[] characters;
    private DialogueCharacter characterCurrent;
    private bool isTriggerWaitingForAnims;
    private bool isTriggerWaitingForInput;
    private int animCount = 0;
    public Dialogues dialogues;
    private bool textFinished;
    private bool isFinished = true;
    private bool canSkip = true;
    private bool isChoosing = false;
    private bool simulateNextInput = false;
    private bool isEnding = false;
    private DialogueChoice[] choiceButtons;

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
        choiceButtons = choiceContainer.GetComponentsInChildren<DialogueChoice>();
        foreach (DialogueChoice btn in choiceButtons)
        {
            btn.gameObject.SetActive(false);
        }
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

    public bool IsFinished() { return isFinished; }

    public void Play(Dialogues dialogue, string tree)
    {
        if(playerController)
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

        string[] choices = dialogues.GetChoices();
        if(choices.Length > 0)
        {
            isChoosing = true;
            createChoices(choices);
        }

        textFinished = true;

        //if(dialogues.End)
    }

    private void createChoices(string[] choices)
    {
        if (choices.Length > choiceButtons.Length)
            Debug.LogWarning("Warning: More choices than predefined choice buttons!");

        if (choices[0].Contains("@"))
        {
            for (int i = 0; i < choices.Length && i < choiceButtons.Length; i++)
            {
                int pos = int.Parse(choices[i].Substring(1, 1));
                string choice = choices[i].Substring(3);

                if(pos < choiceButtons.Length)
                {
                    this.choiceButtons[pos].gameObject.SetActive(true);
                    this.choiceButtons[pos].InitChoice(choices[i], choice);
                }
                else
                    Debug.LogWarning("Warning: More choices than predefined choice buttons!");
            }
        }
        else
        {
            for (int i = 0; i < choices.Length && i < choiceButtons.Length; i++)
            {

                this.choiceButtons[i].gameObject.SetActive(true);
                this.choiceButtons[i].InitChoice(choices[i], choices[i]);
            }
        }
    }

    public void PlayChoice(string choice)
    {
        dialogues.NextChoice(choice);
        isChoosing = false;
        PlayNext();
        foreach(DialogueChoice btn in choiceButtons)
        {
            btn.gameObject.SetActive(false);
        }
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

            case "SetImage":
                if (parameters.Length > 2)
                {
                    character = Array.Find(characters, c => c.characterKey == parameters[1]);
                    character.setPortrait(trigger.Substring(parameters[0].Length + parameters[1].Length + 2));
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
                simulateNextInput = true;
                text.SkipAll();
                dialogues.Next();
                PlayNext();
                break;

            case "Start":
                dialogueBox.Play("fadeIn");
                break;

            case "End":
                text.enabled = false;
                isTriggerWaitingForInput = true;
                isEnding = true;
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

    private void EndDialogue()
    {
        Debug.Log("dialogues ended");

        if(playerController)
            StartCoroutine(playerController.DelayedEnableController());

        isFinished = true;

        
        foreach(DialogueCharacter c in characters)
        {
            if(c.isVisible)
            {
                c.Play("fadeOut");
            }
        }

        onFinished.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinished || isChoosing)
            return;

        if (isTriggerWaitingForInput)
        {
            if(Input.anyKeyDown || simulateNextInput)
            {
                simulateNextInput = false;

                if(!isEnding)
                {
                    isTriggerWaitingForInput = false;
                    text.enabled = true;
                }
                else
                {
                    isEnding = false;
                    isTriggerWaitingForInput = false;
                    text.enabled = true;
                    EndDialogue();
                }
                
            }
        } else if(textFinished)
        {
            if (Input.anyKeyDown || simulateNextInput)
            {
                simulateNextInput = false;

                // TODO: Handle Choices
                if (dialogues.End())
                {
                    EndDialogue();
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
