using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public bool autoStart = true;
    public string tree = "init";

    // Start is called before the first frame update
    void Start()
    {
        if(autoStart)
        {
            PlayDialogue(tree);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDialogue(string tree)
    {
        DialogueController.Instance.Play(this.GetComponent<Dialogues>(), tree);
    }
}
