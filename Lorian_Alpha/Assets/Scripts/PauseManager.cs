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
    public GameObject muralOnePanel;
    public GameObject muralTwoPanel;
    public GameObject muralThreePanel;
    public GameObject muralFourPanel;
    public GameObject dialogBox;
    public Text dialogText;
    [Header("Buttons")]
    public GameObject resumeButton;
    public GameObject backCodex;
    public GameObject codexButton;
    public GameObject backSettings;
    public GameObject settingsButton;
    public GameObject muralOneButton;
    public GameObject muralTwoButton;
    public GameObject muralThreeButton;
    public GameObject muralFourButton;
    public GameObject muralFiveButton;
    public GameObject muralSixButton;
    public GameObject muralOneBlock;
    public GameObject muralTwoBlock;
    public GameObject muralThreeBlock;
    public GameObject muralFourBlock;
    public GameObject muralFiveBlock;
    public GameObject muralSixBlock;
    public GameObject muralOnePic;
    public GameObject muralTwoPic;
    public GameObject muralThreePic;
    public GameObject muralFourPic;
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
        CloseMuralPanels();
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

    public void OpenMuralOne()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(muralOneButton);
    }

    public void OpenMuralTwo()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(muralTwoButton);
    }

    public void OpenMuralThree()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(muralThreeButton);
    }

    public void OpenMuralFour()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(muralFourButton);
    }

    public void OpenMuralFive()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(muralFiveButton);
    }

    public void OpenMuralSix()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(muralSixButton);
    }

    public void CloseMuralOne()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(muralOneBlock);
    }

    public void CloseMuralTwo()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(muralTwoBlock);
    }

    public void CloseMuralThree()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(muralThreeBlock);
    }

    public void CloseMuralFour()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(muralFourBlock);
    }

    public void CloseMuralFive()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(muralFiveBlock);
    }

    public void CloseMuralSix()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(muralSixBlock);
    }

    public void GoToMainMenu()
    {
        Resume();
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

    public void CodexOneUpdate()
    {
        if (muralOnePic.activeInHierarchy)
        {
            muralOnePanel.SetActive(true);
            dialogText.text = "Nayru, Goddess of Time and Order.";
        }
        else
        {
            dialogText.text = "This block is empty.";
        }
    }

    public void CodexTwoUpdate()
    {
        if (muralTwoPic.activeInHierarchy)
        {
            muralTwoPanel.SetActive(true);
            dialogText.text = "Cerunos, God of Chaos. Creator of the Beasts.";
        }
        else
        {
            dialogText.text = "This block is empty.";
        }
    }

    public void CodexThreeUpdate()
    {
        if (muralThreePic.activeInHierarchy)
        {
            muralThreePanel.SetActive(true);
            dialogText.text = "In the beginnings of time the godly siblings shaped the world in harmony, creating as they saw fit.";
        }
        else
        {
            dialogText.text = "This block is empty.";
        }
    }
    
    public void CodexFourUpdate()
    { 
        if (muralFourPic.activeInHierarchy)
        {
            muralFourPanel.SetActive(true);
            dialogText.text = "The war for Drunarya was ended by Nayru's sacrifice locking up Cerunos and bringing peace back again.";
        }
        else
        {
            dialogText.text = "This block is empty.";
        }
    }

    public void CodexEmpty()
    {
        dialogText.text = "This block is empty.";
    }

    public void CloseMuralPanels()
    {
        muralOneButton.SetActive(false);
        muralTwoButton.SetActive(false);
        muralThreeButton.SetActive(false);
        muralFourButton.SetActive(false);
        muralOnePanel.SetActive(false);
        muralTwoPanel.SetActive(false);
        muralThreePanel.SetActive(false);
        muralFourPanel.SetActive(false);
        dialogBox.SetActive(false);
    }
}
