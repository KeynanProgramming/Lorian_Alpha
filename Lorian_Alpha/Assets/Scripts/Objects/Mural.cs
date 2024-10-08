using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mural : Sign
{
    public GameObject objectPanel;
    public GameObject codexMural;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerOnRange == true)
        {
            codexMural.SetActive(true);

            if(dialogBox.activeInHierarchy)
            {
                AudioManager.instance.PlaySound("Button SFX");
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
