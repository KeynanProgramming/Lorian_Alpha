using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollisions : MonoBehaviour
{   
    public Lorian player;
    public void CheckCollisions(Collider2D collision)
    {
        if (collision.CompareTag("Seal"))
        {
            SceneManager.LoadScene(0);
        }

        if (collision.CompareTag("SecretWallSW"))
        {
            AudioManager.instance.PlaySound("Puzzle Solved SFX");
            collision.gameObject.GetComponent<SecretWall>().removeWall();
        }

        if (collision.CompareTag("SecretWallNE"))
        {
            AudioManager.instance.PlaySound("Puzzle Solved SFX");
            collision.gameObject.GetComponent<SecretWall>().removeWall();
        }

        if (collision.CompareTag("Elevator"))
        {
            player.portal = collision.GetComponent<Elevator>();
        }

        if (collision.CompareTag("Exit"))
        {
            player.transform.position = new Vector3(-18,36,0);
        }

        if (collision.CompareTag("Return"))
        {
            player.transform.position = new Vector3(-17, 26.5f, 0);
        }
    }
}
