using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextAnimator : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float CharactersPerSecond;
    private string text;
    private float time = 0f;
    private int charCount = -1;

    const char TAG_START = '<';
    const char TAG_END = '>';
    const char TRIGGER_START = '@';
    const char TRIGGER_END = '\n';

    public bool hasFinished { get; private set; }

    public UnityEvent<string> onTrigger;
    public UnityEvent onCharacter;
    public UnityEvent onFinished;
    public bool skipSpace;
    public float waitAfterNewline;
    public float waitAfterSentence;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        hasFinished = true;
    }

    public void DebugPrint(string text)
    {
        Debug.Log(text);
    }

    public void PlayText(string text)
    {
        this.text = text;
        Restart();
    }

    public void PlayText(string text, int startCharacter, bool skipCharacterEvents = false, bool skipTriggerEvents = false)
    {
        PlayText(text);
        while(charCount < startCharacter)
        {
            RevealNext(skipCharacterEvents, skipTriggerEvents);
        }
    }

    public void SkipAll(bool skipCharacterEvents = false, bool skipTriggerEvents = false)
    {
        Skip(text.Length, skipCharacterEvents, skipTriggerEvents);
    }

    public void Skip(int position, bool skipCharacterEvents = false, bool skipTriggerEvents = false)
    {
        while (charCount < position)
        {
            RevealNext(skipCharacterEvents, skipTriggerEvents);
        }
    }

    public void Restart()
    {
        Clear();
        hasFinished = false;
        
    }

    public void Clear()
    {
        textMesh.text = "";
        time = 0f;
        charCount = -1;
        hasFinished = true;

    }

    private void RevealNext(bool skipCharacterEvents = false,  bool skipTriggerEvents = false)
    {
        charCount++;
        if(charCount >= text.Length)
        {
            hasFinished = true;
            onFinished.Invoke();
            return;
        }

        switch (text[charCount])
        {
            case TAG_START:
                int tagStartIndex = charCount;
                int tagLength = text.IndexOf(TAG_END, charCount) - charCount;
                textMesh.text = textMesh.text + text.Substring(tagStartIndex, tagLength + 1);
                charCount += tagLength;
                RevealNext();
                return;

            case TRIGGER_START:
                int triggerStartIndex = charCount;
                int triggerLength = text.IndexOf(TRIGGER_END, charCount) - charCount;
                if (triggerLength <= 0)
                    triggerLength = text.Length - triggerStartIndex;

                if(!skipTriggerEvents)
                    onTrigger.Invoke(text.Substring(triggerStartIndex + 1, triggerLength - 1));

                charCount += triggerLength;
                //RevealNext();
                return;

            default:
                textMesh.text = textMesh.text + text[charCount];

                if(!skipCharacterEvents)
                    onCharacter.Invoke();
                break;
        }

        switch(text[charCount])
        {
            case ' ':
                if (skipSpace)
                    RevealNext();
                break;

            case '\n':
                time -= waitAfterNewline;
                break;

            case '!':
            case '?':
            case '.':
                if(charCount + 1 < text.Length &&
                    (text[charCount + 1] == ' ' || text[charCount + 1] == '\n'))
                {
                    time -= waitAfterSentence;
                }
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (!hasFinished)
        {
            time += Time.deltaTime * CharactersPerSecond;
            if (time > 1f)
            {
                time -= 1f;
                RevealNext();
            }
        }

    }
}
