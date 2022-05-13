using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutChoiceBar : MonoBehaviour
{
    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();  
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimateFadeInOut();
    }

    void AnimateFadeInOut()
    {
        canvasGroup.alpha = 0.5f * Mathf.Cos(Time.time * 0.5f) + 0.65f;
    }
}
