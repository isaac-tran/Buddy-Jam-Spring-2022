using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeftClickToInteractText : MonoBehaviour
{
    [SerializeField] StarterAssets.FirstPersonController playerController;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.PlayerInteractEnabled)
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        else
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }
}
