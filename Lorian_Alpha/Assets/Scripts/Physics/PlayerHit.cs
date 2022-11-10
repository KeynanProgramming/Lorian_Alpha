using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public GameObject Player;
    public Transform teleport;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Statue"))
        {
            collision.GetComponent<Statue>().OnRestore();
        }

        if (collision.CompareTag("Elevator"))
        {
            Player.transform.position = teleport.transform.position;
           
        }
    }
}
