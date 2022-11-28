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
    public bool playerOnRange;
    public AudioClip objectObtained;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerOnRange == true)
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
            playerOnRange = true;
            dialogBox.SetActive(true);
            dialogText.text = dialog;
            objectPanel.SetActive(true);
            hero.GetComponent<Lorian>().TakeAmulet(amulet);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerOnRange = false;
            dialogBox.SetActive(false);
            objectPanel.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
