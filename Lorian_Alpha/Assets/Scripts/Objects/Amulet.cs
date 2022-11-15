using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amulet : MonoBehaviour
{
    public int amulet;
    public GameObject objectPanel, hero, dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange == true)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                objectPanel.SetActive(false);
                Destroy(this.gameObject);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                objectPanel.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInRange = true;
            dialogBox.SetActive(true);
            dialogText.text = dialog;
            objectPanel.SetActive(true);
            hero.gameObject.GetComponent<Lorian>().TakeAmulet(amulet);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            objectPanel.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
