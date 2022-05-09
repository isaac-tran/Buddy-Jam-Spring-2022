using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] ScreenTransitions ScreenTransitions;

    // Start is called before the first frame update
    void Start()
    {
        ScreenTransitions.StartCoroutine(ScreenTransitions.FadeIn(1));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(EnterGame());
        }
    }

    IEnumerator EnterGame()
    {
        //  Screen fade out
        yield return ScreenTransitions.StartCoroutine(ScreenTransitions.FadeOut(1));

        //  Load level 1 game scene
        SceneManager.LoadScene(1);
        yield return null;
    }
}
