using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public GameObject hero, musicChangerEnabled, musicChangerDisabled, fadePanel;
    public Vector3 deltaPosition;
    public string backgroungMusic;

    public bool fade;

    private Lorian lorian;

    void Awake()
    {
        lorian = hero.GetComponent<Lorian>();
    }

    void Update()
    {
        if (fade == true)
        {
            lorian.MusicChanger();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(MusicChangerCo());
            fade = true;
        }
    }

    private IEnumerator MusicChangerCo()
    {
        GameObject panel = Instantiate(fadePanel, Vector3.zero, Quaternion.identity);
        Destroy(panel, 2);
        yield return new WaitForSeconds(2);
        AudioManager.instance.PlaySound(backgroungMusic);
        lorian.transform.position += deltaPosition;
        musicChangerEnabled.SetActive(true);
        musicChangerDisabled.SetActive(false);
        fade = false;
    }
}
