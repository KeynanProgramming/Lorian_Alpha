using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRestore : MonoBehaviour
{
    public int healtRestore = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian player = collision.gameObject.GetComponent<Lorian>();
        if (player) 
        {
            if (player.TakeDamage(-healtRestore))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
