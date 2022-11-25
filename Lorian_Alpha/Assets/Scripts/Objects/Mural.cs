using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mural : Sign
{
    public GameObject objectPanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange == true)
        {
            if(dialogBox.activeInHierarchy)
            {
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

        if(objectPanel.activeInHierarchy && playerInRange == false)
        {
            objectPanel.SetActive(false);
        }
    }
}
