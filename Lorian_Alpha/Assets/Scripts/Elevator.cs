using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject hero;
    public Transform teleport;
    public float fadeTime;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian enter = collision.GetComponent<Lorian>();

        if(collision.CompareTag("Player"))
        {
            StartCoroutine(FadeCo(enter));
        }
    }

    private IEnumerator FadeCo(Lorian enter)
    {
        if(enter != null)
        {
            yield return new WaitForSeconds(fadeTime);
            hero.transform.position = teleport.transform.position;
        }
    }
}
