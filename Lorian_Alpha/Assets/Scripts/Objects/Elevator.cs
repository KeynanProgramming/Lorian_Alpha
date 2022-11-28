using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject hero, fadeFromWhite, fadeToWhite, uIPortal, actionButton;
    public Transform teleport;
    public float timeBeforeTransport, timeBeforeFade, timeAfterFade;
    public bool playerOnRange;

    private void Awake()
    {
        if(fadeFromWhite != null)
        {
            GameObject panel = Instantiate(fadeFromWhite, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerOnRange == true)
        {
            Lorian enter = GetComponent<Lorian>();
            StartCoroutine(FadeCo());
            StartCoroutine(TransportCo(enter));
            uIPortal.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player"))
        {
            actionButton.SetActive(true);
            playerOnRange = true;
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
        hero.GetComponent<Lorian>().movement = Vector2.zero;
        yield return new WaitForSeconds(timeBeforeFade);

        if(fadeFromWhite || fadeToWhite != null)
        {
            GameObject panelToWhite = Instantiate(fadeToWhite, Vector3.zero, Quaternion.identity);
            Destroy(panelToWhite, 2);
            yield return new WaitForSeconds(timeAfterFade);
            GameObject panelFromWhite = Instantiate(fadeFromWhite, Vector3.zero, Quaternion.identity);
            Destroy(panelFromWhite, 3);
            hero.GetComponent<Lorian>().movement.x = Input.GetAxisRaw("Horizontal");
            hero.GetComponent<Lorian>().movement.y = Input.GetAxisRaw("Vertical");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player)"))
        {
            actionButton.SetActive(false);
            playerOnRange = false;
        }
    }
}
