using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject spaceButton;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange == true)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            spaceButton.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            spaceButton.SetActive(false);
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
