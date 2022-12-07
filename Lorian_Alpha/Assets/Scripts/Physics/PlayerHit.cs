using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BrokenStatue"))
        {
            collision.gameObject.GetComponent<Statue>().OnRestore();
        }      
    }
}

