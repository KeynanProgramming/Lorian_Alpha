using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFade : MonoBehaviour
{
    public GameObject hero, fadePanel;
    public Vector3 deltaPosition;
    public bool fade;

    private Lorian lorian;

    void Awake()
    {
        fade = false;
        lorian = hero.GetComponent<Lorian>();
    }

    void Update()
    {
        if (fade == true)
        {
            lorian.RoomFade();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fade = true;
            StartCoroutine(RoomFadeCo());
        }
    }

    private IEnumerator RoomFadeCo()
    {
        GameObject panel = Instantiate(fadePanel, Vector3.zero, Quaternion.identity);
        Destroy(panel, 2);
        yield return new WaitForSeconds(2);
        hero.GetComponent<Lorian>().transform.position += deltaPosition;
        fade = false;
    }
}
