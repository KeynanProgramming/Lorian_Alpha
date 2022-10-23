using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int cuenta;
    public GameObject cam1;
    public GameObject cam2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian player = collision.gameObject.GetComponent<Lorian>();
        if(cuenta == 0)
        {
            cam2.gameObject.SetActive(true);
            cam1.gameObject.SetActive(false);
            cuenta++;
        }
        else if(cuenta == 1)
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
            cuenta--;
        }
    }
}
