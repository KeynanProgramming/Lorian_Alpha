using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Sign
{
    public bool chestOpened;
    public string nextDialog;
    public GameObject objectPanel, hero;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange == true && chestOpened == false)
        {
            if(dialogBox.activeInHierarchy)
            {
                chestOpened = true;
                dialogBox.SetActive(false);
                objectPanel.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                objectPanel.SetActive(true);

                if(objectPanel.CompareTag("SwordPanel"))
                {
                    hero.gameObject.GetComponent<Lorian>().sword++;
                }

                if (objectPanel.CompareTag("HeartPanel"))
                {
                    hero.gameObject.GetComponent<Lorian>().maxHP++;
                    GameObject newHeart = Instantiate(hero.gameObject.GetComponent<Lorian>().hearts[0],
                        hero.gameObject.GetComponent<Lorian>().heartContainers);
                    newHeart.SetActive(true);
                    hero.gameObject.GetComponent<Lorian>().hearts.Add(newHeart);
                }
            }

            anim.SetBool("Opening", true);
        }

        if(objectPanel.activeInHierarchy && playerInRange == false)
        {
            objectPanel.SetActive(false);
            chestOpened = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && playerInRange == true && chestOpened == true)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = nextDialog;
            }
        }
    }
}
