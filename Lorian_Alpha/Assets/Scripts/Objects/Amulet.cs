using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amulet : MonoBehaviour
{
    public int amulet;
    public GameObject objectPanel, hero, dialogBox;
    public Text dialogText;
    public string dialog, buttonSFX, objectObtainedSFX;
    public bool playerOnRange;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerOnRange == true)
        {
            if(dialogBox.activeInHierarchy)
            {
                AudioManager.instance.PlaySound(buttonSFX);
                dialogBox.SetActive(false);
                objectPanel.SetActive(false);
                Destroy(this.gameObject, 0.2f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerOnRange = true;
            AudioManager.instance.PlaySound(objectObtainedSFX);
            dialogBox.SetActive(true);
            dialogText.text = dialog;
            objectPanel.SetActive(true);
            hero.GetComponent<Lorian>().TakeAmulet(amulet);
        }
    }
}
