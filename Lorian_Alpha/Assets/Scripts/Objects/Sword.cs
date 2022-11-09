using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int sword;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian takeSword = collision.GetComponent<Lorian>();

        if(takeSword == true)
        {
            takeSword.TakeSword(sword);
            Destroy(this.gameObject);
        }
    }
}
