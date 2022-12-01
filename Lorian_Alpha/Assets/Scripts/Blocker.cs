using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blocker : MonoBehaviour
{
    public GameObject dialogBox, hero;
    public Text dialogText;
    public string dialog, buttonSound;
    public bool playerOnRange;
    public bool blockInputs = false;

    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            hero.GetComponent<Lorian>().movement = Vector2.zero;
            hero.GetComponent<Lorian>().BlockerUpdate(true);
        }

        if (playerOnRange == true && Input.GetKeyDown(KeyCode.Space))
        {
            if(dialogBox.activeInHierarchy)
            {
                AudioManager.instance.PlaySound(buttonSound);
                dialogBox.SetActive(false);
                hero.GetComponent<Lorian>().BlockerUpdate(false);
                hero.GetComponent<Lorian>().movement.x = Input.GetAxisRaw("Horizontal");
                hero.GetComponent<Lorian>().movement.y = Input.GetAxisRaw("Vertical");
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnRange = true;
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerOnRange = false;
            dialogBox.SetActive(false);
        }
    }
}
