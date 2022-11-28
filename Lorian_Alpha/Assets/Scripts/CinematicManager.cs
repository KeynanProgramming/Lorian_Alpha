using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicManager : MonoBehaviour
{
    public GameObject fadeFromBlack, fadeToBlack, fadeToWhite, fadeInOut;
    public GameObject panel0, panel1, panel2, panel3;
    public AudioClip dialogBoxSound, initialSound, secondSound, wakingSound;
    private AudioSource audioSource;
    private int i = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (fadeFromBlack != null)
        {
            GameObject panel = Instantiate(fadeFromBlack, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1.5f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject panel;              
            i++;

            switch (i)
            {               
                case 1:
                    audioSource.PlayOneShot(dialogBoxSound);
                    panel = Instantiate(fadeToBlack, Vector3.zero, Quaternion.identity);
                    Destroy(panel, 2.5f);
                    StartCoroutine(fade1Co(panel));
                    break;

                case 2:
                    audioSource.PlayOneShot(dialogBoxSound);
                    panel = Instantiate(fadeToBlack, Vector3.zero, Quaternion.identity);
                    Destroy(panel, 2.5f);
                    StartCoroutine(fade2Co(panel));
                    break;

                case 3:
                    audioSource.PlayOneShot(dialogBoxSound);
                    panel = Instantiate(fadeToBlack, Vector3.zero, Quaternion.identity);
                    Destroy(panel, 2.5f);
                    StartCoroutine(fade3Co(panel));
                    break;

                case 4:
                    audioSource.PlayOneShot(wakingSound);
                    panel = Instantiate(fadeToWhite, Vector3.zero, Quaternion.identity);
                    StartCoroutine(fadeToWhiteCo());
                    break;
            }
        }
    }

    private IEnumerator fade1Co(GameObject panel)
    {
        yield return new WaitForSeconds(2);
        panel = Instantiate(fadeFromBlack, Vector3.zero, Quaternion.identity);
        panel0.SetActive(false);
        panel1.SetActive(true);
        Destroy(panel, 1.5f);
    }
    
    private IEnumerator fade2Co(GameObject panel)
    {
        yield return new WaitForSeconds(2);
        panel = Instantiate(fadeFromBlack, Vector3.zero, Quaternion.identity);
        panel1.SetActive(false);
        panel2.SetActive(true);
        Destroy(panel, 1.5f);
    }
    
    private IEnumerator fade3Co(GameObject panel)
    {
        yield return new WaitForSeconds(2);
        panel = Instantiate(fadeFromBlack, Vector3.zero, Quaternion.identity);
        panel2.SetActive(false);
        panel3.SetActive(true);
        Destroy(panel, 1.5f);
    }
    
    private IEnumerator fadeToWhiteCo()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(2);
    }
                
}
