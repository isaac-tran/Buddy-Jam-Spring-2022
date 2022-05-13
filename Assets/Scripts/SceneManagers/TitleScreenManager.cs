using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] ScreenTransitions ScreenTransitions;
    [SerializeField] UIAnimations uiAnimations;
    [SerializeField] AudioManager audioManager;

    [Space(10)]
    [Header("Title art/text")]
    [SerializeField] GameObject titleArt;
    [SerializeField] Vector3 titleArtStartPosition;
    [SerializeField] Vector3 titleArtEndPosition;

    [Space(10)]
    [Header("New game/options menu")]
    [SerializeField] GameObject titleScreenButtonsSection;
    [SerializeField] Vector3 menuStartPosition;
    [SerializeField] Vector3 menuEndPosition;

    [Space(10)]
    [Header("Credits")]
    [SerializeField] GameObject credits;
    [SerializeField] Vector3 creditsStartPosition;
    [SerializeField] Vector3 creditsEndPosition;


    // Start is called before the first frame update
    void Start()
    {
        titleArt.GetComponent<CanvasGroup>().alpha = 0f;
        titleScreenButtonsSection.GetComponent<CanvasGroup>().alpha = 0f;
        credits.GetComponent<CanvasGroup>().alpha = 0f;
        credits.SetActive(false);

        StartCoroutine(OpeningAnimations());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(EnterGame());
        }
    }

    IEnumerator OpeningAnimations()
    {
        audioManager.PlayMusic("City");

        ScreenTransitions.StartCoroutine(ScreenTransitions.FadeIn(2));
        yield return new WaitForSeconds(2);

        uiAnimations.FadeIn(titleArt, 1);
        uiAnimations.Move(titleArt, 1, titleArtStartPosition, titleArtEndPosition);
        yield return new WaitForSeconds(1);

        uiAnimations.FadeIn(titleScreenButtonsSection, 1);
        uiAnimations.Move(titleScreenButtonsSection, 1, menuStartPosition, menuEndPosition);
        yield return new WaitForSeconds(1);

        //yield return 
        yield return null;
    }

    IEnumerator EnterGame()
    {
        //  Screen fade out
        yield return ScreenTransitions.StartCoroutine(ScreenTransitions.FadeOut(2));
        audioManager.StopMusic("City");

        //  Load level 1 game scene
        SceneManager.LoadScene(1);
        yield return null;
    }

    void ShowCredits()
    {
        StartCoroutine(AnimateShowCredits());
    }

    void HideCredits()
    {
        
        StartCoroutine(AnimateHideCredits());
    }

    IEnumerator AnimateShowCredits()
    {
        credits.SetActive(true);
        uiAnimations.FadeIn(credits, 1);
        uiAnimations.Move(credits, 1, creditsStartPosition, creditsEndPosition);

        yield return null;
    }

    IEnumerator AnimateHideCredits()
    {
        uiAnimations.FadeOut(credits, 1);
        uiAnimations.Move(credits, 1, creditsEndPosition, creditsStartPosition);

        yield return new WaitForSeconds(1);
        credits.SetActive(false);

        yield return null;
    }
}

