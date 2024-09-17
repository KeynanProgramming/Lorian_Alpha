using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public GameObject statueLimit;
    public string statueBreakSFX, statueRestoreSFX;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnRestore()
    {
        anim.SetTrigger("OnRestore");
        AudioManager.instance.PlaySound(statueRestoreSFX);
        statueLimit.gameObject.SetActive(false);
        gameObject.tag = "Statue";
    }

    public void OnBreak()
    {
        anim.SetTrigger("OnBreak");
        AudioManager.instance.PlaySound(statueBreakSFX);
        statueLimit.transform.position = transform.position;
        statueLimit.gameObject.SetActive(true);
        StartCoroutine(StatueBreakCo());
    }

    private IEnumerator StatueBreakCo()
    {
        yield return new WaitForSeconds(1);
        gameObject.tag = "BrokenStatue";
    }
}
