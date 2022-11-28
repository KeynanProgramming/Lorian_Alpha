using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Statue"))
        {
            collision.gameObject.GetComponent<Statue>().OnRestore();
        }

        if (collision.CompareTag("SecretWallSW"))
        {
            collision.gameObject.GetComponent<SecretWall>().removeWall();
        }

        if (collision.CompareTag("SecretWallNE"))
        {
            collision.gameObject.GetComponent<SecretWall>().removeWall();
        }
    }
}

