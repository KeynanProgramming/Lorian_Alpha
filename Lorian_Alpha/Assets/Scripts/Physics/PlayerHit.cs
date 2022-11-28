using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public AudioClip secretReveal, magic;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Statue"))
        {
            audioSource.PlayOneShot(magic);
            collision.gameObject.GetComponent<Statue>().OnRestore();
        }
        if (collision.CompareTag("SecretWallSW"))
        {
            audioSource.PlayOneShot(secretReveal);
            collision.gameObject.GetComponent<SecretWall>().removeWall();
        }
        if (collision.CompareTag("SecretWallNE"))
        {
            audioSource.PlayOneShot(secretReveal);
            collision.gameObject.GetComponent<SecretWall>().removeWall();
        }
    }
}

