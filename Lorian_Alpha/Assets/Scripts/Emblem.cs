using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emblem : MonoBehaviour
{
    public int emblem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian takeEmblem = collision.GetComponent<Lorian>();

        if (takeEmblem == true)
        {
            takeEmblem.TakeEmblem(emblem);
            Destroy(this.gameObject);
        }
    }
}
