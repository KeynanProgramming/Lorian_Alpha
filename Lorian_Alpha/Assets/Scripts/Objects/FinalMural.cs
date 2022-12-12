using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMural : Sign
{
    public GameObject objectPanel;
    public GameObject codexMural;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerOnRange == true)
        {
            codexMural.SetActive(true);

            if (dialogBox.activeInHierarchy)
            {
                AudioManager.instance.PlaySound("Button SFX");
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
