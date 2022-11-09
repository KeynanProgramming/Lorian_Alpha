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

    public void OnRestore()
    {
        anim.SetTrigger("OnRestoring");
        statueLimit.gameObject.SetActive(false);
    }

    public void OnBreak()
    {
        anim.SetTrigger("OnBreak");
        statueLimit.gameObject.SetActive(true);
    }



}
