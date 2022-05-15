using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoice : MonoBehaviour
{
    private string choice;

    public void InitChoice(string choice, string displayText)
    {
        this.choice = choice;
        GetComponent<Button>().onClick.AddListener(OnClicked);
        GetComponentInChildren<TextMeshProUGUI>().SetText(displayText);
    }

    void OnClicked()
    {
        DialogueController.Instance.PlayChoice(choice);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
