using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian player = collision.gameObject.GetComponentInChildren<Lorian>();

        if(player)
        {
            anim.SetTrigger("OnRestoring");
            this.gameObject.isStatic = false;
        }
    }
}
