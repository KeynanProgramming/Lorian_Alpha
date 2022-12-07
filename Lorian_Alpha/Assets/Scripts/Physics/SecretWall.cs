using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
