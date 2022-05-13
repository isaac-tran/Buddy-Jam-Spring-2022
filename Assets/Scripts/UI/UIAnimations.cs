using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class UIAnimations : MonoBehaviour
{ 
    public void FadeIn(GameObject UIElement, float duration)
    {
        StartCoroutine(AnimateFadeIn(UIElement, duration));
    }

    public void FadeOut(GameObject UIElement, float duration)
    {
        StartCoroutine(AnimateFadeOut(UIElement, duration));
    }

    public void Move(GameObject UIElement,float duration, Vector3 startPoint, Vector3 endPoint)
    {
        StartCoroutine(AnimateMove(UIElement, duration, startPoint, endPoint));     
    }

    IEnumerator AnimateFadeIn(GameObject UIElement, float duration)
    {
        CanvasGroup canvasGroup = UIElement.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = UIElement.AddComponent<CanvasGroup>();
        }

        float framesToAnimate = (duration / Time.deltaTime);
        for (float i = 0; i < framesToAnimate + 1; i++)
        {
            //  Fade in: Alpha 0 -> 1
            canvasGroup.alpha = Mathf.Lerp(0, 1, i / framesToAnimate);
            yield return null;
        }

        yield return null;
    }

    IEnumerator AnimateFadeOut(GameObject UIElement, float duration)
    {
        CanvasGroup canvasGroup = UIElement.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = UIElement.AddComponent<CanvasGroup>();
        }

        float framesToAnimate = (duration / Time.deltaTime);
        for (float i = 0; i < framesToAnimate + 1; i++)
        {
            //  Fade in: Alpha 0 -> 1
            canvasGroup.alpha = Mathf.Lerp(1, 0, i / framesToAnimate);
            yield return null;
        }

        yield return null;
    }

    IEnumerator AnimateMove(GameObject UIElement, float duration, Vector3 startPoint, Vector3 endPoint)
    {
        RectTransform UIElemRectTransform = UIElement.GetComponent<RectTransform>(); 

        float framesToAnimate = (duration / Time.deltaTime);
        for (float i = 0; i < framesToAnimate + 1; i++)
        {
            //  Fade in: Alpha 0 -> 1
            UIElemRectTransform.localPosition = Vector3.Lerp(startPoint, endPoint, i / framesToAnimate);
            yield return null;
        }

        yield return null;
    }
}
