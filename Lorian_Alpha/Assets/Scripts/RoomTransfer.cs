using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransfer : MonoBehaviour
{
    public GameObject hero;
    public Vector3 deltaPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hero.GetComponent<Lorian>().transform.position += deltaPosition;
        }
    }
}
