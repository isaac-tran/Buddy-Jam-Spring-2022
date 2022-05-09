using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenTransitions : MonoBehaviour
{
    //  Editable in editor
    [SerializeField] Image BackgroundMaskImage;
    [SerializeField] float FadeInDuration = 1;
    [SerializeField] float FadeOutDuration = 1;
    
    //  Private, for calculating
    [SerializeField] float timer = 0;
    bool isFadingIn = false;
    bool isFadingOut = false;

    public IEnumerator FadeIn(float durationInSeconds)
    {
        //  If screen is in the process of fading out -> do not do fade in
        if (isFadingOut)
            yield break;

        isFadingIn = true;

        Color bgMaskColor = BackgroundMaskImage.color;
        int totalFrames = Mathf.RoundToInt(durationInSeconds / Time.deltaTime);

        for (int currentFrame = 0; currentFrame <= totalFrames; currentFrame++)
        {
            float t = (float) currentFrame / (float) totalFrames;

            //  0 is transparent, 1 is unique. Fade in = black -> transparent
            Color nextMaskImageColor = new Color(
                bgMaskColor.r,
                bgMaskColor.g,
                bgMaskColor.b,
                Mathf.Lerp(1, 0, t)
            );

            BackgroundMaskImage.color = nextMaskImageColor;

            yield return null; 
        }

        isFadingIn = false;
        yield return null;
    }

    public IEnumerator FadeOut(float durationInSeconds)
    {
        //  If screen is in the process of fading out -> do not do fade in
        if (isFadingIn)
            yield break;

        isFadingOut = true;

        Color bgMaskColor = BackgroundMaskImage.color;
        int totalFrames = Mathf.RoundToInt(durationInSeconds / Time.deltaTime);

        for (int currentFrame = 0; currentFrame <= totalFrames; currentFrame++)
        {
            float t = (float)currentFrame / (float)totalFrames;

            //  0 is transparent, 1 is unique. Fade out = transparent -> black
            Color nextMaskImageColor = new Color(
                bgMaskColor.r,
                bgMaskColor.g,
                bgMaskColor.b,
                Mathf.Lerp(0, 1, t)
            );

            BackgroundMaskImage.color = nextMaskImageColor;

            yield return null;
        }

        isFadingOut = false;
        yield return null;
    }
}
