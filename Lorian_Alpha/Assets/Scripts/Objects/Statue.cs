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
        anim.SetTrigger("OnRestore");
        statueLimit.gameObject.SetActive(false);
    }

    public void OnBreak()
    {
        anim.SetTrigger("OnBreak");
        statueLimit.transform.position = transform.position;
        statueLimit.gameObject.SetActive(true);
    }
}
