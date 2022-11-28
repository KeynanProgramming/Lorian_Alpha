using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox, actionButton;
    public Text dialogText;
    public string dialog;
    public bool playerOnRange;
    public AudioClip buttonSound;

    private AudioSource auSource;

    void Start()
    {
        auSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerOnRange == true)
        {
            if(dialogBox.activeInHierarchy)
            {
                auSource.PlayOneShot(buttonSound);
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            actionButton.SetActive(true);
            playerOnRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            actionButton.SetActive(false);
            playerOnRange = false;
        }
    }
}
