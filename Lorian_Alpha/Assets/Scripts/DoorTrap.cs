using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrap : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            objectToActivate.SetActive(true);
        }
    }
}
