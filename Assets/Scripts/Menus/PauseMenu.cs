using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject quitWarning;
    public bool isPaused = false;

    public void changePauseState()
    {
        if (isPaused)
        {
            resume();
        }
        else
        {
            pause();
        }
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void quit()
    {
        quitWarning.SetActive(true);
    }

    public void quitForReal(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
    }

    public void cancelQuit()
    {
        quitWarning.SetActive(false);
    }
}
