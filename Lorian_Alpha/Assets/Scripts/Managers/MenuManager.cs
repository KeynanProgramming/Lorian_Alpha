using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject fadeFromBlack, fadeToBlack, backControls, controlsButton, backCredits, creditsButton;

    private void Start()
    {
        if (fadeFromBlack != null)
        {
            GameObject panel = Instantiate(fadeFromBlack, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1.5f);
        }
    }

    public void Play()
    {
        GameObject panel = Instantiate(fadeToBlack, Vector3.zero, Quaternion.identity);
        StartCoroutine(FadeToBlackCo());
    }

    private IEnumerator FadeToBlackCo()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    public void OpenControls()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backControls);
    }

    public void CloseControls()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controlsButton);
    }

    public void OpenCredits()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backCredits);
    }

    public void CloseCredits()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsButton);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
