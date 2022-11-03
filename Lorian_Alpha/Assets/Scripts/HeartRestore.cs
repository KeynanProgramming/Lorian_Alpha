using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRestore : MonoBehaviour
{
    public int healthRestore = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian takeHeart = collision.gameObject.GetComponent<Lorian>();
        if(takeHeart && takeHeart.gameObject.GetComponent<Lorian>().health < 5) 
        {
            takeHeart.TakeHeart(healthRestore);
            Destroy(this.gameObject);
        }
    }
}
