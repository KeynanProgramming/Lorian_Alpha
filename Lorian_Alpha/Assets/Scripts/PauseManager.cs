using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    public GameObject fadeToBlack, pauseMenuUI, backCodex, codexButton, backSettings, settingsButton;
    public static bool gameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void OpenCodex()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backCodex);
    }

    public void CloseCodex()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(codexButton);
    }

    public void OpenSettings()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backSettings);
    }

    public void CloseSettings()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsButton);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        GameObject panel = Instantiate(fadeToBlack, Vector3.zero, Quaternion.identity);
        StartCoroutine(GoToMainMenuCo());
    }

    private IEnumerator GoToMainMenuCo()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}
