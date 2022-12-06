using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public GameObject musicChangerEnabled, musicChangerDisabled;
    public float timeToPlayMusic;
    public string backgroungMusic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(MusicChangerCo());
        }
    }

    private IEnumerator MusicChangerCo()
    {
        yield return new WaitForSeconds(timeToPlayMusic);
        AudioManager.instance.PlaySound(backgroungMusic);
        musicChangerEnabled.SetActive(true);
        musicChangerDisabled.SetActive(false);
    }
}
