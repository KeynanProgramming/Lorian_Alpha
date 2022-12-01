using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMural : Sign
{
    public GameObject objectPanel;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerOnRange == true)
        {
            if (dialogBox.activeInHierarchy)
            {
                audioSource.PlayOneShot(buttonSound);
                //SceneManager.LoadScene(0);
                this.gameObject.SetActive(false);
                objectPanel.SetActive(false);
                dialogBox.SetActive(false);
            }
            else
            {
                objectPanel.SetActive(true);
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
}
