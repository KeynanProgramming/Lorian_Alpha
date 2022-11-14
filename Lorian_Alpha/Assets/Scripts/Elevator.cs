using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject hero, fadeFromWhite, fadeToWhite;
    public Transform teleport;
    public float timeBeforeTransport, timeBeforeFade, timeAfterFade;

    private void Awake()
    {
        if(fadeFromWhite != null)
        {
            GameObject panel = Instantiate(fadeFromWhite, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian enter = collision.GetComponent<Lorian>();

        if(collision.CompareTag("Player"))
        {
            StartCoroutine(FadeCo());
            StartCoroutine(TransportCo(enter));
        }
    }

    private IEnumerator TransportCo(Lorian enter)
    {
        if(enter != null)
        {
            yield return new WaitForSeconds(timeBeforeTransport);
            hero.transform.position = teleport.transform.position;
        }
    }

    private IEnumerator FadeCo()
    {
        yield return new WaitForSeconds(timeBeforeFade);

        if(fadeFromWhite || fadeToWhite != null)
        {
            GameObject panelToWhite = Instantiate(fadeToWhite, Vector3.zero, Quaternion.identity);
            Destroy(panelToWhite, 2);
            yield return new WaitForSeconds(timeAfterFade);
            GameObject panelFromWhite = Instantiate(fadeFromWhite, Vector3.zero, Quaternion.identity);
            Destroy(panelFromWhite, 3);
        }
        

    }
}
