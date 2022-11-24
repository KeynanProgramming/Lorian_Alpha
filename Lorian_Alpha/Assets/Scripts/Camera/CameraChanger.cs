using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    private OtherCameraMovement otherCam;
    public GameObject cam1, cam2, uIPortal;

    void Start()
    {
        otherCam = GetComponent<OtherCameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cam2.gameObject.SetActive(true);
            cam1.gameObject.SetActive(false);
            uIPortal.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
        }
    }
}
