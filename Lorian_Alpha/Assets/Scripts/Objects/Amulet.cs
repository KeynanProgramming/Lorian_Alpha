using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amulet : MonoBehaviour
{
    public int amulet;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian takeEmblem = collision.GetComponent<Lorian>();

        if (takeEmblem == true)
        {
            takeEmblem.TakeAmulet(amulet);
            Destroy(this.gameObject);
        }
    }
}
