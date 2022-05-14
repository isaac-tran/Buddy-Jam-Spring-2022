using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenTransitions : MonoBehaviour
{
    //  Editable in editor
    [SerializeField] Image BackgroundMaskImage;
    [SerializeField] UIAnimations UIAnimations;
    
    //  Private, for calculating
    bool isFadingIn = false;
    bool isFadingOut = false;

    public IEnumerator FadeIn(float durationInSeconds)
    {
        //  If screen is in the process of fading out -> do not do fade in
        if (isFadingOut)
            yield break;

        isFadingIn = true;

        CanvasGroup bgMaskCanvasGroup = BackgroundMaskImage.GetComponent<CanvasGroup>();
        float timer = 0f;

        for (timer = 0f; timer <= durationInSeconds; timer += Time.deltaTime)
        {
            float t = timer / durationInSeconds;

            //  0 is transparent, 1 is unique. Fade in = black -> transparent
            bgMaskCanvasGroup.alpha = Mathf.Lerp(1, 0, t);

            yield return new WaitForEndOfFrame(); 
        }

        BackgroundMaskImage.enabled = false;
        isFadingIn = false;
        yield return null;
    }

    public IEnumerator FadeOut(float durationInSeconds)
    {
        BackgroundMaskImage.enabled = true;

        //  If screen is in the process of fading out -> do not do fade in
        if (isFadingIn)
            yield break;

        isFadingOut = true;

        CanvasGroup bgMaskCanvasGroup = BackgroundMaskImage.GetComponent<CanvasGroup>();
        float timer = 0f;

        for (timer = 0f; timer <= durationInSeconds; timer += Time.deltaTime)
        {
            float t = timer / durationInSeconds;
            Debug.Log("FPS: " + 1f / Time.fixedDeltaTime);
            Debug.Log(timer + " " + durationInSeconds);

            //  0 is transparent, 1 is unique. Fade out = transparent -> black
            bgMaskCanvasGroup.alpha = Mathf.Lerp(0, 1, t);

            yield return new WaitForEndOfFrame();
        }

        isFadingOut = false;
        yield return null;
    }
}
