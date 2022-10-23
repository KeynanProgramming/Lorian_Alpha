using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int count;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision && count == 0)
        {
            count++;
        }

        if(collision && count == 1)
        {
            count--;
        }
    }
}
