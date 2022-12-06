using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Sign
{
    public bool chestOpened;
    public GameObject objectPanel, hero;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerOnRange == true && chestOpened == false)
        {
            if (dialogBox.activeInHierarchy)
            {
                AudioManager.instance.PlaySound("Button SFX");
                chestOpened = true;
                dialogBox.SetActive(false);
                objectPanel.SetActive(false);
            }
            else
            {
                AudioManager.instance.PlaySound("Object Obtained SFX");
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                objectPanel.SetActive(true);

                if (objectPanel.CompareTag("SwordPanel"))
                {
                    hero.GetComponent<Lorian>().sword++;
                }

                if (objectPanel.CompareTag("HeartPanel"))
                {
                    hero.GetComponent<Lorian>().health++;
                    hero.GetComponent<Lorian>().maxHP++;
                    GameObject newHeart = Instantiate(hero.GetComponent<Lorian>().hearts[0],
                        hero.GetComponent<Lorian>().heartContainers);
                    newHeart.SetActive(true);
                    hero.GetComponent<Lorian>().hearts.Add(newHeart);
                }

                if (objectPanel.CompareTag("HeartPanel2"))
                {
                    hero.GetComponent<Lorian>().health++;
                    hero.GetComponent<Lorian>().maxHP++;
                    GameObject newHeart = Instantiate(hero.GetComponent<Lorian>().hearts[0],
                        hero.GetComponent<Lorian>().heartContainers);
                    newHeart.SetActive(true);
                    hero.GetComponent<Lorian>().hearts.Add(newHeart);
                }

                anim.SetBool("Opening", true);
            }
        }

        if (chestOpened == true)
        {
            actionButton.SetActive(false);
        }
    }
}
