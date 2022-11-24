using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuesRange : MonoBehaviour
{
    public GameObject actionButton;
    public bool playerInRange;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt) && playerInRange == true)
        {
            actionButton.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.gameObject.GetComponent<Lorian>().amuletTimer > 4)
        {
            actionButton.SetActive(true);
            playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            actionButton.SetActive(false);
            playerInRange = false;
        }
    }
}
