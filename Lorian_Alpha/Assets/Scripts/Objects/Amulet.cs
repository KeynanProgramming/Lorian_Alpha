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
    public AudioClip objectObtained, buttonSound;
    public bool playerOnRange;

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
                audioSource.PlayOneShot(buttonSound);
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
            audioSource.PlayOneShot(objectObtained);
            dialogBox.SetActive(true);
            dialogText.text = dialog;
            objectPanel.SetActive(true);
            hero.GetComponent<Lorian>().TakeAmulet(amulet);
        }
    }
}
