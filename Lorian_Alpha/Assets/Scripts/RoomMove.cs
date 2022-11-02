using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    private OtherCameraMovement otherCam;
    public GameObject cam1;
    public GameObject cam2;

    void Start()
    {
        otherCam = GetComponent<OtherCameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian player = collision.gameObject.GetComponent<Lorian>();

        if (collision != null)
        {
            cam2.gameObject.SetActive(true);
            cam1.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Lorian player = collision.gameObject.GetComponent<Lorian>();

        if (collision != null)
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
        }
    }
}
