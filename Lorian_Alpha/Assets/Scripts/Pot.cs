using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public GameObject heart;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerHitBox"))
        {
            Instantiate(heart, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
