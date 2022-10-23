using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public GameObject statueLimit;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Lorian player = collision.gameObject.GetComponentInChildren<Lorian>();

        if(collision.gameObject.CompareTag("PlayerHitBox"))
        {
            anim.SetTrigger("OnRestoring");
            statueLimit.gameObject.SetActive(false);
        }
    }
}
