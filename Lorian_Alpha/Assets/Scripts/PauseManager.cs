using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    [Header("Options")]
    public Slider volumeMaster;
    public Slider volumeSFX;
    public Toggle mute;
    public AudioMixer mixer;
    private float lastVolume;
    [Header("Panels")]
    public GameObject fadeToBlack;
    public GameObject pauseMenuUI;
    public GameObject pausePanel;
    public GameObject codexPanel;
    public GameObject settingsPanel;
    [Header("Buttons")]
    public GameObject resumeButton;
    public GameObject backCodex;
    public GameObject codexButton;
    public GameObject backSettings;
    public GameObject settingsButton;
    public static bool gameIsPaused = false;


    private void Awake()
    {
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
        volumeSFX.onValueChanged.AddListener(ChangeVolumeSFX);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                AudioManager.instance.PlaySound("Button Select SFX");
                Resume();
            }
            else
            {
                AudioManager.instance.PlaySound("Button Select SFX");
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
        RefreshPanels();
    }

    void RefreshPanels()
    {
        pausePanel.SetActive(true);
        codexPanel.SetActive(false);
        settingsPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeButton);
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

    public void ChangeVolumeMaster(float vol)
    {
        mixer.SetFloat("VolMaster", vol);
    }

    public void ChangeVolumeSFX(float vol)
    {
        mixer.SetFloat("VolSFX", vol);
    }

    public void SetMute()
    {
        if (mute.isOn)
        {
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster", -80);
        }
        else
        {
            mixer.SetFloat("VolMaster", lastVolume);
        }
    }
}
